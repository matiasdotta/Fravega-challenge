using MongoDB.Driver;
using Promociones.API.Data;
using Promociones.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Promociones.API.Repositories
{
    public class PromoRepository : IPromotRepository
    {
        private readonly IDataContext _context;

        public PromoRepository(IDataContext context)
        {
            _context = context;
        }

        public async Task CreatePromocion(Promocion promocion)
        {
            await _context.Promociones.InsertOneAsync(promocion);
        }

        public async Task<bool> DeletePromocion(string id)
        {
            var DeleteResult = await _context.Promociones.DeleteOneAsync(filter: q => q.Id == new Guid(id));

            return DeleteResult.IsAcknowledged && DeleteResult.DeletedCount > 0;
        }
       

        public async Task<Promocion> GetPromocion(string id)
        {
            return await _context.Promociones.Find(p => p.Id.ToString() == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Promocion>> GetPromociones()
        {
            var promos = await _context.Promociones.Find(p => true).ToListAsync();
            return promos;
        }

        public async Task<IEnumerable<Promocion>> GetPromocionesVigentes()
        {
            return await _context.Promociones.Find(p => p.FechaFin >= DateTime.Now 
                                                && p.FechaInicio <= DateTime.Now)
                                                    .ToListAsync();
        }

        public async Task<IEnumerable<Promocion>> GetPromocionesVigentesEnFecha(DateTime? fecha)
        {
            return await _context.Promociones.Find(p => p.FechaFin >= fecha 
                                                && p.FechaInicio <= fecha)
                                                .ToListAsync();
        }

        public async Task<IEnumerable<Promocion>> GetPromocionesVigentesParaVenta(string medioDePago, string banco, IEnumerable<string> categoriaProducto)
        {
            return await _context.Promociones.Find(p => p.MediosDePago.Contains(medioDePago) 
                                                && p.Bancos.Contains(banco) 
                                                && p.CategoriasProductos.Any(q => categoriaProducto.Contains(q)))
                                                .ToListAsync();
        }

        public async Task<bool> UpdatePromocion(Promocion promocion)
        {
            var updateResult = await _context.Promociones.ReplaceOneAsync(filter: q => q.Id == promocion.Id, replacement: promocion);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> UpdateVigenciaPromocion(string id, DateTime? fechaInicio, DateTime? fechaFin)
        {
            Guid guid = new Guid(id);
            var update = Builders<Promocion>.Update.Set("FechaInicio", fechaInicio).Set("FechaFin", fechaFin);
            var updateResult = await _context.Promociones.UpdateOneAsync(p => p.Id == guid, update);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
