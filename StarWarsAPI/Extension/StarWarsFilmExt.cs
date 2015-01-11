using StarWarsAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsAPI
{
    public static class StarWarsFilmExt
    {
        async public static Task<IEnumerable<People>> GetPeopleAsync(this Film f)
        {
            StarWarsAPIClient api = new StarWarsAPIClient();
            return await api.GetListAsync<People>(f.characters);

        }

        async public static Task<IEnumerable<Planet>> GetPlanetAsync(this Film f)
        {
            StarWarsAPIClient api = new StarWarsAPIClient();
            return await api.GetListAsync<Planet>(f.planets);

        }

        async public static Task<IEnumerable<Starship>> GetStarshipAsync(this Film f)
        {
            StarWarsAPIClient api = new StarWarsAPIClient();
            return await api.GetListAsync<Starship>(f.starships);

        }

        async public static Task<IEnumerable<Vehicle>> GetVehicleAsync(this Film f)
        {
            StarWarsAPIClient api = new StarWarsAPIClient();
            return await api.GetListAsync<Vehicle>(f.vehicles);

        }

        async public static Task<IEnumerable<Specie>> GetSpecieAsync(this Film f)
        {
            StarWarsAPIClient api = new StarWarsAPIClient();
            return await api.GetListAsync<Specie>(f.species);

        }
        
    }
}
