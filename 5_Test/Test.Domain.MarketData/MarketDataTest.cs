using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pitman.Infrastructure.RealTimeData.Repository;

namespace Test.Domain.MarketData
{
    [TestClass]
    public class MarketDataTest
    {
        [TestMethod]
        public void TestStockCodeStruct()
        {
            StockCode stockCode = new StockCode();
            stockCode.Code = null;
            Assert.IsNull(stockCode.Code);

            stockCode.Code = string.Empty;
            Assert.AreEqual(string.Empty, stockCode.Code);

            stockCode.Code = "      ";
            Assert.AreEqual("      ", stockCode.Code);

            stockCode.Code = "600036";
            Assert.AreEqual("600036", stockCode.Code);

            stockCode.Code = "Aa345&";
            Assert.AreEqual("Aa345&", stockCode.Code);

            stockCode.Code = "测试";
            Assert.AreEqual("测试", stockCode.Code);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestStockCodeStruct1()
        {
            StockCode stockCode = new StockCode();
            stockCode.Code = "测试超过了长度的字符串";
        }
    }
}
