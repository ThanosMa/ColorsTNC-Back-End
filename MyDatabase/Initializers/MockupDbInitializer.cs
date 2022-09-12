using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Entities.Models;
using System.Data.Entity.Migrations;

namespace MyDatabase.Initializers
{
    public class MockupDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            ColorFormula f1 = new ColorFormula() { FormulaName = "Ths Fwtias", Cost = 10, CreationDate = DateTime.Now, Duration = "20", ServiceType = "Vafh" };
            ColorFormula f2 = new ColorFormula() { FormulaName = "Tou Pagou", Cost = 20, CreationDate = DateTime.Now, Duration = "30", ServiceType = "rizes" };
            ColorFormula f3 = new ColorFormula() { FormulaName = "Tou Neilou", Cost = 30, CreationDate = DateTime.Now, Duration = "40", ServiceType = "Adabies" };
            ColorFormula f4 = new ColorFormula() { FormulaName = "Tou Ouranou", Cost = 40, CreationDate = DateTime.Now, Duration = "50", ServiceType = "Rizes2" };
            ColorFormula f5 = new ColorFormula() { FormulaName = "Ths Thalassas", Cost = 50, CreationDate = DateTime.Now, Duration = "60", ServiceType = "Ola" };

            #region product
            Product p1 = new Product() { Brand = "Vella", ColorCode = "123", ExpDate = DateTime.Now, TubeQuantity = 50.0, UsedQuantity = 5, };
            Product p2 = new Product() { Brand = "Loreal", ColorCode = "14", ExpDate = DateTime.Now, TubeQuantity = 55.0, UsedQuantity = 4 };
            Product p3 = new Product() { Brand = "GtMouAksizei", ColorCode = "13", ExpDate = DateTime.Now, TubeQuantity = 54.0, UsedQuantity = 3 };
            Product p4 = new Product() { Brand = "Vella2", ColorCode = "15", ExpDate = DateTime.Now, TubeQuantity = 52.0, UsedQuantity = 2 };
            Product p5 = new Product() { Brand = "Vella3", ColorCode = "12", ExpDate = DateTime.Now, TubeQuantity = 51.0, UsedQuantity = 6 };
            Product p6 = new Product() { Brand = "Vella4", ColorCode = "23", ExpDate = DateTime.Now, TubeQuantity = 58.0, UsedQuantity = 4 };
            Product p7 = new Product() { Brand = "Kevin", ColorCode = "24", ExpDate = DateTime.Now, TubeQuantity = 58.0, UsedQuantity = 4 };
            p1.Formulas = new List<ColorFormula>() { f1, f2 };
            p2.Formulas = new List<ColorFormula>() { f3, f4 };
            p3.Formulas = new List<ColorFormula>() { f4, f5 };
            p4.Formulas = new List<ColorFormula>() { f4, f5 };
            p5.Formulas = new List<ColorFormula>() { f1, f2 };
            p6.Formulas = new List<ColorFormula>() { f2, f3 };

            context.Products.AddOrUpdate(p1, p2, p3, p4, p5, p6, p7);
            context.SaveChanges();
            #endregion

            #region Formulas

            f1.Products = new List<Product>() { p1, p2 };
            f2.Products = new List<Product>() { p2, p3 };
            f3.Products = new List<Product>() { p3, p4 };          
            f4.Products = new List<Product>() { p4, p5, p7 };
            f5.Products = new List<Product>() { p4, p5, p6 };
           
            context.ColorFormulas.AddOrUpdate(f1, f2, f3, f4, f5);
            context.SaveChanges();
            #endregion

            #region Customers
            Customer c1 = new Customer() { FullName = "Oikonomou Nikola", Email = "nikolaos@gmail.com", PhoneNumber = "12345" };
            Customer c2 = new Customer() { FullName = "Oikonomou Kwsta", Email = "kwsta@gmail.com", PhoneNumber = "56789" };
            Customer c3 = new Customer() { FullName = "Mastoras Tanase", Email = "thanos@gmail.com", PhoneNumber = "001203" };
            c1.FormulaIds = new List<int?>();
            c2.FormulaIds = new List<int?>();
            c3.FormulaIds = new List<int?>();
            context.Customers.AddOrUpdate(c1, c2, c3);
            context.SaveChanges();
            #endregion
            base.Seed(context);
        }
    }
}
