using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Domain
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? NameOfProduct { get; set; }
        public double Cost { get; set; }
    }
}
