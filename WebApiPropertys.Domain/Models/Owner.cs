using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiPropertys.Domain.Models
{
    public class Owner
    {
        public int IdOwner { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public byte[] Photo { get; set; }
        public DateTime Birthday { get; set; }

        public ICollection<Property> Properties { get; set; }
    }
}
