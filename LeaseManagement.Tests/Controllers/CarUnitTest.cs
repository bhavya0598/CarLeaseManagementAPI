using AutoFixture.Xunit2;
using LeaseManagement.API.Controllers.Car;
using LeaseManagement.BL.Interfaces;
using LeaseManagement.BusinessEntities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LeaseManagement.Tests
{
    public class CarUnitTest
    {
        [Theory, AutoMoqData]
        public async Task GetCarAsync_When_Valid_Returns_SuccessResponse(
            [Frozen] Mock<ICarManager> _carManager,
            List<CarVM> moqResponse,
            [Greedy] CarsController sut
            )
        {
            _carManager.Setup(x => x.GetAll()).ReturnsAsync(moqResponse);
            
            // Act
            var result = await sut.GetAsync();
            var response = result as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, response.StatusCode);
        }

        [Theory, AutoMoqData]
        public async Task GetCarAsync_When_Invalid_Returns_NotFoundResponse(
            [Frozen] Mock<ICarManager> _carManager,
            [Greedy] CarsController sut)
        {
            _carManager.Setup(x => x.GetAll()).ReturnsAsync(new List<CarVM>());

            // Act
            var result = await sut.GetAsync();
            var response = result as NotFoundObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(404, response.StatusCode);
        }
    }
}
