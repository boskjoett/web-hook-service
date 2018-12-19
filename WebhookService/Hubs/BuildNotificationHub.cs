using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using WebhookService.Models;

namespace WebhookService.Hubs
{
    public class BuildNotificationHub : Hub
    {
        public async Task PushNotificationAsync(BuildNotification buildNotification)
        {
            await Clients.All.SendAsync("BuildCompleted", buildNotification);
        }
    }
}
