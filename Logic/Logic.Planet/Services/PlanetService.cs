using AutoMapper;
using Infrastructure.Planet.DbContext;
using Logic.Planet.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanetEntity = Data.Planet.Models.Planet;

namespace Logic.Planet.Services
{
    internal class PlanetService : IPlanetService
    {
        private readonly IPlanetDbContext planetDbContext;
        private readonly IMapper mapper;
        public PlanetService(IPlanetDbContext planetDbContext, IMapper mapper)
        {
            this.planetDbContext = planetDbContext;
            this.mapper = mapper;
        }

        private PlanetDetailedDTO GetDetailedDTO(PlanetEntity entity)
        {
            return entity != null ? mapper.Map<PlanetDetailedDTO>(entity) : null;

            //if (planetEntity != null)
            //{
            //    return new PlanetDetailedDTO()
            //    {
            //        PK = planetEntity.PK,
            //        Name = planetEntity.Name,
            //        DistanceFromSun = planetEntity.DistanceFromSun,
            //        Diameter = planetEntity.Diameter,
            //        ImageName = planetEntity.ImageName,
            //        Mass = planetEntity.Mass
            //    };
            //}
            //else
            //{
            //    return null;
            //}
        }


        public PlanetLookUpDTO[] Get() 
        {

            return mapper.ProjectTo<PlanetLookUpDTO>(this.planetDbContext.Planets)
                .OrderBy(p => p.Name).ToArray();

            //return this.planetDbContext.Planets.Select(p => new PlanetLookUpDTO() 
            //{
            //    PK = p.PK,
            //    Name = p.Name,
            //}).OrderBy(p => p.Name).ToArray();

            
        }

        

        public PlanetDetailedDTO GetDetailed(string Name)
        {

            var planetEntity = this.planetDbContext.Planets
                .SingleOrDefault(p => p.Name.Equals(Name, StringComparison.OrdinalIgnoreCase));

            return GetDetailedDTO(planetEntity);
        }

        public PlanetDetailedDTO GetDetailed(Guid PK)
        {
            var planetEntity = this.planetDbContext.Planets.Find(PK);

            return GetDetailedDTO(planetEntity);
        }

    }
}
