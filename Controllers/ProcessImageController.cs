using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ProjetDotnetFramework.Api.Controllers
{
    public class ProcessImageController : ApiController
    {
        [HttpPost, Route("api/ProcessImage")]
        // POST: api/ProcessImage
        public async Task<HttpResponseMessage> PostAsync()
        {
            //if (!Request.Content.IsMimeMultipartContent())
            //{
            //    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            //}

            //string root = HttpContext.Current.Server.MapPath("~/App_Data");
            //var provider = new MultipartFormDataStreamProvider(root);

            try
            {
                //await Request.Content.ReadAsMultipartAsync(provider);

                //// Show all the key-value pairs.
                //foreach (var key in provider.FormData.AllKeys)
                //{

                //}

                var url = "https://cesidatastorage.blob.core.windows.net/image/20050a47-525b-432c-99b9-91f628a7cb88";
                var test = new LogoFinder.Service1Client();
                var result = test.ImageUri(url, false);
                var img = test.DrawOnImage(result, url);

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
    }
}
