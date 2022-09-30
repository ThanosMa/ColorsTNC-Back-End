using Entities.Models;
using MyDatabase;
using RepositoryServices.Persistance;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace TestWebApp.Controllers.ApiControllers
{
    //[EnableCors("*", "*", "GET,POST,PUT,DELETE")]
    [Authorize(Roles = "Admin,Employee")]
    public class ImageFormulaController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        UnitOfWork unit;

        public ImageFormulaController()
        {
            unit = new UnitOfWork(db);
        }

        // GET: api/ImageFormula
        public object GetImageFormulas()
        {
            var imageFormulas = unit.ImageFormulas.GetAll();
            return imageFormulas;
        }

        // GET: api/ImageFormula/5
        [ResponseType(typeof(ImageFormula))]
        public HttpResponseMessage GetImageFormula(int id)
        {
            ImageFormula imageFormula = unit.ImageFormulas.GetById(id);
            //SqlDataReader dr = cmd.ExecuteReader();
            if (imageFormula == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            HttpResponseMessage Response = new HttpResponseMessage(HttpStatusCode.OK);
            Response.Content = new StreamContent(new MemoryStream(imageFormula.ImageContent));

            Response.Content.Headers.ContentType =
                        new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpg");
            return Response;
        }

        // PUT: api/ImageFormula/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutImageFormula(int id)
        {
            ImageFormula imageFormula = db.ImageFormulas.Find(id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != imageFormula.Id)
            {
                return BadRequest();
            }
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
            var file = HttpContext.Current.Request.Files[0].InputStream;
            byte[] Image;
            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                Image = memoryStream.ToArray();
                imageFormula.ImageContent = Image;

                unit.ImageFormulas.Update(imageFormula);
                unit.Complete();
            }

            unit.ImageFormulas.Update(imageFormula);

            try
            {
                unit.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImageFormulaExists(id))
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

        // POST: api/ImageFormula
        [ResponseType(typeof(ImageFormula))]
        public IHttpActionResult PostImageFormula()
        {
            // Check if the request contains multipart/form-data.  
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
            var file = HttpContext.Current.Request.Files[0].InputStream;
            byte[] Image;
            ImageFormula imageFormula = new ImageFormula();
            using (var memoryStream = new MemoryStream())
            {
                
                file.CopyTo(memoryStream);
                Image = memoryStream.ToArray();
                imageFormula.ImageContent = Image;

                unit.ImageFormulas.Insert(imageFormula);
                unit.Complete();
            }

            return CreatedAtRoute("DefaultApi", new { id = imageFormula.Id }, imageFormula);
        }

        // DELETE: api/ImageFormula/5
        [ResponseType(typeof(ImageFormula))]
        public IHttpActionResult DeleteImageFormula(int id)
        {
            ImageFormula imageFormula = db.ImageFormulas.Find(id);
            if (imageFormula == null)
            {
                return NotFound();
            }

            unit.ImageFormulas.Delete(imageFormula.Id);
            unit.Complete();

            return Ok(imageFormula);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unit.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ImageFormulaExists(int id)
        {
            return unit.ImageFormulas.GetAll().Count(e => e.Id == id) > 0;
        }
    }
}
