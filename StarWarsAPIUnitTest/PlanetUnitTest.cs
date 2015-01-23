using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWarsAPI;
using StarWarsAPI.Model;
using System.Threading.Tasks;
using System.Linq;

namespace StarWarsAPIUnitTest
{
    [TestClass]
    public class PlanetUnitTest : StarWarsBaseUnitTest
    {
        [TestMethod]
        [Timeout(TestTimeout.Infinite)]
        public async Task GetPlanet()
        {
            //Arrange
            var api = new StarWarsAPIClient();

            //Act
            var p = await api.GetPlanetAsync("1");

            //Assert
            TestObject(p);
          
        }


        void TestObject(Planet p)
        {
            //Assert
            Assert.AreEqual(p.name, "Tatooine");
            Assert.AreEqual(p.rotation_period, "23");
            Assert.AreEqual(p.orbital_period, "304");
            Assert.AreEqual(p.diameter, "10465");

            Assert.AreEqual(p.climate, "arid");
            Assert.AreEqual(p.gravity, "1 standard");
            Assert.AreEqual(p.terrain, "desert");
            Assert.AreEqual(p.surface_water, "1");
            Assert.AreEqual(p.population, "200000");

            TestArrayItems<People>(p.residents, new string[] {
                     "http://swapi.co/api/people/1/", 
                     "http://swapi.co/api/people/2/", 
                     "http://swapi.co/api/people/4/", 
                     "http://swapi.co/api/people/6/", 
                     "http://swapi.co/api/people/7/", 
                     "http://swapi.co/api/people/8/", 
                     "http://swapi.co/api/people/9/", 
                     "http://swapi.co/api/people/11/", 
                     "http://swapi.co/api/people/43/", 
                     "http://swapi.co/api/people/62/"
                }, p.GetResidentAsync);




            TestArrayItems<Film>(p.films, new string[]{
                 "http://swapi.co/api/films/1/", 
                 "http://swapi.co/api/films/3/", 
                 "http://swapi.co/api/films/4/", 
                 "http://swapi.co/api/films/5/", 
                 "http://swapi.co/api/films/6/"
            }, p.GetFilmAsync);


            Assert.AreEqual(p.created, "2014-12-09T13:50:49.641000Z");
            Assert.IsNotNull(p.edited);
            Assert.AreEqual(p.url, "http://swapi.co/api/planets/1/");
        }



        [TestMethod]
        [Timeout(TestTimeout.Infinite)]
        public async Task GetAllPlanets()
        {
            //Arrange
            var api = new StarWarsAPIClient();

            //Act - get page 6
            var obj = await api.GetAllPlanetAsync("6");

            //Assert
            Assert.IsNotNull(obj);
            Assert.AreEqual(obj.count, 60);
            Assert.AreEqual(obj.next,null);
            Assert.AreEqual(obj.previous, "http://swapi.co/api/planets/?page=5");
            Assert.IsNotNull(obj.results);
            Assert.AreEqual(obj.results.Count(), 10);

            var planet = obj.results.Where(e => e.name == "Tatooine").First();
            TestObject(planet);


            //Act
            //now we move back
            obj = await obj.GetPrevAsync();

            //Assert
            Assert.AreEqual(obj.next, "http://swapi.co/api/planets/?page=6");
            Assert.AreEqual(obj.previous, "http://swapi.co/api/planets/?page=4");
            Assert.IsNotNull(obj.results);
            Assert.AreEqual(obj.results.Count(), 10);


            //Act
            //now we move front
            obj = await obj.GetNextAsync();

            //Assert
            Assert.AreEqual(obj.next, null);
            Assert.AreEqual(obj.previous, "http://swapi.co/api/planets/?page=5");
            Assert.IsNotNull(obj.results);
            Assert.AreEqual(obj.results.Count(), 10);
          

        }

    }
}
