using Microsoft.EntityFrameworkCore;
using WebApiPropertys.Domain.Interfaces;
using WebApiPropertys.Domain.Models;
using System.Threading.Tasks;
using WebApiPropertys.Infrastructure.Data;

namespace WebApiPropertys.Infrastructure.Repositories
{
    public class PropertyImageRepository : IPropertyImageRepository
    {
        private readonly ApplicationDbContext _context;

        public PropertyImageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PropertyImage> AddImageAsync(PropertyImage propertyImage)
        {
            await _context.PropertyImages.AddAsync(propertyImage);
            await _context.SaveChangesAsync();
            return propertyImage;
        }

        public async Task<PropertyImage> UpdateImageStatusAsync(int imageId, bool isActive)
        {
            var propertyImage = await _context.PropertyImages.FirstOrDefaultAsync(pi => pi.IdPropertyImage == imageId);
            if (propertyImage != null)
            {
                propertyImage.Enable = isActive;
                await _context.SaveChangesAsync();
            }
            return propertyImage;
        }

        public async Task<PropertyImage> GetPropertyImageByIdAsync(int imageId)
        {
            return await _context.PropertyImages.FirstOrDefaultAsync(pi => pi.IdPropertyImage == imageId);
        }
    }
}
