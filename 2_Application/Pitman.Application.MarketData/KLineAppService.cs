using Framework.Infrastructure.Repository;
using Ore.Infrastructure.MarketData;
using Pitman.Infrastructure.EF.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitman.Application.MarketData
{
    internal class KLineAppService
    {
        public bool Exist(KLineType type, IStockKLine kLine)
        {
            throw new NotImplementedException();
        }

        public void Add(KLineType type, IStockKLine kLine)
        {
            throw new NotImplementedException();
        }

        public void Update(KLineType type, IStockKLine kLine)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IStockKLine> Get(
            KLineType type, string stockCode, 
            DateTime startTime, DateTime endTime)
        {
            /*
            注意需要考虑到：
            1：如果查询的时间跨度很长，记录可能存放于不同的文件中，需要进行查询结果的拼接。
            2：同理在获取Context，以及FilePath的时候，也需要考虑时间跨度导致的多文件处理。
            */

            throw new NotImplementedException();
        }

        private IEnumerable<IRepositoryContext> GetContext(
            KLineType type, string stockCode, 
            DateTime startTime, DateTime endTime)
        {
            /*因为时间跨度可能导致多个存储文件，所以这里的Context返回是一个集合*/
            throw new NotImplementedException();
        }

        private static KLineDbo ConvertToDbo(IStockKLine self)
        {
            KLineDbo outputData = new KLineDbo
            {
                //
                // 摘要:
                //     成交额
                Amount = self.Amount,
                //
                // 摘要:
                //     收盘
                Close = self.Close,
                //
                // 摘要:
                //     最高
                High = self.High,
                //
                // 摘要:
                //     最低
                Low = self.Low,
                //
                // 摘要:
                //     今开
                Open = self.Open,
                //
                // 摘要:
                //     日期与时间
                Time = self.Time,
                //
                // 摘要:
                //     成交量
                Volume = self.Volume
            };

            return outputData;
        }
    }
}
