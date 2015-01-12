A .net C# wrapper around the Starwars API (http://swapi.co/api/)

The library exposes Async methods to retrieve the various objects defined by the SWAPI API.

To start using import the namespaces
  using StarWarsAPI;
  using StarWarsAPI.Model;


To create an instance of the client 
   var api = new StarWarsAPIClient();


To get a single people object:
   var people = api.GetPeopleAsync("1").Result;


The following methods are available to get the objects exposed by the API.
  public async Task<People> GetPeopleAsync(string id)
  public async Task<Planet> GetPlanetAsync(string id)
  public async Task<Specie> GetSpecieAsync(string id)
  public async Task<Starship> GetStarshipAsync(string id)
  public async Task<Film> GetFilmAsync(string id)
  public async Task<Vehicle> GetVehicleAsync(string id)


There are also a set of extension method defined for each object to retrieve the related objects. For example for the People object
  async public static Task<Planet> GetHomeworldAsync(this People p)
  async public static Task<IEnumerable<Film>> GetFilmAsync(this People p)
  async public static Task<IEnumerable<Specie>> GetSpeciesAsync(this People p)
  async public static Task<IEnumerable<Vehicle>> GetVehicleAsync(this People p)
  async public static Task<IEnumerable<Starship>> GetStarshipAsync(this People p)


This has the advantage that each object is a simple POCO type , and the extension method allows retrieval of related properties. For example:
    var api = new StarWarsAPIClient();

    var people = api.GetPeopleAsync("1").Result;

    var homeworld = people.GetHomeworldAsync().Result;

    foreach (var film in people.GetFilmAsync().Result)
    {
      Console.WriteLine(film.episode_id);
    }


To retrieve multiple objects:
  public async Task<StarWarsEntityList<People>> GetAllPeople(string page = "1")
  public async Task<StarWarsEntityList<Planet>> GetAllPlanet(string page = "1")
  public async Task<StarWarsEntityList<Specie>> GetAllSpecie(string page = "1")
  public async Task<StarWarsEntityList<Starship>> GetAllStarship(string page = "1")
  public async Task<StarWarsEntityList<Film>> GetAllFilm(string page = "1")
  public async Task<StarWarsEntityList<Vehicle>> GetAllVehicle(string page = "1")


Extension method defined on the collection object to get the next/prev results
  async public static Task<StarWarsEntityList<T>> GetNextAsync<T>(this StarWarsEntityList<T> list)
  async public static Task<StarWarsEntityList<T>> GetPrevAsync<T>(this StarWarsEntityList<T> list)


Sample to get a list of vehicles - and then iterate
  StarWarsEntityList<Vehicle> vehicles = api.GetAllVehicle().Result;

  Console.WriteLine("total items: {0}", vehicles.count);

  foreach (var v in vehicles.results)
  {
   Console.WriteLine("Name: {0}", v.name);
  }

  if (vehicles.isNext)
  {
      vehicles = vehicles.GetNextAsync().Result;
  }

