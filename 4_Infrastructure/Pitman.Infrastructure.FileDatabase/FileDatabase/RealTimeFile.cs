using Framework.Infrastructure.MemoryMap;
using Ore.Infrastructure.MarketData;
using System;
using System.IO;

namespace Pitman.Infrastructure.FileDatabase
{
    internal class RealTimeFile
        : NonConcurrentMemoryMappedFile<MarketDataFileHeader, RealTimeItem>
    {
        private static string dataFolder = Environment.CurrentDirectory + @"\Data\RealTimeData\";
        /// <summary>
        /// (10缓冲 + 15集合竞价 + 4小时交易 + 10缓冲)每分钟12条记录
        /// </summary>
        private static int maxDataCount = (10 + 15 + (4 * 60) + 10) * 12;

        #region Constructor
        private RealTimeFile(string fullPath) : base(fullPath) { }
        private RealTimeFile(string fullPath, MarketDataFileHeader header) : base(fullPath, header) { }
        #endregion

        #region Create and Open

        private static string GetFilePath(string stockCode, DateTime day)
        {
            string path = dataFolder;
            path += GetMarket(stockCode);
            path += @"\" + stockCode + @"\";
            path += day.ToString("yyyyMMdd") + ".dat";

            return path;
        }

        private static string GetMarket(string stockCode)
        {
            if (stockCode.StartsWith("5") ||
                stockCode.StartsWith("6") ||
                stockCode.StartsWith("9"))
            {
                return "Shanghai";
            }
            else if (stockCode.StartsWith("009") ||
                stockCode.StartsWith("126") ||
                stockCode.StartsWith("110"))
            {
                return "Shanghai";
            }
            else
            {
                return "Shenzhen";
            }
        }

        internal static bool Exist(string stockCode, DateTime day)
        {
            string path = GetFilePath(stockCode, day);
            return File.Exists(path);
        }

        internal static RealTimeFile Open(string stockCode, DateTime day)
        {
            string path = GetFilePath(stockCode, day);
            return new RealTimeFile(path);
        }

        internal static RealTimeFile Create(string stockCode, DateTime day)
        {
            MarketDataFileHeader heaer = new MarketDataFileHeader
            {
                DataCount = 0,
                MaxDataCount = maxDataCount,
                DataType = DataType.RealTime,
                StartDay = day,
                EndDay = day
            };

            string path = GetFilePath(stockCode, day);
            return new RealTimeFile(path, heaer);
        }

        internal static RealTimeFile CreateOrOpen(string stockCode, DateTime day)
        {
            if (Exist(stockCode, day))
            {
                return Open(stockCode, day);
            }
            else
            {
                return Create(stockCode, day);
            }
        }

        #endregion
    }


}
