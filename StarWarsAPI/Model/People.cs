using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsAPI.Model
{

    public class People : StarWarsBase
    {
        public string gender { get; set; }
        public IEnumerable<string> starships { get; set; }
        public string height { get; set; }
        public string eye_color { get; set; }
        public IEnumerable<string> vehicles { get; set; }
        public string hair_color { get; set; }
        public string mass { get; set; }
        public IEnumerable<string> species { get; set; }
        public string name { get; set; }
        public string skin_color { get; set; }
        public IEnumerable<string> films { get; set; }
        public string homeworld { get; set; }
        public string birth_year { get; set; }
       
      
    }
}