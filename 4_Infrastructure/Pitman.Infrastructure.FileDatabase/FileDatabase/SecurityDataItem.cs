using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Infrastructure.MemoryMap;
using Ore.Infrastructure.MarketData;

namespace Pitman.Infrastructure.FileDatabase
{
    internal struct SecurityItem : ISecurity
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

        public Market Market { get; set; }

        public SecurityType Type { get; set; }
    }
}
