using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class NewBatchEvent : Event
    {
        public NewBatchEvent(string id, State state, Client client, DateTime dateTime) : base(id, state, client, dateTime)
        {
        }
    }
}
