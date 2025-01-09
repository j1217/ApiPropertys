using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiPropertys.Application.UseCases;
using WebApiPropertys.Domain.Models;

namespace ApiPropertys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly OwnerService _ownerService;

        public OwnersController(OwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        // Crear propietario
        [HttpPost]
        public async Task<ActionResult<Owner>> CreateOwner([FromBody] Owner owner)
        {
            var result = await _ownerService.CreateOwnerAsync(owner);
            return CreatedAtAction(nameof(GetOwner), new { id = result.IdOwner }, result);
        }

        // Actualizar propietario
        [HttpPut("{id}")]
        public async Task<ActionResult<Owner>> UpdateOwner(int id, [FromBody] Owner owner)
        {
            if (id != owner.IdOwner)
            {
                return BadRequest();
            }

            var updatedOwner = await _ownerService.UpdateOwnerAsync(owner);
            return Ok(updatedOwner);
        }

        // Obtener propietario por nombre
        [HttpGet("name/{name}")]
        public async Task<ActionResult<Owner>> GetOwnerByName(string name)
        {
            var owner = await _ownerService.GetOwnerByNameAsync(name);
            if (owner == null)
            {
                return NotFound();
            }
            return Ok(owner);
        }

        // Obtener propietario con propiedades asociadas
        [HttpGet("{id}")]
        public async Task<ActionResult<Owner>> GetOwner(int id)
        {
            var owner = await _ownerService.GetOwnerWithPropertiesAsync(id);
            if (owner == null)
            {
                return NotFound();
            }
            return Ok(owner);
        }
    }
}
