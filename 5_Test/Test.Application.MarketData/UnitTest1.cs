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
            List<IStockIntraday> intradayList = appService.GetData("600036", new DateTime(2015, 12, 7), new DateTime(2015, 12, 7)).ToList();
        }

        [TestMethod]
        public void TestGet1MinuteKLine()
        {
            var appService = new KLineAppService();
            List<IStockKLine> kLineList = appService.GetBy1Minute("600036", new DateTime(2015, 12, 7), new DateTime(2015, 12, 7)).ToList();
        }
    }
}
