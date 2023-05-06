using System.Threading.Tasks;
using BinanceApiDemo;
using BinanceApiDemo.Data;
using BinanceApiDemo.Services;
using Moq;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class MainPageViewModelTests
    {
        [Test]
        public async Task SuccessfulTest()
        {
            // ARRANGE
            var binanceServiceMock = new Mock<IBinanceService>();
            binanceServiceMock
                .Setup(service => service.GetTicketsAsync())
                .Returns(Task.FromResult(
                    Response<Ticket[]>.Success(new[]
                    {
                        new Ticket(),
                        new Ticket()
                    })));

            var viewModel = new MainPageViewModel(binanceServiceMock.Object);

            // ACT
            await viewModel.InitAsync();
            
            // ASSERT
            Assert.AreEqual(2, viewModel.Tickets.Length);
        }

        [Test]
        public async Task FailTest()
        {
            // ARRANGE
            var testErrorMessage = "TEST";

            var binanceServiceMock = new Mock<IBinanceService>();
            binanceServiceMock
                .Setup(service => service.GetTicketsAsync())
                .Returns(Task.FromResult(Response<Ticket[]>.Fail(testErrorMessage)));

            var viewModel = new MainPageViewModel(binanceServiceMock.Object);

            // ACT
            await viewModel.InitAsync();
            
            // ASSERT
            Assert.AreEqual(testErrorMessage, viewModel.Error);
        }
    }
}