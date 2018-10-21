using Microsoft.Azure.EventHubs;
using System.Text;
using System.Threading.Tasks;
using SpeedTestApi.Models;

namespace SpeedTestApi.Services
{
    public interface ISpeedTestEvents
    {
        Task PublishSpeedTest(TestResult SpeedTest);
    }
}
