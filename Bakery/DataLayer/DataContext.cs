using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
     public class DataContext

    {
        public Catalog catalog = new Catalog();
        public List <Event> events = new List<Event>();
        public State shop = new State();
        public List <Client> clients = new List<Client>();

    }
}
