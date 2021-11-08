using MongoDB.Driver;
using Promociones.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Promociones.API.Data
{
    public interface IDataContext
    {
        IMongoCollection<Promocion> Promociones { get; }
    }
}
