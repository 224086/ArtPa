using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public abstract class Event
    {
        public String Id { get; set; }
        public DateTime dateTime { get; }
        public State state { get; set; }
        public Client client { get; set; }

        public Event(string id, State state, Client client, DateTime dateTime)
        {
            this.Id = id;
            this.state = state;
            this.client = client;
            this.dateTime = dateTime;

        }

        public override bool Equals(object obj)
        {
            var @event = obj as Event;
            return @event != null &&
                   Id == @event.Id;
        }
    }
}
