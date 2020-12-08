using System;
using DataLayer;
using DataLayer.DataGeneration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestingData
{
    [TestClass]
    public class EmptyGenerationTests
    {
        private DataContext our_shop;
        private IDataRepository repository;
        private IGenerator generator;


        [TestInitialize]
        public void Initialize()
        {
            our_shop = new DataContext();
            repository = new DataRepository(our_shop);
            generator = new EmptyGenerator();
            generator.GenarateData(our_shop);
        }


        [TestMethod]
        public void TestMethod1()
        {
            
            Assert.AreEqual(0,repository.GetBakingsNumber());

        }
    }
}
