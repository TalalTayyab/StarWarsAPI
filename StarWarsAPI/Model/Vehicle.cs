﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StarWarsAPI.Model
{
  
    public class Vehicle
    {
        public string vehicle_class { get; set; }
        public string cost_in_credits { get; set; }
        public string max_atmosphering_speed { get; set; }
        public string crew { get; set; }
        public string created { get; set; }
        public string model { get; set; }
        public string cargo_capacity { get; set; }
        public IEnumerable<string> pilots { get; set; }
        public string name { get; set; }
        public string length { get; set; }
        public IEnumerable<string> films { get; set; }
        public string manufacturer { get; set; }
        public string consumables { get; set; }
        public string url { get; set; }
        public string edited { get; set; }
        public string passengers { get; set; }

    }
}


