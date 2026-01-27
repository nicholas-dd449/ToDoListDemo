using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class MongoConnection : IMongoConnection
    {
        public MongoClient MongoDBClient { get; set; }
        public IMongoDatabase DatabaseName { get; set; }

        public MongoConnection(IConfiguration configuration)
        {
            MongoDBClient = new MongoClient(configuration["MongoSettings:Connection"]);
            DatabaseName = MongoDBClient.GetDatabase(configuration["MongoSettings:DatabaseName"]);
        }
    }
}
