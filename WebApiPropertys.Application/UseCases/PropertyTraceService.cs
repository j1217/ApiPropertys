using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPropertys.Domain.Interfaces;
using WebApiPropertys.Domain.Models;

namespace WebApiPropertys.Application.UseCases
{
    public class PropertyTraceService
    {
        private readonly IPropertyTraceRepository _propertyTraceRepository;

        public PropertyTraceService(IPropertyTraceRepository propertyTraceRepository)
        {
            _propertyTraceRepository = propertyTraceRepository;
        }

        // Agregar trazo
        public async Task<PropertyTrace> AddTraceAsync(PropertyTrace propertyTrace)
        {
            return await _propertyTraceRepository.AddTraceAsync(propertyTrace);
        }

        // Obtener trazos históricos
        public async Task<List<PropertyTrace>> GetTracesAsync(int propertyId)
        {
            return await _propertyTraceRepository.GetTracesAsync(propertyId);
        }

        // Obtener trazo por id
        public async Task<PropertyTrace> GetPropertyTraceByIdAsync(int traceId)
        {
            return await _propertyTraceRepository.GetPropertyTraceByIdAsync(traceId);
        }
    }
}
