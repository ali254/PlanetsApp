using Infrastructure.Planet.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Planet.Services
{
    internal class PlanetImageService : IPlanetImageService
    {
        private readonly IPlanetDbContext planetDbContext;
        public PlanetImageService(IPlanetDbContext planetDbContext)
        {
            this.planetDbContext = planetDbContext;
        }

        public byte[] GetFile(Guid PK)
        {
            return this.planetDbContext.PlanetImages.Find(PK)?.Data;
        }
    }
}
