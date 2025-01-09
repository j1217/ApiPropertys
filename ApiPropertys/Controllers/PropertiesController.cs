using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiPropertys.Application.UseCases;
using WebApiPropertys.Domain.Models;

namespace ApiPropertys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly PropertyService _propertyService;

        public PropertiesController(PropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        // Crear propiedad
        [HttpPost]
        public async Task<ActionResult<Property>> CreateProperty([FromBody] Property property)
        {
            var result = await _propertyService.CreatePropertyAsync(property);
            return CreatedAtAction(nameof(GetProperty), new { id = result.IdProperty }, result);
        }

        // Actualizar propiedad
        [HttpPut("{id}")]
        public async Task<ActionResult<Property>> UpdateProperty(int id, [FromBody] Property property)
        {
            if (id != property.IdProperty)
            {
                return BadRequest();
            }

            var updatedProperty = await _propertyService.UpdatePropertyAsync(property);
            return Ok(updatedProperty);
        }

        // Cambiar precio
        [HttpPatch("{id}/price")]
        public async Task<ActionResult<Property>> ChangePrice(int id, [FromBody] decimal newPrice)
        {
            var updatedProperty = await _propertyService.ChangePropertyPriceAsync(id, newPrice);
            return Ok(updatedProperty);
        }

        // Obtener propiedades con filtros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Property>>> GetProperties([FromQuery] string? city, [FromQuery] decimal? minPrice, [FromQuery] decimal? maxPrice)
        {
            var properties = await _propertyService.GetPropertiesWithFiltersAsync(city, minPrice, maxPrice);
            return Ok(properties);
        }

        // Obtener propiedad por id
        [HttpGet("{id}")]
        public async Task<ActionResult<Property>> GetProperty(int id)
        {
            var property = await _propertyService.GetByIdAsync(id);
            if (property == null)
            {
                return NotFound();
            }
            return Ok(property);
        }
    }
}
