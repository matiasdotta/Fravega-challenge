
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Promociones.API.Entities;
using Promociones.API.Repositories;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Promociones.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PromoController : ControllerBase
    {

        private readonly IPromotRepository _repository;
        private readonly ILogger<PromoController> _logger;

        public PromoController(IPromotRepository repository, ILogger<PromoController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Promocion>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Promocion>>> GetPromociones()
        {
            var promociones = await _repository.GetPromociones();
            return Ok(promociones);
        }

        [HttpGet("{id:length(36)}", Name = "GetPromocion")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Promocion), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Promocion>> GetPromocion(string id)
        {
            var product = await _repository.GetPromocion(id);
            if(product == null)
            {
                _logger.LogError($"Product with id: {id}, not found.");
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet("GetPromocionesVigentes")]
        [ProducesResponseType(typeof(IEnumerable<Promocion>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Promocion>>> GetPromocionesVigentes()
        {
            var promociones = await _repository.GetPromocionesVigentes();
            return Ok(promociones);
        }

        [HttpGet("GetPromocionesVigentesEnFecha")]
        [ProducesResponseType(typeof(IEnumerable<Promocion>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Promocion>>> GetPromocionesVigentesEnFecha(DateTime? fecha)
        {
            var promociones = await _repository.GetPromocionesVigentesEnFecha(fecha);
            return Ok(promociones);
        }

        [HttpGet("GetPromocionesVigentesParaVenta")]
        [ProducesResponseType(typeof(IEnumerable<Promocion>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Promocion>>> GetPromocionesVigentesParaVenta(string medioDePago, string banco, IEnumerable<string> categoriaProducto)
        {
            var promociones = await _repository.GetPromocionesVigentesParaVenta(medioDePago, banco, categoriaProducto);
            return Ok(promociones);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Promocion), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Promocion>> CreatePromocion([FromBody] Promocion product)
        {
           await _repository.CreatePromocion(product);
            return CreatedAtRoute("GetPromocion", new { id = product.Id }, product);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Promocion), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdatePromocion([FromBody] Promocion promocion)
        {
            return Ok(await _repository.UpdatePromocion(promocion));
        }

        [HttpPatch]
        [ProducesResponseType(typeof(Promocion), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateVigenciaPromocion(string id, DateTime? fechaInicio, DateTime? fechaFin)
        {
            return Ok(await _repository.UpdateVigenciaPromocion(id,  fechaInicio, fechaFin));
        }


        [HttpDelete("{id:length(36)}", Name = "DeletProduct")]
        [ProducesResponseType(typeof(Promocion), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeletePromocion(string id)
        {
            return Ok(await _repository.DeletePromocion(id));
        }
    }
}
