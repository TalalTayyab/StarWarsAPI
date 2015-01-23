using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWarsAPI;
using System.Linq;
using System.Collections;
using StarWarsAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StarWarsAPIUnitTest
{
    [TestClass]
    public class PeopleUnitTest : StarWarsBaseUnitTest
    {
        [TestMethod]
        [Timeout(TestTimeout.Infinite)]
        public async Task GetPeople()
        {
            //Arrange
            var api = new StarWarsAPIClient();

            //Act
            var p = await api.GetPeopleAsync("1");

            //Assert
            TestObject(p);
        }



        void TestObject(People p)
        {
            Assert.AreEqual(p.name, "Luke Skywalker");
            Assert.AreEqual(p.height, "172");
            Assert.AreEqual(p.mass, "77");
            Assert.AreEqual(p.hair_color, "blond");

            Assert.AreEqual(p.skin_color, "fair");
            Assert.AreEqual(p.eye_color, "blue");
            Assert.AreEqual(p.birth_year, "19BBY");
            Assert.AreEqual(p.gender, "male");

            Assert.AreEqual(p.homeworld, "http://swapi.co/api/planets/1/");
            Assert.AreEqual(p.GetHomeworldAsync().Result.url, "http://swapi.co/api/planets/1/");


            TestArrayItems<Film>(p.films, new string[] {
                       "http://swapi.co/api/films/1/", 
                       "http://swapi.co/api/films/2/", 
                       "http://swapi.co/api/films/3/", 
                       "http://swapi.co/api/films/6/"
                }, p.GetFilmAsync);




            TestArrayItems<Specie>(p.species, new string[]{
                "http://swapi.co/api/species/1/"
            }, p.GetSpeciesAsync);

            TestArrayItems<Vehicle>(p.vehicles, new string[]{
                "http://swapi.co/api/vehicles/14/",
                "http://swapi.co/api/vehicles/30/"
            }, p.GetVehicleAsync);

            TestArrayItems<Starship>(p.starships, new string[]{
                 "http://swapi.co/api/starships/12/", 
                 "http://swapi.co/api/starships/22/"
            }, p.GetStarshipAsync);

            Assert.AreEqual(p.created, "2014-12-09T13:50:51.644000Z");
            Assert.IsNotNull(p.edited);
            Assert.AreEqual(p.url, "http://swapi.co/api/people/1/");
        }

        [TestMethod]
        [Timeout(TestTimeout.Infinite)]
        public async Task GetAllPeople()
        {
            //Arrange
            var api = new StarWarsAPIClient();

            //Act - get first page
            var obj = await api.GetAllPeopleAsync();

            //Assert
            Assert.IsNotNull(obj);
            Assert.AreEqual(obj.count, 82);
            Assert.AreEqual(obj.next, "http://swapi.co/api/people/?page=2");
            Assert.IsNull(obj.previous);
            Assert.IsNotNull(obj.results);
            Assert.AreEqual(obj.results.Count(), 10);
            
            TestObject(obj.results.First());


            //Act
            //now we move next
            obj = await obj.GetNextAsync();

            //Assert
            Assert.AreEqual(obj.next, "http://swapi.co/api/people/?page=3");
            Assert.AreEqual(obj.previous, "http://swapi.co/api/people/?page=1");
            Assert.IsNotNull(obj.results);
            Assert.AreEqual(obj.results.Count(), 10);

            //now we move back
            obj = await obj.GetPrevAsync();

            //Assert
            Assert.AreEqual(obj.next, "http://swapi.co/api/people/?page=2");
            Assert.IsNull(obj.previous);
            Assert.IsNotNull(obj.results);
            Assert.AreEqual(obj.results.Count(), 10);

        }




    

    }
}
