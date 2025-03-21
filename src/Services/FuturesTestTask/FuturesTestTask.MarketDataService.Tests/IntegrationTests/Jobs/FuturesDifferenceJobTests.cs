using System;
using System.Threading;
using System.Threading.Tasks;
using FeaturesTestTask.MarketDataService.Application.UseCases.FuturesData.CreateFuturesDifference;
using FuturesTestTask.MarketDataService.Infrastructure.Jobs;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace FuturesTestTask.MarketDataService.Tests.IntegrationTests.Jobs;

public class FuturesDifferenceJobTests
{
    [Fact]
    public async Task ExecuteAsync_CallsMediatorWithCorrectCommand()
    {
        // Arrange
        var mediatorMock = new Mock<IMediator>();
        var loggerMock = new Mock<ILogger<FuturesDifferenceJob>>();

        var job = new FuturesDifferenceJob(mediatorMock.Object, loggerMock.Object);

        // Act
        await job.ExecuteAsync();

        // Assert
        mediatorMock.Verify(m => m.Send(
            It.Is<CreateFuturesDifferenceCommand>(c =>
                c.Interval == "1d" && c.Date == DateTime.UtcNow.Date),
            It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task ExecuteAsync_LogsStartAndFinish()
    {
        // Arrange
        var mediatorMock = new Mock<IMediator>();
        mediatorMock.Setup(m => m.Send(It.IsAny<CreateFuturesDifferenceCommand>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        var loggerMock = new Mock<ILogger<FuturesDifferenceJob>>();
        var job = new FuturesDifferenceJob(mediatorMock.Object, loggerMock.Object);

        // Act
        await job.ExecuteAsync();

        // Assert: хотя мы не проверяем вывод в консоль, но можно проверить, что логгер был вызван
        loggerMock.VerifyLog(LogLevel.Information, Times.Exactly(2));
    }
}
