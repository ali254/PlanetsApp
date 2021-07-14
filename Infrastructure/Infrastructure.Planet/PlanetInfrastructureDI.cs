using Infrastructure.Planet.DbContext;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Planet
{
    public class PlanetInfrastructureDI : NinjectModule
    {
        public override void Load()
        {
            Bind<IPlanetDbContext>().To<PlanetDbContext>();
        }
    }
}
