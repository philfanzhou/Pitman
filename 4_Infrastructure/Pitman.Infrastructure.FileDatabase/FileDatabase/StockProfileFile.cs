using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Infrastructure.MemoryMap;

namespace Pitman.Infrastructure.FileDatabase
{
    internal class StockProfileFile
        : ConcurrentFile<MarketDataFileHeader, StockProfileDataItem>
    {
        private static int maxCount = 4000;//最大预估4000只股票

        #region Constructor

        internal StockProfileFile(string fullPath) : base(fullPath) { }
        private StockProfileFile(string fullPath, MarketDataFileHeader header) : base(fullPath, header) { }

        #endregion

        internal static StockProfileFile CreateOrOpen()
        {
            string filePath = PathHelper.StockProfileFile;
            if (File.Exists(filePath))
            {
                return new StockProfileFile(filePath);
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
                return new StockProfileFile(filePath, header);
            }
        }
    }
}
