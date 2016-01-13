using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ore.Infrastructure.MarketData;

namespace Pitman.Infrastructure.FileDatabase
{
    public class StockKLineDataRepository
    {
        public void Add(string stockCode, KLineType kLineType, IStockKLine data)
        {
            using (var file = StockKLineFile.CreateOrOpen(stockCode, kLineType, data.Time))
            {
                StockKLineDataItem dataItem = data.Convert();
                file.Add(dataItem);
            }
        }

        public IEnumerable<IStockKLine> GetLatest(IEnumerable<string> stockCodes, KLineType kLineType)
        {
            List<IStockKLine> result = new List<IStockKLine>();
            foreach (string code in stockCodes)
            {
                string filePath = string.Empty;
                if (PathHelper.GetLatestKLineDataFilePath(code, kLineType, ref filePath))
                {
                    var file = new StockKLineFile(filePath);                    
                    var lstAll = from it in file.ReadAll()
                                 orderby it.Time descending
                                 select it;
                    IStockKLine fst = lstAll.First();
                    if (fst != null)
                        result.Add(fst);
                }
            }

            return result.Cast<IStockKLine>();
        }

        public IEnumerable<IStockKLine> GetData(string stockCode, KLineType kLineType, DateTime bgnDt, DateTime endDt)
        {
            List<string> pathList = PathHelper.GetKLineDataFilePath(stockCode, kLineType, bgnDt, endDt).ToList();

            List<StockKLineDataItem> result = new List<StockKLineDataItem>();
            foreach (string path in pathList)
            {
                if (File.Exists(path))
                {
                    var file = new StockKLineFile(path);
                    var lstAll = file.ReadAll();
                    var lstQuery = lstAll.Where(x => x.Time >= bgnDt && x.Time <= endDt);
                    result.AddRange(lstQuery);
                }
            }

            return result.Cast<IStockKLine>();
        }

        public IStockKLine GetData(string stockCode, KLineType kLineType, DateTime dt)
        {
            string filepath = PathHelper.GetKLineDataFilePath(stockCode, kLineType, dt);
                       
            if (File.Exists(filepath))
            {
                var file = new StockKLineFile(filepath);
                var lstAll = file.ReadAll();
                var lstQuery = lstAll.Where(x => x.Time == dt).ToList();
                if (lstQuery != null && lstQuery.Count > 0)
                    return lstQuery.First();
            }

            return null;
        }

        public bool Exists(string stockCode, KLineType kLineType, DateTime dt)
        {
            var query = GetData(stockCode, kLineType, dt);
            return (query != null);
        }
    }    

    internal static class StockKLineExt
    {
        public static StockKLineDataItem Convert(this IStockKLine self)
        {
            StockKLineDataItem outputData = new StockKLineDataItem
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
