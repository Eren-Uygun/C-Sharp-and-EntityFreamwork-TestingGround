using RebornNorthwind.DAL.ORM.CONTEXT;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RebornNorthwind.DAL.ORM.ENTİTY.CONCRETE
{
   public enum Shipvia
    {
        Land,
        Sea,
        Air
    }
    public class Order:BaseClass
    {
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }

        public Shipvia ShipVia { get; set; }

        public string Freight { get; set; }

        public string ShipName { get; set; }
        public string ShipAdress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
        public string ShipperCompanyName { get; set; }

        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public double Discount { get; set; }

        public Product Product { get; set; }

        public Customer Customer { get; set; }
        
        public Employee Employee { get; set; }










    }
}
