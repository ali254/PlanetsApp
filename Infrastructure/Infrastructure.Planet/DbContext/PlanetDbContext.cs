using Data.Planet.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanetEntity = Data.Planet.Models.Planet;

namespace Infrastructure.Planet.DbContext
{
    public class PlanetDbContext : System.Data.Entity.DbContext, IPlanetDbContext
    {

        public PlanetDbContext() : base("PlanetContext")
        {
        }

        public virtual DbSet<PlanetEntity> Planets { get; set; }
        public virtual DbSet<PlanetImage> PlanetImages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
