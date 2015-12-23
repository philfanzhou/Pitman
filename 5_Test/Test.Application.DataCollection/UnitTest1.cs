using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ore.Infrastructure.MarketData;
using System.Collections.Generic;
using Pitman.Application.DataCollection;
using System.Linq;

namespace Test.Application.DataCollection
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSecurityInfo()
        {
            List<ISecurity> securities = SecurityDatasource.GetAll().ToList();
            Assert.IsNotNull(securities);
        }

        [TestMethod]
        public void TestBonusInfo()
        {
            List<IStockBonus> result = FundamentalDatasource.GetBonus("600036").ToList();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestProfileInfo()
        {
            IStockProfile result = FundamentalDatasource.GetProfile("600036");
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestStructureInfo()
        {
            List<IStockStructure> result = FundamentalDatasource.GetStructure("600036").ToList();
            Assert.IsNotNull(result);
        }
    }
}
