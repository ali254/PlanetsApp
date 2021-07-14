using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Planet.DTO
{
    public class PlanetDetailedDTO : PlanetLookUpDTO
    {
        public double Mass { get; set; }
        public double Diameter { get; set; }
        public double DistanceFromSun { get; set; }
        public Guid PlanetImagePK { get; set; }
        public string PlanetImageName { get; set; }
    }
}
