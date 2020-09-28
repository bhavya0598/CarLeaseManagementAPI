namespace LeaseManagement.API.Controllers.Car
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using LeaseManagement.BL.Interfaces;
    using LeaseManagement.BusinessEntities.ViewModels;

    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "JWTAuth")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarManager _car;

        public CarsController(ICarManager _car)
        {
            this._car = _car;
        }

        /// <summary>
        /// Will return all cars
        /// </summary>
        [HttpGet]
        [Route("getAllCars")]
        public async Task<IActionResult> GetAsync()
        {
            var cars = await _car.GetAll();
            if (cars.Count != 0)
                return Ok(cars);
            else
                return NotFound(new ErrorMessageVM() { Message = "No Car Found in the Database!" });
        }

        /// <summary>
        /// Get Car by Id
        /// </summary>
        /// <param name="id">args will be passed when starting this program</param>
        [HttpGet]
        [Route("getCarById/{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var selectedCar = await _car.GetElementById(id);

            if (selectedCar != null)
                return Ok(selectedCar);
            else
                return NotFound(new ErrorMessageVM() { Message = $"Car with {id} not found!" });

        }
    }
}