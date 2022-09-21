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
    public class OrderController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private UnitOfWork unit;


        public OrderController()
        {
            unit = new UnitOfWork(db);

        }

        // GET: api/Order
        public IEnumerable<Order> GetOrders()
        {
            return unit.Orders.GetAll();
        }

        // GET: api/Order/5
        [ResponseType(typeof(Order))]
        public IHttpActionResult GetOrder(int id)
        {
            Order order = unit.Orders.GetById(id);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        // PUT: api/Order/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrder(int id, Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != order.Id)
            {
                return BadRequest();
            }

            unit.Orders.Update(order);

            try
            {
                unit.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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

        // POST: api/Order
        [ResponseType(typeof(Order))]
        public IHttpActionResult PostOrder(Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            unit.Orders.Insert(order);
            unit.Complete();

            return CreatedAtRoute("DefaultApi", new { id = order.Id }, order);
        }

        // DELETE: api/Order/5
        [ResponseType(typeof(Order))]
        public IHttpActionResult DeleteOrder(int id)
        {
            Order order = unit.Orders.GetById(id);
            if (order == null)
            {
                return NotFound();
            }

            unit.Orders.Delete(order);
            unit.Complete();

            return Ok(order);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unit.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderExists(int id)
        {
            return unit.Orders.GetAll().Count(e => e.Id == id) > 0;
        }
    }
}