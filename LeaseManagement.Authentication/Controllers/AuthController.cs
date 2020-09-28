namespace LeaseManagement.Authentication.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using LeaseManagement.Authentication.Interfaces;
    using LeaseManagement.BusinessEntities.ViewModels;

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthenticationManager _authenticationManager;
        public AuthController(IAuthenticationManager authenticationManager)
        {
            _authenticationManager = authenticationManager;
        }

        /// <summary>
        /// LOGIN
        /// </summary>
        /// <param name="userParam">args will be passed when starting this program</param>
        /// <returns>Token</returns>
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody]UserVM userParam)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ErrorMessageVM() { Message = "Entered data is incorrect!" });
            else
            {
                var user = await _authenticationManager.Authenticate(userParam.Email, userParam.Password);
                if (user != null)
                    return Ok(new { token = _authenticationManager.BuildToken(user) });
                else
                    return BadRequest(new ErrorMessageVM() { Message = "Either Username or password is inccorect!"});
            }
        }

        /// <summary>
        /// REGISTER
        /// </summary>
        /// <param name="newUser">args will be passed when starting this program</param>
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserVM newUser)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ErrorMessageVM() { Message = "Entered data is incorrect!" });
            else
            {
                var error = await _authenticationManager.RegisterNewUser(newUser);
                if (error != null)
                    return BadRequest(JsonConvert.SerializeObject(error));
                return Ok();
            }
        }

        /// <summary>
        /// Verification
        /// </summary>
        /// <param name="newUser">args will be passed when starting this program</param>
        [HttpPost]
        [Route("verification")]
        public async Task<IActionResult> Verification([FromBody] UserVM newUser)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ErrorMessageVM() { Message = "Entered data is incorrect!" });
            else
            {
                var response = await _authenticationManager.VerificationLink(newUser);
                if (response)
                    return Ok();
                else
                    return BadRequest(new ErrorMessageVM() { Message = "Email not verified!" });
            }
        }

        /// <summary>
        /// Verification
        /// </summary>
        /// <param name="ActivationCode">args will be passed when starting this program</param>
        [HttpGet]
        [Route("verification")]
        public async Task<IActionResult> Verification(string ActivationCode)
        {
            var isVerified = await _authenticationManager.CheckVerification(ActivationCode);
            if (isVerified)
                return Redirect("http://localhost:4200/login");
            return BadRequest(new ErrorMessageVM() { Message = "Email verification failed!" });
        }
    }
}