using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace EFBookService.Models
{
    public class EFBookServiceContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public EFBookServiceContext() : base("name=EFBookServiceContext")
        {
            //this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s); // to trace the SQL 

            this.Database.Log = message => Trace.Write(message);
        }

        public System.Data.Entity.DbSet<EFBookService.Models.Author> Authors { get; set; }

        public System.Data.Entity.DbSet<EFBookService.Models.Book> Books { get; set; }
    }
}
