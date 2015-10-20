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
        private static int maxDataCount = (10 + 15 + 4 * 60 + 10) * 12;

        #region Constructor
        private RealTimeFile(string fullPath) : base(fullPath) { }
        private RealTimeFile(string fullPath, MarketDataFileHeader header) : base(fullPath, header) { }
        #endregion

        #region Create and Open

        private static string GetFilePath(ISecurity securityInfo, DateTime day)
        {
            string path = dataFolder;
            if (securityInfo.Market == Market.XSHG)
            {
                path += @"Shanghai\";
            }
            else if (securityInfo.Market == Market.XSHE)
            {
                path += @"Shenzhen\";
            }

            path += securityInfo.Code + @"\";
            path += day.ToString("yyyyMMdd") + ".dat";

            return path;
        }

        internal static bool Exist(ISecurity securityInfo, DateTime day)
        {
            string path = GetFilePath(securityInfo, day);
            return File.Exists(path);
        }

        internal static RealTimeFile Open(ISecurity securityInfo, DateTime day)
        {
            string path = GetFilePath(securityInfo, day);
            return new RealTimeFile(path);
        }

        internal static RealTimeFile Create(ISecurity securityInfo, DateTime day)
        {
            MarketDataFileHeader heaer = new MarketDataFileHeader
            {
                DataCount = 0,
                MaxDataCount = maxDataCount,
                DataType = DataType.RealTime,
                StartDay = day,
                EndDay = day
            };

            string path = GetFilePath(securityInfo, day);
            return new RealTimeFile(path, heaer);
        }

        internal static RealTimeFile CreateOrOpen(ISecurity securityInfo, DateTime day)
        {
            if (Exist(securityInfo, day))
            {
                return Open(securityInfo, day);
            }
            else
            {
                return Create(securityInfo, day);
            }
        }

        #endregion
    }


}
