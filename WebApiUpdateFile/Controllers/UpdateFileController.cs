using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace WebApiUpdateFile.Controllers
{
    public class UpdateFileController : ApiController
    {
        // GET: api/UpdateFile
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/UpdateFile/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/UpdateFile
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/UpdateFile/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/UpdateFile/5
        public void Delete(int id)
        {
        }


        [HttpPost]
        [Route(@"api/UploadFile")]
        public void UploadFile()
        {
            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {
                // Get the uploaded image from the Files collection
                var httpPostedFile = HttpContext.Current.Request.Files["UploadedImage"];
                var httpPosted = HttpContext.Current.Request;

                if (httpPostedFile != null)
                {
                    // Validate the uploaded image(optional)

                    // Get the complete file path
                    var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/UploadedFiles"), httpPostedFile.FileName);

                    // Save the uploaded file to "UploadedFiles" folder
                    httpPostedFile.SaveAs(fileSavePath);
                }
            }
        }
    }
}
