using Ore.Infrastructure.MarketData;
using System.Collections.Generic;

namespace Pitman.RESTful.Client
{
    public interface IStockProfileClient
    {
        IStockProfile Get(string stockCode);
    }
}
