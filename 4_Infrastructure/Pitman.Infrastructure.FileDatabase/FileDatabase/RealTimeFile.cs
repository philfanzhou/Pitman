using Framework.Infrastructure.MemoryMap;
using System;
using System.IO;

namespace Pitman.Infrastructure.FileDatabase
{
    internal class RealTimeFile
        : ConcurrentFile<MarketDataFileHeader, RealTimeItem>
    {
        private static string dataFolder = Environment.CurrentDirectory + @"\Data\RealTimeData\";
        /// <summary>
        /// (10缓冲 + 15集合竞价 + 4小时交易 + 10缓冲)每分钟12条记录
        /// </summary>
        private static int maxDataCount = (10 + 15 + (4 * 60) + 10) * 12;

        #region Constructor
        internal RealTimeFile(string fullPath) : base(fullPath) { }
        private RealTimeFile(string fullPath, MarketDataFileHeader header) : base(fullPath, header) { }
        #endregion

        internal static RealTimeFile CreateOrOpen(string stockCode, DateTime day)
        {
            string filePath = PathHelper.GetFilePath(stockCode, day);
            if (File.Exists(filePath))
            {
                return new RealTimeFile(filePath);
            }
            else
            {
                MarketDataFileHeader heaer = new MarketDataFileHeader
                {
                    DataCount = 0,
                    MaxDataCount = maxDataCount,
                    DataType = DataType.RealTime,
                    StartDay = day,
                    EndDay = day
                };
                return new RealTimeFile(filePath, heaer);
            }
        }
    }
}
