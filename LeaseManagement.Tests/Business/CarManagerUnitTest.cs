using AutoFixture.Xunit2;
using Castle.Core.Configuration;
using LeaseManagement.BL.Car;
using LeaseManagement.BusinessEntities.ViewModels;
using LeaseManagement.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LeaseManagement.Tests.Business
{
    public class CarManagerUnitTest
    {
        [Theory, AutoMoqData]
        public async Task GetAll_When_Valid_Returns_AllCars(
            [Frozen] Mock<IUnitOfWork> _uow,
            List<CarVM> moqResponse,
            [Greedy] CarManager sut)
        {
            // Arrange
            _uow.Setup(x => x.CarRepository.GetAllCar()).ReturnsAsync(moqResponse);

            //Act
            var result = await sut.GetAll();

            //Assert
            Assert.NotNull(result);
        }
    }
}
