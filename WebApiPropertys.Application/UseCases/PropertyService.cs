using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPropertys.Domain.Interfaces;
using WebApiPropertys.Domain.Models;

namespace WebApiPropertys.Application.UseCases
{
    public class PropertyService
    {
        private readonly IPropertyRepository _propertyRepository;

        public PropertyService(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        // Crear propiedad
        public async Task<Property> CreatePropertyAsync(Property property)
        {
            return await _propertyRepository.CreateAsync(property);
        }

        // Actualizar propiedad
        public async Task<Property> UpdatePropertyAsync(Property property)
        {
            return await _propertyRepository.UpdateAsync(property);
        }

        // Cambiar precio
        public async Task<Property> ChangePropertyPriceAsync(int propertyId, decimal newPrice)
        {
            return await _propertyRepository.ChangePriceAsync(propertyId, newPrice);
        }

        // Obtener propiedades con filtros
        public async Task<List<Property>> GetPropertiesWithFiltersAsync(string location, decimal? minPrice, decimal? maxPrice)
        {
            return await _propertyRepository.GetPropertiesWithFiltersAsync(location, minPrice, maxPrice);
        }

        // Obtener propiedad por ID
        public async Task<Property> GetByIdAsync(int id)
        {
            return await _propertyRepository.GetByIdAsync(id);
        }
    }
}
