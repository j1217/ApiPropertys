using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPropertys.Domain.Models;

namespace WebApiPropertys.Domain.Interfaces
{
    public interface IOwnerRepository : IRepository<Owner>
    {
        // Método para crear un propietario
        Task<Owner> CreateOwnerAsync(Owner owner);

        // Método para actualizar un propietario
        Task<Owner> UpdateOwnerAsync(Owner owner);

        // Obtener un propietario por su nombre
        Task<Owner> GetOwnerByNameAsync(string name);

        // Obtener un propietario con sus propiedades asociadas
        Task<Owner> GetOwnerWithPropertiesAsync(int ownerId);

        // Obtener todos los propietarios con sus propiedades
        Task<IEnumerable<Owner>> GetAllOwnersWithPropertiesAsync();
    }
}
