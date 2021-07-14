using Constants;
using Data.Base.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Planet.Models
{
    public class Planet : BaseModel
    {
        [Required]
        [MaxLength(255)]
        [Index(DbIndexNames.UniquePlanetName, IsUnique = true)]
        public string Name { get; set; }
        public virtual PlanetImage PlanetImage { get; set; }
        public Guid PlanetImagePK { get; set; }
        public double Mass { get; set; }
        public double Diameter { get; set; }
        public double DistanceFromSun { get; set; }




    }
}
