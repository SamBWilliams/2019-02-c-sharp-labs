using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab_123_crud_07.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
    }
}
