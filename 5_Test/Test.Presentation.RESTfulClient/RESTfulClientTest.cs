using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ore.Infrastructure.MarketData;
using Pitman.RESTful.Client;
using System;
using System.Linq;

namespace Test.Presentation.RESTfulClient
{
    [TestClass]
    public class RESTfulClientTest
    {
        //private string serverAddress = "http://localhost:9999/api";
        private string serverAddress = "http://quantum1234.cloudapp.net:6688/api";

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

        [TestMethod]
        public void TestParticipationClient()
        {
            using (var client = new ClientApi(serverAddress))
            {
                var result = client.GetParticipation("600036").ToList()[0];

                Assert.IsNotNull(result);
                Assert.AreEqual(new DateTime(1999,9,9,9,9,9), result.Time);
            }
        }

        #region KLine
        [TestMethod]
        public void TestKLineDayClient()
        {
            using (var client = new ClientApi(serverAddress))
            {
                var result = client.GetStockKLine(
                    KLineType.Day, "600000", 
                    new DateTime(2015, 11, 10), DateTime.Now).ToList();

                Assert.IsNotNull(result);
                Assert.IsTrue(result[0].Open - 18 < 0.00000001);

                result = client.GetStockKLine(
                    KLineType.Day, "600000",
                    new DateTime(1990, 1, 1), DateTime.Now).ToList();
            }
        }

        [TestMethod]
        public void TestKLineWeekClient()
        {
            using (var client = new ClientApi(serverAddress))
            {
                var result = client.GetStockKLine(
                    KLineType.Week, "600036",
                    new DateTime(2015, 11, 10), new DateTime(2015, 11, 12)).ToList();

                Assert.IsNotNull(result);
                Assert.IsTrue(result[0].Open - 22.22 < 0.00000001);
            }
        }

        [TestMethod]
        public void TestKLineMonthClient()
        {
            using (var client = new ClientApi(serverAddress))
            {
                var result = client.GetStockKLine(
                    KLineType.Month, "600036",
                    new DateTime(2015, 11, 10), new DateTime(2015, 11, 12)).ToList();

                Assert.IsNotNull(result);
                Assert.IsTrue(result[0].Open - 33.33 < 0.00000001);
            }
        }

        [TestMethod]
        public void TestKLineQuarterClient()
        {
            using (var client = new ClientApi(serverAddress))
            {
                var result = client.GetStockKLine(
                    KLineType.Quarter, "600036",
                    new DateTime(2015, 11, 10), new DateTime(2015, 11, 12)).ToList();

                Assert.IsNotNull(result);
                Assert.IsTrue(result[0].Open - 44.44 < 0.00000001);
            }
        }

        [TestMethod]
        public void TestKLineYearClient()
        {
            using (var client = new ClientApi(serverAddress))
            {
                var result = client.GetStockKLine(
                    KLineType.Year, "600036",
                    new DateTime(2015, 11, 10), new DateTime(2015, 11, 12)).ToList();

                Assert.IsNotNull(result);
                Assert.IsTrue(result[0].Open - 55.55 < 0.00000001);
            }
        }

        [TestMethod]
        public void TestKLineMin1Client()
        {
            using (var client = new ClientApi(serverAddress))
            {
                var result = client.GetStockKLine(
                    KLineType.Min1, "600036",
                    new DateTime(2015, 11, 10), new DateTime(2015, 11, 12)).ToList();

                Assert.IsNotNull(result);
                Assert.IsTrue(result[0].Open - 32.09 < 0.00000001);
            }
        }

        [TestMethod]
        public void TestKLineMin5Client()
        {
            using (var client = new ClientApi(serverAddress))
            {
                var result = client.GetStockKLine(
                    KLineType.Min5, "600036",
                    new DateTime(2015, 11, 10), new DateTime(2015, 11, 12)).ToList();

                Assert.IsNotNull(result);
                Assert.IsTrue(result[0].Open - 8.88 < 0.00000001);
            }
        }

        [TestMethod]
        public void TestKLineMin15Client()
        {
            using (var client = new ClientApi(serverAddress))
            {
                var result = client.GetStockKLine(
                    KLineType.Min15, "600036",
                    new DateTime(2015, 11, 10), new DateTime(2015, 11, 12)).ToList();

                Assert.IsNotNull(result);
                Assert.IsTrue(result[0].Open - 66.66 < 0.00000001);
            }
        }

        [TestMethod]
        public void TestKLineMin30Client()
        {
            using (var client = new ClientApi(serverAddress))
            {
                var result = client.GetStockKLine(
                    KLineType.Min30, "600036",
                    new DateTime(2015, 11, 10), new DateTime(2015, 11, 12)).ToList();

                Assert.IsNotNull(result);
                Assert.IsTrue(result[0].Open - 77.77 < 0.00000001);
            }
        }

        [TestMethod]
        public void TestKLineMin60Client()
        {
            using (var client = new ClientApi(serverAddress))
            {
                var result = client.GetStockKLine(
                    KLineType.Min60, "600036",
                    new DateTime(2015, 11, 10), new DateTime(2015, 11, 12)).ToList();

                Assert.IsNotNull(result);
                Assert.IsTrue(result[0].Open - 88.88 < 0.00000001);
            }
        }
        #endregion
    }
}
