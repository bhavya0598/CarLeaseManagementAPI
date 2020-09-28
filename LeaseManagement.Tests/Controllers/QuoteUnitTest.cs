using AutoFixture.Xunit2;
using LeaseManagement.BL.Quote;
using LeaseManagement.BusinessEntities.ViewModels;
using LeaseManagement.QuoteService.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LeaseManagement.Tests
{
    public class QuoteUnitTest
    {
        [Theory, AutoMoqData]
        public async Task GetPaybackTime_When_Valid_Returns_SuccessResponse(
            [Frozen] Mock<IQuoteManager> _quoteManager,
            List<PaybackTimeVM> moqResponse,
            [Greedy] QuoteController sut
            )
        {
            // Arrange
            _quoteManager.Setup(x => x.GetPaybackTime()).ReturnsAsync(moqResponse);

            // Act
            var result = await sut.GetPaybackTime();
            var response = result as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, response.StatusCode);
        }

        [Theory, AutoMoqData]
        public async Task GetPaybackTime_When_Invalid_Returns_NotFoundResponse(
            [Frozen] Mock<IQuoteManager> _quoteManager,
            [Greedy] QuoteController sut)
        {
            // Arrange
            _quoteManager.Setup(x => x.GetPaybackTime()).ReturnsAsync(new List<PaybackTimeVM>());

            // Act
            var result = await sut.GetPaybackTime();
            var response = result as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, response.StatusCode);
        }

        [Theory, AutoMoqData]
        public async Task GetMileageLimit_When_Valid_Returns_SuccessResponse(
            [Frozen] Mock<IQuoteManager> _quoteManager,
            List<MileageLimitVM> moqResponse,
            [Greedy] QuoteController sut)
        {
            // Arrange
            _quoteManager.Setup(x => x.GetMileageLimit()).ReturnsAsync(moqResponse);

            // Act
            var result = await sut.GetMileageLimit();
            var response = result as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, response.StatusCode);
        }

        [Theory, AutoMoqData]
        public async Task GetMileageLimit_When_Invalid_Returns_NotFoundResponse(
            [Frozen] Mock<IQuoteManager> _quoteManager,
            [Greedy] QuoteController sut)
        {
            // Arrange
            _quoteManager.Setup(x => x.GetMileageLimit()).ReturnsAsync(new List<MileageLimitVM>());

            // Act
            var result = await sut.GetMileageLimit();
            var response = result as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, response.StatusCode);
        }

        [Theory, AutoMoqData]
        public async Task SaveQuote_When_Valid_Quote_Returns_SuccessResponse(
            [Frozen] Mock<IQuoteManager> _quoteManager,
            QuoteVM moqResponse,
            QuoteVM request,
            [Greedy] QuoteController sut
            )
        {
            // Arrange
            _quoteManager.Setup(x => x.SaveQuoteAsync(It.IsAny<QuoteVM>())).ReturnsAsync(moqResponse);

            // Act
            var result = await sut.SaveQuoteAsync(request);
            var response = result as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, response.StatusCode);
        }

        [Theory, AutoMoqData]
        public async Task SaveQuote_When_InValid_Quote_Returns_BadRequestResponse(
            [Frozen] Mock<IQuoteManager> _quoteManager,
            QuoteVM request,
            [Greedy] QuoteController sut)
        {
            // Arrange
            _quoteManager.Setup(x => x.SaveQuoteAsync(It.IsAny<QuoteVM>())).ReturnsAsync((QuoteVM)null);

            // Act
            var result = await sut.SaveQuoteAsync(request);
            var response = result as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, response.StatusCode);
        }
    }
}
