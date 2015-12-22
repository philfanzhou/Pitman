﻿using Ore.Infrastructure.MarketData;
using System.Collections.Generic;

namespace Pitman.Presentation.RESTfulClient
{
    public interface ISecurityClient
    {
        IEnumerable<ISecurity> GetAll();
    }
}
