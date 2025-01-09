using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPropertys.Domain.Models;

namespace WebApiPropertys.Domain.Interfaces
{
    public interface IPropertyImageRepository
    {
        Task<PropertyImage> AddImageAsync(PropertyImage propertyImage); // Agregar imagen
        Task<PropertyImage> UpdateImageStatusAsync(int imageId, bool isActive); // Actualizar estado de imagen
        Task<PropertyImage> GetPropertyImageByIdAsync(int imageId); // Obtener imagen por Id
    }
}
