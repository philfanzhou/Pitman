using Ore.Infrastructure.MarketData;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

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
            throw new NotImplementedException();
        }

        public static IEnumerable<string> GetKLineFiles(
            KLineType type, string stockCode,
            DateTime startTime, DateTime endTime)
        {
            /*因为时间跨度可能导致多个存储文件，所以这里的Path返回是一个集合*/
            throw new NotImplementedException();
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
