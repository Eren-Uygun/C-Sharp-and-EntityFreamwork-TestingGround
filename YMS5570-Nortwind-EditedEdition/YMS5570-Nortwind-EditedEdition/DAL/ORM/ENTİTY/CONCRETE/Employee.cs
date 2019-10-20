using RebornNorthwind.DAL.ORM.CONTEXT;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RebornNorthwind.DAL.ORM.ENTİTY.CONCRETE
{
   public class Employee:BaseClass
    {
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }

        public string Title { get; set; }
        [Required]
        public string TitleOfCourtesy { get; set; }

        public DateTime? BirthDate  { get; set; }
        
        public DateTime HireDate { get; set; }

        public string Adress { get; set; }

        public string City { get; set; }

        public string Region { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        [Required]
        public string Phone { get; set; }




    }
}
