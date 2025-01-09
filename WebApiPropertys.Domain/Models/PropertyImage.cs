using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiPropertys.Domain.Models
{
    public class PropertyImage
    {
        public int IdPropertyImage { get; set; }
        public int? IdProperty { get; set; }
        public byte[] FileProperty { get; set; }
        public bool? Enable { get; set; }

        public Property Property { get; set; }
    }
}
