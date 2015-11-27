using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pitman.Infrastructure.FileDatabase;
using Ore.Infrastructure.MarketData.DataSource.Sina;
using Ore.Infrastructure.MarketData;
using System.Collections.Generic;

namespace Test.Infrastructure.FileDatabase
{
    [TestClass]
    public class TestRealTime
    {
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

        //[TestMethod]
        //public void TestAddRealTimeData()
        //{
        //    var api = new SinaRealTimePriceAPI();
        //    var repository = new RealTimeDataRepository();

        //    var securityInfo = GetSecurityInfo();
        //    var expected = api.GetData(securityInfo);
        //    repository.Add(expected);

        //    repository = new RealTimeDataRepository();
        //    var actual = repository.GetOneDayData(securityInfo.Code, DateTime.Now).Last();

        //    CompareDataField(expected, actual);
        //}

        //[TestMethod]
        //public void TestReadData()
        //{
        //    var securityInfo = GetSecurityInfo();
        //    var repository = new RealTimeDataRepository();
        //    var actual = repository.GetOneDayData(securityInfo.Code, new DateTime(2015, 11, 2)).ToList();

        //    Assert.IsNotNull(actual);
        //    Assert.IsTrue(actual.Count == 3003);
        //    Assert.IsTrue(actual[0].Current == 0);
        //    Assert.IsTrue(actual[3002].Current == 17.83);
        //}

        [TestMethod]
        public void TestGetData()
        {
            var repository = new RealTimeDataRepository();
            var actual = repository.GetData("600036", new DateTime(2015, 11, 03), new DateTime(2015, 11, 08)).ToList();
            Assert.IsNotNull(actual);
        }


        [TestMethod]
        public void TestPathHelper()
        {
            var result = PathHelper.GetFilePath("600036", new DateTime(2015, 11, 5), new DateTime(2015, 11, 16));

            List<string> expected = new List<string>();
            string folder = Environment.CurrentDirectory + @"\Data\RealTimeData\Shanghai\600036\";
            expected.Add(folder + "20151105.dat");
            expected.Add(folder + "20151106.dat");
            expected.Add(folder + "20151107.dat");
            expected.Add(folder + "20151108.dat");
            expected.Add(folder + "20151109.dat");
            expected.Add(folder + "20151110.dat");
            expected.Add(folder + "20151111.dat");
            expected.Add(folder + "20151112.dat");
            expected.Add(folder + "20151113.dat");
            expected.Add(folder + "20151114.dat");
            expected.Add(folder + "20151115.dat");
            expected.Add(folder + "20151116.dat");

            List<string> actual = result.ToList();
            Assert.AreEqual(expected.Count, actual.Count);
            for(int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }
    }
}
