using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using WebhookService.Models;

namespace ClientConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Azure DevOps build notification client started");

            try
            {
                StartSignalRHub().Wait();

                Console.WriteLine("SignalR connection started");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            Console.WriteLine("Press ENTER to exit...");
            Console.ReadLine();
        }

        private static async Task StartSignalRHub()
        {
            var connection = new HubConnectionBuilder()
                .WithUrl("https://devopswebhook.azurewebsites.net/BuildNotificationHub")
                //.ConfigureLogging(logging =>
                //{
                //    logging.AddConsole();
                //})
                .Build();

            await connection.StartAsync();

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
