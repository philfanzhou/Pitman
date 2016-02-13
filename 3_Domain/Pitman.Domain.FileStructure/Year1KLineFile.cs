using Ore.Infrastructure.MarketData;
using Quantum.Domain.TimeSeries;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Pitman.Domain.FileStructure
{
    /// <summary>
    /// 每票一年一个文件的方式存储
    /// </summary>
    public abstract class Year1KLineFile : Year1Collections<IStockKLine>
    {
        private readonly string _stockCode;

        public Year1KLineFile(string stockCode)
        {
            _stockCode = stockCode;
        }

        /// <summary>
        /// 获取K线类型的字符串表达方式
        /// </summary>
        protected abstract string StrKLineType { get; }

        public string GetFilePath(ITimeSeriesPackage<IStockKLine> package)
        {
            return GetFilePath(package.Zone);
        }

        public IEnumerable<string> GetFilePath(DateTime startTime, DateTime endTime)
        {
            var zones = GetTimeZone(startTime, endTime);
            return zones.Select(p => GetFilePath(p));
        }

        public string GetFilePath(DateTime time)
        {
            var zone = GetTimeZone(time);
            return GetFilePath(zone);
        }

        protected string GetFilePath(ITimeZone zone)
        {

            string folder = Path.Combine(DataFiles.GetKLineFolder(_stockCode), StrKLineType);
            DataFiles.CreateFolderIsNotExist(folder);

            string fileName = string.Format("{0}_{1}_{2}{3}",
                _stockCode, 
                StrKLineType,
                zone.StartTime.ToString("yyyy"),
                DataFiles._fileExtName);

            return Path.Combine(folder, fileName);
        }
    }
}
