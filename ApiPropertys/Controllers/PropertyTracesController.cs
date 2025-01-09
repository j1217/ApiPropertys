using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiPropertys.Application.UseCases;
using WebApiPropertys.Domain.Models;

namespace ApiPropertys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyTracesController : ControllerBase
    {
        private readonly PropertyTraceService _propertyTraceService;

        public PropertyTracesController(PropertyTraceService propertyTraceService)
        {
            _propertyTraceService = propertyTraceService;
        }

        // Agregar trazo de venta
        [HttpPost("{propertyId}/traces")]
        public async Task<ActionResult<PropertyTrace>> AddTraceToProperty([FromBody] PropertyTrace propertyTrace)
        {
            var result = await _propertyTraceService.AddTraceAsync(propertyTrace);
            return CreatedAtAction(nameof(GetPropertyTrace), new { id = result.IdPropertyTrace }, result);
        }

        // Obtener trazos históricos de propiedad
        [HttpGet("{propertyId}/traces")]
        public async Task<ActionResult<IEnumerable<PropertyTrace>>> GetPropertyTraces(int propertyId)
        {
            var traces = await _propertyTraceService.GetTracesAsync(propertyId);
            return Ok(traces);
        }

        // Obtener trazo por id
        [HttpGet("{traceId}")]
        public async Task<ActionResult<PropertyTrace>> GetPropertyTrace(int traceId)
        {
            var trace = await _propertyTraceService.GetPropertyTraceByIdAsync(traceId);
            if (trace == null)
            {
                return NotFound();
            }
            return Ok(trace);
        }
    }
}
