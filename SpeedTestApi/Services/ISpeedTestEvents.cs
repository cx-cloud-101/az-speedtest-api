using SpeedTestLogger.Models;

namespace SpeedTestApi.Services;

public interface ISpeedTestEvents
{
    Task PublishSpeedTest(TestResult speedTest);
}
