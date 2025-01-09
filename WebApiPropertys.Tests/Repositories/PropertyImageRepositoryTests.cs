using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiPropertys.Domain.Models;
using WebApiPropertys.Infrastructure.Data;
using WebApiPropertys.Infrastructure.Repositories;
using Xunit;

namespace WebApiPropertys.Tests.Repositories
{
    public class PropertyImageRepositoryTests
    {
        private readonly ApplicationDbContext _context;

        public PropertyImageRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("TestDatabase_PropertyImage")
                .Options;

            _context = new ApplicationDbContext(options);
        }

        [Fact]
        public async Task AddImageAsync_ShouldAddImage()
        {
            var repository = new PropertyImageRepository(_context);
            var image = new PropertyImage { IdPropertyImage = 1, IdProperty = 1, Enable = true };

            var result = await repository.AddImageAsync(image);

            Assert.NotNull(result);
            Assert.Single(_context.PropertyImages);
        }
    }
}
