using Ore.Infrastructure.MarketData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitman.Presentation.RESTfulClient
{
    public interface ISecurityClient
    {
        IEnumerable<ISecurity> GetAll();
    }
}
