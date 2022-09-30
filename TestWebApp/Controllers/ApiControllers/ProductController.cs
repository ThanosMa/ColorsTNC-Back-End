using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Entities.Models;
using MyDatabase;
using RepositoryServices.Persistance;

namespace TestWebApp.Controllers.ApiControllers
{
    //[EnableCors("*", "*", "GET,POST,PUT,DELETE")]
    public class ProductController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private UnitOfWork unit;

        public ProductController()
        {
            unit = new UnitOfWork(db);
        }

        // GET: api/Product
        public IEnumerable<object> GetProducts()
        {
            var products = unit.Products.GetAll().Select(x => new
            {
                ID = x.ID,
                Brand = x.Brand,
                ColorCode = x.ColorCode,
                UsedQuantity = x.UsedQuantity,
                ExpDate = x.ExpDate,
                TubeQuantity = x.TubeQuantity,
                //Formulas = x.Formulas.Select(y => new { FormulaName = y.FormulaName})
            });
            return products;
        }

        // GET: api/Product/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(int id)
        {
            Product product = unit.Products.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Product/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.ID)
            {
                return BadRequest();
            }
          
            unit.Products.Update(product);

            try
            {
                unit.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        // POST: api/Product
        [ResponseType(typeof(Product))]
        public IHttpActionResult PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            unit.Products.Insert(product);
            unit.Complete();

            return CreatedAtRoute("DefaultApi", new { id = product.ID }, product);
        }

        // DELETE: api/Product/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult DeleteProduct(int id)
        {
            Product product = unit.Products.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

            unit.Products.Delete(product.ID);
            unit.Complete();

            return Ok(product);
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unit.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return unit.Products.GetAll().Count(e => e.ID == id) > 0;
        }
    }
}