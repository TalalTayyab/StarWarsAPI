using StarWarsAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsAPI
{
    public static class StarWarsPlanetExt
    {
        async public static Task<IEnumerable<Film>> GetFilmAsync(this Planet p)
        {
            StarWarsAPIClient api = new StarWarsAPIClient();
            return await api.GetListAsync<Film>(p.films);

        }

        async public static Task<IEnumerable<People>> GetResidentAsync(this Planet p)
        {
            StarWarsAPIClient api = new StarWarsAPIClient();
            return await api.GetListAsync<People>(p.residents);

        }
    }
}
