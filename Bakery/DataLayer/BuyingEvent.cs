using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class BuyingEvent : Event
    {
        public BuyingEvent(string id, State state, Client client, DateTime dateTime) : base(id, state, client, dateTime)
        {
    

        }
    }
}
