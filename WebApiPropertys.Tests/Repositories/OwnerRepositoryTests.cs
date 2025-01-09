using System;
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
    public class OwnerRepositoryTests
    {
        private readonly ApplicationDbContext _context;

        public OwnerRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("TestDatabase_Owner")
                .Options;

            _context = new ApplicationDbContext(options);
            SeedData();
        }

        private void SeedData()
        {
            _context.Owners.AddRange(new List<Owner>
            {
                new Owner { IdOwner = 1, Name = "John Doe", Address = "123 Main St", Birthday = new DateTime(1980, 1, 1) },
                new Owner { IdOwner = 2, Name = "Jane Doe", Address = "456 Elm St", Birthday = new DateTime(1990, 2, 2) }
            });
            _context.SaveChanges();
        }

        [Fact]
        public void GetById_ShouldReturnOwner()
        {
            var repository = new OwnerRepository(_context);
            var result = ((IRepository<Owner>)repository).GetById(1);

            Assert.NotNull(result);
            Assert.Equal("John Doe", result.Name);
        }

        [Fact]
        public void GetAll_ShouldReturnAllOwners()
        {
            var repository = new OwnerRepository(_context);
            var result = ((IRepository<Owner>)repository).GetAll();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void Add_ShouldAddOwner()
        {
            var repository = new OwnerRepository(_context);
            ((IRepository<Owner>)repository).Add(new Owner { IdOwner = 3, Name = "New Owner", Address = "789 Pine St", Birthday = DateTime.Now });

            Assert.Equal(3, _context.Owners.Count());
        }

        [Fact]
        public void Delete_ShouldRemoveOwner()
        {
            var repository = new OwnerRepository(_context);
            ((IRepository<Owner>)repository).Delete(1);

            Assert.Single(_context.Owners);
        }
    }
}
