using StarWarsAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsAPI
{
    public static class StarWarsStarshipExt
    {
        async public static Task<IEnumerable<Film>> GetFilmAsync(this Starship s)
        {
            StarWarsAPIClient api = new StarWarsAPIClient();
            return await api.GetListAsync<Film>(s.films);

        }

        async public static Task<IEnumerable<People>> GetPilotAsync(this Starship s)
        {
            StarWarsAPIClient api = new StarWarsAPIClient();
            return await api.GetListAsync<People>(s.pilots);

        }

    }

}
