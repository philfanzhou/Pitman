using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ore.Infrastructure.MarketData;
using Pitman.Infrastructure.FileDatabase;

namespace Test.Infrastructure.FileDatabase
{
    [TestClass]
    public class TestStockStructure
    {
        //count = 8
        private List<IStockStructure> ExampleStockStructure_600036()
        {
            List<IStockStructure> examples = new List<IStockStructure>();

            examples.Add(new StockStructureDataItem
            {
                Code = "600036",
                DateOfChange = new DateTime(2013, 10, 2),
                DateOfDeclaration = new DateTime(2013, 9, 27),
                DomesticLegalPersonShares = 0,
                DomesticSponsorsShares = 0,
                ExecutiveShares = 0,
                FundsShares = 0,
                GeneralLegalPersonShares = 0,
                InternalStaffShares = 0,
                Market = Market.Unknown,
                PreferredStock = 0,
                RaiseLegalPersonShares = 0,
                Reason = null,
                RestrictedSharesA = 0,
                RestrictedSharesB = 0,
                SharesA = 2062894.443,
                SharesB = 0,
                SharesH = 459090.117,
                ShortName = "招商银行",
                StateOwnedLegalPersonShares = 0,
                StateShares = 0,
                StrategicInvestorsShares = 0,
                TotalShares = 2521984.56,
                TransferredAllottedShares = 0
            });

            examples.Add(new StockStructureDataItem
            {
                Code = "600036",
                DateOfChange = new DateTime(2013, 9, 11),
                DateOfDeclaration = new DateTime(2013, 9, 9),
                DomesticLegalPersonShares = 0,
                DomesticSponsorsShares = 0,
                ExecutiveShares = 0,
                FundsShares = 0,
                GeneralLegalPersonShares = 0,
                InternalStaffShares = 0,
                Market = Market.Unknown,
                PreferredStock = 0,
                RaiseLegalPersonShares = 0,
                Reason = null,
                RestrictedSharesA = 0,
                RestrictedSharesB = 0,
                SharesA = 2062894.443,
                SharesB = 0,
                SharesH = 391047.8,
                ShortName = "招商银行",
                StateOwnedLegalPersonShares = 0,
                StateShares = 0,
                StrategicInvestorsShares = 0,
                TotalShares = 2453942.243,
                TransferredAllottedShares = 0
            });

            examples.Add(new StockStructureDataItem
            {
                Code = "600036",
                DateOfChange = new DateTime(2010, 4, 9),
                DateOfDeclaration = new DateTime(2010, 4, 8),
                DomesticLegalPersonShares = 0,
                DomesticSponsorsShares = 0,
                ExecutiveShares = 0,
                FundsShares = 0,
                GeneralLegalPersonShares = 0,
                InternalStaffShares = 0,
                Market = Market.Unknown,
                PreferredStock = 0,
                RaiseLegalPersonShares = 0,
                Reason = null,
                RestrictedSharesA = 0,
                RestrictedSharesB = 0,
                SharesA = 1766613.089,
                SharesB = 0,
                SharesH = 391047.8,
                ShortName = "招商银行",
                StateOwnedLegalPersonShares = 0,
                StateShares = 0,
                StrategicInvestorsShares = 0,
                TotalShares = 2157660.889,
                TransferredAllottedShares = 0,
            });

            examples.Add(new StockStructureDataItem
            {
                Code = "600036",
                DateOfChange = new DateTime(2010, 3, 19),
                DateOfDeclaration = new DateTime(2010, 3, 17),
                DomesticLegalPersonShares = 0,
                DomesticSponsorsShares = 0,
                ExecutiveShares = 0,
                FundsShares = 0,
                GeneralLegalPersonShares = 0,
                InternalStaffShares = 0,
                Market = Market.Unknown,
                PreferredStock = 0,
                RaiseLegalPersonShares = 0,
                Reason = null,
                RestrictedSharesA = 0,
                RestrictedSharesB = 0,
                SharesA = 1766613.089,
                SharesB = 0,
                SharesH = 346060,
                ShortName = "招商银行",
                StateOwnedLegalPersonShares = 0,
                StateShares = 0,
                StrategicInvestorsShares = 0,
                TotalShares = 2112673.089,
                TransferredAllottedShares = 0,
            });

            examples.Add(new StockStructureDataItem
            {
                Code = "600036",
                DateOfChange = new DateTime(2009, 11, 10),
                DateOfDeclaration = new DateTime(2009, 11, 12),
                DomesticLegalPersonShares = 0,
                DomesticSponsorsShares = 0,
                ExecutiveShares = 0,
                FundsShares = 0,
                GeneralLegalPersonShares = 0,
                InternalStaffShares = 0,
                Market = Market.Unknown,
                PreferredStock = 0,
                RaiseLegalPersonShares = 0,
                Reason = null,
                RestrictedSharesA = 0,
                RestrictedSharesB = 0,
                SharesA = 1565889.002,
                SharesB = 0,
                SharesH = 346060,
                ShortName = "招商银行",
                StateOwnedLegalPersonShares = 0,
                StateShares = 0,
                StrategicInvestorsShares = 0,
                TotalShares = 1911949.002,
                TransferredAllottedShares = 0,
            });

            examples.Add(new StockStructureDataItem
            {
                Code = "600036",
                DateOfChange = new DateTime(2009, 10, 30),
                DateOfDeclaration = new DateTime(2009, 11, 5),
                DomesticLegalPersonShares = 0,
                DomesticSponsorsShares = 0,
                ExecutiveShares = 0,
                FundsShares = 0,
                GeneralLegalPersonShares = 0,
                InternalStaffShares = 0,
                Market = Market.Unknown,
                PreferredStock = 0,
                RaiseLegalPersonShares = 0,
                Reason = null,
                RestrictedSharesA = 0,
                RestrictedSharesB = 0,
                SharesA = 1565883.598,
                SharesB = 0,
                SharesH = 346060,
                ShortName = "招商银行",
                StateOwnedLegalPersonShares = 0,
                StateShares = 0,
                StrategicInvestorsShares = 0,
                TotalShares = 1911943.598,
                TransferredAllottedShares = 0,
            });

            examples.Add(new StockStructureDataItem
            {
                Code = "600036",
                DateOfChange = new DateTime(2009, 9, 30),
                DateOfDeclaration = new DateTime(2009, 10, 10),
                DomesticLegalPersonShares = 0,
                DomesticSponsorsShares = 0,
                ExecutiveShares = 0,
                FundsShares = 0,
                GeneralLegalPersonShares = 0,
                InternalStaffShares = 0,
                Market = Market.Unknown,
                PreferredStock = 0,
                RaiseLegalPersonShares = 0,
                Reason = null,
                RestrictedSharesA = 0,
                RestrictedSharesB = 0,
                SharesA = 1565881.043,
                SharesB = 0,
                SharesH = 346060,
                ShortName = "招商银行",
                StateOwnedLegalPersonShares = 0,
                StateShares = 0,
                StrategicInvestorsShares = 0,
                TotalShares = 1911941.043,
                TransferredAllottedShares = 0,
            });

            examples.Add(new StockStructureDataItem
            {
                Code = "600036",
                DateOfChange = new DateTime(2009, 9, 29),
                DateOfDeclaration = new DateTime(2009, 10, 10),
                DomesticLegalPersonShares = 0,
                DomesticSponsorsShares = 0,
                ExecutiveShares = 0,
                FundsShares = 0,
                GeneralLegalPersonShares = 0,
                InternalStaffShares = 0,
                Market = Market.Unknown,
                PreferredStock = 0,
                RaiseLegalPersonShares = 0,
                Reason = null,
                RestrictedSharesA = 0,
                RestrictedSharesB = 0,
                SharesA = 1565880.975,
                SharesB = 0,
                SharesH = 346060,
                ShortName = "招商银行",
                StateOwnedLegalPersonShares = 0,
                StateShares = 0,
                StrategicInvestorsShares = 0,
                TotalShares = 1911940.975,
                TransferredAllottedShares = 0,
            });

            return examples;
        }
        //count = 18
        private List<IStockStructure> ExampleStockStructure_600518()
        {
            List<IStockStructure> examples = new List<IStockStructure>();
            examples.Add(new StockStructureDataItem
            {
                Code = "600518",
                DateOfChange = new DateTime(2015, 6, 17),
                DateOfDeclaration = new DateTime(2015, 6, 10),
                DomesticLegalPersonShares = 0,
                DomesticSponsorsShares = 0,
                ExecutiveShares = 0,
                FundsShares = 0,
                GeneralLegalPersonShares = 0,
                InternalStaffShares = 0,
                Market = Market.Unknown,
                PreferredStock = 0,
                RaiseLegalPersonShares = 0,
                Reason = null,
                RestrictedSharesA = 0,
                RestrictedSharesB = 0,
                SharesA = 439742.897,
                SharesB = 0,
                SharesH = 0,
                ShortName = "康美药业",
                StateOwnedLegalPersonShares = 0,
                StateShares = 0,
                StrategicInvestorsShares = 0,
                TotalShares = 439742.897,
                TransferredAllottedShares = 0,
            });

            examples.Add(new StockStructureDataItem
            {
                Code = "600518",
                DateOfChange = new DateTime(2014, 12, 30),
                DateOfDeclaration = new DateTime(2014, 12, 25),
                DomesticLegalPersonShares = 0,
                DomesticSponsorsShares = 0,
                ExecutiveShares = 0,
                FundsShares = 0,
                GeneralLegalPersonShares = 0,
                InternalStaffShares = 0,
                Market = Market.Unknown,
                PreferredStock = 0,
                RaiseLegalPersonShares = 0,
                Reason = null,
                RestrictedSharesA = 0,
                RestrictedSharesB = 0,
                SharesA = 219871.448,
                SharesB = 0,
                SharesH = 0,
                ShortName = "康美药业",
                StateOwnedLegalPersonShares = 0,
                StateShares = 0,
                StrategicInvestorsShares = 0,
                TotalShares = 219871.448,
                TransferredAllottedShares = 0,
            });

            examples.Add(new StockStructureDataItem
            {
                Code = "600518",
                DateOfChange = new DateTime(2011, 1, 12),
                DateOfDeclaration = new DateTime(2011, 1, 10),
                DomesticLegalPersonShares = 0,
                DomesticSponsorsShares = 0,
                ExecutiveShares = 0,
                FundsShares = 0,
                GeneralLegalPersonShares = 0,
                InternalStaffShares = 0,
                Market = Market.Unknown,
                PreferredStock = 0,
                RaiseLegalPersonShares = 0,
                Reason = null,
                RestrictedSharesA = 0,
                RestrictedSharesB = 0,
                SharesA = 219871.448,
                SharesB = 0,
                SharesH = 0,
                ShortName = "康美药业",
                StateOwnedLegalPersonShares = 0,
                StateShares = 0,
                StrategicInvestorsShares = 0,
                TotalShares = 219871.448,
                TransferredAllottedShares = 0,
            });

            examples.Add(new StockStructureDataItem
            {
                Code = "600518",
                DateOfChange = new DateTime(2009, 5, 25),
                DateOfDeclaration = new DateTime(2009, 5, 26),
                DomesticLegalPersonShares = 0,
                DomesticSponsorsShares = 0,
                ExecutiveShares = 0,
                FundsShares = 0,
                GeneralLegalPersonShares = 0,
                InternalStaffShares = 0,
                Market = Market.Unknown,
                PreferredStock = 0,
                RaiseLegalPersonShares = 0,
                Reason = null,
                RestrictedSharesA = 0,
                RestrictedSharesB = 0,
                SharesA = 169437.005,
                SharesB = 0,
                SharesH = 0,
                ShortName = "康美药业",
                StateOwnedLegalPersonShares = 0,
                StateShares = 0,
                StrategicInvestorsShares = 0,
                TotalShares = 169437.005,
                TransferredAllottedShares = 0,
            });

            examples.Add(new StockStructureDataItem
            {
                Code = "600518",
                DateOfChange = new DateTime(2009, 4, 23),
                DateOfDeclaration = new DateTime(2009, 4, 16),
                DomesticLegalPersonShares = 0,
                DomesticSponsorsShares = 0,
                ExecutiveShares = 0,
                FundsShares = 0,
                GeneralLegalPersonShares = 0,
                InternalStaffShares = 0,
                Market = Market.Unknown,
                PreferredStock = 0,
                RaiseLegalPersonShares = 0,
                Reason = null,
                RestrictedSharesA = 0,
                RestrictedSharesB = 0,
                SharesA = 152880,
                SharesB = 0,
                SharesH = 0,
                ShortName = "康美药业",
                StateOwnedLegalPersonShares = 0,
                StateShares = 0,
                StrategicInvestorsShares = 0,
                TotalShares = 152880,
                TransferredAllottedShares = 0,
            });

            examples.Add(new StockStructureDataItem
            {
                Code = "600518",
                DateOfChange = new DateTime(2008, 10, 27),
                DateOfDeclaration = new DateTime(2008, 10, 21),
                DomesticLegalPersonShares = 0,
                DomesticSponsorsShares = 0,
                ExecutiveShares = 0,
                FundsShares = 0,
                GeneralLegalPersonShares = 0,
                InternalStaffShares = 0,
                Market = Market.Unknown,
                PreferredStock = 0,
                RaiseLegalPersonShares = 0,
                Reason = null,
                RestrictedSharesA = 0,
                RestrictedSharesB = 0,
                SharesA = 76440,
                SharesB = 0,
                SharesH = 0,
                ShortName = "康美药业",
                StateOwnedLegalPersonShares = 0,
                StateShares = 0,
                StrategicInvestorsShares = 0,
                TotalShares = 76440,
                TransferredAllottedShares = 0,
            });

            examples.Add(new StockStructureDataItem
            {
                Code = "600518",
                DateOfChange = new DateTime(2008, 3, 5),
                DateOfDeclaration = new DateTime(2008, 2, 27),
                DomesticLegalPersonShares = 0,
                DomesticSponsorsShares = 0,
                ExecutiveShares = 0,
                FundsShares = 0,
                GeneralLegalPersonShares = 0,
                InternalStaffShares = 0,
                Market = Market.Unknown,
                PreferredStock = 0,
                RaiseLegalPersonShares = 0,
                Reason = null,
                RestrictedSharesA = 20660.83,
                RestrictedSharesB = 0,
                SharesA = 55779.17,
                SharesB = 0,
                SharesH = 0,
                ShortName = "康美药业",
                StateOwnedLegalPersonShares = 0,
                StateShares = 0,
                StrategicInvestorsShares = 0,
                TotalShares = 76440,
                TransferredAllottedShares = 0,
            });

            examples.Add(new StockStructureDataItem
            {
                Code = "600518",
                DateOfChange = new DateTime(2007, 10, 25),
                DateOfDeclaration = new DateTime(2007, 10, 19),
                DomesticLegalPersonShares = 0,
                DomesticSponsorsShares = 0,
                ExecutiveShares = 0,
                FundsShares = 0,
                GeneralLegalPersonShares = 0,
                InternalStaffShares = 0,
                Market = Market.Unknown,
                PreferredStock = 0,
                RaiseLegalPersonShares = 0,
                Reason = null,
                RestrictedSharesA = 13773.887,
                RestrictedSharesB = 0,
                SharesA = 37186.113,
                SharesB = 0,
                SharesH = 0,
                ShortName = "康美药业",
                StateOwnedLegalPersonShares = 0,
                StateShares = 0,
                StrategicInvestorsShares = 0,
                TotalShares = 50960,
                TransferredAllottedShares = 0,
            });

            examples.Add(new StockStructureDataItem
            {
                Code = "600518",
                DateOfChange = new DateTime(2007, 9, 17),
                DateOfDeclaration = new DateTime(2007, 9, 14),
                DomesticLegalPersonShares = 0,
                DomesticSponsorsShares = 0,
                ExecutiveShares = 0,
                FundsShares = 0,
                GeneralLegalPersonShares = 0,
                InternalStaffShares = 0,
                Market = Market.Unknown,
                PreferredStock = 0,
                RaiseLegalPersonShares = 0,
                Reason = null,
                RestrictedSharesA = 15366.887,
                RestrictedSharesB = 0,
                SharesA = 35593.113,
                SharesB = 0,
                SharesH = 0,
                ShortName = "康美药业",
                StateOwnedLegalPersonShares = 0,
                StateShares = 0,
                StrategicInvestorsShares = 0,
                TotalShares = 50960,
                TransferredAllottedShares = 0,
            });

            examples.Add(new StockStructureDataItem
            {
                Code = "600518",
                DateOfChange = new DateTime(2007, 5, 9),
                DateOfDeclaration = new DateTime(2007, 4, 25),
                DomesticLegalPersonShares = 0,
                DomesticSponsorsShares = 0,
                ExecutiveShares = 0,
                FundsShares = 0,
                GeneralLegalPersonShares = 0,
                InternalStaffShares = 0,
                Market = Market.Unknown,
                PreferredStock = 0,
                RaiseLegalPersonShares = 0,
                Reason = null,
                RestrictedSharesA = 15366.887,
                RestrictedSharesB = 0,
                SharesA = 28493.113,
                SharesB = 0,
                SharesH = 0,
                ShortName = "康美药业",
                StateOwnedLegalPersonShares = 0,
                StateShares = 0,
                StrategicInvestorsShares = 0,
                TotalShares = 43860,
                TransferredAllottedShares = 0,
            });

            examples.Add(new StockStructureDataItem
            {
                Code = "600518",
                DateOfChange = new DateTime(2006, 10, 25),
                DateOfDeclaration = new DateTime(2006, 10, 20),
                DomesticLegalPersonShares = 0,
                DomesticSponsorsShares = 0,
                ExecutiveShares = 0,
                FundsShares = 0,
                GeneralLegalPersonShares = 0,
                InternalStaffShares = 0,
                Market = Market.Unknown,
                PreferredStock = 0,
                RaiseLegalPersonShares = 0,
                Reason = null,
                RestrictedSharesA = 7683.443,
                RestrictedSharesB = 0,
                SharesA = 14246.557,
                SharesB = 0,
                SharesH = 0,
                ShortName = "康美药业",
                StateOwnedLegalPersonShares = 0,
                StateShares = 0,
                StrategicInvestorsShares = 0,
                TotalShares = 21930,
                TransferredAllottedShares = 0,
            });

            examples.Add(new StockStructureDataItem
            {
                Code = "600518",
                DateOfChange = new DateTime(2006, 8, 11),
                DateOfDeclaration = new DateTime(2006, 8, 7),
                DomesticLegalPersonShares = 0,
                DomesticSponsorsShares = 0,
                ExecutiveShares = 0,
                FundsShares = 0,
                GeneralLegalPersonShares = 0,
                InternalStaffShares = 0,
                Market = Market.Unknown,
                PreferredStock = 0,
                RaiseLegalPersonShares = 0,
                Reason = null,
                RestrictedSharesA = 10867.5,
                RestrictedSharesB = 0,
                SharesA = 11062.5,
                SharesB = 0,
                SharesH = 0,
                ShortName = "康美药业",
                StateOwnedLegalPersonShares = 0,
                StateShares = 0,
                StrategicInvestorsShares = 0,
                TotalShares = 21930,
                TransferredAllottedShares = 0,
            });

            examples.Add(new StockStructureDataItem
            {
                Code = "600518",
                DateOfChange = new DateTime(2006, 7, 11),
                DateOfDeclaration = new DateTime(2006, 7, 10),
                DomesticLegalPersonShares = 0,
                DomesticSponsorsShares = 0,
                ExecutiveShares = 0,
                FundsShares = 0,
                GeneralLegalPersonShares = 0,
                InternalStaffShares = 0,
                Market = Market.Unknown,
                PreferredStock = 0,
                RaiseLegalPersonShares = 0,
                Reason = null,
                RestrictedSharesA = 12917.5,
                RestrictedSharesB = 0,
                SharesA = 9012.5,
                SharesB = 0,
                SharesH = 0,
                ShortName = "康美药业",
                StateOwnedLegalPersonShares = 0,
                StateShares = 0,
                StrategicInvestorsShares = 0,
                TotalShares = 21930,
                TransferredAllottedShares = 0,
            });

            examples.Add(new StockStructureDataItem
            {
                Code = "600518",
                DateOfChange = new DateTime(2006, 5, 19),
                DateOfDeclaration = new DateTime(2006, 5, 12),
                DomesticLegalPersonShares = 0,
                DomesticSponsorsShares = 0,
                ExecutiveShares = 0,
                FundsShares = 0,
                GeneralLegalPersonShares = 0,
                InternalStaffShares = 0,
                Market = Market.Unknown,
                PreferredStock = 0,
                RaiseLegalPersonShares = 0,
                Reason = null,
                RestrictedSharesA = 10867.5,
                RestrictedSharesB = 0,
                SharesA = 5062.5,
                SharesB = 0,
                SharesH = 0,
                ShortName = "康美药业",
                StateOwnedLegalPersonShares = 0,
                StateShares = 0,
                StrategicInvestorsShares = 0,
                TotalShares = 15930,
                TransferredAllottedShares = 0,
            });

            examples.Add(new StockStructureDataItem
            {
                Code = "600518",
                DateOfChange = new DateTime(2005, 10, 25),
                DateOfDeclaration = new DateTime(2005, 10, 20),
                DomesticLegalPersonShares = 0,
                DomesticSponsorsShares = 0,
                ExecutiveShares = 0,
                FundsShares = 0,
                GeneralLegalPersonShares = 0,
                InternalStaffShares = 0,
                Market = Market.Unknown,
                PreferredStock = 0,
                RaiseLegalPersonShares = 0,
                Reason = null,
                RestrictedSharesA = 7245,
                RestrictedSharesB = 0,
                SharesA = 3375,
                SharesB = 0,
                SharesH = 0,
                ShortName = "康美药业",
                StateOwnedLegalPersonShares = 0,
                StateShares = 0,
                StrategicInvestorsShares = 0,
                TotalShares = 10620,
                TransferredAllottedShares = 0,
            });

            examples.Add(new StockStructureDataItem
            {
                Code = "600518",
                DateOfChange = new DateTime(2004, 5, 21),
                DateOfDeclaration = new DateTime(0001, 1, 1),
                DomesticLegalPersonShares = 7050,
                DomesticSponsorsShares = 7920,
                ExecutiveShares = 0,
                FundsShares = 0,
                GeneralLegalPersonShares = 0,
                InternalStaffShares = 0,
                Market = Market.Unknown,
                PreferredStock = 0,
                RaiseLegalPersonShares = 0,
                Reason = null,
                RestrictedSharesA = 0,
                RestrictedSharesB = 0,
                SharesA = 2700,
                SharesB = 0,
                SharesH = 0,
                ShortName = "康美药业",
                StateOwnedLegalPersonShares = 0,
                StateShares = 0,
                StrategicInvestorsShares = 0,
                TotalShares = 10620,
                TransferredAllottedShares = 0,
            });

            examples.Add(new StockStructureDataItem
            {
                Code = "600518",
                DateOfChange = new DateTime(2001, 3, 19),
                DateOfDeclaration = new DateTime(0001, 1, 1),
                DomesticLegalPersonShares = 4700,
                DomesticSponsorsShares = 5280,
                ExecutiveShares = 0,
                FundsShares = 0,
                GeneralLegalPersonShares = 0,
                InternalStaffShares = 0,
                Market = Market.Unknown,
                PreferredStock = 0,
                RaiseLegalPersonShares = 0,
                Reason = null,
                RestrictedSharesA = 0,
                RestrictedSharesB = 0,
                SharesA = 1800,
                SharesB = 0,
                SharesH = 0,
                ShortName = "康美药业",
                StateOwnedLegalPersonShares = 0,
                StateShares = 0,
                StrategicInvestorsShares = 0,
                TotalShares = 7080,
                TransferredAllottedShares = 0,
            });

            examples.Add(new StockStructureDataItem
            {
                Code = "600518",
                DateOfChange = new DateTime(2001, 2, 26),
                DateOfDeclaration = new DateTime(0001, 1, 1),
                DomesticLegalPersonShares = 4700,
                DomesticSponsorsShares = 5280,
                ExecutiveShares = 0,
                FundsShares = 0,
                GeneralLegalPersonShares = 0,
                InternalStaffShares = 0,
                Market = Market.Unknown,
                PreferredStock = 0,
                RaiseLegalPersonShares = 0,
                Reason = null,
                RestrictedSharesA = 0,
                RestrictedSharesB = 0,
                SharesA = 0,
                SharesB = 0,
                SharesH = 0,
                ShortName = "康美药业",
                StateOwnedLegalPersonShares = 0,
                StateShares = 0,
                StrategicInvestorsShares = 0,
                TotalShares = 5280,
                TransferredAllottedShares = 0,
            });

            return examples;
        }

