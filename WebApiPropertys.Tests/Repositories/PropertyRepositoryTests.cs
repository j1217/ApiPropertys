using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiPropertys.Domain.Models;
using WebApiPropertys.Infrastructure.Data;
using WebApiPropertys.Infrastructure.Repositories;
using Xunit;

namespace WebApiPropertys.Tests.Repositories
{
    public class PropertyRepositoryTests
    {
        private readonly ApplicationDbContext _context;

        public PropertyRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("TestDatabase_Property")
                .Options;

            _context = new ApplicationDbContext(options);
            SeedData();
        }

        private void SeedData()
        {
            _context.Properties.AddRange(new List<Property>
            {
                new Property { IdProperty = 1, Name = "Property A", Address = "Location A", Price = 100000 },
                new Property { IdProperty = 2, Name = "Property B", Address = "Location B", Price = 200000 }
            });
            _context.SaveChanges();
        }

        [Fact]
        public async Task CreateAsync_ShouldAddProperty()
        {
            var repository = new PropertyRepository(_context);
            var newProperty = new Property { IdProperty = 3, Name = "Property C", Address = "Location C", Price = 300000 };

            var result = await repository.CreateAsync(newProperty);

            Assert.NotNull(result);
            Assert.Equal(3, _context.Properties.Count());
        }

        [Fact]
        public async Task ChangePriceAsync_ShouldUpdatePrice()
        {
            var repository = new PropertyRepository(_context);
            var result = await repository.ChangePriceAsync(1, 150000);

            Assert.NotNull(result);
            Assert.Equal(150000, result.Price);
        }
    }
}
