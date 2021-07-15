using Data.Planet.Models;
using Infrastructure.Planet.DbContext;
using Logic.Planet.DTO;
using Logic.Planet.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ninject;
using PlanetApp.App_Start;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using PlanetEntity = Data.Planet.Models.Planet;

namespace PlanetApp.Test
{
    [TestClass]
    public class PlanetServiceTest
    {

        private IQueryable<PlanetEntity> _data;
        private IPlanetService _service;
        private readonly IKernel _kernel = NinjectWebCommon.CreateKernel();

        [TestInitialize]
        public void Initialize()
        {
            _data = new List<PlanetEntity>()
            {
                new PlanetEntity()
                {
                    PK = Guid.NewGuid(),
                    Name = "Earth",
                    Diameter = 12742,
                    DistanceFromSun = 149600000,
                    Mass = 5.972e+24,
                    PlanetImage = new PlanetImage() { Name = "Earth" }

                },
                new PlanetEntity()
                {
                    PK = Guid.NewGuid(),
                    Name = "Jupiter",
                    Diameter = 139820,
                    DistanceFromSun = 778500000,
                    Mass = 1.8986e+27,
                    PlanetImage = new PlanetImage() { Name = "Jupiter" }
                },
                new PlanetEntity()
                {
                    PK = Guid.NewGuid(),
                    Name = "Uranus",
                    Diameter = 50724,
                    DistanceFromSun = 2871000000,
                    Mass = 8.6810e+25,
                    PlanetImage = new PlanetImage() { Name = "Uranus" }
                },
                new PlanetEntity()
                {
                    PK = Guid.NewGuid(),
                    Name = "Mars",
                    Diameter = 6779,
                    DistanceFromSun = 227900000,
                    Mass = 6.4185e+23,
                    PlanetImage = new PlanetImage() { Name = "Mars"}
                },
                new PlanetEntity()
                {
                    PK = Guid.NewGuid(),
                    Name = "Saturn",
                    Diameter = 116460,
                    DistanceFromSun = 1434000000,
                    Mass = 5.6846e+26,
                    PlanetImage = new PlanetImage() { Name = "Saturn" }
                },
                new PlanetEntity()
                {
                    PK = Guid.NewGuid(),
                    Name = "Venus",
                    Diameter = 12104,
                    DistanceFromSun = 108200000,
                    Mass = 4.8685e+24,
                    PlanetImage = new PlanetImage() { Name = "Venus" }
                },
                new PlanetEntity()
                {
                    PK = Guid.NewGuid(),
                    Name = "Neptune",
                    Diameter = 49244,
                    DistanceFromSun = 4495100000,
                    Mass = 10.243e+25,
                    PlanetImage = new PlanetImage() { Name = "Neptune" }
                },
                new PlanetEntity()
                {
                    PK = Guid.NewGuid(),
                    Name = "Mercury",
                    Diameter = 4879.4,
                    DistanceFromSun = 57900000,
                    Mass = 3.3022e+23,
                    PlanetImage = new PlanetImage() { Name = "Mercury" }
                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<PlanetEntity>>();
            mockSet.Setup(set => set.Find(It.IsAny<object[]>()))
                .Returns((object[] input) => _data.SingleOrDefault(x => x.PK == (Guid)input.First()));
            mockSet.As<IQueryable<PlanetEntity>>().Setup(m => m.Provider).Returns(_data.Provider);
            mockSet.As<IQueryable<PlanetEntity>>().Setup(m => m.Expression).Returns(_data.Expression);
            mockSet.As<IQueryable<PlanetEntity>>().Setup(m => m.ElementType).Returns(_data.ElementType);
            mockSet.As<IQueryable<PlanetEntity>>().Setup(m => m.GetEnumerator()).Returns(_data.GetEnumerator());

            Mock<PlanetDbContext> mockContext = new Mock<PlanetDbContext>();
            mockContext.Setup(c => c.Planets).Returns(mockSet.Object);

            _service = _kernel.TryGet<IPlanetService>(new Ninject.Parameters.ConstructorArgument("planetDbContext", mockContext.Object));
        }

        [TestMethod]
        public void GetAllPlanets_ordered_by_name()
        {

            PlanetLookUpDTO[] realData = _service.Get();

            Assert.AreEqual(8, realData.Length);
            Assert.AreEqual("Earth", realData[0].Name);
            Assert.AreEqual("Jupiter", realData[1].Name);
            Assert.AreEqual("Mars", realData[2].Name);
            Assert.AreEqual("Mercury", realData[3].Name);
            Assert.AreEqual("Neptune", realData[4].Name);
            Assert.AreEqual("Saturn", realData[5].Name);
            Assert.AreEqual("Uranus", realData[6].Name);
            Assert.AreEqual("Venus", realData[7].Name);



        }

        private void AssertPlanetEntity_with_DetailedDTO(PlanetEntity dataEntity, PlanetDetailedDTO loadedItem)
        {
            Assert.AreEqual(dataEntity.PK, loadedItem.PK);
            Assert.AreEqual(dataEntity.Name, loadedItem.Name);
            Assert.AreEqual(dataEntity.Mass, loadedItem.Mass);
            Assert.AreEqual(dataEntity.Diameter, loadedItem.Diameter);
            Assert.AreEqual(dataEntity.DistanceFromSun, loadedItem.DistanceFromSun);
            Assert.AreEqual(dataEntity.PlanetImagePK, loadedItem.PlanetImagePK);
            Assert.AreEqual(dataEntity.PlanetImage.Name, loadedItem.PlanetImageName);
        }

        [TestMethod]
        public void GetPlanetDetailed_By_PK()
        {
            var dataEntity = _data.ToList()[1];
            PlanetDetailedDTO loadedItem = _service.GetDetailed(dataEntity.PK);
            AssertPlanetEntity_with_DetailedDTO(dataEntity, loadedItem);
        }

        [TestMethod]
        public void GetPlanetDetailed_By_Name()
        {

            PlanetEntity dataEntity = _data.ToList()[0];
            PlanetDetailedDTO loadedItem = _service.GetDetailed(dataEntity.Name);
            AssertPlanetEntity_with_DetailedDTO(dataEntity, loadedItem);

        }


    }
}
