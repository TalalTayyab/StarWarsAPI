using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWarsAPI;
using StarWarsAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsAPIUnitTest
{
    [TestClass]
    public class VehicleUnitTest : StarWarsBaseUnitTest
    {
        [TestMethod]
        [Timeout(TestTimeout.Infinite)]
        public async Task Get()
        {
            //Arrange
            var api = new StarWarsAPIClient();

            //Act
            var v = await api.GetVehicleAsync("14");

            //Assert
            Assert.AreEqual(v.name, "Snowspeeder");
            Assert.AreEqual(v.model, "t-47 airspeeder");
            Assert.AreEqual(v.manufacturer, "Incom corporation");
            Assert.AreEqual(v.cost_in_credits, "unknown");
            Assert.AreEqual(v.length, "4.5");
            Assert.AreEqual(v.max_atmosphering_speed, "650");
            Assert.AreEqual(v.crew, "2");
            Assert.AreEqual(v.passengers, "0");
            Assert.AreEqual(v.cargo_capacity, "10");
            Assert.AreEqual(v.consumables, "none");
            Assert.AreEqual(v.vehicle_class, "airspeeder");

          

            TestArrayItems<People>(v.pilots, new string[] {
                        @"http://swapi.co/api/people/1/", 
                        @"http://swapi.co/api/people/18/"
                }, v.GetPilotAsync);

            TestArrayItems<Film>(v.films, new string[] {
                       @"http://swapi.co/api/films/2/"
                }, v.GetFilmAsync);




            Assert.AreEqual(v.created, "2014-12-15T12:22:12Z");
            Assert.IsNotNull(v.edited);
            Assert.AreEqual(v.url, "http://swapi.co/api/vehicles/14/");

        }
    }
}
