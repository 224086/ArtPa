
using DataLayer;
using System;
using System.Collections.Generic;
using System.Text;



namespace LogicLayer
{

    public class DataService
    {

        private IDataRepository repository;

        public DataService(IDataRepository repository)
        {
            this.repository = repository;
        }

        public Baking GetBakingByType(DataLayer.BakingType type)
        {
            return repository.GetBakingByType(type);
        }
        public Baking GetBakingById(int id)
        {
            return repository.GetBaking(id);
        }
        public int GetNumberOfBakings()
        {
            return repository.GetBakingsNumber();
        }

        public int GetAllClientsNumber()
        {
            return repository.GetAllClientsNumber();

        }

        public int GetStateOfBaking(int id)
        {
            return repository.GetBakingState(id);
        }

        public void AddBaking(Baking baking)
        {
         repository.AddBaking(baking);
        }

        public void DeleteBaking(int id)
        {
            repository.DeleteBaking(id);
        }

        public Client GetClientById(string id)
        {
           return repository.GetClient(id);
        }
        public void AddClient(Client client)
        {
            repository.AddClient(client);
        }
        
        public void UpdateClientInfo(String first_name, String last_name, String Id)
        {
            Client C = new Client(first_name, last_name, Id);
            repository.UpdateClientsInfo(C);
        }

        public void DeleteClient(String id)
        {
            repository.DeleteClient(id);
        }

        public int GetClientNumber()
        {
            return repository.GetAllClientsNumber();
        }


       public State GetState()
        {
            return repository.GetState();
        }

        public void UpdateBakingStateInfo(int ID, int new_state)
        {
            repository.UpdateBakingStateInfo(ID, new_state);
        }

        public void DeleteOneBakingState(int id)
        {
            repository.DeleteOneBakingState(id);
            
        }

            public void AddEvent(Event e)
        {
            repository.AddEvent(e);
        }
       
            public int GetAllEventsNumber()
        {
            return repository.GetAllEventsNumber();
        }

       
        public void DeleteEvent(string id)
        {
            repository.DeleteEvent(id);
        }
        public void GetEventByID(string id)
        {
            repository.GetEventById(id);
        }

        public IEnumerable<Event> GetEventsForTheClient(string id)
        {
            Client client = repository.GetClient(id);
            List<Event> allEvents = new List<Event>();

            foreach (Event myEvent in repository.GetAllEvents())
            {
                if (myEvent.client.Equals(client))
                {
                    allEvents.Add(myEvent);
                }
            }
            return allEvents;
        }
     
        public void BuyBaking(string customerId, int bakingId, DateTime dayOfBuying, int amount)
        {
            Client client = repository.GetClient(customerId);
            Baking baking = repository.GetBaking(bakingId);
            int amountLeft = GetStateOfBaking(bakingId) - amount;
            if (GetStateOfBaking(bakingId) < amount)
            {
                throw new InvalidOperationException("There is not enough bakings in the shop.");
            }

            BuyingEvent buyEvent = new BuyingEvent(customerId, repository.GetState(), client, dayOfBuying);
            repository.AddEvent(buyEvent);
            UpdateBakingStateInfo(bakingId, amountLeft);
            
        }

        public void NewBatch(string supplierId, int bakingId, DateTime dayOfRestock, int amountProvided)
        {
            Client supplier = repository.GetClient(supplierId);
            int newAmount = amountProvided + GetStateOfBaking(bakingId);

            NewBatchEvent restockEvent = new NewBatchEvent(supplierId, repository.GetState(), supplier, dayOfRestock);
            repository.AddEvent(restockEvent);
            UpdateBakingStateInfo(bakingId, newAmount);

        }

        public void AddandUpdate (Baking baking, int amount)
        {
            
            AddBaking(baking);
            UpdateBakingStateInfo(baking.Id, amount );
        }
    }
}
