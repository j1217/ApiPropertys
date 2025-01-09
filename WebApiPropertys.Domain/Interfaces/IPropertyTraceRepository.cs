using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPropertys.Domain.Models;

namespace WebApiPropertys.Domain.Interfaces
{
    public interface IPropertyTraceRepository
    {
        Task<PropertyTrace> AddTraceAsync(PropertyTrace propertyTrace); // Agregar trazo de venta
        Task<List<PropertyTrace>> GetTracesAsync(int propertyId); // Obtener trazos históricos de propiedad
        Task<PropertyTrace> GetPropertyTraceByIdAsync(int traceId); // Obtener trazo por Id
    }
}
