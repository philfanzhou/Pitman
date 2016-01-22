using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ore.Infrastructure.MarketData;
using Pitman.Application.MarketData;
using Pitman.Distributed.Dto;
using Pitman.Domain.FileStructure;

namespace Test.Application.MarketData
{
    [TestClass]
    public class StockBonusTest
    {
        private StockBonusDto example()
        {
            return new StockBonusDto()
            {
                ActualDispatchRate = 0,
                BAndHDividendAfterTax = 0,
                BAndHPreTaxDividend = 0,
                BonusRate = 0,
                CapitalStockBeforeDispatch = 0,
                CapitalSurplusIncreaseRate = 0,
                DispatchPrice = 0,
                DispatchRate = 0,
                DividendAfterTax = 0,
                ExchangeRate = 0,
                IncreaseRate = 0,
                TotalDispatch = 0,
                TransferredAllottedPrice = 0,
                TransferredAllottedRate = 0,
                ShareSplitCount = 0,
                PreTaxDividend = 0,
                ReserveSurplusIncreaseRate = 0,
                Description = "Example Description",
                IssuingObject = "Example IssuingObject",
                Type = BounsType.ProfitSharing,

                CapitalStockBaseDate = new DateTime(2015, 7, 2),
                ConvertibleBondDate = new DateTime(2015, 7, 2),
                DateOfDeclaration = new DateTime(2015, 7, 2),
                DispatchExpiryDate = new DateTime(2015, 7, 2),
                DispatchListingDate = new DateTime(2015, 7, 2),
                ExdividendDate = new DateTime(2015, 7, 2),
                ExpirationDate = new DateTime(2015, 7, 2),
                LastTradingDay = new DateTime(2015, 7, 2),
                RegisterDate = new DateTime(2015, 7, 2),
                ResolutionOfShareholdersMeetingDate = new DateTime(2015, 7, 2),
                StartOrArriveDate = new DateTime(2015, 7, 2),
            };
    }

        [TestMethod]
        public void TestMethod1()
        {
            string stockCode = "600036";
            StockBonusDto insertData = example();

            string dataFile = DataFiles.GetStockBonusFile(stockCode);
            if (File.Exists(dataFile))
            {
                File.Delete(dataFile);
            }

            var appService = new StockBonusAppService();

            // 测试插入数据
            appService.Add(stockCode, insertData);
            Assert.IsTrue(appService.Exists(stockCode, insertData));

            // 测试更新数据
            insertData.PreTaxDividend = 100;
            appService.Update(stockCode, insertData);

            insertData.Description = "测试测试";
            appService.Update(stockCode, insertData);

            Assert.IsTrue(appService.Exists(stockCode, insertData));

            // 测试读取数据
            var securities = appService.Get(stockCode).ToList();
            Assert.IsNotNull(securities);
            Assert.IsTrue(securities.Count == 1);
            Assert.AreEqual(insertData.DateOfDeclaration, securities[0].DateOfDeclaration);
            Assert.AreEqual(insertData.PreTaxDividend, securities[0].PreTaxDividend);
            Assert.AreEqual(insertData.Description, securities[0].Description);
        }
    }
}
