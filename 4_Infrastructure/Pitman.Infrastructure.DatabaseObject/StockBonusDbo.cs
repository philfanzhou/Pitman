using Ore.Infrastructure.MarketData;
using System;

namespace Pitman.Infrastructure.DatabaseObject
{
    public class StockBonusDbo : IStockBonus
    {
        public double ActualDispatchRate { get; set; }

        public double BAndHDividendAfterTax { get; set; }

        public double BAndHPreTaxDividend { get; set; }

        public double BonusRate { get; set; }

        public DateTime CapitalStockBaseDate { get; set; }

        public double CapitalStockBeforeDispatch { get; set; }

        public double CapitalSurplusIncreaseRate { get; set; }

        public DateTime ConvertibleBondDate { get; set; }

        public DateTime DateOfDeclaration { get; set; }

        public string Description { get; set; }

        public DateTime DispatchExpiryDate { get; set; }

        public DateTime DispatchListingDate { get; set; }

        public double DispatchPrice { get; set; }

        public double DispatchRate { get; set; }

        public double DividendAfterTax { get; set; }

        public double ExchangeRate { get; set; }

        public DateTime ExdividendDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public double IncreaseRate { get; set; }

        public string IssuingObject { get; set; }

        public DateTime LastTradingDay { get; set; }

        public double PreTaxDividend { get; set; }

        public DateTime RegisterDate { get; set; }

        public double ReserveSurplusIncreaseRate { get; set; }

        public DateTime ResolutionOfShareholdersMeetingDate { get; set; }

        public double ShareSplitCount { get; set; }

        public DateTime StartOrArriveDate { get; set; }

        public double TotalDispatch { get; set; }

        public double TransferredAllottedPrice { get; set; }

        public double TransferredAllottedRate { get; set; }

        public BounsType Type { get; set; }
    }

    public static class StockBonusConverter
    {
        public static StockBonusDbo ToDbo(this IStockBonus self)
        {
            StockBonusDbo outputData = new StockBonusDbo
            {
                ActualDispatchRate = self.ActualDispatchRate,
                BAndHDividendAfterTax = self.BAndHDividendAfterTax,
                BAndHPreTaxDividend = self.BAndHPreTaxDividend,
                BonusRate = self.BonusRate,
                CapitalStockBaseDate = self.CapitalStockBaseDate,
                CapitalStockBeforeDispatch = self.CapitalStockBeforeDispatch,
                CapitalSurplusIncreaseRate = self.CapitalSurplusIncreaseRate,
                ConvertibleBondDate = self.ConvertibleBondDate,
                DateOfDeclaration = self.DateOfDeclaration,
                Description = self.Description,
                DispatchExpiryDate = self.DispatchExpiryDate,
                DispatchListingDate = self.DispatchListingDate,
                DispatchPrice = self.DispatchPrice,
                DispatchRate = self.DispatchRate,
                DividendAfterTax = self.DividendAfterTax,
                ExchangeRate = self.ExchangeRate,
                ExdividendDate = self.ExdividendDate,
                ExpirationDate = self.ExpirationDate,
                IncreaseRate = self.IncreaseRate,
                IssuingObject = self.IssuingObject,
                LastTradingDay = self.LastTradingDay,
                PreTaxDividend = self.PreTaxDividend,
                RegisterDate = self.RegisterDate,
                ReserveSurplusIncreaseRate = self.ReserveSurplusIncreaseRate,
                ResolutionOfShareholdersMeetingDate = self.ResolutionOfShareholdersMeetingDate,
                ShareSplitCount = self.ShareSplitCount,
                StartOrArriveDate = self.StartOrArriveDate,
                TotalDispatch = self.TotalDispatch,
                TransferredAllottedPrice = self.TransferredAllottedPrice,
                TransferredAllottedRate = self.TransferredAllottedRate,
                Type = self.Type
            };

            return outputData;
        }
    }
}
