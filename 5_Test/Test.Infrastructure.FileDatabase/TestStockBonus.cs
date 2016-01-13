using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ore.Infrastructure.MarketData;
using Pitman.Infrastructure.FileDatabase;
using System.Linq;

namespace Test.Infrastructure.FileDatabase
{
    /// <summary>
    /// TestStockBonus 的摘要说明
    /// </summary>
    [TestClass]
    public class TestStockBonus
    {
        private IEnumerable<IStockBonus> ExampleStockBonus_600036()
        {
            List<IStockBonus> exmple = new List<IStockBonus>();

            exmple.Add(new StockBonusDataItem
            {
                ActualDispatchRate = 0,
                BAndHDividendAfterTax = 0,
                BAndHPreTaxDividend = 0,
                BonusRate = 0,
                CapitalStockBaseDate = new DateTime(2015, 7, 2),
                CapitalStockBeforeDispatch = 0,
                CapitalSurplusIncreaseRate = 0,
                Code = "600036",
                ConvertibleBondDate = new DateTime(0001, 1, 1),
                DateOfDeclaration = new DateTime(2015, 6, 25),
                Description = null,
                DispatchExpiryDate = new DateTime(0001, 1, 1),
                DispatchListingDate = new DateTime(0001, 1, 1),
                DispatchPrice = 0,
                DispatchRate = 0,
                DividendAfterTax = 6.37,
                ExchangeRate = 0,
                ExdividendDate = new DateTime(2015, 7, 3),
                ExpirationDate = new DateTime(0001, 1, 1),
                IncreaseRate = 0,
                IssuingObject = null,
                LastTradingDay = new DateTime(0001, 1, 1),
                Market = Market.Unknown,
                PreTaxDividend = 6.7,
                RegisterDate = new DateTime(2015, 7, 2),
                ReserveSurplusIncreaseRate = 0,
                ResolutionOfShareholdersMeetingDate = new DateTime(2015, 6, 20),
                ShareSplitCount = 0,
                ShortName = "招商银行",
                StartOrArriveDate = new DateTime(2015, 7, 3),
                TotalDispatch = 0,
                TransferredAllottedPrice = 0,
                TransferredAllottedRate = 0,
                Type = BounsType.ProfitSharing
            });

            exmple.Add(new StockBonusDataItem
            {
                ActualDispatchRate = 0,
                BAndHDividendAfterTax = 0,
                BAndHPreTaxDividend = 0,
                BonusRate = 0,
                CapitalStockBaseDate = new DateTime(2013, 12, 31),
                CapitalStockBeforeDispatch = 0,
                CapitalSurplusIncreaseRate = 0,
                Code = "600036",
                ConvertibleBondDate = new DateTime(0001, 1, 1),
                DateOfDeclaration = new DateTime(2014, 7, 3),
                Description = null,
                DispatchExpiryDate = new DateTime(0001, 1, 1),
                DispatchListingDate = new DateTime(0001, 1, 1),
                DispatchPrice = 0,
                DispatchRate = 0,
                DividendAfterTax = 5.89,
                ExchangeRate = 0,
                ExdividendDate = new DateTime(2014, 7, 11),
                ExpirationDate = new DateTime(0001, 1, 1),
                IncreaseRate = 0,
                IssuingObject = null,
                LastTradingDay = new DateTime(0001, 1, 1),
                Market = Market.Unknown,
                PreTaxDividend = 6.2,
                RegisterDate = new DateTime(2014, 7, 10),
                ReserveSurplusIncreaseRate = 0,
                ResolutionOfShareholdersMeetingDate = new DateTime(2014, 7, 1),
                ShareSplitCount = 0,
                ShortName = "招商银行",
                StartOrArriveDate = new DateTime(2014, 7, 11),
                TotalDispatch = 0,
                TransferredAllottedPrice = 0,
                TransferredAllottedRate = 0,
                Type = BounsType.ProfitSharing
            });

            exmple.Add(new StockBonusDataItem
            {
                ActualDispatchRate = 0,
                BAndHDividendAfterTax = 0,
                BAndHPreTaxDividend = 0,
                BonusRate = 0,
                CapitalStockBaseDate = new DateTime(2012, 12, 31),
                CapitalStockBeforeDispatch = 0,
                CapitalSurplusIncreaseRate = 0,
                Code = "600036",
                ConvertibleBondDate = new DateTime(0001, 1, 1),
                DateOfDeclaration = new DateTime(2013, 6, 4),
                Description = null,
                DispatchExpiryDate = new DateTime(0001, 1, 1),
                DispatchListingDate = new DateTime(0001, 1, 1),
                DispatchPrice = 0,
                DispatchRate = 0,
                DividendAfterTax = 5.99,
                ExchangeRate = 0,
                ExdividendDate = new DateTime(2013, 6, 13),
                ExpirationDate = new DateTime(0001, 1, 1),
                IncreaseRate = 0,
                IssuingObject = null,
                LastTradingDay = new DateTime(0001, 1, 1),
                Market = Market.Unknown,
                PreTaxDividend = 6.3,
                RegisterDate = new DateTime(2013, 6, 7),
                ReserveSurplusIncreaseRate = 0,
                ResolutionOfShareholdersMeetingDate = new DateTime(2013, 6, 1),
                ShareSplitCount = 0,
                ShortName = "招商银行",
                StartOrArriveDate = new DateTime(2013, 6, 19),
                TotalDispatch = 0,
                TransferredAllottedPrice = 0,
                TransferredAllottedRate = 0,
                Type = BounsType.ProfitSharing
            });

            exmple.Add(new StockBonusDataItem
            {
                ActualDispatchRate = 0,
                BAndHDividendAfterTax = 0,
                BAndHPreTaxDividend = 0,
                BonusRate = 0,
                CapitalStockBaseDate = new DateTime(2012, 6, 6),
                CapitalStockBeforeDispatch = 0,
                CapitalSurplusIncreaseRate = 0,
                Code = "600036",
                ConvertibleBondDate = new DateTime(0001, 1, 1),
                DateOfDeclaration = new DateTime(2012, 6, 1),
                Description = null,
                DispatchExpiryDate = new DateTime(0001, 1, 1),
                DispatchListingDate = new DateTime(0001, 1, 1),
                DispatchPrice = 0,
                DispatchRate = 0,
                DividendAfterTax = 3.78,
                ExchangeRate = 0,
                ExdividendDate = new DateTime(2012, 6, 7),
                ExpirationDate = new DateTime(0001, 1, 1),
                IncreaseRate = 0,
                IssuingObject = null,
                LastTradingDay = new DateTime(0001, 1, 1),
                Market = Market.Unknown,
                PreTaxDividend = 4.2,
                RegisterDate = new DateTime(2012, 6, 6),
                ReserveSurplusIncreaseRate = 0,
                ResolutionOfShareholdersMeetingDate = new DateTime(2012, 5, 31),
                ShareSplitCount = 0,
                ShortName = "招商银行",
                StartOrArriveDate = new DateTime(2012, 6, 13),
                TotalDispatch = 0,
                TransferredAllottedPrice = 0,
                TransferredAllottedRate = 0,
                Type = BounsType.ProfitSharing
            });

            exmple.Add(new StockBonusDataItem
            {
                ActualDispatchRate = 0,
                BAndHDividendAfterTax = 0,
                BAndHPreTaxDividend = 0,
                BonusRate = 0,
                CapitalStockBaseDate = new DateTime(2010, 12, 31),
                CapitalStockBeforeDispatch = 0,
                CapitalSurplusIncreaseRate = 0,
                Code = "600036",
                ConvertibleBondDate = new DateTime(0001, 1, 1),
                DateOfDeclaration = new DateTime(2011, 6, 3),
                Description = null,
                DispatchExpiryDate = new DateTime(0001, 1, 1),
                DispatchListingDate = new DateTime(0001, 1, 1),
                DispatchPrice = 0,
                DispatchRate = 0,
                DividendAfterTax = 2.61,
                ExchangeRate = 0,
                ExdividendDate = new DateTime(2011, 6, 10),
                ExpirationDate = new DateTime(0001, 1, 1),
                IncreaseRate = 0,
                IssuingObject = null,
                LastTradingDay = new DateTime(0001, 1, 1),
                Market = Market.Unknown,
                PreTaxDividend = 2.9,
                RegisterDate = new DateTime(2011, 6, 9),
                ReserveSurplusIncreaseRate = 0,
                ResolutionOfShareholdersMeetingDate = new DateTime(2011, 5, 31),
                ShareSplitCount = 0,
                ShortName = "招商银行",
                StartOrArriveDate = new DateTime(2011, 6, 16),
                TotalDispatch = 0,
                TransferredAllottedPrice = 0,
                TransferredAllottedRate = 0,
                Type = BounsType.ProfitSharing
            });

            return exmple;
        }

