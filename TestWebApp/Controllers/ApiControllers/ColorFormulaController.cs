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
                Duration = x.Duration,
                Cost = x.Cost,
                ServiceType = x.ServiceType,
                Products = x.Products?.Select(y=> new { Brand = y?.Brand})
              
            });
            return colorFormulas;
        }

        // GET: api/ColorFormula/5
        [ResponseType(typeof(ColorFormula))]
        public IHttpActionResult GetColorFormula(int id)
        {
            ColorFormula colorFormula = unit.ColorFormulas.GetById(id);
            if (colorFormula == null)
            {
                return NotFound();
            }

            return Ok(colorFormula);
        }

        // PUT: api/ColorFormula/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutColorFormula(int id, ColorFormula colorFormula)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != colorFormula.ColorFormulaID)
            {
                return BadRequest();
            }

            unit.ColorFormulas.Update(colorFormula);
            //db.Entry(colorFormula).State = EntityState.Modified;

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
            //var file = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files[0] : null;
            //if (file != null && file.ContentLength > 0)
            //{
            //    var fileName = Path.GetFileName(file.FileName);
            //    var path = Path.Combine(HttpContext.Current.Server.MapPath("~/Image"), fileName);
            //    file.SaveAs(path);
            //}
            //ColorFormula colorFormula = new ColorFormula();
            //colorFormula.ColorFormulaID = dto.Id;
            //colorFormula.FormulaName = dto.FormulaName;
            //colorFormula.CreationDate = DateTime.Now;
            //colorFormula.Duration = dto.Duration;
            //colorFormula.Cost = dto.Cost;
            //colorFormula.ServiceType = dto.ServiceType;
            //colorFormula.Products = dto?.Products;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            unit.ColorFormulas.Insert(colorFormula);
            unit.Complete();

            return CreatedAtRoute("DefaultApi", new { id = colorFormula.ColorFormulaID }, colorFormula);
        }

        // DELETE: api/ColorFormula/5
        [ResponseType(typeof(ColorFormula))]
        public IHttpActionResult DeleteColorFormula(int id)
        {
            ColorFormula colorFormula = unit.ColorFormulas.GetById(id);
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