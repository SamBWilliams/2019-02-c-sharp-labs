﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab_123_crud_website.Model
{
    public class Product
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public Product()
        //{
        //    this.Order_Details = new HashSet<Order_Detail>();
        //}

        public int ProductID { get; set; }
        public string ProductName { get; set; }
        //public Nullable<int> SupplierID { get; set; }
        //public Nullable<int> CategoryID { get; set; }
        public string QuantityPerUnit { get; set; }
       // public Nullable<decimal> UnitPrice { get; set; }
        //public Nullable<short> UnitsInStock { get; set; }
        //public Nullable<short> UnitsOnOrder { get; set; }
        //public Nullable<short> ReorderLevel { get; set; }
        //public bool Discontinued { get; set; }

        //public virtual Category Category { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Order_Detail> Order_Details { get; set; }
        //public virtual Supplier Supplier { get; set; }
    }
}