        [TestMethod]
        public void TestMethod1()
        {
            IEnumerable<IStockStructure> stockStructure_600036 = ExampleStockStructure_600036();//招商银行
            IEnumerable<IStockStructure> stockStructure_600518 = ExampleStockStructure_600518();//康美药业

            var repository = new StockStructureDataRepository();
            if (!repository.Exists("600036"))
            {
                foreach (var item in stockStructure_600036)
                {
                    repository.Add(item);
                }
            }
            if (!repository.Exists("600518"))
            {
                foreach (var item in stockStructure_600518)
                {
                    repository.Add(item);
                }
            }

            var lstAll = repository.GetDataAll().ToList();
            Assert.IsNotNull(lstAll);
            Assert.IsTrue(lstAll.Count == 26);

            var datas_600036 = repository.GetData("600036").ToList();
            Assert.IsNotNull(datas_600036);
            Assert.IsTrue(datas_600036.Count == 8);

            var datas_600518 = repository.GetData("600518").ToList();
            Assert.IsNotNull(datas_600518);
            Assert.IsTrue(datas_600518.Count == 18);

            List<string> stockCodes = new List<string>();
            stockCodes.Add("600518");//康美药业
            stockCodes.Add("600036");//招商银行
            stockCodes.Add("600298");//安琪酵母
            stockCodes.Add("601933");//永辉超市
            stockCodes.Add("600660");//福耀玻璃
            stockCodes.Add("600196");//复星医药
            stockCodes.Add("300118");//东方日升
            stockCodes.Add("000800");//一汽轿车
            var muti_datas = repository.GetData(stockCodes).ToList();
            Assert.IsNotNull(muti_datas);
            Assert.IsTrue(muti_datas.Count == 26);
        }
    }
}
