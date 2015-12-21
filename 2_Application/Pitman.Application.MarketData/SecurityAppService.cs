using Ore.Infrastructure.MarketData;
using System;
using System.Collections.Generic;

namespace Pitman.Application.MarketData
{
    public class SecurityAppService
    {
        public IEnumerable<ISecurity> GetAll()
        {
            throw new NotFiniteNumberException();
        }
    }
}
