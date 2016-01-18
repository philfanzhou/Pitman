using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ore.Infrastructure.MarketData;

namespace Pitman.Infrastructure.EF.Repository
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
}
