using Ore.Infrastructure.MarketData;
using Ore.Infrastructure.MarketData.DataSource.Eastmoney;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitman.Application.DataCollection
{
    internal class Security : CollectionService
    {
        public override string ServiceName
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        internal static IEnumerable<ISecurity> GetDataFromApi()
        {
            SecurityInfoApi api = new SecurityInfoApi();
            return api.GetAllSecurity();
        }

        protected override void DoWork()
        {
            throw new NotImplementedException();
        }

        protected override bool IsWorkingTime(DateTime now)
        {
            throw new NotImplementedException();
        }
    }
}
