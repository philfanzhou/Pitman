using Ore.Infrastructure.MarketData;
using System.Collections.Generic;

namespace Pitman.RESTful.Client
{
    public interface ISecurityClient
    {
        IEnumerable<ISecurity> GetAll();
    }
}
