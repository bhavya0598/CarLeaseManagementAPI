using AutoFixture.Xunit2;
using LeaseManagement.Authentication;
using LeaseManagement.BusinessEntities.ViewModels;
using LeaseManagement.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LeaseManagement.Tests.Business
{

    public class AuthenticateManagerUnitTest
    {
        [Theory, AutoMoqData]
        private async Task Authenticate_When_Valid_Returns_UserVM(
            [Frozen] Mock<IUnitOfWork> _uow,
            UserVM moqResponse,
            string email,
            string password,
            [Greedy] AuthenticationManager sut)
        {
            // Arrange
            var expected = moqResponse;
            moqResponse.IsVerified = true;
            _uow.Setup(x=>x.UserAuthenticationRepository.GetUser(It.IsAny<string>(),It.IsAny<string>())).ReturnsAsync(moqResponse);

            // Act
            var result = await sut.Authenticate(email, password);

            // Assert
            Assert.NotNull(result);
            Assert.True(moqResponse.IsVerified);
        }

        [Theory, AutoMoqData]
        private async Task Authenticate_When_InValid_Returns_Null(
            [Frozen] Mock<IUnitOfWork> _uow,
            string email,
            string password,
            [Greedy] AuthenticationManager sut)
        {
            // Arrange
            _uow.Setup(x => x.UserAuthenticationRepository.GetUser(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync((UserVM)null);

            // Act
            var result = await sut.Authenticate(email, password);

            // Assert
            Assert.Null(result);
        }

        [Theory, AutoMoqData]
        public async Task CheckVerification_When_Valid_ActivationCode_Returns_True(
            [Frozen] Mock<IUnitOfWork> _uow,
            string ActivationCode,
            UserVM moqResponse,
            [Greedy] AuthenticationManager sut)
        {
            // Arrange
            _uow.Setup(x => x.UserAuthenticationRepository.CheckActivationCode(It.IsAny<string>())).ReturnsAsync(moqResponse);

            // Act
            var result = await sut.CheckVerification(ActivationCode);

            //Assert
            Assert.True(result);
        }

        [Theory, AutoMoqData]
        public async Task CheckVerification_When_Invalid_ActivationCode_Returns_False(
            [Frozen] Mock<IUnitOfWork> _uow,
            string ActivationCode,
            [Greedy] AuthenticationManager sut)
        {
            // Arrange
            _uow.Setup(x => x.UserAuthenticationRepository.CheckActivationCode(It.IsAny<string>())).ReturnsAsync((UserVM)null);

            // Act
            var result = await sut.CheckVerification(ActivationCode);

            //Assert
            Assert.False(result);
        }

        [Theory, AutoMoqData]
        public async Task RegisterNewUser_When_Invalid_User_Returns_Error(
            [Frozen] Mock<IUnitOfWork> _uow,
            ErrorMessageVM moqResponse,
            UserVM request,
            [Greedy] AuthenticationManager sut)
        {
            // Arrange
            _uow.Setup(x => x.UserAuthenticationRepository.CheckDuplicate(It.IsAny<string>(),It.IsAny<string>())).ReturnsAsync(moqResponse);

            // Act
            var error = await sut.RegisterNewUser(request);

            //Assert
            Assert.NotNull(error);
        }

        [Theory, AutoMoqData]
        public async Task RegisterNewUser_When_Valid_User_Returns_NoError(
            [Frozen] Mock<IUnitOfWork> _uow,
            UserVM request,
            [Greedy] AuthenticationManager sut)
        {
            // Arrange
            _uow.Setup(x => x.UserAuthenticationRepository.CheckDuplicate(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync((ErrorMessageVM)null);

            // Act
            var error = await sut.RegisterNewUser(request);

            //Assert
            Assert.Null(error);
        }
    }
}
