using StarWarsAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsAPI
{
    public static class StarWarsVehicleExt
    {
        async public static Task<IEnumerable<Film>> GetFilmAsync(this Vehicle v)
        {
            StarWarsAPIClient api = new StarWarsAPIClient();
            return await api.GetListAsync<Film>(v.films);

        }

        async public static Task<IEnumerable<People>> GetPilotAsync(this Vehicle v)
        {
            StarWarsAPIClient api = new StarWarsAPIClient();
            return await api.GetListAsync<People>(v.pilots);

        }

    }

}
