using Microsoft.Azure.EventHubs;
using System.Text;
using System.Threading.Tasks;
using SpeedtestApi.Models;

namespace SpeedtestApi.Services
{
    public interface ISpeedtestEvents
    {
        Task PublishSpeedtest(Speedtest speedtest);
    }
}
