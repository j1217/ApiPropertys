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
    public class PropertyTraceRepositoryTests
    {
        private readonly ApplicationDbContext _context;

        public PropertyTraceRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("TestDatabase_PropertyTrace")
                .Options;

            _context = new ApplicationDbContext(options);
        }

        [Fact]
        public async Task AddTraceAsync_ShouldAddTrace()
        {
            var repository = new PropertyTraceRepository(_context);
            var trace = new PropertyTrace { IdPropertyTrace = 1, IdProperty = 1 };

            var result = await repository.AddTraceAsync(trace);

            Assert.NotNull(result);
            Assert.Single(_context.PropertyTraces);
        }
    }
}
