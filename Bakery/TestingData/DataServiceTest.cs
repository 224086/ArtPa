using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer;
using DataLayer.DataGeneration;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestingData
{
    [TestClass]
    public class DataServiceTests
	{

		private DataService service;
		private DataContext our_shop;
		private IGenerator generator;

		[TestInitialize]
		public void Initialize()
		{
			our_shop = new DataContext();
			service = new DataService(new DataRepository(our_shop));
			generator = new FixedGenerator();
			generator.GenarateData(our_shop);
		}

		[TestMethod]
		public void AddAndGetClient()
		{
			Client c = new Client("Paweł", "Burczyk", "6");
			Assert.AreEqual(service.GetAllClientsNumber(), 4);
			service.AddClient(c);
			Assert.AreEqual(service.GetAllClientsNumber(), 5);
			Client temp = service.GetClientById("6");
			Assert.AreEqual(temp, c);
		}

        [TestMethod]
        public void UpdateClientInfo()
        {
          
            Assert.AreEqual("Artur", service.GetClientById("1").FirstName);
            service.UpdateClientInfo("Adam", "Rojek ", "1");
            Assert.AreEqual("Adam", service.GetClientById("1").FirstName);
        }

        [TestMethod]
        public void DeleteClientCorrect()
        {

            service.DeleteClient("1");
            Assert.AreEqual(service.GetAllClientsNumber(), 3);


        }


        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void DeleteClientException()
        {

            service.DeleteClient("BPOPO");
            Assert.AreEqual(service.GetAllClientsNumber(), 3);

        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void DeleteBakingException()
        {

            service.DeleteBaking(54857);
            Assert.AreEqual(service.GetNumberOfBakings(), 3);

        }

        [TestMethod]
		public void BakingTest()
        {
			Baking baking = new Baking(58, 6.7, BakingType.cookie);
			service.AddBaking(baking);
			Assert.AreEqual(baking, service.GetBakingById(58));
			service.DeleteBaking(58);
			
		}


        [TestMethod]
        public void EventCorrectDeleteTests()
        {
            Client temp = service.GetClientById("1");
            DateTime now = DateTime.Now;
            Event b = new BuyingEvent("b1", service.GetState(), temp, now);
            service.AddEvent(b);
            Assert.AreEqual(service.GetAllEventsNumber(), 1);
            service.DeleteEvent("b1");
            Assert.AreEqual(service.GetAllEventsNumber(), 0);

        }


        [TestMethod]
        public void EventUserBuyingTests()
        {
            
            DateTime now = DateTime.Now;
            service.BuyBaking("1", 1, now, 5);
            Assert.AreEqual(service.GetAllEventsNumber(), 1);
            Assert.AreEqual(5, service.GetStateOfBaking(1));
            IEnumerable<Event> lista = service.GetEventsForTheClient("1");
            Assert.AreEqual(1, lista.Count());
            service.BuyBaking("1", 2, now, 4);
            lista = service.GetEventsForTheClient("1");
            Assert.AreEqual(2, lista.Count());

        }



        [TestMethod]
		public void BuyBakingsTest()
		{
			Client client = new Client("Amadeus", "Gola", "5");
			service.AddClient(client);
			Baking baking = new Baking(86, 8.7, BakingType.bun);
			DateTime now = DateTime.Now;
			service.AddandUpdate(baking, 50);
			int stateThen = service.GetStateOfBaking(86);
			service.BuyBaking("5", 86 , now, 17);
			Assert.AreEqual(stateThen - 17, service.GetStateOfBaking(86));

		}

		[TestMethod]

		public void NewBatchTest()
        {
			Client supplier = new Client("Bobby", "Burger", "8");
            service.AddClient(supplier);
            Baking baking = new Baking(997, 4.20, BakingType.bagel);
			DateTime now = DateTime.Now;
            service.AddandUpdate(baking, 0);
			int stateThen = service.GetStateOfBaking(997);
			service.NewBatch("8", 997, now, 112);
			Assert.AreEqual(stateThen + 112, service.GetStateOfBaking(997));
		}

        [TestMethod]
        public void EventUserNewBatchTests()
        {

            DateTime now = DateTime.Now;
            service.NewBatch("1", 1, now, 5);
            Assert.AreEqual(service.GetAllEventsNumber(), 1);
            Assert.AreEqual(15, service.GetStateOfBaking(1));
            IEnumerable<Event> lista = service.GetEventsForTheClient("1");
            Assert.AreEqual(1, lista.Count());
           

        }
    }
}
