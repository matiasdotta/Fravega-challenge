using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Promociones.API.Entities
{
    public class Promocion
    {
        [BsonId]
        public Guid Id { get; private set; }
        public IEnumerable<string> MediosDePago { get; private set; }
        public IEnumerable<string> Bancos { get; private set; }
        public IEnumerable<string> CategoriasProductos { get; private set; }
        public int? MaximaCantidadDeCuotas { get; private set; }
        public decimal? ValorInteresCuotas { get; private set; }
        public decimal? PorcentajeDeDescuento { get; private set; }
        public DateTime? FechaInicio { get; private set; }
        public DateTime? FechaFin { get; private set; }
        public bool Activo { get; private set; }
        public DateTime FechaCreacion { get; private set; }
        public DateTime? FechaModificacion { get; private set; }

        public Promocion(Guid id, IEnumerable<string> mediosDePago, IEnumerable<string> bancos, IEnumerable<string> categoriasProductos, int? maximaCantidadDeCuotas, decimal? valorInteresCuotas, decimal? porcentajeDeDescuento, DateTime? fechaInicio, DateTime? fechaFin, bool activo, DateTime fechaCreacion, DateTime? fechaModificacion)
        {
            Id = id;
            MediosDePago = mediosDePago;
            Bancos = bancos;
            CategoriasProductos = categoriasProductos;
            MaximaCantidadDeCuotas = maximaCantidadDeCuotas;
            ValorInteresCuotas = valorInteresCuotas;
            PorcentajeDeDescuento = porcentajeDeDescuento;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            Activo = activo;
            FechaCreacion = fechaCreacion;
            FechaModificacion = fechaModificacion;
        }
    }
}
