using System;
using System.Linq;
using System.Collections.Generic;
using WebhookService.Models;

namespace WebhookService.Repositories
{
    internal class BuildNotificationRepository : IRepository<BuildNotification>
    {
        private HashSet<BuildNotification> buildNotifications;

        public BuildNotificationRepository()
        {
            buildNotifications = new HashSet<BuildNotification>();
        }

        public IEnumerable<BuildNotification> GetAll()
        {
            return buildNotifications;
        }

        public IEnumerable<BuildNotification> Get(Func<BuildNotification, bool> predicate)
        {
            return buildNotifications.Where(predicate);
        }

        public void Add(BuildNotification buildNotification)
        {
            if (buildNotification == null)
            {
                throw new ArgumentNullException(nameof(buildNotification));
            }

            buildNotifications.Add(buildNotification);
        }

        public void DeleteById(string id)
        {
            buildNotifications.RemoveWhere(x => x.Id.Equals(id));
        }
    }
}
