using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pitman.Application.MarketData;
using Ore.Infrastructure.MarketData;
using System.Collections.Generic;

namespace Test.Application.MarketData
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetIntradayData()
        {
            var appService = new IntradayAppService();
            List<IStockIntraday> intradayList = appService.GetData("600036", new DateTime(2015, 11, 10), new DateTime(2015, 11, 13)).ToList();
        }
    }
}
