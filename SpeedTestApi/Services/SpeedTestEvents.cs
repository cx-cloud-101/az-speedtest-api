using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.EventHubs;
using SpeedTestApi.Models;

namespace SpeedTestApi.Services
{
    public class SpeedTestEvents : ISpeedTestEvents, IDisposable
    {
        private readonly EventHubClient client;

        public SpeedTestEvents(string connectionString, string entityPath)
        {
            // Creates an EventHubsConnectionStringBuilder object from the connection string, and sets the EntityPath.
            // Typically, the connection string should have the entity path in it, but this simple scenario
            // uses the connection string from the namespace.
            var connectionStringBuilder = new EventHubsConnectionStringBuilder(connectionString)
            {
                EntityPath = entityPath
            };
            
            client = EventHubClient.CreateFromConnectionString(connectionStringBuilder.ToString());
        }

        public async Task PublishSpeedTest(TestResult SpeedTest)
        {
            var message = "Some serialized SpeedTest";

            await SendMessage(message);
        }

        private async Task SendMessage(string message)
        {
            var data = new EventData(Encoding.UTF8.GetBytes(message));
            try
            {
                await client.SendAsync(data);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{DateTime.Now} > Exception: {exception.Message}");
            }
        }

        public void Dispose()
        {
            client.CloseAsync();
        }
    }
}
