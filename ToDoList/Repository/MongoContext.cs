using MongoDB.Driver;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class MongoContext : IMongoContext
    {
        private readonly IMongoDatabase _mongoDatabaseName;
        private readonly MongoClient _mongoClient;
        private readonly List<Func<IClientSessionHandle, Task>> _commands = new List<Func<IClientSessionHandle, Task>>();

        public MongoContext(IMongoConnection connection)
        {
            _mongoClient = connection.MongoDBClient;
            _mongoDatabaseName = connection.DatabaseName;
        }

        public async Task AddCommandAsync(Func<IClientSessionHandle, Task> func)
        {
            _commands.Add(func);
            await Task.CompletedTask;
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _mongoDatabaseName.GetCollection<T>(name);
        }

        public async Task<int> SaveChangeAsync(IClientSessionHandle session)
        {
            try
            {
                session.StartTransaction();//开始事务

                foreach (var command in _commands)
                {
                    await command(session);
                }

                await session.CommitTransactionAsync();//提交事务
                return _commands.Count;

            }
            catch (Exception ex)
            {
                await session.AbortTransactionAsync();//回滚事务
                return 0;
            }
            finally
            {
                _commands.Clear();
            }
        }

        public async Task<IClientSessionHandle> StartSessionAsync()
        {
            var session = await _mongoClient.StartSessionAsync();
            return session;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
