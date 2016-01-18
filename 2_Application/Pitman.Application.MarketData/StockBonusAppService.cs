using Framework.Infrastructure.Repository;
using Ore.Infrastructure.MarketData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitman.Application.MarketData
{
    public class StockBonusAppService
    {
        public bool Exists(string stockCode, IStockBonus stockBonus)
        {
            throw new NotImplementedException();
        }

        public void Add(string stockCode, IStockBonus stockBonus)
        {
            throw new NotImplementedException();
        }

        public void Update(string stockCode, IStockBonus stockBonus)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IStockBonus> Get(string stockCode)
        {
            throw new NotImplementedException();
        }

        private IRepositoryContext GetContext()
        {
            throw new NotImplementedException();
        }

        //private static StockBonusDbo ConvertToDbo(IStockBonus self)
    }
}
