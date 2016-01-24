using Ore.Infrastructure.MarketData;
using System;

namespace Pitman.Infrastructure.EF.Repository
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
}
