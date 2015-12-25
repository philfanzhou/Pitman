using Ore.Infrastructure.MarketData;
using System.Collections.Generic;

namespace Pitman.Presentation.RESTfulClient
{
    public interface IStockProfileClient
    {
        IStockProfile Get(string stockCode);
    }
}
