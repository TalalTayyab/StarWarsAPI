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
        public async Task GetVehicle()
        {
            //Arrange
            var api = new StarWarsAPIClient();

            //Act
            var v = await api.GetVehicleAsync("14");

            TestObject(v);



        }


        void TestObject(Vehicle v)
        {
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
                        "http://swapi.co/api/people/1/", 
                        "http://swapi.co/api/people/18/"
                }, v.GetPilotAsync);

            TestArrayItems<Film>(v.films, new string[] {
                       "http://swapi.co/api/films/2/"
                }, v.GetFilmAsync);




            Assert.AreEqual(v.created, "2014-12-15T12:22:12Z");
            Assert.IsNotNull(v.edited);
            Assert.AreEqual(v.url, "http://swapi.co/api/vehicles/14/");
        }


        [TestMethod]
        [Timeout(TestTimeout.Infinite)]
        public async Task GetAllVehicles()
        {
            //Arrange
            var api = new StarWarsAPIClient();

            //Act
            var obj = await api.GetAllVehicleAsync();

            //Assert
            Assert.IsNotNull(obj);
            Assert.AreEqual(obj.count, 39);
            Assert.AreEqual(obj.next, "http://swapi.co/api/vehicles/?page=2");
            Assert.IsNull(obj.previous);
            Assert.IsNotNull(obj.results);
            Assert.AreEqual(obj.results.Count(), 10);

            var vehicle = obj.results.Where(e => e.name == "Snowspeeder").First();
            TestObject(vehicle);


            //Act
            //now we move next
            obj = await obj.GetNextAsync();

            //Assert
            Assert.AreEqual(obj.next, "http://swapi.co/api/vehicles/?page=3");
            Assert.AreEqual(obj.previous, "http://swapi.co/api/vehicles/?page=1");
            Assert.IsNotNull(obj.results);
            Assert.AreEqual(obj.results.Count(), 10);

            //Act
            //now we move back
            obj = await obj.GetPrevAsync();

            //Assert
            Assert.AreEqual(obj.next, "http://swapi.co/api/vehicles/?page=2");
            Assert.IsNull(obj.previous);
            Assert.IsNotNull(obj.results);
            Assert.AreEqual(obj.results.Count(), 10);
           
           
        }

    }
}
