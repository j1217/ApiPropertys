using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPropertys.Domain.Interfaces;
using WebApiPropertys.Domain.Models;

namespace WebApiPropertys.Application.UseCases
{
    public class PropertyImageService
    {
        private readonly IPropertyImageRepository _propertyImageRepository;

        public PropertyImageService(IPropertyImageRepository propertyImageRepository)
        {
            _propertyImageRepository = propertyImageRepository;
        }

        // Agregar imagen
        public async Task<PropertyImage> AddImageAsync(PropertyImage propertyImage)
        {
            return await _propertyImageRepository.AddImageAsync(propertyImage);
        }

        // Actualizar estado de imagen
        public async Task<PropertyImage> UpdateImageStatusAsync(int imageId, bool isActive)
        {
            return await _propertyImageRepository.UpdateImageStatusAsync(imageId, isActive);
        }

        // Obtener imagen de propiedad por id
        public async Task<PropertyImage> GetPropertyImageByIdAsync(int imageId)
        {
            return await _propertyImageRepository.GetPropertyImageByIdAsync(imageId);
        }
    }
}
