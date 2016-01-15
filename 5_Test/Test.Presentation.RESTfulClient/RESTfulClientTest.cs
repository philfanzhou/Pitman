using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pitman.RESTful.Client;
using System;
using System.Linq;

namespace Test.Presentation.RESTfulClient
{
    [TestClass]
    public class RESTfulClientTest
    {
        private string serverAddress = "http://localhost:9999/api";
        //private string serverAddress = "http://quantum1234.cloudapp.net:6688/api";

        [TestMethod]
        public void TestCollectionStatusClient()
        {
            using (var client = new ClientApi(serverAddress))
            {
                var result = client.GetAllServiceName().ToList();
                Assert.IsNotNull(result);

                var status = client.GetServiceStatus(result[0]);
                Assert.IsNotNull(status);
            }
        }

        [TestMethod]
        public void TestKLineClient()
        {
            using (var client = new ClientApi(serverAddress))
            {
                var result = client.GetStockKLine_Day("600036", new DateTime(2015, 11, 10), new DateTime(2015, 11, 12)).ToList();

                Assert.IsNotNull(result);
            }
        }

        [TestMethod]
        public void TestSecurityClient()
        {
            using (var client = new ClientApi(serverAddress))
            {
                var result = client.GetAllSecurity().ToList();

                Assert.IsNotNull(result);
            }
        }

        [TestMethod]
        public void TestStockBonusClient()
        {
            using (var client = new ClientApi(serverAddress))
            {
                var result = client.GetStockBonus("600036");

                Assert.IsNotNull(result);
            }
        }

        [TestMethod]
        public void TestStockProfileClient()
        {
            using (var client = new ClientApi(serverAddress))
            {
                var result = client.GetStockProfile("600036");

                Assert.IsNotNull(result);
            }
        }

        [TestMethod]
        public void TestStockStructureClient()
        {
            using (var client = new ClientApi(serverAddress))
            {
                var result = client.GetStockStructure("600036");

                Assert.IsNotNull(result);
            }
        }
    }
}
