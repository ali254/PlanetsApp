using AutoMapper;
using Logic.Planet.DTO;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PlanetEntity = Data.Planet.Models.Planet;

namespace PlanetApp
{
    public class AutoMapperModule : NinjectModule
    {
        public override void Load()
        {

            var mapperConfiguration = CreateConfiguration();
            Bind<MapperConfiguration>().ToConstant(mapperConfiguration).InSingletonScope();

            // This teaches Ninject how to create automapper instances say if for instance
            // MyResolver has a constructor with a parameter that needs to be injected
            Bind<IMapper>().ToMethod(ctx =>
                 new Mapper(mapperConfiguration, type => ctx.Kernel.Get(type)));
        }

        private MapperConfiguration CreateConfiguration()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PlanetEntity, PlanetDetailedDTO>();
                cfg.CreateMap<PlanetEntity, PlanetLookUpDTO>();
            });

        }
    }
}