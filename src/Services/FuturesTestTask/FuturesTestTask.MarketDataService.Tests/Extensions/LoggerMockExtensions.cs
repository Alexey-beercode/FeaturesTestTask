using Microsoft.Extensions.Logging;
using Moq;

public static class LoggerMockExtensions
{
    public static void VerifyLog(this Mock<ILogger> logger, LogLevel level, Times times)
    {
        logger.Verify(x =>
                x.Log(
                    level,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => true),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            times);
    }

    public static void VerifyLog<T>(this Mock<ILogger<T>> logger, LogLevel level, Times times)
    {
        logger.Verify(x =>
                x.Log(
                    level,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => true),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            times);
    }
}