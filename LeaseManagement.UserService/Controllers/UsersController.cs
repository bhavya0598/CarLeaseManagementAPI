namespace LeaseManagement.UserService.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using LeaseManagement.BL.UserDetails;
    using LeaseManagement.BusinessEntities.ViewModels;
    using System;

    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "JWTAuth")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserManager _userManager;

        public UsersController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        /// <summary>
        /// Get User Personal Data
        /// </summary>
        [HttpGet]
        [Route("personal")]
        public async Task<IActionResult> UserPersonalAsync()
        {
            var userId = _userManager.GetUserId(HttpContext.User.Identity as ClaimsIdentity);
            var response = await _userManager.GetUserPerosnalAsync(userId);
            if (response != null)
                return Ok(response);
            return Ok();
        }

        /// <summary>
        /// Add User Personal Data
        /// </summary>
        /// <param name="userPersonal">args will be passed when starting this program</param>
        [HttpPost]
        [Route("personal")]
        public async Task<IActionResult> UserPersonalAsync(UserPersonalVM userPersonal)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ErrorMessageVM() { Message = "User Personal Data Not Valid!" });
            else
            {
                var response = await _userManager.AddUserPersonalDataAsync(userPersonal);
                if (response != null)
                    return Ok(response);
                else
                    return BadRequest(new ErrorMessageVM() { Message = "Unable to save!" });
            }
        }

        /// <summary>
        /// Verification
        /// </summary>
        /// <param name="ActivationCode">args will be passed when starting this program</param>
        [HttpGet]
        [Route("getaccounttypes")]
        public async Task<IActionResult> GetAccountTypesAsync()
        {
            var response = await _userManager.GetAccountTypesAsync();
            if (response != null)
                return Ok(response);
            else
                return BadRequest();
        }

        /// <summary>
        /// Get User Bank Data
        /// </summary>
        [HttpGet]
        [Route("bank")]
        public async Task<IActionResult> UserBankAsync()
        {
            var userId = _userManager.GetUserId(HttpContext.User.Identity as ClaimsIdentity);
            var response = await _userManager.GetUserBankDataAsync(userId);
            if (response != null)
                return Ok(response);
            return Ok();
        }

        /// <summary>
        /// User Bank Async
        /// </summary>
        /// <param name="userbank">args will be passed when starting this program</param>
        [HttpPost]
        [Route("bank")]
        public async Task<IActionResult> UserBankAsync(UserBankVM userbank)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "something went wrong" });
            else
            {
                var response = await _userManager.AddUserBankData(userbank);
                if (response != null)
                    return Ok(response);
                else
                    return BadRequest(new ErrorMessageVM() { Message = "Unable to save!" });
            }
        }

        /// <summary>
        /// Get User Employment Data
        /// </summary>
        [HttpGet]
        [Route("employment")]
        public async Task<IActionResult> UserEmploymentAsync()
        {
            var userId = _userManager.GetUserId(HttpContext.User.Identity as ClaimsIdentity);
            var response = await _userManager.GetUserEmploymentDataAsync(userId);
            if (response != null)
                return Ok(response);
            return Ok();
        }

        /// <summary>
        /// User Employment Async
        /// </summary>
        /// <param name="userEmployment">args will be passed when starting this program</param>
        [HttpPost]
        [Route("employment")]
        public async Task<IActionResult> UserEmploymentAsync(UserEmploymentVM userEmployment)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "something went wrong" });
            else
            {
                var response = await _userManager.AddUserEmploymentDataAsync(userEmployment);
                if (response != null)
                    return Ok(response);
                else
                    return BadRequest(new ErrorMessageVM() { Message = "Unable to save!" });
            }
        }

        /// <summary>
        /// Get Contracts Async
        /// </summary>
        [HttpGet]
        [Route("getcontracts")]
        public async Task<IActionResult> GetContractsAsync()
        {
            var response = await _userManager.GetContractsAsync();
            if (response != null)
                return Ok(response);
            else
                return BadRequest();
        }

        /// <summary>
        /// Get Employment Types Async
        /// </summary>
        [HttpGet]
        [Route("getemploymenttypes")]
        public async Task<IActionResult> GetEmploymentTypesAsync()
        {
            var response = await _userManager.GetEmploymentTypesAsync();
            if (response != null)
                return Ok(response);
            else
                return BadRequest();
        }
    }
}