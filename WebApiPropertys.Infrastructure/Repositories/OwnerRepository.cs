using Microsoft.EntityFrameworkCore;
using WebApiPropertys.Domain.Interfaces;
using WebApiPropertys.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiPropertys.Infrastructure.Data;

namespace WebApiPropertys.Infrastructure.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly ApplicationDbContext _context;

        public OwnerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Implementación de los métodos de la interfaz IRepository<Owner>
        Owner IRepository<Owner>.GetById(int id)
        {
            return _context.Owners.FirstOrDefault(o => o.IdOwner == id);
        }

        IEnumerable<Owner> IRepository<Owner>.GetAll()
        {
            return _context.Owners.ToList();
        }

        void IRepository<Owner>.Add(Owner entity)
        {
            _context.Owners.Add(entity);
            _context.SaveChanges();
        }

        void IRepository<Owner>.Update(Owner entity)
        {
            _context.Owners.Update(entity);
            _context.SaveChanges();
        }

        void IRepository<Owner>.Delete(int id)
        {
            var owner = _context.Owners.FirstOrDefault(o => o.IdOwner == id);
            if (owner != null)
            {
                _context.Owners.Remove(owner);
                _context.SaveChanges();
            }
        }

        // Métodos específicos de IOwnerRepository
        public async Task<Owner> CreateOwnerAsync(Owner owner)
        {
            await _context.Owners.AddAsync(owner);
            await _context.SaveChangesAsync();
            return owner;
        }

        public async Task<Owner> UpdateOwnerAsync(Owner owner)
        {
            _context.Owners.Update(owner);
            await _context.SaveChangesAsync();
            return owner;
        }

        public async Task<Owner> GetOwnerByNameAsync(string name)
        {
            return await _context.Owners
                                 .FirstOrDefaultAsync(o => o.Name == name);
        }

        public async Task<Owner> GetOwnerWithPropertiesAsync(int ownerId)
        {
            return await _context.Owners
                                 .Include(o => o.Properties)
                                 .FirstOrDefaultAsync(o => o.IdOwner == ownerId);
        }

        public async Task<IEnumerable<Owner>> GetAllOwnersWithPropertiesAsync()
        {
            return await _context.Owners
                                 .Include(o => o.Properties)
                                 .ToListAsync();
        }
    }
}
