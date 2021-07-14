using Infrastructure.Planet.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanetEntity = Data.Planet.Models.Planet;

namespace Infrastructure.Planet
{
    public class PlanetInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<PlanetDbContext>
    {
        protected override void Seed(PlanetDbContext context)
        {
            #region "seed planets"

            context.Planets.Add(
                new PlanetEntity() { Name = "Earth", Diameter = 12742, DistanceFromSun = 149600000, Mass = 5.972e+24 });
            context.Planets.Add(
                new PlanetEntity() { Name = "Jupiter", Diameter = 139820, DistanceFromSun = 778500000, Mass = 1.8986e+27 });
            context.Planets.Add(
                new PlanetEntity() { Name = "Uranus", Diameter = 50724, DistanceFromSun = 2871000000, Mass = 8.6810e+25 });
            context.Planets.Add(
                new PlanetEntity() { Name = "Mars", Diameter = 6779, DistanceFromSun = 227900000, Mass = 6.4185e+23 });
            context.Planets.Add(
                new PlanetEntity() { Name = "Saturn", Diameter = 116460, DistanceFromSun = 1434000000, Mass = 5.6846e+26 });
            context.Planets.Add(
                new PlanetEntity() { Name = "Venus", Diameter = 12104, DistanceFromSun = 108200000, Mass = 4.8685e+24 });
            context.Planets.Add(
                new PlanetEntity() { Name = "Neptune", Diameter = 49244, DistanceFromSun = 4495100000, Mass = 10.243e+25 });
            context.Planets.Add(
                new PlanetEntity() { Name = "Mercury", Diameter = 4879.4, DistanceFromSun = 57900000, Mass = 3.3022e+23 });

            #endregion

            context.SaveChanges();
        }
    }
}
