using Promociones.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Promociones.API.Repositories
{
    public interface IPromotRepository
    {
        Task<IEnumerable<Promocion>> GetPromociones();
        Task<Promocion> GetPromocion(string id);
        Task<IEnumerable<Promocion>> GetPromocionesVigentes();
        Task<IEnumerable<Promocion>> GetPromocionesVigentesEnFecha(DateTime? fecha);
        Task<IEnumerable<Promocion>> GetPromocionesVigentesParaVenta(string MedioDePago, string Banco, IEnumerable<string> CategoriaProducto);

        Task CreatePromocion(Promocion promocion);
        Task<bool> UpdatePromocion(Promocion promocion);
        Task<bool> UpdateVigenciaPromocion(string id, DateTime? fechaInicio, DateTime? fechaFin);

        Task<bool> DeletePromocion(string id);
    }
}
