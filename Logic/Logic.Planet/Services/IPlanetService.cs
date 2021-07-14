using Logic.Planet.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Planet.Services
{
    public interface IPlanetService
    {
        PlanetLookUpDTO[] Get();
        PlanetDetailedDTO GetDetailed(string Name);
        PlanetDetailedDTO GetDetailed(Guid PK);
            
    }
}
