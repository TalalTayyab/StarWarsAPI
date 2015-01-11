using StarWarsAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsAPI
{
    public static class StarWarsEntityListExt
    {
       
        async public static Task<StarWarsEntityList<T>> GetNextAsync<T>(this StarWarsEntityList<T> list)
        {
            StarWarsAPIClient api = new StarWarsAPIClient();
            return await api.GetAsync<StarWarsEntityList<T>>(list.next);
        }

        async public static Task<StarWarsEntityList<T>> GetPrevAsync<T>(this StarWarsEntityList<T> list)
        {
            StarWarsAPIClient api = new StarWarsAPIClient();
            return await api.GetAsync<StarWarsEntityList<T>>(list.previous);
        }
    }
}
