using MongoDB.Driver;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly IMongoContext _context;

        public UnitOfWork(IMongoContext context)
        { 
            _context = context;
        }

        public async Task<bool> Commit(IClientSessionHandle session)
        {
            return await _context.SaveChangeAsync(session) > 0;
        }

        public async Task<IClientSessionHandle> InitTransaction()
        {
            return await _context.StartSessionAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