        private IEnumerable<IStockBonus> ExampleStockBonus_600518()
        {
            List<IStockBonus> exmple = new List<IStockBonus>();

            exmple.Add(new StockBonusDataItem
            {
                ActualDispatchRate = 0,
                BAndHDividendAfterTax = 0,
                BAndHPreTaxDividend = 0,
                BonusRate = 5,
                CapitalStockBaseDate = new DateTime(2014, 12, 31),
                CapitalStockBeforeDispatch = 0,
                CapitalSurplusIncreaseRate = 5,
                Code = "600518",
                ConvertibleBondDate = new DateTime(0001, 1, 1),
                DateOfDeclaration = new DateTime(2015, 6, 10),
                Description = null,
                DispatchExpiryDate = new DateTime(0001, 1, 1),
                DispatchListingDate = new DateTime(2015, 6, 17),
                DispatchPrice = 0,
                DispatchRate = 0,
                DividendAfterTax = 0,
                ExchangeRate = 0,
                ExdividendDate = new DateTime(2015, 6, 16),
                ExpirationDate = new DateTime(0001, 1, 1),
                IncreaseRate = 5,
                IssuingObject = null,
                LastTradingDay = new DateTime(0001, 1, 1),
                Market = Market.Unknown,
                PreTaxDividend = 3.2,
                RegisterDate = new DateTime(2015, 6, 15),
                ReserveSurplusIncreaseRate = 0,
                ResolutionOfShareholdersMeetingDate = new DateTime(2015, 6, 3),
                ShareSplitCount = 0,
                ShortName = "康美药业",
                StartOrArriveDate = new DateTime(2015, 6, 16),
                TotalDispatch = 0,
                TransferredAllottedPrice = 0,
                TransferredAllottedRate = 0,
                Type = BounsType.ProfitSharing
            });

            exmple.Add(new StockBonusDataItem
            {
                ActualDispatchRate = 0,
                BAndHDividendAfterTax = 0,
                BAndHPreTaxDividend = 0,
                BonusRate = 0,
                CapitalStockBaseDate = new DateTime(2013, 12, 31),
                CapitalStockBeforeDispatch = 0,
                CapitalSurplusIncreaseRate = 0,
                Code = "600518",
                ConvertibleBondDate = new DateTime(0001, 1, 1),
                DateOfDeclaration = new DateTime(2014, 7, 16),
                Description = null,
                DispatchExpiryDate = new DateTime(0001, 1, 1),
                DispatchListingDate = new DateTime(0001, 1, 1),
                DispatchPrice = 0,
                DispatchRate = 0,
                DividendAfterTax = 2.47,
                ExchangeRate = 0,
                ExdividendDate = new DateTime(2014, 7, 22),
                ExpirationDate = new DateTime(0001, 1, 1),
                IncreaseRate = 0,
                IssuingObject = null,
                LastTradingDay = new DateTime(0001, 1, 1),
                Market = Market.Unknown,
                PreTaxDividend = 2.6,
                RegisterDate = new DateTime(2014, 7, 21),
                ReserveSurplusIncreaseRate = 0,
                ResolutionOfShareholdersMeetingDate = new DateTime(2014, 5, 29),
                ShareSplitCount = 0,
                ShortName = "康美药业",
                StartOrArriveDate = new DateTime(2014, 7, 22),
                TotalDispatch = 0,
                TransferredAllottedPrice = 0,
                TransferredAllottedRate = 0,
                Type = BounsType.ProfitSharing
            });

            exmple.Add(new StockBonusDataItem
            {
                ActualDispatchRate = 0,
                BAndHDividendAfterTax = 0,
                BAndHPreTaxDividend = 0,
                BonusRate = 0,
                CapitalStockBaseDate = new DateTime(2012, 12, 31),
                CapitalStockBeforeDispatch = 0,
                CapitalSurplusIncreaseRate = 0,
                Code = "600518",
                ConvertibleBondDate = new DateTime(0001, 1, 1),
                DateOfDeclaration = new DateTime(2013, 7, 22),
                Description = null,
                DispatchExpiryDate = new DateTime(0001, 1, 1),
                DispatchListingDate = new DateTime(0001, 1, 1),
                DispatchPrice = 0,
                DispatchRate = 0,
                DividendAfterTax = 1.9,
                ExchangeRate = 0,
                ExdividendDate = new DateTime(2013, 7, 26),
                ExpirationDate = new DateTime(0001, 1, 1),
                IncreaseRate = 0,
                IssuingObject = null,
                LastTradingDay = new DateTime(0001, 1, 1),
                Market = Market.Unknown,
                PreTaxDividend = 2,
                RegisterDate = new DateTime(2013, 7, 25),
                ReserveSurplusIncreaseRate = 0,
                ResolutionOfShareholdersMeetingDate = new DateTime(2013, 6, 8),
                ShareSplitCount = 0,
                ShortName = "康美药业",
                StartOrArriveDate = new DateTime(2013, 8, 5),
                TotalDispatch = 0,
                TransferredAllottedPrice = 0,
                TransferredAllottedRate = 0,
                Type = BounsType.ProfitSharing
            });

            exmple.Add(new StockBonusDataItem
            {
                ActualDispatchRate = 0,
                BAndHDividendAfterTax = 0,
                BAndHPreTaxDividend = 0,
                BonusRate = 0,
                CapitalStockBaseDate = new DateTime(2011, 12, 31),
                CapitalStockBeforeDispatch = 0,
                CapitalSurplusIncreaseRate = 0,
                Code = "600518",
                ConvertibleBondDate = new DateTime(0001, 1, 1),
                DateOfDeclaration = new DateTime(2012, 5, 23),
                Description = null,
                DispatchExpiryDate = new DateTime(0001, 1, 1),
                DispatchListingDate = new DateTime(0001, 1, 1),
                DispatchPrice = 0,
                DispatchRate = 0,
                DividendAfterTax = 0.45,
                ExchangeRate = 0,
                ExdividendDate = new DateTime(2012, 5, 29),
                ExpirationDate = new DateTime(0001, 1, 1),
                IncreaseRate = 0,
                IssuingObject = null,
                LastTradingDay = new DateTime(0001, 1, 1),
                Market = Market.Unknown,
                PreTaxDividend = 0.5,
                RegisterDate = new DateTime(2012, 5, 28),
                ReserveSurplusIncreaseRate = 0,
                ResolutionOfShareholdersMeetingDate = new DateTime(2012, 5, 17),
                ShareSplitCount = 0,
                ShortName = "康美药业",
                StartOrArriveDate = new DateTime(2012, 6, 1),
                TotalDispatch = 0,
                TransferredAllottedPrice = 0,
                TransferredAllottedRate = 0,
                Type = BounsType.ProfitSharing
            });

            exmple.Add(new StockBonusDataItem
            {
                ActualDispatchRate = 0,
                BAndHDividendAfterTax = 0,
                BAndHPreTaxDividend = 0,
                BonusRate = 0,
                CapitalStockBaseDate = new DateTime(2011, 5, 24),
                CapitalStockBeforeDispatch = 0,
                CapitalSurplusIncreaseRate = 0,
                Code = "600518",
                ConvertibleBondDate = new DateTime(0001, 1, 1),
                DateOfDeclaration = new DateTime(2011, 5, 19),
                Description = null,
                DispatchExpiryDate = new DateTime(0001, 1, 1),
                DispatchListingDate = new DateTime(0001, 1, 1),
                DispatchPrice = 0,
                DispatchRate = 0,
                DividendAfterTax = 0.45,
                ExchangeRate = 0,
                ExdividendDate = new DateTime(2011, 5, 25),
                ExpirationDate = new DateTime(0001, 1, 1),
                IncreaseRate = 0,
                IssuingObject = null,
                LastTradingDay = new DateTime(0001, 1, 1),
                Market = Market.Unknown,
                PreTaxDividend = 0.5,
                RegisterDate = new DateTime(2011, 5, 24),
                ReserveSurplusIncreaseRate = 0,
                ResolutionOfShareholdersMeetingDate = new DateTime(2011, 5, 13),
                ShareSplitCount = 0,
                ShortName = "康美药业",
                StartOrArriveDate = new DateTime(2011, 5, 30),
                TotalDispatch = 0,
                TransferredAllottedPrice = 0,
                TransferredAllottedRate = 0,
                Type = BounsType.ProfitSharing
            });

            return exmple;
        }

