using System.Collections.Generic;

namespace Ore.Infrastructure.MarketData
{
    public interface IProfileReader
    {
        IEnumerable<ISecurityProfile> GetAll();
    }
}
