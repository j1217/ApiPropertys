using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiPropertys.Application.UseCases;
using WebApiPropertys.Domain.Models;

namespace ApiPropertys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyImagesController : ControllerBase
    {
        private readonly PropertyImageService _propertyImageService;

        public PropertyImagesController(PropertyImageService propertyImageService)
        {
            _propertyImageService = propertyImageService;
        }

        // Agregar imagen a propiedad
        [HttpPost("{propertyId}/images")]
        public async Task<ActionResult<PropertyImage>> AddImageToProperty([FromBody] PropertyImage propertyImage)
        {
            var result = await _propertyImageService.AddImageAsync(propertyImage);
            return CreatedAtAction(nameof(GetPropertyImage), new { id = result.IdPropertyImage }, result);
        }

        // Actualizar estado de imagen
        [HttpPut("{imageId}/status")]
        public async Task<ActionResult<PropertyImage>> UpdateImageStatus(int imageId, [FromBody] string newStatus)
        {
            var updatedImage = await _propertyImageService.UpdateImageStatusAsync(imageId, Convert.ToBoolean(newStatus));
            return Ok(updatedImage);
        }

        // Obtener imagen de propiedad
        [HttpGet("{imageId}")]
        public async Task<ActionResult<PropertyImage>> GetPropertyImage(int imageId)
        {
            var image = await _propertyImageService.GetPropertyImageByIdAsync(imageId);
            if (image == null)
            {
                return NotFound();
            }
            return Ok(image);
        }
    }
}
