using Ore.Infrastructure.MarketData;
using System;

namespace Pitman.Infrastructure.DatabaseObject
{
    public class StockStructureDbo : IStockStructure
    {
        public DateTime DateOfChange { get; set; }

        public DateTime DateOfDeclaration { get; set; }

        public double DomesticLegalPersonShares { get; set; }

        public double DomesticSponsorsShares { get; set; }

        public double ExecutiveShares { get; set; }

        public double FundsShares { get; set; }

        public double GeneralLegalPersonShares { get; set; }

        public double InternalStaffShares { get; set; }

        public double PreferredStock { get; set; }

        public double RaiseLegalPersonShares { get; set; }

        public string Reason { get; set; }

        public double RestrictedSharesA { get; set; }

        public double RestrictedSharesB { get; set; }

        public double SharesA { get; set; }

        public double SharesB { get; set; }

        public double SharesH { get; set; }

        public double StateOwnedLegalPersonShares { get; set; }

        public double StateShares { get; set; }

        public double StrategicInvestorsShares { get; set; }

        public double TotalShares { get; set; }

        public double TransferredAllottedShares { get; set; }
    }

    public static class StockStructureConverter
    {
        public static StockStructureDbo ToDbo(this IStockStructure self)
        {
            StockStructureDbo outputData = new StockStructureDbo
            {
                DateOfChange = self.DateOfChange,
                DateOfDeclaration = self.DateOfDeclaration,
                DomesticLegalPersonShares = self.DomesticLegalPersonShares,
                DomesticSponsorsShares = self.DomesticSponsorsShares,
                ExecutiveShares = self.ExecutiveShares,
                FundsShares = self.FundsShares,
                GeneralLegalPersonShares = self.GeneralLegalPersonShares,
                InternalStaffShares = self.InternalStaffShares,
                PreferredStock = self.PreferredStock,
                RaiseLegalPersonShares = self.RaiseLegalPersonShares,
                Reason = self.Reason,
                RestrictedSharesA = self.RestrictedSharesA,
                RestrictedSharesB = self.RestrictedSharesB,
                SharesA = self.SharesA,
                SharesB = self.SharesB,
                SharesH = self.SharesH,
                StateOwnedLegalPersonShares = self.StateOwnedLegalPersonShares,
                StateShares = self.StateShares,
                StrategicInvestorsShares = self.StrategicInvestorsShares,
                TotalShares = self.TotalShares,
                TransferredAllottedShares = self.TransferredAllottedShares
            };

            return outputData;
        }
    }
}
