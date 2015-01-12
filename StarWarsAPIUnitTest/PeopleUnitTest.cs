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
        public async Task Get()
        {
            //Arrange
            var api = new StarWarsAPIClient();

            //Act
            var p = await api.GetPeopleAsync("1");

            //Assert
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
                       @"http://swapi.co/api/films/1/", 
                       @"http://swapi.co/api/films/2/", 
                       @"http://swapi.co/api/films/3/", 
                       @"http://swapi.co/api/films/6/"
                }, p.GetFilmAsync);




            TestArrayItems<Specie>(p.species, new string[]{
                @"http://swapi.co/api/species/1/"
            },p.GetSpeciesAsync);

            TestArrayItems<Vehicle>(p.vehicles, new string[]{
                @"http://swapi.co/api/vehicles/14/",
                @"http://swapi.co/api/vehicles/30/"
            },p.GetVehicleAsync);

            TestArrayItems<Starship>(p.starships, new string[]{
                 "http://swapi.co/api/starships/12/", 
                 "http://swapi.co/api/starships/22/"
            },p.GetStarshipAsync);

            Assert.AreEqual(p.created, "2014-12-09T13:50:51.644000Z");
            Assert.IsNotNull(p.edited);
            Assert.AreEqual(p.url, "http://swapi.co/api/people/1/");
        }






    

    }
}
