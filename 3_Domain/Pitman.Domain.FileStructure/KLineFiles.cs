using Ore.Infrastructure.MarketData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitman.Domain.FileStructure
{
    public static partial class DataFiles
    {
        private const string FileNameExtension = ".sdf";
        private const int SpanYears = 10;
        private static DateTime StockCreatedTime = new DateTime(1990, 1, 1, 0, 0, 0);

        public static IEnumerable<KLineFileInfo> GetKLineFileInfo(KLineType type, string stockCode, DateTime startTime, DateTime endTime)
        {
            if (startTime > endTime)
            {
                throw new ArgumentOutOfRangeException("startTime", "startTime is less than endTime");
            }

            // 获取文件夹路径
            string folder = GetKLineFolder(type, stockCode);

            // 获取文件信息
            List<KLineFileInfo> fileInfoList;
            switch (type)
            {
                case KLineType.Day:
                    fileInfoList = GetKLineDayFileInfo(folder, startTime, endTime);
                    break;
                case KLineType.Min1:
                    fileInfoList = GetKLineMin1FileInfo(folder, startTime, endTime);
                    break;
                case KLineType.Min5:
                    fileInfoList = GetKLineMin5FileInfo(folder, startTime, endTime);
                    break;
                default:
                    throw new NotSupportedException();
            }

            return fileInfoList;
        }

        public static KLineFileInfo GetKLineFileInfo(KLineType type, string stockCode, DateTime time)
        {
            return GetKLineFileInfo(type, stockCode, time, time).ToList().First();
        }

        #region Private Method

        private static List<KLineFileInfo> GetKLineFileInfos(string folder)
        {
            List<KLineFileInfo> kLineFileInfos = new List<KLineFileInfo>();
            if (Directory.Exists(folder))
            {
                DirectoryInfo directory = new DirectoryInfo(folder);
                FileInfo[] fileInfoArray = directory.GetFiles();
                foreach (var fileInfo in fileInfoArray)
                {
                    var splitName = fileInfo.Name.Replace(FileNameExtension, "").Split('-');
                    int bgnYear = 0;
                    int endYear = 0;
                    if (splitName.Count() == 1)
                    {
                        bgnYear = endYear = Int32.Parse(splitName[0]);
                    }
                    else if (splitName.Count() == 2)
                    {
                        bgnYear = Int32.Parse(splitName[0]);
                        endYear = Int32.Parse(splitName[1]);
                    }

                    kLineFileInfos.Add(new KLineFileInfo(bgnYear, endYear, Path.Combine(folder, fileInfo.Name)));
                }
            }
            return kLineFileInfos;
        }
        
        private static List<KLineFileInfo> NewKLineDayFileInfo(string folder, DateTime startTime, DateTime endTime)
        {
            if (startTime > endTime)
            {
                throw new ArgumentOutOfRangeException("startTime", "startTime is less than endTime");
            }

            DateTime dtStockCreated = StockCreatedTime;
            if (endTime.Year < dtStockCreated.Year)
            {
                throw new ArgumentOutOfRangeException("StockCreatedTime", "endTime is less than StockCreatedTime");
            }

            List<KLineFileInfo> kLineFileInfos = new List<KLineFileInfo>();            
            while (endTime.Year >= dtStockCreated.Year)
            {
                if (startTime.Year <= dtStockCreated.AddYears(SpanYears).Year)
                {
                    string fullPath = Path.Combine(folder, string.Format("{0}-{1}{2}", dtStockCreated.Year, dtStockCreated.AddYears(SpanYears).Year, FileNameExtension));
                    kLineFileInfos.Add(new KLineFileInfo(dtStockCreated.BeginYear(), dtStockCreated.AddYears(SpanYears).EndYear(), fullPath));
                }

                dtStockCreated = dtStockCreated.AddYears(SpanYears + 1);
            }

            return kLineFileInfos;
        }

        private static List<KLineFileInfo> NewKLineMinFileInfo(string folder, DateTime startTime, DateTime endTime)
        {
            if (startTime > endTime)
            {
                throw new ArgumentOutOfRangeException("startTime", "startTime is less than endTime");
            }

            List<KLineFileInfo> kLineFileInfos = new List<KLineFileInfo>();
            if (startTime.Year == endTime.Year)
            {
                string fullPath = Path.Combine(folder, string.Format("{0}{1}", startTime.Year, FileNameExtension));
                kLineFileInfos.Add(new KLineFileInfo(startTime.BeginYear(), startTime.EndYear(), fullPath));
            }
            else
            {
                DateTime dt = startTime;
                while (dt.Year <= endTime.Year)
                {
                    string fullPath = Path.Combine(folder, string.Format("{0}{1}", dt.Year, FileNameExtension));
                    kLineFileInfos.Add(new KLineFileInfo(dt.Year, dt.Year, fullPath));
                    dt = dt.AddYears(1);
                }
            }

            return kLineFileInfos;
        }

        private static List<KLineFileInfo> GetKLineDayFileInfo(
            string folder, DateTime startTime, DateTime endTime)
        {
            /*
            1：不用特殊考虑开始时间和结束时间相同的问题，只要开始时间和结束时间落在范围内，按范围返回就是了
            2：日线可以不用考虑分文件的问题
            3：min1和min5需要考虑分文件
            4：文件后缀名为sdf, 建议在这个类中用一个常量来表示，不用每个地方都硬编码
            */
            var searchKLineFileInfos = GetKLineFileInfos(folder).Where(p =>
            (startTime.Year >= p.StartTime.Year && startTime.Year <= p.EndTime.Year) ||
            (endTime.Year >= p.StartTime.Year && endTime.Year <= p.EndTime.Year) ||
            (startTime.Year <= p.StartTime.Year && endTime.Year >= p.EndTime.Year)).Select(p => p).ToList();

            if (searchKLineFileInfos.Count < 1)
            {
                searchKLineFileInfos.AddRange(NewKLineDayFileInfo(folder, startTime, endTime));
            }

            return searchKLineFileInfos;
        }

        private static List<KLineFileInfo> GetKLineMin1FileInfo(
            string folder, DateTime startTime, DateTime endTime)
        {
            var searchKLineFileInfos = GetKLineFileInfos(folder).Where(p =>
            startTime.Year <= p.StartTime.Year && endTime.Year >= p.EndTime.Year).Select(p => p).ToList();

            if (searchKLineFileInfos.Count < 1)
            {
                searchKLineFileInfos.AddRange(NewKLineMinFileInfo(folder, startTime, endTime));
            }

            return searchKLineFileInfos;
        }

        private static List<KLineFileInfo> GetKLineMin5FileInfo(
            string folder, DateTime startTime, DateTime endTime)
        {
            var searchKLineFileInfos = GetKLineFileInfos(folder).Where(p =>
            startTime.Year <= p.StartTime.Year && endTime.Year >= p.EndTime.Year).Select(p => p).ToList();

            if (searchKLineFileInfos.Count < 1)
            {
                searchKLineFileInfos.AddRange(NewKLineMinFileInfo(folder, startTime, endTime));
            }

            return searchKLineFileInfos;
        }

        private static string GetKLineFolder(KLineType type, string stockCode)
        {
            string strType;
            switch (type)
            {
                // 这里不直接使用枚举转string，为了避免将来可能修改了枚举名字，导致文件路径无法读取的问题
                case KLineType.Day:
                    strType = "Day";
                    break;
                case KLineType.Min1:
                    strType = "Min1";
                    break;
                case KLineType.Min5:
                    strType = "Min5";
                    break;
                default:
                    throw new NotSupportedException();
            }

            // 文件路径增加了市场，避免不同市场存在相同挂牌代码的问题
            string folder = Path.Combine(DataFolder, "KLineData", GetStockMarket(stockCode), stockCode, strType);
            CreateFolderIsNotExist(folder);
            return folder;
        }

        private static string GetStockMarket(string stockCode)
        {
            if (stockCode.StartsWith("5") ||
                stockCode.StartsWith("6") ||
                stockCode.StartsWith("9"))
            {
                return "sh";
            }
            else if (stockCode.StartsWith("009") ||
                stockCode.StartsWith("126") ||
                stockCode.StartsWith("110"))
            {
                return "sh";
            }
            else
            {
                return "sz";
            }
        }
        #endregion
    }
}
