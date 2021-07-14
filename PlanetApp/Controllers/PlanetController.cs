using Logic.Planet.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlanetApp.Controllers
{
    public class PlanetController : ApiController
    {
        private readonly IPlanetService planetService;
        public PlanetController(IPlanetService planetService)
        {
            this.planetService = planetService;
        }

        // GET: api/Planet
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        // GET: api/Planet/5
        [HttpGet]
        public string Get(int id)
        {
            return "value";
        }
    }
}
