using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsAPI.Model
{

    public class Film : StarWarsBase
    {
        public string producer { get; set; }
        public int episode_id { get; set; }
        public IEnumerable<string> starships { get; set; }
        public IEnumerable<string> species { get; set; }
        public string opening_crawl { get; set; }
        public IEnumerable<string> vehicles { get; set; }
        public IEnumerable<string> planets { get; set; }
        public string title { get; set; }
        public string director { get; set; }
        public IEnumerable<string> characters { get; set; }
    }
}