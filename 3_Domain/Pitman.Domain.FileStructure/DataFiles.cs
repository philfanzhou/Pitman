using Ore.Infrastructure.MarketData;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Pitman.Domain.FileStructure
{
    public static class DataFiles
    {
        private static readonly string DataFolder = Environment.CurrentDirectory + @"\Data";


        /*需要将FileDatabase.PathHelper中的逻辑移动到此工程来。
        因为Path的逻辑相对固定，属于Pitman的具体业务，和底层的具体实现无太大关系，所以移动到Domain里面来
        */

        public static string GetSecuritiesFile()
        {
            string folder = Path.Combine(DataFolder, "SecurityData");
            CreateFolderIsNotExist(folder);
            return Path.Combine(folder, "Securities.sdf");// 注意文件后缀名必须是sdf
        }

        public static string GetStockBonusFile(string stockCode)
        {
            /*因为是一只股票一个文件，所以需要传入参数*/
            string folder = Path.Combine(DataFolder, "StockBonusData");
            CreateFolderIsNotExist(folder);
            return Path.Combine(folder, stockCode + ".sdf");
        }

        public static string GetStockProfileFile()
        {
            string folder = Path.Combine(DataFolder, "StockProfileData");
            CreateFolderIsNotExist(folder);
            return Path.Combine(folder, "StockProfile.sdf");
        }

        public static string GetStockStructureFile(string stockCode)
        {
            /*因为是一只股票一个文件，所以需要传入参数*/
            string folder = Path.Combine(DataFolder, "StockStructureData");
            CreateFolderIsNotExist(folder);
            return Path.Combine(folder, stockCode + ".sdf");
        }

        public static string GetKLineFiles(KLineType type, string stockCode, DateTime dt)
        {
            string folder = GetKLineFolder(type, stockCode);
            ////方案1
            //return Path.Combine(folder, dt.ToString("yyyy") + ".sdf");

            //方案2
            var existFiles = GetKLineFileNamePerYears(folder, dt, dt);
            if (existFiles != null && existFiles.Count() > 0)
                return Path.Combine(folder, existFiles.First());

            string filepath = null;
            switch (type)
            {
                /// 日线
                case KLineType.Day:
                    filepath = Path.Combine(folder, string.Format("{0}-{1}.sdf", dt.ToString("yyyy"), dt.AddYears(10).ToString("yyyy")));
                    break;
                /// 1分钟线
                case KLineType.Min1:
                /// 5分钟线
                case KLineType.Min5:
                    filepath = Path.Combine(folder, dt.ToString("yyyy") + ".sdf");
                    break;
            }
            return filepath;
        }

        public static IEnumerable<string> GetKLineFiles(KLineType type, string stockCode, DateTime startTime, DateTime endTime)
        {
            /*因为时间跨度可能导致多个存储文件，所以这里的Path返回是一个集合*/
            if (startTime > endTime)
            {
                throw new ArgumentOutOfRangeException("startTime", "startTime is less than endTime");
            }

            if (startTime == endTime)
            {
                return new List<string>() { GetKLineFiles(type, stockCode, startTime) };
            }

            string folder = GetKLineFolder(type, stockCode);

            List<string> result = new List<string>();
            ////方案1 
            //while (startTime.Year <= endTime.Year)
            //{
            //    result.Add(Path.Combine(folder, startTime.ToString("yyyy") + ".sdf"));
            //    startTime = startTime.AddYears(1);
            //}
            //if (Directory.Exists(folder))
            //{
            //    DirectoryInfo dir = new DirectoryInfo(folder);
            //    var files = dir.GetFiles().Select(p =>
            //    {
            //        var dts = p.Name.Split('-');
            //        return ((startTime.ToString("yyyy").CompareTo(dts[0]) == 0 || startTime.ToString("yyyy").CompareTo(dts[0]) > 0) &&
            //        (dt.ToString("yyyy").CompareTo(dts[1]) == 0 || dt.ToString("yyyy").CompareTo(dts[1]) < 0));
            //    });               
            //}
            //方案2
            var files = GetKLineFileNamePerYears(folder, startTime, endTime);
            foreach(var f in files)
            {
                result.Add(Path.Combine(folder, f));
            }
            return result;
        }

        private static IEnumerable<string> GetKLineFileNamePerYears(string folder, DateTime startTime, DateTime endTime)
        {
            List<string> files = new List<string>();
            if (Directory.Exists(folder))
            {
                DirectoryInfo directory = new DirectoryInfo(folder);
                FileInfo[] fileInfoArray = directory.GetFiles();
                var queryFiles = fileInfoArray.Where(p =>
                {
                    var splitName = p.Name.Replace(".sdf", "").Split('-');
                    if (splitName.Count() == 2)
                    {
                        return ((startTime.ToString("yyyy").CompareTo(splitName[0]) >= 0 && startTime.ToString("yyyy").CompareTo(splitName[1]) <= 0) ||
                        (endTime.ToString("yyyy").CompareTo(splitName[0]) >= 0 && endTime.ToString("yyyy").CompareTo(splitName[1]) <= 0) ||
                        (startTime.ToString("yyyy").CompareTo(splitName[0]) <= 0 && endTime.ToString("yyyy").CompareTo(splitName[1]) >= 0));
                    }
                    else
                    {
                        return (startTime.ToString("yyyy").CompareTo(splitName[0]) <= 0 && endTime.ToString("yyyy").CompareTo(splitName[0]) >= 0);
                    }
                }).Select(p => p.Name);

                files.AddRange(queryFiles);
            }
            return files;
        }        

        private static string GetKLineFolder(KLineType type, string stockCode)
        {
            string folder = Path.Combine(DataFolder, "KLineData", stockCode, type.ToString());
            CreateFolderIsNotExist(folder);
            return folder;
        }

        private static void CreateFolderIsNotExist(string folder)
        {
            if(!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
        }

    }
}
