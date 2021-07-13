using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Planet.DataModels
{
    public class PlanetDataModel
    {
        public string Name { get; set; }
        public string ImageName { get; set; }
        public double Mass { get; set; }
        public double Diameter { get; set; }
        public int DistanceFromSun { get; set; }
    }
}
