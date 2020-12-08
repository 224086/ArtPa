using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
     public interface IDataRepository
    {


         void AddClient(Client c);

         Client GetClient(String id);


        IEnumerable<Client> GetAllClients();

        void UpdateClientsInfo(Client C);


        void DeleteClient(String id);

        void AddBaking(Baking d);

        int GetAllEventsNumber();

        int GetAllClientsNumber();

        Baking GetBaking(int id);
       
        Baking GetBakingByType(BakingType type);
        int GetBakingsNumber();


         IEnumerable<Baking> GetAllBakings();

         void UpdateBakingInfo(Baking D);


         void DeleteBaking(int id);


         List<Event> GetAllEvents();


         Event GetEventById(String id);


         void AddEvent(Event e);


         void DeleteEvent(String id);

        int GetBakingState(int id);


         Dictionary<int, int> GetAllStates();


         void UpdateBakingStateInfo(int ID, int new_state);


        void DeleteOneBakingState(int id);

        State GetState();



    }
}
