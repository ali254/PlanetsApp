using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Planet.Models
{
    public class Planet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PK { get; set; }
        public string Name { get; set; }
        public string ImageName { get; set; }

        public double Mass { get; set; }

        public double Diameter { get; set; }
        public int DistanceFromSun { get; set; }




    }
}
