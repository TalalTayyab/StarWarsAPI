using StarWarsAPI;
using StarWarsAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsConsoleTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Planet homeworld = people.GetHomeworldAsync().Result;
                //Console.WriteLine(homeworld.name);


                GetPeople();
                //GetVehiclException();
                GetVehicleList();

                Console.WriteLine("Press any key to exit");

                Console.ReadKey();

            }

            catch (Exception exp)
            {
                Console.WriteLine(exp.ToString());
            }

        }


        static void GetVehicleList(StarWarsEntityList<Vehicle> result = null)
        {
            var api = new StarWarsAPIClient();

            if (result == null)
            {
                result = api.GetAllVehicle().Result;
            }


            Console.WriteLine("total items: {0}", result.count);
            foreach (var v in result.results)
            {
                Console.WriteLine("Name: {0}", v.name);


            }


            if (result.isNext)
            {
                Console.WriteLine("press N for next 10 results");
            }

            if (result.isPrev)
            {
                Console.WriteLine("press P for last 10 results");
            }



            var key = Console.ReadKey();
           
            if (result.isNext && key.KeyChar == 'n')
            {
                result = result.GetNextAsync().Result;
                GetVehicleList(result);
            }
            else if (result.isPrev && key.KeyChar == 'p')
            {
                result = result.GetPrevAsync().Result;
                GetVehicleList(result);
            }

          


        }

        static void GetVehiclException()
        {
            var api = new StarWarsAPIClient();

            var v = api.GetVehicleAsync("1").Result;
            Console.WriteLine(v.name);

        }

        static void GetPeople()
        {
            var api = new StarWarsAPIClient();

            var people = api.GetPeopleAsync("1").Result;
            Console.WriteLine(people.name);

            Console.WriteLine(people.GetHomeworldAsync().Result.name);

            foreach (var film in people.GetFilmAsync().Result)
            {
                Console.WriteLine(film.episode_id);
            }

            foreach (var specie in people.GetSpeciesAsync().Result)
            {
                Console.WriteLine(specie.name);

            }

            foreach (var vehicle in people.GetVehicleAsync().Result)
            {
                Console.WriteLine(vehicle.name);

            }

            foreach (var starship in people.GetStarshipAsync().Result)
            {
                Console.WriteLine(starship.name);

            }
        }
    }
}
