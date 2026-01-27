using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IMongoConnection
    {
        public MongoClient MongoDBClient { get; set; }
        public IMongoDatabase DatabaseName { get; set; }
    }
}
