using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoFixture.Xunit2;
using Moq;
using Xunit;
using LeaseManagement.BL.UserDetails;
using LeaseManagement.BusinessEntities.ViewModels;
using LeaseManagement.UserService.Controllers;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace LeaseManagement.Tests
{
    public class UserUnitTest
    {
        [Theory, AutoMoqData]
        public async Task UserPersonalAsync_When_Valid_Id_Returns_SuccessResponseWithModel(
            [Frozen] Mock<IUserManager> _userManager,
            UserPersonalVM moqResponse,
            string id,
            [Greedy] UsersController sut
            )
        {
            // Arrange
            sut.ControllerContext = new ControllerContext();
            sut.ControllerContext.HttpContext = new DefaultHttpContext();
            sut.ControllerContext.HttpContext.Request.Headers["device-id"] = "20317";

            _userManager.Setup(x => x.GetUserId(It.IsAny<ClaimsIdentity>())).Returns(id);
            _userManager.Setup(x => x.GetUserPerosnalAsync(It.IsAny<string>())).ReturnsAsync(moqResponse);

            // Act
            var result = await sut.UserPersonalAsync();
            var response = result as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, response.StatusCode);
            Assert.NotNull(response.Value);
        }

        [Theory, AutoMoqData]
        public async Task UserPersonalAsync_When_InValid_Id_Returns_SuccessResponseWithoutModel(
            [Frozen] Mock<IUserManager> _userManager,
            string id,
            [Greedy] UsersController sut
            )
        {
            // Arrange
            sut.ControllerContext = new ControllerContext();
            sut.ControllerContext.HttpContext = new DefaultHttpContext();
            sut.ControllerContext.HttpContext.Request.Headers["device-id"] = "20317";

            _userManager.Setup(x => x.GetUserId(It.IsAny<ClaimsIdentity>())).Returns(id);
            _userManager.Setup(x => x.GetUserPerosnalAsync(It.IsAny<string>())).ReturnsAsync((UserPersonalVM)null);

            // Act
            var result = await sut.UserPersonalAsync();
            var response = result as OkResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, response.StatusCode);
        }

        [Theory, AutoMoqData]
        public async Task UserPersonalAsync_When_Valid_NotExist_Returns_SuccessResponse(
            [Frozen] Mock<IUserManager> _userManager,
            UserPersonalVM request,
            UserPersonalVM moqRequest,
            string id,
            [Greedy] UsersController sut
    )
        {
            // Arrange
            sut.ControllerContext = new ControllerContext();
            sut.ControllerContext.HttpContext = new DefaultHttpContext();
            sut.ControllerContext.HttpContext.Request.Headers["device-id"] = "20317";

            _userManager.Setup(x => x.AddUserPersonalDataAsync(It.IsAny<UserPersonalVM>())).ReturnsAsync(moqRequest);
            _userManager.Setup(x => x.GetUserId(It.IsAny<ClaimsIdentity>())).Returns(id);

            // Act
            var result = await sut.UserPersonalAsync(request);
            var response = result as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, response.StatusCode);
        }

        [Theory, AutoMoqData]
        public async Task UserPersonalAsync_When_Valid_AlreadyExists_Returns_BadRequestResponse(
            [Frozen] Mock<IUserManager> _userManager,
            UserPersonalVM request,
            string id,
            [Greedy] UsersController sut
            )
        {
            // Arrange
            sut.ControllerContext = new ControllerContext();
            sut.ControllerContext.HttpContext = new DefaultHttpContext();
            sut.ControllerContext.HttpContext.Request.Headers["device-id"] = "20317";

            _userManager.Setup(x => x.AddUserPersonalDataAsync(It.IsAny<UserPersonalVM>())).ReturnsAsync((UserPersonalVM)null);
            _userManager.Setup(x => x.GetUserId(It.IsAny<ClaimsIdentity>())).Returns(id);

            // Act
            var result = await sut.UserPersonalAsync(request);
            var response = result as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, response.StatusCode);
        }

        [Theory, AutoMoqData]
        public async Task UserEmploymentAsync_When_Valid_Id_Returns_SuccessResponseWithModel(
            [Frozen] Mock<IUserManager> _userManager,
            UserEmploymentVM moqResponse,
            string id,
            [Greedy] UsersController sut
            )
        {
            // Arrange
            sut.ControllerContext = new ControllerContext();
            sut.ControllerContext.HttpContext = new DefaultHttpContext();
            sut.ControllerContext.HttpContext.Request.Headers["device-id"] = "20317";

            _userManager.Setup(x => x.GetUserEmploymentDataAsync(It.IsAny<string>())).ReturnsAsync(moqResponse);
            _userManager.Setup(x => x.GetUserId(It.IsAny<ClaimsIdentity>())).Returns(id);

            // Act
            var result = await sut.UserEmploymentAsync();
            var response = result as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, response.StatusCode);
            Assert.NotNull(response.Value);
        }

        [Theory, AutoMoqData]
        public async Task UserEmploymentAsync_When_Invalid_Id_Returns_SuccessResponseWithoutModel(
            [Frozen] Mock<IUserManager> _userManager,
            string id,
            [Greedy] UsersController sut
            )
        {
            // Arrange
            sut.ControllerContext = new ControllerContext();
            sut.ControllerContext.HttpContext = new DefaultHttpContext();
            sut.ControllerContext.HttpContext.Request.Headers["device-id"] = "20317";

            _userManager.Setup(x => x.GetUserEmploymentDataAsync(It.IsAny<string>())).ReturnsAsync((UserEmploymentVM)null);
            _userManager.Setup(x => x.GetUserId(It.IsAny<ClaimsIdentity>())).Returns(id);

            // Act
            var result = await sut.UserEmploymentAsync();
            var response = result as OkResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, response.StatusCode);
        }

        [Theory, AutoMoqData]
        public async Task UserEmploymentAsync_When_Valid_NotExist_Returns_SuccessResponse(
            [Frozen] Mock<IUserManager> _userManager,
            UserEmploymentVM moqResponse,
            UserEmploymentVM request,
            string id,
            [Greedy] UsersController sut
            )
        {
            // Arrange
            sut.ControllerContext = new ControllerContext();
            sut.ControllerContext.HttpContext = new DefaultHttpContext();
            sut.ControllerContext.HttpContext.Request.Headers["device-id"] = "20317";

            _userManager.Setup(x => x.AddUserEmploymentDataAsync(It.IsAny<UserEmploymentVM>())).ReturnsAsync(moqResponse);
            _userManager.Setup(x => x.GetUserId(It.IsAny<ClaimsIdentity>())).Returns(id);

            // Act
            var result = await sut.UserEmploymentAsync(request);
            var response = result as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, response.StatusCode);
        }

        [Theory, AutoMoqData]
        public async Task UserEmploymentAsync_When_Invalid_AlreadyExist_Returns_BadRequestResponse(
            [Frozen] Mock<IUserManager> _userManager,
            UserEmploymentVM request,
            string id,
            [Greedy] UsersController sut
            )
        {
            // Arrange
            sut.ControllerContext = new ControllerContext();
            sut.ControllerContext.HttpContext = new DefaultHttpContext();
            sut.ControllerContext.HttpContext.Request.Headers["device-id"] = "20317";

            _userManager.Setup(x => x.AddUserEmploymentDataAsync(It.IsAny<UserEmploymentVM>())).ReturnsAsync((UserEmploymentVM)null);
            _userManager.Setup(x => x.GetUserId(It.IsAny<ClaimsIdentity>())).Returns(id);

            // Act
            var result = await sut.UserEmploymentAsync(request);
            var response = result as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, response.StatusCode);
        }


        [Theory, AutoMoqData]
        public async Task UserBankAsync_When_Valid_Id_Returns_SuccessResponseWithModel(
            [Frozen] Mock<IUserManager> _userManager,
            UserBankVM moqResponse,
            string id,
            [Greedy] UsersController sut
            )
        {
            // Arrange
            sut.ControllerContext = new ControllerContext();
            sut.ControllerContext.HttpContext = new DefaultHttpContext();
            sut.ControllerContext.HttpContext.Request.Headers["device-id"] = "20317";

            _userManager.Setup(x => x.GetUserBankDataAsync(It.IsAny<string>())).ReturnsAsync(moqResponse);
            _userManager.Setup(x => x.GetUserId(It.IsAny<ClaimsIdentity>())).Returns(id);

            // Act
            var result = await sut.UserBankAsync();
            var response = result as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, response.StatusCode);
            Assert.NotNull(response.Value);
        }

        [Theory, AutoMoqData]
        public async Task UserBankAsync_When_Invalid_Id_Returns_SuccessResponseWithoutModel(
            [Frozen] Mock<IUserManager> _userManager,
            string id,
            [Greedy] UsersController sut
    )
        {
            // Arrange
            sut.ControllerContext = new ControllerContext();
            sut.ControllerContext.HttpContext = new DefaultHttpContext();
            sut.ControllerContext.HttpContext.Request.Headers["device-id"] = "20317";

            _userManager.Setup(x => x.GetUserBankDataAsync(It.IsAny<string>())).ReturnsAsync((UserBankVM)null);
            _userManager.Setup(x => x.GetUserId(It.IsAny<ClaimsIdentity>())).Returns(id);

            // Act
            var result = await sut.UserBankAsync();
            var response = result as OkResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, response.StatusCode);
        }

        [Theory, AutoMoqData]
        public async Task UserBankAsync_When_Valid_NotExist_Returns_SuccessResponse(
            [Frozen] Mock<IUserManager> _userManager,
            string id,
            UserBankVM moqResponse,
            UserBankVM request,
            [Greedy] UsersController sut
        )
        {
            // Arrange
            sut.ControllerContext = new ControllerContext();
            sut.ControllerContext.HttpContext = new DefaultHttpContext();
            sut.ControllerContext.HttpContext.Request.Headers["device-id"] = "20317";

            _userManager.Setup(x => x.AddUserBankData(It.IsAny<UserBankVM>())).ReturnsAsync(moqResponse);
            _userManager.Setup(x => x.GetUserId(It.IsAny<ClaimsIdentity>())).Returns(id);

            // Act
            var result = await sut.UserBankAsync(request);
            var response = result as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, response.StatusCode);
        }

        [Theory, AutoMoqData]
        public async Task UserBankAsync_When_Invalid_AlreadyExists_Returns_BadRequestResponse(
            [Frozen] Mock<IUserManager> _userManager,
            string id,
            UserBankVM request,
            [Greedy] UsersController sut
            )
        {
            // Arrange
            sut.ControllerContext = new ControllerContext();
            sut.ControllerContext.HttpContext = new DefaultHttpContext();
            sut.ControllerContext.HttpContext.Request.Headers["device-id"] = "20317";

            _userManager.Setup(x => x.AddUserBankData(It.IsAny<UserBankVM>())).ReturnsAsync((UserBankVM)null);
            _userManager.Setup(x => x.GetUserId(It.IsAny<ClaimsIdentity>())).Returns(id);

            // Act
            var result = await sut.UserBankAsync(request);
            var response = result as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, response.StatusCode);
        }
    }
}
