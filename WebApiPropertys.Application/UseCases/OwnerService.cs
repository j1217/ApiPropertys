using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPropertys.Domain.Interfaces;
using WebApiPropertys.Domain.Models;

namespace WebApiPropertys.Application.UseCases
{
    public class OwnerService
    {
        private readonly IOwnerRepository _ownerRepository;

        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        // Crear propietario
        public async Task<Owner> CreateOwnerAsync(Owner owner)
        {
            return await _ownerRepository.CreateOwnerAsync(owner);
        }

        // Actualizar propietario
        public async Task<Owner> UpdateOwnerAsync(Owner owner)
        {
            return await _ownerRepository.UpdateOwnerAsync(owner);
        }

        // Obtener propietario por nombre
        public async Task<Owner> GetOwnerByNameAsync(string name)
        {
            return await _ownerRepository.GetOwnerByNameAsync(name);
        }

        // Obtener propietario con propiedades
        public async Task<Owner> GetOwnerWithPropertiesAsync(int ownerId)
        {
            return await _ownerRepository.GetOwnerWithPropertiesAsync(ownerId);
        }

        // Obtener todos los propietarios con sus propiedades
        public async Task<IEnumerable<Owner>> GetAllOwnersWithPropertiesAsync()
        {
            return await _ownerRepository.GetAllOwnersWithPropertiesAsync();
        }
    }
}
