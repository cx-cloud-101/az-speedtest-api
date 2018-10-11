using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.EventHubs;
using SpeedtestApi.Models;

namespace SpeedtestApi.Services
{
    public class SpeedtestEvents : ISpeedtestEvents, IDisposable
    {
        private static EventHubClient client;
        private const string EhConnectionString = "{Event Hubs connection string}";
        private const string EhEntityPath = "{Event Hub path/name}";

        public SpeedtestEvents(string connectionString, string entityPath)
        {
            EhConnectionString = "{Event Hubs connection string}";
            EhEntityPath = "{Event Hub path/name}";

            // Creates an EventHubsConnectionStringBuilder object from the connection string, and sets the EntityPath.
            // Typically, the connection string should have the entity path in it, but this simple scenario
            // uses the connection string from the namespace.
            var connectionStringBuilder = new EventHubsConnectionStringBuilder(EhConnectionString)
            {
                EntityPath = EhEntityPath
            };
            
            eventHubClient = EventHubClient.CreateFromConnectionString(connectionStringBuilder.ToString());
        }

        public async Task PublishSpeedtest(Speedtest speedtest)
        {
            await SendMessagesToEventHub(100);
        }

        public void Dispose()
        {
            client.CloseAsync();
        }
    }
}
