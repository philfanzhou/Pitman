using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Infrastructure.MemoryMap;

namespace Pitman.Infrastructure.FileDatabase
{
    internal class SecurityFile
        : ConcurrentFile<MarketDataFileHeader, SecurityItem>
    {
        private static int maxCount = 4000;//最大预估4000只股票

        #region Constructor

        internal SecurityFile(string fullPath) : base(fullPath) { }
        private SecurityFile(string fullPath, MarketDataFileHeader header) : base(fullPath, header) { }

        #endregion

        internal static SecurityFile CreateOrOpen()
        {
            string filePath = PathHelper.SecurityFile;
            if (File.Exists(filePath))
            {
                return new SecurityFile(filePath);
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
                return new SecurityFile(filePath, header);
            }
        }
    }
}
