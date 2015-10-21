using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pitman.Infrastructure.FileDatabase;
using Ore.Infrastructure.MarketData.DataSource.Sina;
using Ore.Infrastructure.MarketData;

namespace Test.Infrastructure.FileDatabase
{
    [TestClass]
    public class TestRealTime
    {
        private SecurityInfo GetSecurityInfo()
        {
            SecurityInfo info = new SecurityInfo();
            info.Code = "600036";
            info.Market = Market.XSHG;
            info.ShortName = "招商银行";
            info.Type = SecurityType.Sotck;

            return info;
        }

        private void CompareDataField(IStockRealTimePrice expected, IStockRealTimePrice actual)
        {
            Assert.AreEqual(expected.Amount, actual.Amount);
            Assert.AreEqual(expected.Buy1Price, actual.Buy1Price);
            Assert.AreEqual(expected.Buy1Volume, actual.Buy1Volume);
            Assert.AreEqual(expected.Buy2Price, actual.Buy2Price);
            Assert.AreEqual(expected.Buy2Volume, actual.Buy2Volume);
            Assert.AreEqual(expected.Buy3Price, actual.Buy3Price);
            Assert.AreEqual(expected.Buy3Volume, actual.Buy3Volume);
            Assert.AreEqual(expected.Buy4Price, actual.Buy4Price);
            Assert.AreEqual(expected.Buy4Volume, actual.Buy4Volume);
            Assert.AreEqual(expected.Buy5Price, actual.Buy5Price);
            Assert.AreEqual(expected.Buy5Volume, actual.Buy5Volume);
            Assert.AreEqual(expected.Code, actual.Code);
            Assert.AreEqual(expected.Current, actual.Current);
            Assert.AreEqual(expected.High, actual.High);
            Assert.AreEqual(expected.Low, actual.Low);
            Assert.AreEqual(expected.Market, actual.Market);
            Assert.AreEqual(expected.Sell1Price, actual.Sell1Price);
            Assert.AreEqual(expected.Sell1Volume, actual.Sell1Volume);
            Assert.AreEqual(expected.Sell2Price, actual.Sell2Price);
            Assert.AreEqual(expected.Sell2Volume, actual.Sell2Volume);
            Assert.AreEqual(expected.Sell3Price, actual.Sell3Price);
            Assert.AreEqual(expected.Sell3Volume, actual.Sell3Volume);
            Assert.AreEqual(expected.Sell4Price, actual.Sell4Price);
            Assert.AreEqual(expected.Sell4Volume, actual.Sell4Volume);
            Assert.AreEqual(expected.Sell5Price, actual.Sell5Price);
            Assert.AreEqual(expected.Sell5Volume, actual.Sell5Volume);
            Assert.AreEqual(expected.ShortName, actual.ShortName);
            Assert.AreEqual(expected.Time, actual.Time);
            Assert.AreEqual(expected.TodayOpen, actual.TodayOpen);
            Assert.AreEqual(expected.Volume, actual.Volume);
            Assert.AreEqual(expected.YesterdayClose, actual.YesterdayClose);
        }

        [TestMethod]
        public void TestAddRealTimeData()
        {
            var api = new SinaRealTimePriceAPI();
            var repository = new RealTimeDataRepository();

            var securityInfo = GetSecurityInfo();
            var expected = api.GetData(securityInfo);
            repository.Add(expected);

            repository = new RealTimeDataRepository();
            var actual = repository.GetOneDayData(securityInfo.Code, DateTime.Now).Last();

            CompareDataField(expected, actual);
        }
    }
}
