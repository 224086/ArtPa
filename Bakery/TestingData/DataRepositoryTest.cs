using System;
using DataLayer;
using DataLayer.DataGeneration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestingData
{
    [TestClass]
    public class DataRepositoryTest
    {

        private DataContext our_shop;
        private IDataRepository repository;
        private IGenerator generator;


        [TestInitialize]
        public void Initialize()
        {
            our_shop = new DataContext();
            repository = new DataRepository(our_shop);
            generator = new FixedGenerator();
            generator.GenarateData(our_shop);
        }


        [TestMethod]
        public void AddAndGetClient()
        {
            Client c = new Client("Paweł", "Burczyk", "7");
            Assert.AreEqual(repository.GetAllClientsNumber(), 4);
            repository.AddClient(c);
            Assert.AreEqual(repository.GetAllClientsNumber(), 5);
            Client temp = repository.GetClient("7");
            Assert.AreEqual(temp, c);
        }

        [TestMethod]
        public void DeleteClientCorrect()
        {

            repository.DeleteClient("1");
            Assert.AreEqual(repository.GetAllClientsNumber(), 3);

        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void DeleteClientException()
        {

            repository.DeleteClient("POLOP");
            Assert.AreEqual(repository.GetAllClientsNumber(), 3);

        }

        [TestMethod]
        public void UpdateClientInfo()
        {
            Client temp = repository.GetClient("1");
            Assert.AreEqual("Artur", temp.FirstName);
            Client c = new Client("Adam", "Rojek", "1");
            repository.UpdateClientsInfo(c);
            temp = repository.GetClient("1");
            Assert.AreEqual("Adam", temp.FirstName);
        }


        [TestMethod]
        public void AddAndGetBaking()
        {
            Baking c = new Baking(999, 12.5, BakingType.bagel);
            Assert.AreEqual(repository.GetBakingsNumber(), 4);
            repository.AddBaking(c);
            Assert.AreEqual(repository.GetBakingsNumber(), 5);
            Baking temp = repository.GetBaking(999);
            Assert.AreEqual(temp, c);
        }

        [TestMethod]
        public void DeleteBakingCorrect()
        {

            repository.DeleteBaking(2);
            Assert.AreEqual(repository.GetBakingsNumber(), 3);

        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void DeleteBakingException()
        {

            repository.DeleteBaking(12345);
            Assert.AreEqual(repository.GetAllClientsNumber(),4);

        }

        [TestMethod]
        public void UpdateBakingInfo()
        {
            Baking temp = repository.GetBaking(2);
            Assert.AreEqual(3.1, temp.Price);
            Baking c = new Baking(2, 3.5, BakingType.bagel);
            repository.UpdateBakingInfo(c);
            temp = repository.GetBaking(2);
            Assert.AreEqual(3.5, temp.Price);
        }

        [TestMethod]
        public void EventTests()
        {
            Client temp = repository.GetClient("1");
            DateTime now = DateTime.Now;
            Event b = new BuyingEvent("b1", repository.GetState(), temp, now);
            repository.AddEvent(b);
            Assert.AreEqual(repository.GetAllEventsNumber(), 1);

        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void EventTestsDeleteException()
        {
            Client temp = repository.GetClient("1");
            DateTime now = DateTime.Now;
            Event b = new BuyingEvent("b1", repository.GetState(), temp, now);
            repository.AddEvent(b);
            Assert.AreEqual(repository.GetAllEventsNumber(), 1);
            repository.DeleteEvent("chlep");

        }

        [TestMethod]
        public void EventCorrectDeleteTests()
        {
            Client temp = repository.GetClient("1");
            DateTime now = DateTime.Now;
            Event b = new BuyingEvent("b1", repository.GetState(), temp, now);
            repository.AddEvent(b);
            Assert.AreEqual(repository.GetAllEventsNumber(), 1);
            repository.DeleteEvent("b1");
            Assert.AreEqual(repository.GetAllEventsNumber(), 0);

        }


        [TestMethod]
        public void StatesTest()
        {
            Assert.AreEqual(repository.GetBakingState(1), 10);
            repository.UpdateBakingStateInfo(1, 7);
            Assert.AreEqual(repository.GetBakingState(1), 7);

        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void ExceptionNoBakingToDeleteTest()
        {
            Assert.AreEqual(repository.GetBakingState(1), 10);
            repository.DeleteOneBakingState(54587);


        }




    }
}
