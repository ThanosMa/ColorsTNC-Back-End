using Entities.Models;
using MyDatabase;
using RepositoryServices.Persistance;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace TestWebApp.Controllers.ApiControllers
{
    [EnableCors("*", "*", "GET,POST,PUT,DELETE")]
    public class PhotoController : ApiController
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        private UnitOfWork unit;

        public PhotoController()
        {
            unit = new UnitOfWork(db);
        }

        [Route("api/Photo/GetPhoto")]
        public IHttpActionResult GetPhoto(int id)
        {
            Photo photo = unit.Photos.GetById(id);
            if (photo == null)
            {
                return NotFound();
            }

            return Ok(photo);
        }

        [HttpPost]
        [Route("api/Photo/UploadFile")]
        public async Task<string> UploadFile()
        {
            Photo tempPhoto = new Photo();
            
            var ctx = HttpContext.Current;
            var root = ctx.Server.MapPath("~/App_Data");
            var provider =
                new MultipartFormDataStreamProvider(root);
            try
            {
                await Request.Content
                    .ReadAsMultipartAsync(provider);
                foreach (var file in provider.FileData)
                {
                    var name = file.Headers
                        .ContentDisposition
                        .FileName;
                    // remove double quotes from string.
                    name = name.Trim('"');
                    var localFileName = file.LocalFileName;
                    var filePath = Path.Combine(root, name);
                    File.Move(localFileName, filePath);
                    tempPhoto.FilePath = filePath;
                }
                unit.Photos.Insert(tempPhoto);
                unit.Complete();
            }
            catch (Exception e)
            {
                return $"Error: {e.Message}";
            }
            return tempPhoto.Id.ToString();
        }
    }
}
