using Ore.Infrastructure.MarketData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Infrastructure.FileDatabase
{
    public class SecurityInfo : ISecurity
    {
        public string Code
        {
            get; set;
        }

        public Market Market
        {
            get; set;
        }

        public string ShortName
        {
            get; set;
        }

        public SecurityType Type
        {
            get; set;
        }
    }
}
