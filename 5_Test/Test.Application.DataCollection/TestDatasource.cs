using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ore.Infrastructure.MarketData;
using System.Collections.Generic;
using Pitman.Application.DataCollection;
using System.Linq;

namespace Test.Application.DataCollection
{
    [TestClass]
    public class TestDatasource
    {
        [TestMethod]
        public void TestRealTimeInfo()
        {
            List<IStockRealTime> realTimes = RealTime.GetDataFromApi(new[] { "600036" }).ToList();
            Assert.IsNotNull(realTimes);
        }

        [TestMethod]
        public void TestSecurityInfo()
        {
            List<ISecurity> securities = Security.GetDataFromApi().ToList();
            Assert.IsNotNull(securities);
        }

        [TestMethod]
        public void TestBonusInfo()
        {
            List<IStockBonus> result = StockBonus.GetDataFromApi("600036").ToList();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestProfileInfo()
        {
            IStockProfile result = StockProfile.GetDataFromApi("600036");
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestStructureInfo()
        {
            List<IStockStructure> result = StockStructure.GetDataFromApi("600036").ToList();
            Assert.IsNotNull(result);
        }
    }
}
