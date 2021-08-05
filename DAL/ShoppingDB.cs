using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    class ShoppingDB : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public ShoppingDB() : base("name=sDB")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //if add this row: table name is like class name, without "s" at end
            // modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //this is table name of this object
        }

        public DbSet<BE.Costumer> Costumers { get; set; }
        public DbSet<BE.Store> Stores { get; set; }
        public DbSet<BE.Product> Products { get; set; }
        public DbSet<BE.QRcode> QRcodes { get; set; }
        public DbSet<BE.Purchase> Purchases { get; set; }

    }
}

