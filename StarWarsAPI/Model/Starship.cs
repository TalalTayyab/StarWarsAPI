using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsAPI.Model
{
    /// <summary>
    /// A vehicle.
    /// </summary>
    public class Starship : StarWarsBase
    {
        public string cost_in_credits { get; set; }
        public string max_atmosphering_speed { get; set; }
        public string starship_class { get; set; }
        public string crew { get; set; }
        public string hyperdrive_rating { get; set; }
        public string model { get; set; }
        public string cargo_capacity { get; set; }
        public IEnumerable<string> pilots { get; set; }
        public string name { get; set; }
        public string length { get; set; }
        public string MGLT { get; set; }
        public IEnumerable<string> films { get; set; }
        public string manufacturer { get; set; }
        public string consumables { get; set; }
        public string passengers { get; set; }
         
    }
}


