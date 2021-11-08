using MongoDB.Driver;
using Promociones.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Promociones.API.Data
{
    public class DataContextSeed
    {
        public static void SeedData(IMongoCollection<Promocion> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();
            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetSeedData());
            }
        }

        private static IEnumerable<Promocion> GetSeedData()
        {
            var promo1 = new Promocion(
                   id: new Guid("426cc3be-cd5c-4001-bd46-7566a18f2376"),
                   mediosDePago: null,
                   bancos: null,
                   categoriasProductos: null,
                   maximaCantidadDeCuotas: 12,
                   valorInteresCuotas: 0,
                   porcentajeDeDescuento: null,
                   fechaInicio: new DateTime(2018, 06, 01),
                   fechaFin: new DateTime(2030, 06, 01),
                   activo: true,
                   fechaCreacion: DateTime.Now,
                   fechaModificacion: DateTime.Now);

            var promo2 = new Promocion(
                    id: new Guid("426cc3be-cd5c-4001-bd46-7566a18f2376"),
                    mediosDePago: new string[] { "Efectivo" },
                    bancos: null,
                    categoriasProductos: new string[] { "Colchones" },
                    maximaCantidadDeCuotas: null,
                    valorInteresCuotas: null,
                    porcentajeDeDescuento: 10,
                    fechaInicio: new DateTime(2018, 06, 01),
                    fechaFin: new DateTime(2030, 06, 01),
                    activo: true,
                    fechaCreacion: DateTime.Now,
                    fechaModificacion: DateTime.Now);

            var promo3 = new Promocion(
                    id: new Guid("426cc3be-cd5c-4001-bd46-7566a18f2376"),
                    mediosDePago: new string[] { "TARJETA_CREDITO", "TARJETA_DEBITO" },
                    bancos: new string[] { "Galicia", "Macro" },
                    categoriasProductos: new string[] { "Celulares", "Audio" },
                    maximaCantidadDeCuotas: 12,
                    valorInteresCuotas: (decimal)3.15,
                    porcentajeDeDescuento: null,
                    fechaInicio: new DateTime(2018, 06, 01),
                    fechaFin: new DateTime(2030, 06, 01),
                    activo: true,
                    fechaCreacion: DateTime.Now,
                    fechaModificacion: DateTime.Now);
            return new List<Promocion>(){promo1,promo2,promo3};  
        }
    }
}
