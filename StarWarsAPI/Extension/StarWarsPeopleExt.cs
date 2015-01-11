using StarWarsAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsAPI
{
    public static class StarWarsPeopleExt
    {
        async public static Task<Planet> GetHomeworldAsync(this People p)
        {
            StarWarsAPIClient api = new StarWarsAPIClient();
            return await api.GetAsync<Planet>(p.homeworld);
        }

        async public static Task<IEnumerable<Film>> GetFilmAsync(this People p)
        {
            StarWarsAPIClient api = new StarWarsAPIClient();
            return await api.GetListAsync<Film>(p.films);

        }

        async public static Task<IEnumerable<Specie>> GetSpeciesAsync(this People p)
        {
            StarWarsAPIClient api = new StarWarsAPIClient();
            return await api.GetListAsync<Specie>(p.species);

        }

        async public static Task<IEnumerable<Vehicle>> GetVehicleAsync(this People p)
        {
            StarWarsAPIClient api = new StarWarsAPIClient();
            return await api.GetListAsync<Vehicle>(p.vehicles);

        }

        async public static Task<IEnumerable<Starship>> GetStarshipAsync(this People p)
        {
            StarWarsAPIClient api = new StarWarsAPIClient();
            return await api.GetListAsync<Starship>(p.starships);

        }
    }
}
