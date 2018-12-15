using System;
using WebhookService.Repositories;

namespace WebhookService.Models
{
    public class BuildNotification : RepositoryItem
    {
        public string EventType { get; set; }
        public string ResourceUrl { get; set; }
        public DateTime CreatedTime { get; set; }

        public override bool Equals(object obj)
        {
            BuildNotification other = obj as BuildNotification;
            if (other == null)
                return false;

            return Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
