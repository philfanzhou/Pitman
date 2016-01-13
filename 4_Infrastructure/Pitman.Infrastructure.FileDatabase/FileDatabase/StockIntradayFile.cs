using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Infrastructure.MemoryMap;

namespace Pitman.Infrastructure.FileDatabase
{
    internal class StockIntradayFile
        : ConcurrentFile<MarketDataFileHeader, StockIntradayDataItem>
    {
        #region Constructor

        internal StockIntradayFile(string fullPath) : base(fullPath) { }
        private StockIntradayFile(string fullPath, MarketDataFileHeader header) : base(fullPath, header) { }

        #endregion

        internal static StockIntradayFile CreateOrOpen(DateTime day)
        {
            string filePath = null;
            if (File.Exists(filePath))
            {
                return new StockIntradayFile(filePath);
            }
            else
            {
                MarketDataFileHeader header = new MarketDataFileHeader
                {
                    DataCount = 0,
                    MaxDataCount = 4000,
                    DataType = DataType.RealTime,
                    StartDay = day,
                    EndDay = day
                };
                return new StockIntradayFile(filePath, header);
            }
        }
    }
}
