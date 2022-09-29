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
    public class WarehouseProductController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private UnitOfWork unit;

        public WarehouseProductController()
        {
            unit = new UnitOfWork(db);
        }

        // GET: api/WarehouseProduct
        public IEnumerable<WarehouseProduct> GetWarehouseProducts()
        {
            return unit.WarehouseProducts.GetAll();
        }

        // GET: api/WarehouseProduct/5
        [ResponseType(typeof(WarehouseProduct))]
        public IHttpActionResult GetWarehouseProduct(int id)
        {
            WarehouseProduct warehouseProduct = unit.WarehouseProducts.GetById(id);
            if (warehouseProduct == null)
            {
                return NotFound();
            }

            return Ok(warehouseProduct);
        }

        // PUT: api/WarehouseProduct/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWarehouseProduct(int id, WarehouseProduct warehouseProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != warehouseProduct.Id)
            {
                return BadRequest();
            }

            unit.WarehouseProducts.Update(warehouseProduct);

            try
            {
                unit.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WarehouseProductExists(id))
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

        // POST: api/WarehouseProduct
        [ResponseType(typeof(WarehouseProduct))]
        public IHttpActionResult PostWarehouseProduct(WarehouseProduct warehouseProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            unit.WarehouseProducts.Insert(warehouseProduct);
            unit.Complete();

            return CreatedAtRoute("DefaultApi", new { id = warehouseProduct.Id }, warehouseProduct);
        }

        // DELETE: api/WarehouseProduct/5
        [ResponseType(typeof(WarehouseProduct))]
        public IHttpActionResult DeleteWarehouseProduct(int id)
        {
            WarehouseProduct warehouseProduct = unit.WarehouseProducts.GetById(id);
            if (warehouseProduct == null)
            {
                return NotFound();
            }

            unit.WarehouseProducts.Delete(warehouseProduct.Id);
            unit.Complete();

            return Ok(warehouseProduct);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unit.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WarehouseProductExists(int id)
        {
            return unit.WarehouseProducts.GetAll().Count(e => e.Id == id) > 0;
        }
    }
}