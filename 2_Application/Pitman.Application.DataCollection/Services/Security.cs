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
        private const string _serviceName = "Security";

        public override string ServiceName
        {
            get { return _serviceName; }
        }

        protected override void DoWork()
        {
            throw new NotImplementedException();
        }

        protected override bool IsWorkingTime(DateTime now)
        {
            throw new NotImplementedException();
        }

        internal static IEnumerable<ISecurity> GetDataFromApi()
        {
            SecurityInfoApi api = new SecurityInfoApi();
            return api.GetAllSecurity();
        }
    }
}
