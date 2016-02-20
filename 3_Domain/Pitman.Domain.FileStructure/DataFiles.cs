using Ore.Infrastructure.MarketData;
using System;
using System.IO;

namespace Pitman.Domain.FileStructure
{
    public static partial class DataFiles
    {
        #region Field
        /// <summary>
        /// 数据存放跟目录
        /// </summary>
        internal static readonly string _dataFolder = Environment.CurrentDirectory + @"\Data";
        /// <summary>
        /// 数据文件扩展名
        /// </summary>
        internal const string _fileExtName = ".sdf";
        #endregion

        public static string GetSecuritiesFile()
        {
            CreateFolderIsNotExist(_dataFolder);
            return Path.Combine(_dataFolder, "Securities" + _fileExtName);
        }

        public static string GetStockBonusFile(string stockCode)
        {
            // todo: 根据stockcode来存储文件的时候，为了避免重复代码，folder需要考虑市场子目录
            string folder = Path.Combine(_dataFolder, "StockBonusData", GetStockMarket(stockCode));
            CreateFolderIsNotExist(folder);
            return Path.Combine(folder, stockCode + "Bonus" + _fileExtName);
        }

        public static string GetParticipationFile(string stockCode)
        {
            string folder = Path.Combine(_dataFolder, "ParticipationData", GetStockMarket(stockCode));
            CreateFolderIsNotExist(folder);
            return Path.Combine(folder, stockCode + "Participation" + _fileExtName);
        }

        public static string GetStockProfileFile()
        {
            CreateFolderIsNotExist(_dataFolder);
            return Path.Combine(_dataFolder, "StockProfile" + _fileExtName);
        }

        public static string GetStockStructureFile(string stockCode)
        {
            string folder = Path.Combine(_dataFolder, "StockStructureData", GetStockMarket(stockCode));
            CreateFolderIsNotExist(folder);
            return Path.Combine(folder, stockCode + "Structure" + _fileExtName);
        }

        internal static string GetKLineFolder(string stockCode)
        {
            string folder = Path.Combine(_dataFolder, "KLineData", GetStockMarket(stockCode), stockCode);
            return folder;
        }
        internal static void CreateFolderIsNotExist(string folder)
        {
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
        }

        #region Private Method
        private static string GetStockMarket(string stockCode)
        {
            return FullStockCode.GetByCode(stockCode).Replace(stockCode, string.Empty);
        }
        #endregion

    }
}
