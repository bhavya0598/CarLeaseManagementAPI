namespace LeaseManagement.QuoteService.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using LeaseManagement.BL.Quote;
    using LeaseManagement.BusinessEntities.ViewModels;

    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "JWTAuth")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        IQuoteManager _quoteManager;
        public QuoteController(IQuoteManager quoteManager)
        {
            _quoteManager = quoteManager;
        }

        /// <summary>
        /// Get Payback Time
        /// </summary>
        [HttpGet]
        [Route("getpaybacktime")]
        public async Task<IActionResult> GetPaybackTime()
        {
            var response = await _quoteManager.GetPaybackTime();
            if (response.Count != 0)
                return Ok(response);
            else
                return BadRequest(new ErrorMessageVM() { Message = "Cannot retrieve Payback Time Data!" });
        }

        /// <summary>
        /// Get Mileage Limit
        /// </summary>
        [HttpGet]
        [Route("getmileagelimit")]
        public async Task<IActionResult> GetMileageLimit()
        {
            var response = await _quoteManager.GetMileageLimit();
            if (response.Count != 0)
                return Ok(response);
            else
                return BadRequest(new ErrorMessageVM() { Message = "Cannot retrieve Mileage Limit Data!" });
        }

        /// <summary>
        /// Save Quote Async
        /// </summary>
        /// <param name="quote">args will be passed when starting this program</param>
        [HttpPost]
        [Route("saveQuote")]
        public async Task<IActionResult> SaveQuoteAsync(QuoteVM quote)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ErrorMessageVM(){ Message = "Quote is not valid!" });
            else
            {
                var response = await _quoteManager.SaveQuoteAsync(quote);
                if (response!=null)
                    return Ok(response);
                else
                    return BadRequest(new ErrorMessageVM() { Message = "Unable to save!" });
            }
        }        
    }
}