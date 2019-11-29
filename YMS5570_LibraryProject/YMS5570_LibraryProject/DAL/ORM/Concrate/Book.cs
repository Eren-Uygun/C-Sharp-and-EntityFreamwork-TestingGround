using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMS5570_LibraryProject.DAL.ORM.Abstarct;
using Microsoft.SqlServer;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YMS5570_LibraryProject.DAL.ORM.Concrate
{
    public class Book:BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        [ForeignKey("AppUser")]
        public int AppUserID { get; set; }
        public virtual AppUser AppUser { get; set; }


       



    }
}
