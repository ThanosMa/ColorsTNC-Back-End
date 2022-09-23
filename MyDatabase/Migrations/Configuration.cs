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
            //WarehouseProduct whPr1 = new WarehouseProduct() { Brand = "Vella", ColorCode = "1.0", TubeQuantity = 50, TotalQuantity = 250 };
            //WarehouseProduct whPr2 = new WarehouseProduct() { Brand = "Vella", ColorCode = "2.0", TubeQuantity = 50, TotalQuantity = 250 };
            //WarehouseProduct whPr3 = new WarehouseProduct() { Brand = "Vella", ColorCode = "3.0", TubeQuantity = 50, TotalQuantity = 250 };
            //WarehouseProduct whPr4 = new WarehouseProduct() { Brand = "Vella", ColorCode = "4.0", TubeQuantity = 50, TotalQuantity = 250 };
            //WarehouseProduct whPr5 = new WarehouseProduct() { Brand = "Vella", ColorCode = "5.0", TubeQuantity = 50, TotalQuantity = 250 };
            //WarehouseProduct whPr6 = new WarehouseProduct() { Brand = "Vella", ColorCode = "6.0", TubeQuantity = 50, TotalQuantity = 250 };
            //WarehouseProduct whPr7 = new WarehouseProduct() { Brand = "Kevin Murphy", ColorCode = "1.0", TubeQuantity = 50, TotalQuantity = 350 };
            //WarehouseProduct whPr8 = new WarehouseProduct() { Brand = "Kevin Murphy", ColorCode = "2.0", TubeQuantity = 50, TotalQuantity = 100 };
            //WarehouseProduct whPr9 = new WarehouseProduct() { Brand = "Kevin Murphy", ColorCode = "3.0", TubeQuantity = 50, TotalQuantity = 450 };
            //WarehouseProduct whPr10 = new WarehouseProduct() { Brand = "Kevin Murphy", ColorCode = "4.0", TubeQuantity = 50, TotalQuantity = 900 };
            //WarehouseProduct whPr11 = new WarehouseProduct() { Brand = "Kevin Murphy", ColorCode = "5.0", TubeQuantity = 50, TotalQuantity = 1250 };
            //WarehouseProduct whPr12 = new WarehouseProduct() { Brand = "Kevin Murphy", ColorCode = "6.0", TubeQuantity = 50, TotalQuantity = 50 };
            //WarehouseProduct whPr13 = new WarehouseProduct() { Brand = "Apivita", ColorCode = "1.0", TubeQuantity = 50, TotalQuantity = 50 };
            //WarehouseProduct whPr14 = new WarehouseProduct() { Brand = "Apivita", ColorCode = "2.0", TubeQuantity = 50, TotalQuantity = 350 };
            //WarehouseProduct whPr15 = new WarehouseProduct() { Brand = "Apivita", ColorCode = "3.0", TubeQuantity = 50, TotalQuantity = 500 };
            //WarehouseProduct whPr16 = new WarehouseProduct() { Brand = "Apivita", ColorCode = "4.0", TubeQuantity = 50, TotalQuantity = 100 };
            //WarehouseProduct whPr17 = new WarehouseProduct() { Brand = "Apivita", ColorCode = "5.0", TubeQuantity = 50, TotalQuantity = 2000 };
            //WarehouseProduct whPr18 = new WarehouseProduct() { Brand = "Apivita", ColorCode = "6.0", TubeQuantity = 50, TotalQuantity = 1400 };
            //context.WarehouseProducts.AddOrUpdate(whPr1, whPr2, whPr3, whPr4, whPr5, whPr6, whPr7, whPr8, whPr9, whPr10, whPr12, whPr13, whPr14, whPr15, whPr16, whPr17, whPr18);
            //context.SaveChanges();


            //Order sc1 = new Order() { FirstName = "Nikos", LastName = "Oikonomou", Email = "nikosoikonomou88@gmail.com", Address = "Plastira 55", TotalCost = 150 };
            //Order sc2 = new Order() { FirstName = "Kwstas", LastName = "Oikonomou", Email = "kwstasoikonomou88@gmail.com", Address = "Plastira 45", TotalCost = 140 };
            //Order sc3 = new Order() { FirstName = "Thanasis", LastName = "Mastrogiannis", Email = "mastrogiannisath@gmail.com", Address = "Plastira 55", TotalCost = 130 };
            //context.Orders.AddOrUpdate(sc1, sc2, sc3);
            //context.SaveChanges();
            //base.Seed(context);



            //ColorFormula f1 = new ColorFormula() { FormulaName = "Fire", Cost = 10, CreationDate = DateTime.Now, Duration = "20", ServiceType = "All Over", FormulasPhotosUrl = "\\Photos\\redHair.jpg" };
            //ColorFormula f2 = new ColorFormula() { FormulaName = "Ice", Cost = 20, CreationDate = DateTime.Now, Duration = "30", ServiceType = "Roots", FormulasPhotosUrl = "\\Photos\\whiteHair.jpg" };
            //ColorFormula f3 = new ColorFormula() { FormulaName = "Desert", Cost = 30, CreationDate = DateTime.Now, Duration = "40", ServiceType = "All Over", FormulasPhotosUrl = "\\Photos\\blondeHair.jpg" };
            //ColorFormula f4 = new ColorFormula() { FormulaName = "Sky", Cost = 40, CreationDate = DateTime.Now, Duration = "50", ServiceType = "Length", FormulasPhotosUrl = "\\Photos\\skyBlue.jpg" };
            //ColorFormula f5 = new ColorFormula() { FormulaName = "Sea", Cost = 50, CreationDate = DateTime.Now, Duration = "60", ServiceType = "Strands", FormulasPhotosUrl = "\\Photos\\seaBlue.jpg" };

            //#region product
            //Product p1 = new Product() { Brand = "Vella", ColorCode = "6.0", ExpDate = DateTime.Now, TubeQuantity = 50.0, UsedQuantity = 5, };
            //Product p2 = new Product() { Brand = "Loreal", ColorCode = "5.8", ExpDate = DateTime.Now, TubeQuantity = 55.0, UsedQuantity = 4 };
            //Product p3 = new Product() { Brand = "Herbal Essences", ColorCode = "7.5", ExpDate = DateTime.Now, TubeQuantity = 50.0, UsedQuantity = 3 };
            //Product p4 = new Product() { Brand = "Garnier", ColorCode = "2.2", ExpDate = DateTime.Now, TubeQuantity = 50.0, UsedQuantity = 2 };
            //Product p5 = new Product() { Brand = "Mamaearth", ColorCode = "5.7", ExpDate = DateTime.Now, TubeQuantity = 50.0, UsedQuantity = 6 };
            //Product p6 = new Product() { Brand = "Biotique", ColorCode = "3.9", ExpDate = DateTime.Now, TubeQuantity = 50.0, UsedQuantity = 4 };
            //Product p7 = new Product() { Brand = "Kevin", ColorCode = "9.8", ExpDate = DateTime.Now, TubeQuantity = 50.0, UsedQuantity = 4 };
            ////p1.Formulas = new List<ColorFormula>() { f1, f2 };
            ////p2.Formulas = new List<ColorFormula>() { f3, f4 };
            ////p3.Formulas = new List<ColorFormula>() { f4, f5 };
            ////p4.Formulas = new List<ColorFormula>() { f4, f5 };
            ////p5.Formulas = new List<ColorFormula>() { f1, f2 };
            ////p6.Formulas = new List<ColorFormula>() { f2, f3 };

            //context.Products.AddOrUpdate(p1, p2, p3, p4, p5, p6, p7);
            //context.SaveChanges();
            //#endregion

            //#region Formulas

            //f1.Products = new List<Product>() { p1, p2 };
            //f2.Products = new List<Product>() { p2, p3 };
            //f3.Products = new List<Product>() { p3, p4 };
            //f4.Products = new List<Product>() { p4, p5, p7 };
            //f5.Products = new List<Product>() { p4, p5, p6 };

            //context.ColorFormulas.AddOrUpdate(f1, f2, f3, f4, f5);
            //context.SaveChanges();
            //#endregion

        }
    }
}
