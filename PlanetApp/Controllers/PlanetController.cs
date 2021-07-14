using Logic.Planet.DTO;
using Logic.Planet.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlanetApp.Controllers
{
    [RoutePrefix("api/Planet")]
    public class PlanetController : ApiController
    {
        private readonly IPlanetService planetService;
        public PlanetController(IPlanetService planetService)
        {
            this.planetService = planetService;
        }

        // GET: api/Planet
        [HttpGet]
        public IEnumerable<PlanetLookUpDTO> Get()
        {
            return this.planetService.Get();
        }


        // GET: api/Planet/<Guid>
        [HttpGet]
        [Route("{pk}")]
        public PlanetDetailedDTO Get(Guid pk)
        {
            return this.planetService.GetDetailed(pk);
        }
    }
}
