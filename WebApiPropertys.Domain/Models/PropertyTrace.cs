﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiPropertys.Domain.Models
{
    public class PropertyTrace
    {
        public int IdPropertyTrace { get; set; }
        public DateTime? DataSale { get; set; }
        public string Name { get; set; }
        public decimal? Value { get; set; }
        public decimal? Tax { get; set; }

        public int? IdProperty { get; set; }
        public Property Property { get; set; }
    }
}
