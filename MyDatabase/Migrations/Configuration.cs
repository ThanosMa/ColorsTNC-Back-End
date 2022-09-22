namespace MyDatabase.Migrations
{
    using Entities.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyDatabase.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MyDatabase.ApplicationDbContext context)
        {
            //WarehouseProduct whPr1 = new WarehouseProduct() { Brand = "Vella", ColorCode = "1.0", TotalQuantity = 250 };
            //WarehouseProduct whPr2 = new WarehouseProduct() { Brand = "Vella", ColorCode = "2.0", TotalQuantity = 250 };
            //WarehouseProduct whPr3 = new WarehouseProduct() { Brand = "Vella", ColorCode = "3.0", TotalQuantity = 250 };
            //WarehouseProduct whPr4 = new WarehouseProduct() { Brand = "Vella", ColorCode = "4.0", TotalQuantity = 250 };
            //WarehouseProduct whPr5 = new WarehouseProduct() { Brand = "Vella", ColorCode = "5.0", TotalQuantity = 250 };
            //WarehouseProduct whPr6 = new WarehouseProduct() { Brand = "Vella", ColorCode = "6.0", TotalQuantity = 250 };
            //WarehouseProduct whPr7 = new WarehouseProduct() { Brand = "Kevin Murphy", ColorCode = "1.0", TotalQuantity = 350 };
            //WarehouseProduct whPr8 = new WarehouseProduct() { Brand = "Kevin Murphy", ColorCode = "2.0", TotalQuantity = 100 };
            //WarehouseProduct whPr9 = new WarehouseProduct() { Brand = "Kevin Murphy", ColorCode = "3.0", TotalQuantity = 450 };
            //WarehouseProduct whPr10 = new WarehouseProduct() { Brand = "Kevin Murphy", ColorCode = "4.0", TotalQuantity = 900 };
            //WarehouseProduct whPr11 = new WarehouseProduct() { Brand = "Kevin Murphy", ColorCode = "5.0", TotalQuantity = 1250 };
            //WarehouseProduct whPr12 = new WarehouseProduct() { Brand = "Kevin Murphy", ColorCode = "6.0", TotalQuantity = 50 };
            //WarehouseProduct whPr13 = new WarehouseProduct() { Brand = "Apivita", ColorCode = "1.0", TotalQuantity = 50 };
            //WarehouseProduct whPr14 = new WarehouseProduct() { Brand = "Apivita", ColorCode = "2.0", TotalQuantity = 350 };
            //WarehouseProduct whPr15 = new WarehouseProduct() { Brand = "Apivita", ColorCode = "3.0", TotalQuantity = 500 };
            //WarehouseProduct whPr16 = new WarehouseProduct() { Brand = "Apivita", ColorCode = "4.0", TotalQuantity = 100 };
            //WarehouseProduct whPr17 = new WarehouseProduct() { Brand = "Apivita", ColorCode = "5.0", TotalQuantity = 2000 };
            //WarehouseProduct whPr18 = new WarehouseProduct() { Brand = "Apivita", ColorCode = "6.0", TotalQuantity = 1400 };
            //context.WarehouseProducts.AddOrUpdate(whPr1, whPr2, whPr3, whPr4, whPr5, whPr6, whPr7, whPr8, whPr9, whPr10, whPr12, whPr13, whPr14, whPr15, whPr16, whPr17, whPr18);
            //context.SaveChanges();


            //Order sc1 = new Order() { FirstName = "Nikos", LastName = "Oikonomou", Email = "nikosoikonomou88@gmail.com", Address = "Plastira 55", TotalCost = 150 };
            //Order sc2 = new Order() { FirstName = "Kwstas", LastName = "Oikonomou", Email = "kwstasoikonomou88@gmail.com", Address = "Plastira 45", TotalCost = 140 };
            //Order sc3 = new Order() { FirstName = "Thanasis", LastName = "Mastrogiannis", Email = "mastrogiannisath@gmail.com", Address = "Plastira 55", TotalCost = 130 };
            //context.Orders.AddOrUpdate(sc1, sc2, sc3);
            //context.SaveChanges();
            //base.Seed(context);

        }
    }
}
