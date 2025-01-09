using Microsoft.EntityFrameworkCore;
using WebApiPropertys.Domain.Interfaces;
using WebApiPropertys.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiPropertys.Infrastructure.Data;

namespace WebApiPropertys.Infrastructure.Repositories
{
    public class PropertyTraceRepository : IPropertyTraceRepository
    {
        private readonly ApplicationDbContext _context;

        public PropertyTraceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PropertyTrace> AddTraceAsync(PropertyTrace propertyTrace)
        {
            await _context.PropertyTraces.AddAsync(propertyTrace);
            await _context.SaveChangesAsync();
            return propertyTrace;
        }

        public async Task<List<PropertyTrace>> GetTracesAsync(int propertyId)
        {
            return await _context.PropertyTraces
                                 .Where(pt => pt.IdProperty == propertyId)
                                 .ToListAsync();
        }

        public async Task<PropertyTrace> GetPropertyTraceByIdAsync(int traceId)
        {
            return await _context.PropertyTraces.FirstOrDefaultAsync(pt => pt.IdPropertyTrace == traceId);
        }
    }
}
