using Logic.Planet.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Planet
{
    public class PlanetLogicDI : NinjectModule
    {
        public override void Load()
        {
            Bind<IPlanetService>().To<PlanetService>();
            Bind<IPlanetImageService>().To<PlanetImageService>();
        }
    }
}
