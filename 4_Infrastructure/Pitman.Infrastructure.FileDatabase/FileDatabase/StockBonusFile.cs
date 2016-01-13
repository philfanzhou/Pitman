using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Infrastructure.MemoryMap;

namespace Pitman.Infrastructure.FileDatabase
{
    internal class StockBonusFile
        : ConcurrentFile<MarketDataFileHeader, StockBonusDataItem>
    {
        private static int maxCount = 2 * 30;//以一年2次，最大预估30年数据

        #region Constructor

        internal StockBonusFile(string fullPath) : base(fullPath) { }
        private StockBonusFile(string fullPath, MarketDataFileHeader header) : base(fullPath, header) { }

        #endregion

        internal static StockBonusFile CreateOrOpen(string stockCode)
        {
            string filePath = string.Format(@"{0}\{1}.dat", PathHelper.StockBonusFolder, stockCode);
            if (File.Exists(filePath))
            {
                return new StockBonusFile(filePath);
            }
            else
            {
                MarketDataFileHeader header = new MarketDataFileHeader
                {
                    DataCount = 0,
                    MaxDataCount = maxCount,
                    DataType = DataType.RealTime,
                    StartDay = DateTime.Now,
                    EndDay = DateTime.Now
                };
                return new StockBonusFile(filePath, header);
            }
        }
    }
}
