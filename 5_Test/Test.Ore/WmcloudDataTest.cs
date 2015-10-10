using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ore.Infrastructure.MarketData;
using Ore.Infrastructure.MarketData.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Test.Ore
{
    [TestClass]
    public class WmcloudDataTest
    {
        [TestMethod]
        public void TestGetBasicInfo()
        {
            IProfileReader reader = new WmcloudDataReader();
            List<ISecurityProfile> infoList = reader.GetAll().ToList();

            Assert.IsNotNull(infoList);
            Assert.IsTrue(infoList.Count > 0);

            var dataItem = infoList[0];
            var equ = dataItem as Equ;
            Assert.IsNotNull(dataItem);

            Assert.AreEqual("主板", equ.ListSector);
            Assert.AreEqual(1, equ.ListSectorCD);
            Assert.AreEqual(null, equ.delistDate);
            Assert.AreEqual("沪深A股", equ.equType);
            Assert.AreEqual("A", equ.equTypeCD);
            Assert.AreEqual("CHN", equ.exCountryCD);
            Assert.AreEqual("XSHE", equ.exchangeCD);
            Assert.AreEqual("1991-04-03", equ.listDate);
            Assert.AreEqual("L", equ.listStatusCD);
            Assert.IsTrue(equ.nonrestFloatShares - 11804054579 < 0.000001);
            Assert.IsTrue(equ.nonrestfloatA - 11804054579 < 0.000001);
            Assert.IsTrue(equ.officeAddr.Length > 0);
            Assert.AreEqual("2", equ.partyID);
            Assert.IsTrue(equ.primeOperating.Length > 0);
            Assert.IsTrue(equ.secFullName.Length > 0);
            Assert.AreEqual("000001.XSHE", equ.secID);
            Assert.AreEqual("平安银行", equ.secShortName);
            Assert.AreEqual("000001", equ.ticker);
            Assert.IsTrue(equ.totalShares - 14308676139 < 0.000001);
            Assert.AreEqual("CNY", equ.transCurrCD);
            Assert.AreEqual("2015-06-30", equ.endDate);
            Assert.IsTrue(equ.TShEquity - 150880000000 < 0.000001);
            
            Assert.AreEqual(Exchange.XSHE, dataItem.Exchange);
            Assert.AreEqual(new DateTime(1991,4,3), dataItem.ListDate);
            Assert.AreEqual(ListStatus.List, dataItem.ListStatus);
            Assert.IsTrue(dataItem.NonrestFloatShares - 11804054579 < 0.000001);
            Assert.IsTrue(dataItem.OfficeAddress.Length > 0);
            Assert.IsTrue(dataItem.PrimeBusiness.Length > 0);
            Assert.IsTrue(dataItem.FullName.Length > 0);
            Assert.AreEqual("000001.XSHE", dataItem.SecurityID);
            Assert.AreEqual("平安银行", dataItem.ShortName);
            Assert.AreEqual("000001", dataItem.SecurityCode);
            Assert.IsTrue(dataItem.TotalShares - 14308676139 < 0.000001);
            Assert.AreEqual(new DateTime(2015, 6, 30), dataItem.FinancialReportDate);
            Assert.IsTrue(dataItem.ShareholderEquity - 150880000000 < 0.000001);
        }

        [TestMethod]
        public void TestGetDailyStockData()
        {
            WmcloudDataReader reader = new WmcloudDataReader();
            List<MktEqud> dailyStockDataList
                = reader.GetDailyStockData("600036", 
                new DateTime(2015, 9, 28), 
                new DateTime(2015, 9, 30)).ToList();

            Assert.IsNotNull(dailyStockDataList);
            Assert.AreEqual(3, dailyStockDataList.Count);

            var dataItem = dailyStockDataList[2];
            Assert.IsTrue(dataItem.PB - 1.3496 < 0.000001);
            Assert.IsTrue(dataItem.PE - 7.6702 < 0.000001);
            Assert.IsTrue(dataItem.PE1 - 6.7952 < 0.000001);
            Assert.IsTrue(dataItem.accumAdjFactor - 1 < 0.000001);
            Assert.IsTrue(dataItem.actPreClosePrice - 17.44 < 0.000001);
            Assert.IsTrue(dataItem.closePrice - 17.77 < 0.000001);
            Assert.IsTrue(dataItem.dealAmount - 24881 < 0.000001);
            Assert.AreEqual("XSHG", dataItem.exchangeCD);
            Assert.IsTrue(dataItem.highestPrice - 17.91 < 0.000001);
            Assert.IsTrue(dataItem.lowestPrice - 17.39 < 0.000001);
            Assert.IsTrue(dataItem.marketValue - 448156656329.77 < 0.000001);
            Assert.IsTrue(dataItem.negMarketValue - 366576342503.33 < 0.000001);
            Assert.IsTrue(dataItem.openPrice - 17.5 < 0.000001);
            Assert.IsTrue(dataItem.preClosePrice - 17.44 < 0.000001);
            Assert.AreEqual("600036.XSHG", dataItem.secID);
            Assert.AreEqual("招商银行", dataItem.secShortName);
            Assert.AreEqual("600036", dataItem.ticker);
            Assert.AreEqual("2015-09-30", dataItem.tradeDate);
            Assert.IsTrue(dataItem.turnoverRate - 0.0027 < 0.000001);
            Assert.IsTrue(dataItem.turnoverValue - 972151314 < 0.000001);
            Assert.IsTrue(dataItem.turnoverVol - 54828280 < 0.000001);

        }

        [TestMethod]
        public void TestGetDailyIndexData()
        {
            WmcloudDataReader reader = new WmcloudDataReader();
            List<MktIdxd> dailyIndexDataList
                = reader.GetDailyIndexData("000001", 
                new DateTime(2015, 9, 28), 
                new DateTime(2015, 9, 30)).ToList();

            Assert.IsNotNull(dailyIndexDataList);
            Assert.AreEqual(3, dailyIndexDataList.Count);

            var dataItem = dailyIndexDataList[2];
            Assert.IsTrue(dataItem.CHG - 14.644 < 0.000001);
            Assert.IsTrue(dataItem.CHGPct - 0.00482 < 0.00000001);
            Assert.IsTrue(dataItem.closeIndex - 3052.781 < 0.00000001);
            Assert.AreEqual("XSHG", dataItem.exchangeCD);
            Assert.IsTrue(dataItem.highestIndex - 3073.3 < 0.00000001);
            Assert.AreEqual("000001.ZICN", dataItem.indexID);
            Assert.IsTrue(dataItem.lowestIndex - 3039.742 < 0.00000001);
            Assert.IsTrue(dataItem.openIndex - 3052.841 < 0.00000001);
            Assert.AreEqual("上海证券交易所", dataItem.porgFullName);
            Assert.IsTrue(dataItem.preCloseIndex - 3038.137 < 0.00000001);
            Assert.AreEqual("上证综指", dataItem.secShortName);
            Assert.AreEqual("000001", dataItem.ticker);
            Assert.AreEqual("2015-09-30", dataItem.tradeDate);
            Assert.IsTrue(dataItem.turnoverValue - 156569197540.3 < 0.000001);
            Assert.IsTrue(dataItem.turnoverVol - 14664244900 < 0.000001);
        }
    }
}
