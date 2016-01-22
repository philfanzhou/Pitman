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
        public static IEnumerable<KLineFileInfo> GetKLineFileInfo(
            KLineType type, string stockCode,
            DateTime startTime, DateTime endTime)
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

        public static KLineFileInfo GetKLineFileInfo(
            KLineType type, string stockCode, DateTime time)
        {
            return GetKLineFileInfo(type, stockCode, time, time).ToList()[0];
        }

        #region Private Method
        private static List<KLineFileInfo> GetKLineDayFileInfo(
            string folder, DateTime startTime, DateTime endTime)
        {
            /*
            1：不用特殊考虑开始时间和结束时间相同的问题，只要开始时间和结束时间落在范围内，按范围返回就是了
            2：日线可以不用考虑分文件的问题
            3：min1和min5需要考虑分文件
            4：文件后缀名为sdf, 建议在这个类中用一个常量来表示，不用每个地方都硬编码
            */

            throw new NotImplementedException();
        }

        private static List<KLineFileInfo> GetKLineMin1FileInfo(
            string folder, DateTime startTime, DateTime endTime)
        {
            throw new NotImplementedException();
        }

        private static List<KLineFileInfo> GetKLineMin5FileInfo(
            string folder, DateTime startTime, DateTime endTime)
        {
            throw new NotImplementedException();
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
