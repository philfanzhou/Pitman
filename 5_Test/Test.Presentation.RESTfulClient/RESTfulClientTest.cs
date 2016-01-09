using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pitman.Presentation.RESTfulClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Test.Presentation.RESTfulClient
{
    [TestClass]
    public class RESTfulClientTest
    {
        private string serverAddress = "http://localhost:9999";
        //private string serverAddress = "http://quantum1234.cloudapp.net:6688";

        [TestMethod]
        public void TestCollectionStatusClient()
        {
            var client = ClientFactory.CreateCollectionStatusClient(serverAddress);
            var result = client.GetAllServiceName().ToList();
            Assert.IsNotNull(result);

            var status = client.GetStatus(result[0]);
            Assert.IsNotNull(status);
        }

        [TestMethod]
        public void TestRealTimePriceClient()
        {
            var client = ClientFactory.CreateRealTimeClient(serverAddress);
            var result = client.GetLatest(new List<string>() { "600036"}).ToList();

            Assert.IsNotNull(result);
            Assert.AreEqual("600036", result[0].Code);
        }

        [TestMethod]
        public void TestKLineClient()
        {
            var client = ClientFactory.CreateKLineClient(serverAddress);
            var result = client.GetDay("600036", new DateTime(2015, 11, 10), new DateTime(2015, 11, 12)).ToList();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestIntradayClient()
        {
            var client = ClientFactory.CreateIntradayClient(serverAddress);
            //var result = client.GetData("600036", new DateTime(2015, 11, 10), new DateTime(2015, 11, 12)).ToList();
            var result = client.GetData("600036", DateTime.Now, DateTime.Now).ToList();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestSecurityClient()
        {
            var client = ClientFactory.CreateSecurityService(serverAddress);
            var result = client.GetAll().ToList();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestStockBonusClient()
        {
            var client = ClientFactory.CreateStockBonusClient(serverAddress);
            var result = client.Get("600036");

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestStockProfileClient()
        {
            var client = ClientFactory.CreateStockProfileClient(serverAddress);
            var result = client.Get("600036");

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestStockStructureClient()
        {
            var client = ClientFactory.CreateStockStructureClient(serverAddress);
            var result = client.Get("600036");

            Assert.IsNotNull(result);
        }
    }
}
