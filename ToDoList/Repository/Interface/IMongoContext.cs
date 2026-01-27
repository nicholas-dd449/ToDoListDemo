using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IMongoContext : IDisposable
    {
        Task AddCommandAsync(Func<IClientSessionHandle, Task> func);

        Task<int> SaveChangeAsync(IClientSessionHandle session);

        Task<IClientSessionHandle> StartSessionAsync();

        IMongoCollection<T> GetCollection<T>(string name);

    }
}
