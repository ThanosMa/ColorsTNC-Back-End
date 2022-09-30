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
    [EnableCors("*", "*", "GET,POST,PUT,DELETE")]
    public class ShopProductController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private UnitOfWork unit;

        public ShopProductController()
        {
            unit = new UnitOfWork(db);
        }

        // GET: api/ShopProduct
        [AllowAnonymous]
        public IEnumerable<ShopProduct> GetShopProducts()
        {
            return unit.ShopProducts.GetAll();
        }

        // GET: api/ShopProduct/5
        [ResponseType(typeof(ShopProduct))]
        [AllowAnonymous]
        public IHttpActionResult GetShopProduct(int id)
        {
            ShopProduct shopProduct = unit.ShopProducts.GetById(id);
            if (shopProduct == null)
            {
                return NotFound();
            }

            return Ok(shopProduct);
        }

        // PUT: api/ShopProduct/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutShopProduct(int id, ShopProduct shopProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != shopProduct.Id)
            {
                return BadRequest();
            }

            unit.ShopProducts.Update(shopProduct);

            try
            {
                unit.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShopProductExists(id))
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

        public IHttpActionResult PutShopProduct(List<ShopProduct> shopProducts)
        {
            var tempProduct = new ShopProduct();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (shopProducts.Count == 0)
            {
                return BadRequest();
            }

            foreach (var product in shopProducts)
            {
                if (product == null)
                {
                    return NotFound();
                }
                tempProduct = unit.ShopProducts.GetById(product.Id);
                tempProduct.Quantity = product.Quantity;
                unit.ShopProducts.Update(tempProduct);
                unit.Complete();
            }

            return Ok(shopProducts);

        }


        // POST: api/ShopProduct
        [ResponseType(typeof(ShopProduct))]
        public IHttpActionResult PostShopProduct(ShopProduct shopProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            unit.ShopProducts.Insert(shopProduct);
            unit.Complete();

            return CreatedAtRoute("DefaultApi", new { id = shopProduct.Id }, shopProduct);
        }

        // DELETE: api/ShopProduct/5
        [ResponseType(typeof(ShopProduct))]
        public IHttpActionResult DeleteShopProduct(int id)
        {
            ShopProduct shopProduct = unit.ShopProducts.GetById(id);
            if (shopProduct == null)
            {
                return NotFound();
            }

            unit.ShopProducts.Delete(shopProduct);
            unit.Complete();

            return Ok(shopProduct);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unit.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ShopProductExists(int id)
        {
            return unit.ShopProducts.GetAll().Count(e => e.Id == id) > 0;
        }
    }
}