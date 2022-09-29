using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Entities.Models;
using MyDatabase;
using RepositoryServices.Persistance;
using TestWebApp.Dtos;

namespace TestWebApp.Controllers
{
    [AllowAnonymous]
    [EnableCors("*", "*", "GET,POST,PUT,DELETE")]
    public class ColorFormulaController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private UnitOfWork unit;


        public ColorFormulaController()
        {
            unit = new UnitOfWork(db);

        }

        // GET: api/ColorFormula
        public IEnumerable<object> GetColorFormulas()
        {    
            var colorFormulas = unit.ColorFormulas.GetAll().Select(x => new 
            {
                ColorFormulaID = x.ColorFormulaID,
                FormulaName = x.FormulaName,
                CreationDate = x.CreationDate,
                Cost = x.Cost,
                Duration = x.Duration,
                ServiceType = x.ServiceType,
                FormulasPhotosid = x.FormulasPhotosid,
                FormulasPhotosUrl=x.FormulasPhotosUrl,
                Products = x.Products?.Select(y=> new 
                { 
                    ID = y?.ID, 
                    Brand = y?.Brand,  
                    ColorCode = y?.ColorCode,
                    UsedQuantity = y?.UsedQuantity,
                    ExpDate = y?.ExpDate,
                    TubeQuantity = y?.TubeQuantity,
                })
            });
            return colorFormulas;
        }

        // GET: api/ColorFormula/5
        [ResponseType(typeof(ColorFormula))]
        public IHttpActionResult GetColorFormula(int id)
        {
            ColorFormula colorFormula = unit.ColorFormulas.GetById(id);
            IEnumerable<int> productIds = null;
            if (colorFormula == null)
            {
                return NotFound();
            }
            if (colorFormula.Products != null)
            {
                productIds = new List<int>(colorFormula.Products.Select(x => x.ID));
            }

            ColorFormula tempFormula = new ColorFormula();

            tempFormula.ColorFormulaID = colorFormula.ColorFormulaID;
            tempFormula.FormulaName = colorFormula.FormulaName;
            tempFormula.CreationDate = colorFormula.CreationDate;
            tempFormula.Cost = colorFormula.Cost;
            tempFormula.Duration = colorFormula.Duration;
            tempFormula.ServiceType = colorFormula.ServiceType;
            tempFormula.FormulasPhotosid = colorFormula.FormulasPhotosid;
            tempFormula.FormulasPhotosUrl = colorFormula.FormulasPhotosUrl;

            tempFormula.Products = new List<Product>();
            if (productIds != null)
            {
                foreach (var proId in productIds)
                {
                    var product = unit.Products.GetById(proId);
                    if (product != null)
                    {
                        tempFormula.Products.Add(product);
                    }
                }
            }
            return Ok(tempFormula);
        }

        // PUT: api/ColorFormula/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutColorFormula(int id, ColorFormula colorFormula)
        {
             IEnumerable<int> productIds = null;
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != colorFormula.ColorFormulaID)
            {
                return BadRequest();
            }
            ColorFormula tempFormula = unit.ColorFormulas.GetById(id);
            tempFormula.FormulaName = colorFormula.FormulaName;
            tempFormula.Duration = colorFormula.Duration;
            tempFormula.ServiceType = colorFormula.ServiceType;
            tempFormula.Cost = colorFormula.Cost;
            tempFormula.CreationDate = colorFormula.CreationDate;
            tempFormula.FormulasPhotosid = colorFormula.FormulasPhotosid;
            tempFormula.FormulasPhotosUrl = colorFormula.FormulasPhotosUrl;
            tempFormula.Products.Clear();
            if(colorFormula.Products != null)
            {
               productIds = new List<int>(colorFormula.Products.Select(x => x.ID));
            }
           
            
            if(productIds != null)
            {
                foreach (var proId in productIds)
                {
                    var product = unit.Products.GetById(proId);
                    if(product != null)
                    {
                        tempFormula.Products.Add(product);
                    }
                }
            }

            unit.ColorFormulas.Update(tempFormula);
            try
            {
                unit.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColorFormulaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ColorFormula

        [ResponseType(typeof(ColorFormula))]
        public IHttpActionResult PostColorFormula(ColorFormula colorFormula)
        {
            //IEnumerable<int> productIds = null;
            IEnumerable<Product> tempProducts = null;
            DateTime date = DateTime.Now;
            colorFormula.CreationDate = date;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ColorFormula tempFormula = new ColorFormula();
            tempFormula.FormulaName = colorFormula.FormulaName;
            tempFormula.Duration = colorFormula.Duration;
            tempFormula.ServiceType = colorFormula.ServiceType;
            tempFormula.Cost = colorFormula.Cost;
            tempFormula.CreationDate = colorFormula.CreationDate;
            tempFormula.FormulasPhotosid = colorFormula.FormulasPhotosid;
            tempFormula.FormulasPhotosUrl = colorFormula.FormulasPhotosUrl;
            tempFormula.Products = new List<Product>();
            
            if (colorFormula.Products != null)
            {
                var query = from pro in colorFormula.Products
                            select new Product() { Brand = pro.Brand, ColorCode = pro.ColorCode, UsedQuantity = pro.UsedQuantity };

                tempProducts = new List<Product>(query);
                foreach (var product in tempProducts)
                {
                    tempFormula.Products.Add(product);
                }
            }
            
            
            unit.ColorFormulas.Insert(tempFormula);
            unit.Complete();

            return CreatedAtRoute("DefaultApi", new { id = colorFormula.ColorFormulaID }, colorFormula);
        }


        // DELETE: api/ColorFormula/5
        [ResponseType(typeof(ColorFormula))]
        public IHttpActionResult DeleteColorFormula(int id)
        {
            ColorFormula colorFormula = unit.ColorFormulas.GetById(id);
            colorFormula.Products.Clear();
          
            if (colorFormula == null)
            {
                return NotFound();
            }

            unit.ColorFormulas.Delete(colorFormula.ColorFormulaID);
            unit.Complete();

            return Ok(colorFormula);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unit.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ColorFormulaExists(int id)
        {
            return unit.ColorFormulas.GetAll().Count(e => e.ColorFormulaID == id) > 0;
        }
    }
}