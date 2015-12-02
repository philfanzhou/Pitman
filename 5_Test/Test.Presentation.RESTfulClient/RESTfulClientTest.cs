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
            var client = ClientFactory.CreateRealTimePrice(serverAddress);
            var result = client.GetLatest(new List<string>() { "600036"}).ToList();

            Assert.IsNotNull(result);
            Assert.AreEqual("600036", result[0].Code);
        }

        [TestMethod]
        public void Test1MinuteDataClient()
        {
            var client = ClientFactory.CreateHistoryPriceClient(serverAddress);
            var result = client.GetBy1Minute("600036", new DateTime(2015, 11, 10), new DateTime(2015, 11, 12)).ToList();

            Assert.IsNotNull(result);
        }
    }
}
