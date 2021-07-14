using Logic.Planet.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace PlanetApp.Controllers
{
    [RoutePrefix("api/PlanetImage")]
    public class PlanetImageController : ApiController
    {
        private readonly IPlanetImageService planetImageService;
        public PlanetImageController(IPlanetImageService planetImageService)
        {
            this.planetImageService = planetImageService;
        }


        // GET: api/PlanetImage/<Guid>
        [HttpGet]
        [Route("{pk}")]
        public HttpResponseMessage Get(Guid pk)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            var filebytes = this.planetImageService.GetFile(pk);
            if (filebytes != null)
            {
                response.StatusCode = HttpStatusCode.OK;
                response.Content = new ByteArrayContent(filebytes);
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpg");
            }
            else
            {
                response.StatusCode = HttpStatusCode.NoContent;
            }
            return response;
        }


    }
}