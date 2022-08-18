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
            //#region product
            //Product p1 = new Product() { Brand = "Vella", ColorCode = "123", ExpDate = DateTime.Now, TubeQuantity = 50.0, UsedQuantity = 5 };
            //Product p2 = new Product() { Brand = "Loreal", ColorCode = "14", ExpDate = DateTime.Now, TubeQuantity = 55.0, UsedQuantity = 4 };
            //Product p3 = new Product() { Brand = "GtMouAksizei", ColorCode = "13", ExpDate = DateTime.Now, TubeQuantity = 54.0, UsedQuantity = 3 };
            //Product p4 = new Product() { Brand = "Vella2", ColorCode = "15", ExpDate = DateTime.Now, TubeQuantity = 52.0, UsedQuantity = 2 };
            //Product p5 = new Product() { Brand = "Vella3", ColorCode = "12", ExpDate = DateTime.Now, TubeQuantity = 51.0, UsedQuantity = 6 };
            //Product p6 = new Product() { Brand = "Vella4", ColorCode = "23", ExpDate = DateTime.Now, TubeQuantity = 58.0, UsedQuantity = 4 };
            //context.Products.AddOrUpdate(p1, p2, p3, p4, p5, p6);
            //context.SaveChanges();
            //#endregion

            //#region Formulas
            //ColorFormula f1 = new ColorFormula() { Cost = 10, CreationDate = DateTime.Now, Duration = "20l", ServiceType = "Vafh" };
            //ColorFormula f2 = new ColorFormula() { Cost = 20, CreationDate = DateTime.Now, Duration = "30l", ServiceType = "rizes" };
            //ColorFormula f3 = new ColorFormula() { Cost = 30, CreationDate = DateTime.Now, Duration = "40l", ServiceType = "Adabies" };
            //ColorFormula f4 = new ColorFormula() { Cost = 40, CreationDate = DateTime.Now, Duration = "50l", ServiceType = "Rizes2" };
            //ColorFormula f5 = new ColorFormula() { Cost = 50, CreationDate = DateTime.Now, Duration = "60l", ServiceType = "Ola" };
           
            ////f1.Products.Add(p1);
            ////f2.Products.Add(p2);
            ////f2.Products.Add(p3);
            ////f3.Products.Add(p3);
            ////f3.Products.Add(p4);
            ////f4.Products.Add(p4);
            ////f4.Products.Add(p5);
            ////f5.Products.Add(p5);
            ////f5.Products.Add(p4);
            ////f5.Products.Add(p3);
            //context.ColorFormulas.AddOrUpdate(f1, f2, f3, f4, f5);
            //context.SaveChanges();
            //#endregion
            //base.Seed(context);
        }
    }
}
