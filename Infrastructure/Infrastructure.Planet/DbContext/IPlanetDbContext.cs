using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanetEntity = Data.Planet.Models.Planet;

namespace Infrastructure.Planet.DbContext
{
    public interface IPlanetDbContext
    {
        DbSet<PlanetEntity> Planets { get; set; }
    }
}
