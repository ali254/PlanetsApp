﻿using Data.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Planet.Models
{
    public class PlanetImage : BaseModel
    {
        public string Name { get; set; }
        public byte[] Data { get; set; }

    }
}
