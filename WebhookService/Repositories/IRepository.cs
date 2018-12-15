using System;
using System.Collections.Generic;

namespace WebhookService.Repositories
{
    public interface IRepository<T> where T : RepositoryItem
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Get(Func<T, bool> predicate);

        void Add(T item);
        void DeleteById(string id);
    }
}
