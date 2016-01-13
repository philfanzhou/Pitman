using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Infrastructure.MemoryMap;
using Ore.Infrastructure.MarketData;

namespace Pitman.Infrastructure.FileDatabase
{
    internal struct StockStructureDataItem : IStockStructure
    {
        private String64 code;
        public string Code
        {
            get
            {
                return code.Value;
            }
            set
            {
                code.Value = value;
            }
        }

        public DateTime DateOfChange { get; set; }

        public DateTime DateOfDeclaration { get; set; }

        public double DomesticLegalPersonShares { get; set; }

        public double DomesticSponsorsShares { get; set; }

        public double ExecutiveShares { get; set; }

        public double FundsShares { get; set; }

        public double GeneralLegalPersonShares { get; set; }

        public double InternalStaffShares { get; set; }

        public Market Market { get; set; }

        public double PreferredStock { get; set; }

        public double RaiseLegalPersonShares { get; set; }

        private String256 reason;
        public string Reason
        {
            get
            {
                return reason.Value;
            }
            set
            {
                reason.Value = value;
            }
        }

        public double RestrictedSharesA { get; set; }

        public double RestrictedSharesB { get; set; }

        public double SharesA { get; set; }

        public double SharesB { get; set; }

        public double SharesH { get; set; }

        private String256 shortName;
        public string ShortName
        {
            get
            {
                return shortName.Value;
            }
            set
            {
                shortName.Value = value;
            }
        }

        public double StateOwnedLegalPersonShares { get; set; }

        public double StateShares { get; set; }

        public double StrategicInvestorsShares { get; set; }

        public double TotalShares { get; set; }

        public double TransferredAllottedShares { get; set; }
    }
}
