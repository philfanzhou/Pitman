using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Infrastructure.MemoryMap;

namespace Pitman.Infrastructure.FileDatabase
{
    internal class StockStructureFile
        : ConcurrentFile<MarketDataFileHeader, StockStructureDataItem>
    {
        private static int maxCount = 12 * 30;//考虑一个月变更一次，最大预估30年数据

        #region Constructor

        internal StockStructureFile(string fullPath) : base(fullPath) { }
        private StockStructureFile(string fullPath, MarketDataFileHeader header) : base(fullPath, header) { }

        #endregion

        internal static StockStructureFile CreateOrOpen(string stockCode)
        {
            string filePath = string.Format(@"{0}\{1}.dat", PathHelper.StockStructureFolder, stockCode);
            if (File.Exists(filePath))
            {
                return new StockStructureFile(filePath);
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
                return new StockStructureFile(filePath, header);
            }
        }
    }
}
