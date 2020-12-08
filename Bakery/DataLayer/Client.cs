using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
     public class Client
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public string Id { get; set; }

        public Client(String FirstName, String LastName, String Id)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Id = Id;

        }

        public override bool Equals(object obj)
        {
            Client other = (Client)obj;
            return this.Id == other.Id;
        }
    }
}
