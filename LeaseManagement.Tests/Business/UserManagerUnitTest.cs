using AutoFixture.Xunit2;
using LeaseManagement.BL.UserDetails;
using LeaseManagement.BusinessEntities.ViewModels;
using LeaseManagement.Infrastructure;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LeaseManagement.Tests.Business
{
    public class UserManagerUnitTest
    {
        [Theory, AutoMoqData]
        public async Task AddUserPersonalDataAsync_Check_UserPersonalVM_Exists_Returns_SameUserPersonalVM(
            [Frozen] Mock<IUnitOfWork> _uow,
            UserPersonalVM request,
            [Greedy] UserManager sut)
        {
            // Arrange
            _uow.Setup(x => x.UserPersonalRepository.CheckPersonalDataIfExist(It.IsAny<Guid>())).ReturnsAsync(true);

            // Act
            var result = await sut.AddUserPersonalDataAsync(request);

            // Assert
            Assert.Same(request,result);
        }

        [Theory, AutoMoqData]
        public async Task AddUserPersonalDataAsync_Check_UserPersonalVM_Exists_Returns_NewUserPersonalVM(
            [Frozen] Mock<IUnitOfWork> _uow,
            UserPersonalVM request,
            [Greedy] UserManager sut)
        {
            // Arrange
            _uow.Setup(x => x.UserPersonalRepository.CheckPersonalDataIfExist(It.IsAny<Guid>())).ReturnsAsync(false);

            // Act
            var result = await sut.AddUserPersonalDataAsync(request);

            // Assert
            Assert.NotSame(request, result);
        }

        [Theory, AutoMoqData]
        public async Task AddUserBanklDataAsync_Check_UserBankVM_Exists_Returns_SameUserBankVM(
            [Frozen] Mock<IUnitOfWork> _uow,
            UserBankVM request,
            [Greedy] UserManager sut)
        {
            // Arrange
            _uow.Setup(x => x.UserBankRepository.CheckBankDataIfExist(It.IsAny<Guid>())).ReturnsAsync(true);

            // Act
            var result = await sut.AddUserBankData(request);

            // Assert
            Assert.Same(request, result);
        }

        [Theory, AutoMoqData]
        public async Task AddUserBanklDataAsync_Check_UserBankVM_Exists_Returns_NewUserBankVM(
            [Frozen] Mock<IUnitOfWork> _uow,
            UserBankVM request,
            [Greedy] UserManager sut)
        {
            // Arrange
            _uow.Setup(x => x.UserBankRepository.CheckBankDataIfExist(It.IsAny<Guid>())).ReturnsAsync(false);

            // Act
            var result = await sut.AddUserBankData(request);

            // Assert
            Assert.NotSame(request, result);
        }

        [Theory, AutoMoqData]
        public async Task AddUserEmploymentDataAsync_Check_UserEmploymentVM_Exists_Returns_SameUserEmploymentVM(
            [Frozen] Mock<IUnitOfWork> _uow,
            UserEmploymentVM request,
            [Greedy] UserManager sut)
        {
            // Arrange
            _uow.Setup(x => x.UserEmploymentRepository.CheckEmploymentDataIfExist(It.IsAny<Guid>())).ReturnsAsync(true);

            // Act
            var result = await sut.AddUserEmploymentDataAsync(request);

            // Assert
            Assert.Same(request, result);
        }

        [Theory, AutoMoqData]
        public async Task AddUserEmploymentDataAsync_Check_UserEmploymentVM_Exists_Returns_NewUserEmploymentVM(
            [Frozen] Mock<IUnitOfWork> _uow,
            UserEmploymentVM request,
            [Greedy] UserManager sut)
        {
            // Arrange
            _uow.Setup(x => x.UserEmploymentRepository.CheckEmploymentDataIfExist(It.IsAny<Guid>())).ReturnsAsync(false);

            // Act
            var result = await sut.AddUserEmploymentDataAsync(request);

            // Assert
            Assert.NotSame(request, result);
        }
    }
}
