
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Promociones.API.Entities;
using System;

namespace Promociones.API.Data
{
    public class DataContext : IDataContext
    {
        public DataContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
            Promociones = database.GetCollection<Promocion>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            DataContextSeed.SeedData(Promociones);
        }
        public IMongoCollection<Promocion> Promociones { get; }
    }
}
