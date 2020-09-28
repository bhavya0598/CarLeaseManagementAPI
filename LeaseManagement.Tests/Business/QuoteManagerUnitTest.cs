using AutoFixture.Xunit2;
using LeaseManagement.BL.Quote;
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
    public class QuoteManagerUnitTest
    {
        [Theory, AutoMoqData]
        public async Task GetPaybackTime_When_Valid_Returns_ListOfPaybackTimeVM(
            [Frozen] Mock<IUnitOfWork> _uow,
            List<PaybackTimeVM> moqResponse,
            [Greedy] QuoteManager sut
            )
        {
            // Arrange
            _uow.Setup(x => x.PaybackTimeRepository.GetPaybackTime()).ReturnsAsync(moqResponse);
            
            // Act
            var result = await sut.GetPaybackTime();
            
            // Assert
            Assert.NotNull(result);
        }

        [Theory, AutoMoqData]
        public async Task GetMileageLimit_When_Valid_Returns_ListOfMileageLimitVM(
            [Frozen] Mock<IUnitOfWork> _uow,
            List<MileageLimitVM> moqResponse,
            [Greedy] QuoteManager sut)
        {
            // Arrange
            _uow.Setup(x => x.MileageLimitRepository.GetMileageLimit()).ReturnsAsync(moqResponse);

            // Act
            var result = await sut.GetMileageLimit();

            // Assert
            Assert.NotNull(result);
        }

        [Theory, AutoMoqData]
        public async Task SaveQuoteAsync_When_Vaid_Quote_Returns_Quote(
            [Frozen] Mock<IUnitOfWork> uow,
            QuoteVM MoqResponse,
            QuoteVM request,
            [Greedy] QuoteManager sut
            )
        {
            // Arrange
            uow.Setup(x => x.QuoteRepository.SaveQuoteAsync(It.IsAny<QuoteVM>())).ReturnsAsync(MoqResponse);

            // Act
            var result = await sut.SaveQuoteAsync(request);

            // Assert
            Assert.NotNull(result);
        }
    }
}
