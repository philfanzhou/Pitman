using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
    }
}
