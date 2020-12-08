using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public class DataRepository : IDataRepository
    {
        private DataContext context;

        public DataRepository(DataContext context)
        {
            this.context = context;
        }


        #region Client
        public void AddClient(Client c)
        {
            context.clients.Add(c);
        }

        public Client GetClient(String id)
        {
            foreach (Client C in context.clients)
            {
                if (C.Id == id)
                {
                    return C;
                }
            }
            throw new Exception("There is no client with this ID");
        }

        public IEnumerable<Client> GetAllClients()
        {
            return context.clients;
        }

        public int GetAllClientsNumber()
        {
            return context.clients.Count;
        }



        public void UpdateClientsInfo(Client C)
        {
            for (int i = 0; i < context.clients.Count; i++)
            {
                if (context.clients[i].Id == C.Id)
                {
                    context.clients[i].FirstName = C.FirstName;
                    context.clients[i].LastName = C.LastName;
                    return;
                }
            }
            throw new Exception("Client with such ID does not exist");
        }

        public void DeleteClient(String id)
        {
            for (int i = 0; i < context.clients.Count; i++)
            {
                if (context.clients[i].Id == id)
                {
                    context.clients.Remove(context.clients[i]);
                    return;
                }
            }
            throw new Exception("Client with such ID does not exist");
        }

        #endregion

        #region Catalog

        public void AddBaking(Baking d)

        {
            if (context.catalog.products.ContainsKey(d.Id))
            {
                throw new Exception("No such baking in our shop");
            }
                context.catalog.products.Add(d.Id, d);
        }

        public int GetBakingsNumber()
        {
            return context.catalog.products.Count();

        }

        public Baking GetBaking(int id)
        {
            return context.catalog.products[id];
        }

        public Baking GetBakingByType(BakingType type)
        {
            foreach (var baking in context.catalog.products.ToArray())
            {
                if (context.catalog.products[baking.Key].Type == type)
                {
                    return context.catalog.products[baking.Key];
                }
            }
            throw new Exception("There is no baking of this type");
        }

        public IEnumerable<Baking> GetAllBakings()
        {
            return context.catalog.products.Values;
        }

        public void UpdateBakingInfo(Baking D)
        {
            if (context.catalog.products.ContainsKey(D.Id))
            {
                context.catalog.products[D.Id].Price = D.Price;
                context.catalog.products[D.Id].Type = D.Type;
                return;
            }
            throw new Exception("No such baking in our shop");
        }

        public void DeleteBaking(int id)
        {
            if (context.catalog.products.ContainsKey(id))
            {
                context.catalog.products.Remove(id);
                return;
            }
            throw new Exception("There is no such baking already");
        }

        #endregion

        #region Event

        public List<Event> GetAllEvents()
        {
            return context.events;
        }

        public int GetAllEventsNumber()
        {
            return context.events.Count;
        }

        public Event GetEventById(String id)
        {
            for (int i = 0; i < context.events.Count; i++)
            {
                if (context.events[i].Id == id)
                {
                    return context.events[i];
                }
            }
            throw new Exception("Event with such id does not exist");
        }


        public void AddEvent(Event e)
        {
            context.events.Add(e);
        }

        public void DeleteEvent(String id)
        {
            for (int i = 0; i < context.events.Count; i++)
            {
                if (context.events[i].Id == id)
                {
                    context.events.Remove(context.events[i]);
                    return;
                }
            }
            throw new Exception("Event with such id does not exist");
        }

        #endregion

        #region State

        public int GetBakingState(int id)
        {
            return context.shop.inventory[id];
        }

        public State GetState()
        {
            return context.shop;
        }

        public Dictionary<int, int> GetAllStates()
        {
            return context.shop.inventory;
        }

        public void UpdateBakingStateInfo(int ID, int new_state)
        {
            if (context.catalog.products.ContainsKey(ID))
            {

                context.shop.inventory[ID] = new_state;
                return;
            }
            throw new Exception("No baking with such ID");
        }

        public void DeleteOneBakingState(int id)
        {
            if (context.shop.inventory.ContainsKey(id))
            {
                context.shop.inventory.Remove(id);
                return;
            }
            throw new Exception("There is no such baking already");
        }

        #endregion






    }
    }




