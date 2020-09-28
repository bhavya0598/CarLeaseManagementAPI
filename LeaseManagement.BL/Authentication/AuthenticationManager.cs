namespace LeaseManagement.Authentication
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.IO;
    using System.Net;
    using System.Net.Mail;
    using System.Security.Claims;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using LeaseManagement.Authentication.Interfaces;
    using LeaseManagement.BusinessEntities.ViewModels;
    using LeaseManagement.Infrastructure;

    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly IUnitOfWork _uow;
        private readonly IConfiguration _config;
        private readonly string ENCRYPTION_KEY = "MAKV2SPBNI99212";

        public AuthenticationManager(IConfiguration config, IUnitOfWork uow)
        {
            _config = config;
            _uow = uow;
        }

        #region Authneticate
        public async Task<UserVM> Authenticate(string email, string password)
        {
            password = EncryptPassword(password);
            var user = await _uow.UserAuthenticationRepository.GetUser(email, password);
            if (user != null && user.IsVerified)           
                return user;
            else           
                return null;         
        }
        #endregion

        #region Build Token
        public string BuildToken(UserVM user)
        {
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["jwt:SecretKey"]));
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim("Username", user.Username),
                new Claim("UserId",user.UserId.ToString()),
            };
            var jwt = new JwtSecurityToken(claims: claims, signingCredentials: signingCredentials, expires: DateTime.UtcNow.AddDays(int.Parse(_config["Jwt:ValidForDays"])));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return encodedJwt;
        }
        #endregion

        #region Register New User
        public async Task<ErrorMessageVM> RegisterNewUser(UserVM newUser)
        {
            newUser.Password = EncryptPassword(newUser.Password);
            newUser.ActivationCode = GenerateGUID(newUser.ActivationCode);
            var response = await _uow.UserAuthenticationRepository.CheckDuplicate(newUser.Username, newUser.Email);
            if (response == null)
                await _uow.UserAuthenticationRepository.AddUser(newUser);
            return response;
        }
        #endregion

        #region Generate GUID
        private string GenerateGUID(string activationCode) => Guid.NewGuid().ToString();
        #endregion

        #region Encrypt Password
        private string EncryptPassword(string password)
        {
            byte[] clearBytes = Encoding.Unicode.GetBytes(password);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(ENCRYPTION_KEY, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    password = Convert.ToBase64String(ms.ToArray());
                }
            }
            return password;
        }
        #endregion

        #region Decrypt Password
        private string DecryptPassword(string cipherText)
        {
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(ENCRYPTION_KEY, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
        #endregion

        #region Verification Link
        public async Task<bool> VerificationLink(UserVM newUser)
        {
            newUser.Password = EncryptPassword(newUser.Password);
            newUser.ActivationCode = await GetActivationCode(newUser.Email, newUser.Password);
            var varifyUrl = $"https://localhost:44301/verification?ActivationCode={newUser.ActivationCode.ToString()}";
            var message = new MailMessage();
            message.To.Add(newUser.Email);
            message.From = new MailAddress("Bhavya Shah <bhavya0598@gmail.com>");
            message.Subject = "Email Activation";
            message.Body = $"<br/><br/>We are excited to tell you that your account is successfully created. Please click on the below link to verify your account <br/><br/><a href='{ varifyUrl }'> {varifyUrl}</a>";
            message.IsBodyHtml = true;
            using (var smtp = new SmtpClient("smtp.gmail.com", 587))
            {
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("bhavya0598@gmail.com", "lead2ordergenerate");
                smtp.EnableSsl = true;
                try
                {
                    smtp.Send(message);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        #endregion

        #region Check Verification
        public async Task<bool> CheckVerification(string ActivationCode)
        {
            var user = await _uow.UserAuthenticationRepository.CheckActivationCode(ActivationCode);
            if (user != null)
                return true;
            return false;
        }
        #endregion

        #region Get Activation Code
        private async Task<string> GetActivationCode(string email, string password)
        {
            var user = await _uow.UserAuthenticationRepository.GetUser(email, password);
            return user.ActivationCode;
        }
        #endregion
    }
}
