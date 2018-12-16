using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using WebhookService.Models;

namespace ClientConsoleApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Azure DevOps build notification client started");

            var connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5000/BuildNotificationHub")
                //.ConfigureLogging(logging =>
                //{
                //    logging.AddConsole();
                //})
                //.AddMessagePackProtocol()
                .Build();

            await connection.StartAsync();

            Console.WriteLine("SignalR connection started");

            connection.Closed += e =>
            {
                Console.WriteLine("SignalR connection closed with error: {0}", e);
                return Task.CompletedTask;
            };

            connection.On<BuildNotification>("BuildCompleted", (buildNotification) =>
            {
                Console.WriteLine($"Build completed at {buildNotification.CreatedTime}");
            });
        }
    }
}
