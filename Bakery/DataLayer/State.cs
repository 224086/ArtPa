using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer { 

    public class State

    {
        public Dictionary<int, int> inventory { get; set; } = new Dictionary<int, int>();

        public Catalog catalog { get; set; } = new Catalog();


        
    }
}
