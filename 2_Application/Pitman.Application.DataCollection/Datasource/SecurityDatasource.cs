using Ore.Infrastructure.MarketData;
using Ore.Infrastructure.MarketData.DataSource.Eastmoney;
using System.Collections.Generic;

namespace Pitman.Application.DataCollection
{
    public class SecurityDatasource
    {
        public static IEnumerable<ISecurity> GetAll()
        {
            SecurityInfoApi api = new SecurityInfoApi();
            return api.GetAllSecurity();
        }
    }
}
