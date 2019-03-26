using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab_123_crud_05.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public double Total { get; set; }

        public int ProductID { get; set; }
        public Order() { }

        public Order(DateTime ordDate, double ordTotal, int pID)
        {
            this.OrderDate = ordDate;
            this.Total = ordTotal;
            this.ProductID = pID;
        }

        public Order(double ordTotal, int pID)
        {
            //this.OrderDate = ordDate;
            this.Total = ordTotal;
            this.ProductID = pID;
        }


    }
}
