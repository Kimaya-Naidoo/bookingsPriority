using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace invoice.Models
{
    public class invoiceContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public invoiceContext() : base("name=dbcontext19")
        {
        }

        public System.Data.Entity.DbSet<invoice.Models.Booking> Bookings { get; set; }
        public System.Data.Entity.DbSet<invoice.Models.prices> Prices { get; set; }
        public System.Data.Entity.DbSet<invoice.Models.Invoice> Invoies { get; set; }
        public System.Data.Entity.DbSet<invoice.Models.accountant> accountants { get; set; }
        public System.Data.Entity.DbSet<invoice.Models.Truck> trucks { get; set; }
        public System.Data.Entity.DbSet<invoice.Models.maintain> Maintains { get; set; }
        public System.Data.Entity.DbSet<invoice.Models.Vat> vats { get; set; }



        //public DbSet<accountant> accountants { get; set; }
        //public DbSet<Truck> trucks { get; set; }

        //public DbSet<maintain> Maintains { get; set; }
    }
}
