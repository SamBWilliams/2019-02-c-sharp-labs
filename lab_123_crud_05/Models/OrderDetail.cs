using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab_123_crud_05.Models
{
    public class OrderDetail
    {
        [Key]
        [Column(Order = 1)]
        public int ProductID { get; set; }
        [Key]
        [Column(Order = 2)]
        public int OrderID { get; set; }

        public int Quantity { get; set; }

        public OrderDetail() { }

        public OrderDetail(int productID)
        {
            this.ProductID = productID;
        }

    }
}