        [TestMethod]
        public void TestMethod1()
        {
            IEnumerable<IStockBonus> stockBonus_600036 = ExampleStockBonus_600036();//招商银行
            IEnumerable<IStockBonus> stockBonus_600518 = ExampleStockBonus_600518();//康美药业

            var repository = new StockBonusDataRepository();
            if (!repository.Exists("600036"))
            {
                foreach (var item in stockBonus_600036)
                {
                    repository.Add(item);
                }
            }

            if (!repository.Exists("600518"))
            {
                foreach (var item in stockBonus_600518)
                {
                    repository.Add(item);
                }
            }

            var lst_600036 = repository.GetData("600036").ToList();
            Assert.IsNotNull(lst_600036);
            Assert.IsTrue(lst_600036.Count == 5);

            var lst_600518 = repository.GetData("600518").ToList();
            Assert.IsNotNull(lst_600518);
            Assert.IsTrue(lst_600518.Count == 5);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var repository = new StockBonusDataRepository();

            List<string> stockCodes = new List<string>();
            stockCodes.Add("600518");//康美药业
            stockCodes.Add("600036");//招商银行
            stockCodes.Add("600298");//安琪酵母
            stockCodes.Add("601933");//永辉超市
            stockCodes.Add("600660");//福耀玻璃
            stockCodes.Add("600196");//复星医药
            stockCodes.Add("300118");//东方日升
            stockCodes.Add("000800");//一汽轿车

            var lstStockBonus = repository.GetData(stockCodes).ToList();
            Assert.IsNotNull(lstStockBonus);
            Assert.IsTrue(lstStockBonus.Count == 10);

            var lstAll = repository.GetDataAll().ToList();
            Assert.IsNotNull(lstAll);
            Assert.IsTrue(lstAll.Count == 10);
        }
    }
}
