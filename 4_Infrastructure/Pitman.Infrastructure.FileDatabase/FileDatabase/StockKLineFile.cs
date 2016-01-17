using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Infrastructure.MemoryMap;
using Ore.Infrastructure.MarketData;

namespace Pitman.Infrastructure.FileDatabase
{
    internal class StockKLineFile
        : ConcurrentFile<MarketDataFileHeader, StockKLineDataItem>
    {
        private static int maxCount_Day = 23 * 12;//日K线：以年计最大264条数据
        private static int maxCount_Min1 = 272 * 23 * 12;//1分钟K线：每天272条数据；每月最大23天；以月计月最大数据——6256；以年计最大数据——75072
        private static int maxCount_Min5 = 56 * 23 * 12;//5分钟K线：每天56条数据；每月最大23天；以月计月最大数据——1288；以年计最大数据——15456

        #region Constructor

        internal StockKLineFile(string fullPath) : base(fullPath) { }
        private StockKLineFile(string fullPath, MarketDataFileHeader header) : base(fullPath, header) { }

        #endregion

        internal static StockKLineFile CreateOrOpen(string stockCode, KLineType kLineType, DateTime dt)
        {
            string filePath = PathHelper.GetKLineDataFilePath(stockCode, kLineType, dt);
            if (File.Exists(filePath))
            {
                return new StockKLineFile(filePath);
            }
            else
            {
                MarketDataFileHeader header = new MarketDataFileHeader
                {
                    DataCount = 0,
                    MaxDataCount = GetMaxCount(kLineType),
                    DataType = DataType.RealTime,
                    StartDay = dt,
                    EndDay = dt
                };
                return new StockKLineFile(filePath, header);
            }
        }

        private static int GetMaxCount(KLineType kLineType)
        {
            int maxCount = 0;
            switch (kLineType)
            {
                /// 日线
                case KLineType.Day:
                    maxCount = maxCount_Day;
                    break;
                /// 1分钟线
                case KLineType.Min1:
                    maxCount = maxCount_Min1;
                    break;
                /// 5分钟线
                case KLineType.Min5:
                    maxCount = maxCount_Min5;
                    break;
            }
            return maxCount;
        }
    }    
}
