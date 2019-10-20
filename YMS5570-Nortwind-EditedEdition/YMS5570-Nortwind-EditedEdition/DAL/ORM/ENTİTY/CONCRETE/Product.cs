using RebornNorthwind.DAL.ORM.CONTEXT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RebornNorthwind.DAL.ORM.ENTİTY.CONCRETE
{
    public class Product : BaseClass
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int QuantityPerUnit { get; set; }
        public int UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitsOnOrder { get; set; }
        public int ReorderLevel { get; set; }
        public bool Discontiniued { get; set; }
     
        public string CategoryName { get; set; }
        public string CategoryDesc { get; set; }
        
        public Supplier supplier { get; set; }

    }

}
