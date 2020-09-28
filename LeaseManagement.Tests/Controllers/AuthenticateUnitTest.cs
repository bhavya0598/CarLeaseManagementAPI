using LeaseManagement.Authentication.Controllers;
using LeaseManagement.Authentication.Interfaces;
using LeaseManagement.BusinessEntities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Xunit;
using AutoFixture.Xunit2;
using AutoFixture;

namespace LeaseManagement.Tests
{
    public class AuthenticateUnitTest
    {
        [Theory, AutoMoqData]
        public async Task Login_When_Valid_EmailAndPassword_Returns_SuccessResponse(
            [Frozen] Mock<IAuthenticationManager> _authenticationManager,
            UserVM request,
            UserVM MoqResponse,
            string tokenResponse,
            [Greedy]AuthController sut)
        {
            _authenticationManager.Setup(x => x.Authenticate(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(MoqResponse);
            _authenticationManager.Setup(x => x.BuildToken(It.IsAny<UserVM>())).Returns(tokenResponse);

            // Act
            var result = await sut.Login(request);
            var resultObj = result as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, resultObj.StatusCode);
        }

        [Theory, AutoMoqData]
        public async Task Login_When_Invalid_EmailAndPassword_Returns_BadRequestResponse(
            [Frozen] Mock<IAuthenticationManager> _authenticationManager,
            UserVM request,
            [Greedy]AuthController sut)
        {
            _authenticationManager.Setup(x => x.Authenticate(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync((UserVM)null);

            // Act
            var result = await sut.Login(request);
            var resultObj = result as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, resultObj.StatusCode);
        }

        [Theory, AutoMoqData]
        public async Task Register_When_Valid_NewUser_Returns_SuccessResponse(
            [Frozen] Mock<IAuthenticationManager> _authenticationManager,
            UserVM request,
            [Greedy] AuthController sut
            )
        {
            _authenticationManager.Setup(x => x.RegisterNewUser(It.IsAny<UserVM>())).ReturnsAsync((ErrorMessageVM)null);

            //Act
            var result = await sut.Register(request);
            var response = result as OkResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, response.StatusCode);
        }

        [Theory, AutoMoqData]
        public async Task Register_When_Invalid_ExistedUser_Returns_BadRequestRespond(
            [Frozen] Mock<IAuthenticationManager> _authenticationManager,
            UserVM request,
            ErrorMessageVM moqResponse,
            [Greedy] AuthController sut)
        {
            _authenticationManager.Setup(x => x.RegisterNewUser(It.IsAny<UserVM>())).ReturnsAsync(moqResponse);

            //Act
            var result = await sut.Register(request);
            var response = result as BadRequestObjectResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(400, response.StatusCode);
        }

        [Theory, AutoMoqData]
        public async Task Verification_When_Valid_Email_Sent_Returns_SuccessResponse(
            [Frozen] Mock<IAuthenticationManager> _authenticationManager,
            UserVM request, 
            [Greedy] AuthController sut)
        {
            bool moqResponse = true;
            _authenticationManager.Setup(x => x.VerificationLink(It.IsAny<UserVM>())).ReturnsAsync(moqResponse);

            //Act
            var result = await sut.Verification(request);
            var response = result as OkResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, response.StatusCode);
        }

        [Theory, AutoMoqData]
        public async Task Verification_When_Invalid_Email_Not_Sent_Returns_BadRequestResponse(
            [Frozen] Mock<IAuthenticationManager> _authenticationManager,
            UserVM request,
            [Greedy] AuthController sut)
        {
            bool moqResponse = false;
            _authenticationManager.Setup(x => x.VerificationLink(It.IsAny<UserVM>())).ReturnsAsync(moqResponse);

            //Act
            var result = await sut.Verification(request);
            var response = result as BadRequestObjectResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(400, response.StatusCode);
        }

        [Theory, AutoMoqData]
        public async Task VerifyActivationCode_When_Valid_IsVerified_Returns_RedirectUrl(
            [Frozen] Mock<IAuthenticationManager> _authenticationManager,
            string request,
            [Greedy] AuthController sut
            )
        {
            var moqResponse = true;

            //Dummy Method
            _authenticationManager.Setup(x => x.CheckVerification(It.IsAny<string>())).ReturnsAsync(moqResponse);

            //Act
            var result = await sut.Verification(request);
            var response = result as RedirectResult;

            //Assert
            Assert.Equal("http://localhost:4200/login", response.Url);
        }

        [Theory, AutoMoqData]
        public async Task VerifyActivationCode_When_Invalid_IsNotVerified_Returns_BadRequestRespond(
            [Frozen] Mock<IAuthenticationManager> _authenticationManager,
            string request,
            [Greedy] AuthController sut
    )
        {
            var moqResponse = false;

            //Dummy Method
            _authenticationManager.Setup(x => x.CheckVerification(It.IsAny<string>())).ReturnsAsync(moqResponse);

            //Act
            var result = await sut.Verification(request);
            var response = result as BadRequestObjectResult;

            //Assert
            Assert.Equal(400,response.StatusCode);
        }
    }
}
