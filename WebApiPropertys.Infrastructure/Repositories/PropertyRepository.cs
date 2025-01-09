using Microsoft.EntityFrameworkCore;
using WebApiPropertys.Domain.Interfaces;
using WebApiPropertys.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiPropertys.Infrastructure.Data;

namespace WebApiPropertys.Infrastructure.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly ApplicationDbContext _context;

        public PropertyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Implementación de los métodos de la interfaz IRepository<Property>
        Property IRepository<Property>.GetById(int id)
        {
            return _context.Properties.FirstOrDefault(p => p.IdProperty == id);
        }

        IEnumerable<Property> IRepository<Property>.GetAll()
        {
            return _context.Properties.ToList();
        }

        void IRepository<Property>.Add(Property entity)
        {
            _context.Properties.Add(entity);
            _context.SaveChanges();
        }

        void IRepository<Property>.Update(Property entity)
        {
            _context.Properties.Update(entity);
            _context.SaveChanges();
        }

        void IRepository<Property>.Delete(int id)
        {
            var property = _context.Properties.FirstOrDefault(p => p.IdProperty == id);
            if (property != null)
            {
                _context.Properties.Remove(property);
                _context.SaveChanges();
            }
        }

        // Métodos específicos de IPropertyRepository
        public async Task<Property> CreateAsync(Property property)
        {
            await _context.Properties.AddAsync(property);
            await _context.SaveChangesAsync();
            return property;
        }

        public async Task<Property> UpdateAsync(Property property)
        {
            _context.Properties.Update(property);
            await _context.SaveChangesAsync();
            return property;
        }

        public async Task<Property> ChangePriceAsync(int propertyId, decimal newPrice)
        {
            var property = await _context.Properties
                                          .FirstOrDefaultAsync(p => p.IdProperty == propertyId);

            if (property != null)
            {
                property.Price = newPrice;
                _context.Properties.Update(property);
                await _context.SaveChangesAsync();
            }

            return property;
        }

        public async Task<Property> GetByIdAsync(int id)
        {
            return await _context.Properties
                                 .FirstOrDefaultAsync(p => p.IdProperty == id);
        }

        public async Task<List<Property>> GetPropertiesWithFiltersAsync(string location, decimal? minPrice, decimal? maxPrice)
        {
            var query = _context.Properties.AsQueryable();

            if (!string.IsNullOrEmpty(location))
            {
                query = query.Where(p => p.Address.Contains(location));
            }

            if (minPrice.HasValue)
            {
                query = query.Where(p => p.Price >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                query = query.Where(p => p.Price <= maxPrice.Value);
            }

            return await query.ToListAsync();
        }
    }
}
