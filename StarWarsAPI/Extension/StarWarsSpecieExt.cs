using StarWarsAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsAPI
{
    public static class StarWarsSpecieExt
    {
        async public static Task<IEnumerable<Film>> GetFilmAsync(this Specie s)
        {
            StarWarsAPIClient api = new StarWarsAPIClient();
            return await api.GetListAsync<Film>(s.films);

        }

        async public static Task<IEnumerable<People>> GetPeopleAsync(this Specie s)
        {
            StarWarsAPIClient api = new StarWarsAPIClient();
            return await api.GetListAsync<People>(s.people);

        }

        async public static Task<Planet> GetHomeworldAsync(this Specie p)
        {
            StarWarsAPIClient api = new StarWarsAPIClient();
            return await api.GetAsync<Planet>(p.homeworld);
        }
    }
      
}
