using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Ore.Infrastructure.MarketData;

namespace Pitman.Infrastructure.FileDatabase
{
    internal static class PathHelper
    {
        private static string dataFolder = Environment.CurrentDirectory + @"\Data\RealTimeData";

        private static string GetMarketFolder(string stockCode)
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

        private static string GetFileFolder(string stockCode)
        {
            return string.Format(@"{0}\{1}\{2}\", dataFolder, GetMarketFolder(stockCode), stockCode);
        }

        private static string GetFileName(DateTime day)
        {
            return string.Format("{0}.dat", day.ToString("yyyyMMdd"));
        }

        internal static string GetFilePath(string stockCode, DateTime day)
        {
            return GetFileFolder(stockCode) + GetFileName(day);
        }

        internal static bool GetLatestFilePath(string stockCode, ref string latestFilePath)
        {
            latestFilePath = string.Empty;

            string todayFilePath = GetFilePath(stockCode, DateTime.Now.Date);
            if(File.Exists(todayFilePath))
            {
                latestFilePath = todayFilePath;
                return true;
            }

            string fileFolder = GetFileFolder(stockCode);
            if(Directory.Exists(fileFolder))
            {
                DirectoryInfo dir = new DirectoryInfo(fileFolder);
                FileInfo file = dir.GetFiles().OrderBy(p => p.CreationTime).LastOrDefault();
                if(file != null)
                {
                    latestFilePath = file.FullName;
                    return true;
                }
            }

            return false;
        }

        internal static IEnumerable<string> GetFilePath(string stockCode, DateTime startDay, DateTime endDay)
        {
            if(startDay.Date > endDay.Date)
            {
                throw new ArgumentOutOfRangeException("startDay", "startDay is less than endDay");
            }

            if(startDay.Date == endDay.Date)
            {
                return new List<string>() { GetFilePath(stockCode, startDay) };
            }

            List<string> result = new List<string>();
            string fileFolder = GetFileFolder(stockCode);
            while(startDay.Date <= endDay.Date)
            {
                result.Add(fileFolder + GetFileName(startDay));
                startDay = startDay.AddDays(1);
            }

            return result;
        }

        /***********************************************************************************/

        public static string DataFolder = Environment.CurrentDirectory + @"\Data";

        public static string SecurityFile = string.Format(@"{0}\SecurityData\Securities.dat", PathHelper.DataFolder);

        public static string StockProfileFile = string.Format(@"{0}\StockProfileData\StockProfiles.dat", PathHelper.DataFolder);

        public static string ParticipationFolder = string.Format(@"{0}\ParticipationData", PathHelper.DataFolder);

        public static string StockBonusFolder = string.Format(@"{0}\StockBonusData", PathHelper.DataFolder);

        public static string StockStructureFolder = string.Format(@"{0}\StockStructureData", PathHelper.DataFolder);

        public static string StockKLineFolder = string.Format(@"{0}\StockKLineData", PathHelper.DataFolder);

        internal static string GetKLineDataFilePath(string stockCode, KLineType kLineType, DateTime dt)
        {
            //方案1
            return string.Format(@"{0}\{1}\{2}\{3}.dat", StockKLineFolder, stockCode, kLineType.ToString(), dt.ToString("yyyy"));

            //方案2
            //string filepath = null;
            //switch (kLineType)
            //{
            //    /// 日线
            //    case KLineType.Daily:
            //        filepath = string.Format(@"{0}\{1}\{2}\{3}.dat", StockKLineFolder, stockCode, kLineType.ToString(), dt.ToString("yyyy"));
            //        break;
            //    /// 1分钟线
            //    case KLineType.Min1:
            //    /// 5分钟线
            //    case KLineType.Min5:
            //        filepath = string.Format(@"{0}\{1}\{2}\{3}.dat", StockKLineFolder, stockCode, kLineType.ToString(), dt.ToString("yyyyMM"));
            //        break;
            //}
            //return filepath;
        }

        internal static IEnumerable<string> GetKLineDataFilePath(string stockCode, KLineType kLineType, DateTime bgnDt, DateTime endDt)
        {
            if (bgnDt > endDt)
            {
                throw new ArgumentOutOfRangeException("startDay", "startDay is less than endDay");
            }

            if (bgnDt == endDt)
            {
                return new List<string>() { GetKLineDataFilePath(stockCode, kLineType, bgnDt) };
            }

            List<string> result = new List<string>();
            string fileFolder = string.Format(@"{0}\{1}\{2}", StockKLineFolder, stockCode, kLineType.ToString());
            //方案1
            while (bgnDt.Year <= endDt.Year)
            {
                result.Add(fileFolder + string.Format(@"\{0}.dat", bgnDt.ToString("yyyy")));
                bgnDt = bgnDt.AddYears(1);
            }
            //方案2
            //switch (kLineType)
            //{
            //    /// 日线
            //    case KLineType.Daily:
            //        while (bgnDt.Year <= endDt.Year)
            //        {
            //            result.Add(fileFolder + string.Format(@"\{0}.dat", bgnDt.ToString("yyyy")));
            //            bgnDt = bgnDt.AddYears(1);
            //        }
            //        break;
            //    /// 1分钟线
            //    case KLineType.Min1:
            //    /// 5分钟线
            //    case KLineType.Min5:
            //        while ((12 * bgnDt.Year + bgnDt.Month) <= (12 * endDt.Year + endDt.Month))
            //        {
            //            result.Add(fileFolder + string.Format(@"\{0}.dat", bgnDt.ToString("yyyyMM")));
            //            bgnDt = bgnDt.AddMonths(1);
            //        }
            //        break;
            //}

            return result;
        }

        internal static bool GetLatestKLineDataFilePath(string stockCode, KLineType kLineType, ref string latestFilePath)
        {
            latestFilePath = string.Empty;

            string todayFilePath = GetKLineDataFilePath(stockCode, kLineType, DateTime.Now);
            if (File.Exists(todayFilePath))
            {
                latestFilePath = todayFilePath;
                return true;
            }

            string fileFolder = string.Format(@"{0}\{1}\{2}", StockKLineFolder, stockCode, kLineType.ToString());
            if (Directory.Exists(fileFolder))
            {
                DirectoryInfo dir = new DirectoryInfo(fileFolder);
                FileInfo file = dir.GetFiles().OrderBy(p => p.CreationTime).LastOrDefault();
                if (file != null)
                {
                    latestFilePath = file.FullName;
                    return true;
                }
            }

            return false;
        }        
    }
}
