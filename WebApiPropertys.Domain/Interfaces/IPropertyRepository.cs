using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPropertys.Domain.Models;

namespace WebApiPropertys.Domain.Interfaces
{
    public interface IPropertyRepository : IRepository<Property>
    {
        Task<Property> CreateAsync(Property property); // Crear propiedad
        Task<Property> UpdateAsync(Property property); // Actualizar propiedad
        Task<Property> ChangePriceAsync(int propertyId, decimal newPrice); // Cambiar precio
        Task<Property> GetByIdAsync(int id); // Obtener propiedad por ID
        Task<List<Property>> GetPropertiesWithFiltersAsync(string location, decimal? minPrice, decimal? maxPrice); // Obtener propiedades con filtros
    }
}
