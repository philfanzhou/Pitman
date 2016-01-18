using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ore.Infrastructure.MarketData;

namespace Pitman.Infrastructure.FileDatabase
{
    public class StockBonusDataRepository
    {
        public void Add(string stockCode, IStockBonus data)
        {
            using (var file = StockBonusFile.CreateOrOpen(stockCode))
            {
                StockBonusDataItem dataItem = data.Convert();
                file.Add(dataItem);
            }
        }

        public IEnumerable<IStockBonus> GetData(string stockCode)
        {
            string filePath = string.Format(@"{0}\{1}.dat", PathHelper.StockBonusFolder, stockCode);
            
            List<StockBonusDataItem> result = new List<StockBonusDataItem>();
            if (File.Exists(filePath))
            {
                var file = new StockBonusFile(filePath);
                result.AddRange(file.ReadAll());
            }

            return result.Cast<IStockBonus>();
        }

        public IEnumerable<IStockBonus> GetData(IEnumerable<string> stockCodes)
        {
            string fileFolder = PathHelper.StockBonusFolder;
            if (!Directory.Exists(fileFolder))
                return null;

            List<StockBonusDataItem> result = new List<StockBonusDataItem>();
            foreach (var it in stockCodes)
            {
                string fileName = string.Format(@"{0}\{1}.dat", fileFolder, it);
                if (File.Exists(fileName))
                {
                    var file = new StockBonusFile(fileName);
                    result.AddRange(file.ReadAll());
                }
            }

            return result.Cast<IStockBonus>();
        }

        public IEnumerable<IStockBonus> GetDataAll()
        {
            string fileFolder = PathHelper.StockBonusFolder;
            if (!Directory.Exists(fileFolder))
                return null;

            List<StockBonusDataItem> result = new List<StockBonusDataItem>();
            DirectoryInfo dir = new DirectoryInfo(fileFolder);            
            foreach (var it in dir.GetFiles())
            {
                var file = new StockBonusFile(it.FullName);
                result.AddRange(file.ReadAll());
            }

            return result.Cast<IStockBonus>();
        }

        public bool Exists(string stockCode)
        {
            string filePath = string.Format(@"{0}\{1}.dat", PathHelper.StockBonusFolder, stockCode);
            return File.Exists(filePath);
        }
    }

    internal static class StockBonusExt
    {
        public static StockBonusDataItem Convert(this IStockBonus self)
        {
            StockBonusDataItem outputData = new StockBonusDataItem
            {
                //
                // 摘要:
                //     实际配股比例
                ActualDispatchRate = self.ActualDispatchRate,
                //
                // 摘要:
                //     B、H股税后红利（人民币）
                BAndHDividendAfterTax = self.BAndHDividendAfterTax,
                //
                // 摘要:
                //     B、H股税前红利（人民币）
                BAndHPreTaxDividend = self.BAndHPreTaxDividend,
                //
                // 摘要:
                //     送股比例（10送）
                BonusRate = self.BonusRate,
                //
                // 摘要:
                //     股本基准日
                CapitalStockBaseDate = self.CapitalStockBaseDate,
                //
                // 摘要:
                //     配股前总股本 (万股)
                CapitalStockBeforeDispatch = self.CapitalStockBeforeDispatch,
                //
                // 摘要:
                //     资本公积金转增比例（10转增）
                CapitalSurplusIncreaseRate = self.CapitalSurplusIncreaseRate,
                ////
                //// 摘要:
                ////     代码
                //Code = self.Code,
                //
                // 摘要:
                //     可转债享受权益转股截止日
                ConvertibleBondDate = self.ConvertibleBondDate,
                //
                // 摘要:
                //     公告日期
                DateOfDeclaration = self.DateOfDeclaration,
                //
                // 摘要:
                //     权息说明
                Description = self.Description,
                //
                // 摘要:
                //     配股有效期
                DispatchExpiryDate = self.DispatchExpiryDate,
                //
                // 摘要:
                //     配股上市日
                DispatchListingDate = self.DispatchListingDate,
                //
                // 摘要:
                //     配股价
                DispatchPrice = self.DispatchPrice,
                //
                // 摘要:
                //     配股比例（10配）
                DispatchRate = self.DispatchRate,
                //
                // 摘要:
                //     税后红利（10派）（报价币种）
                DividendAfterTax = self.DividendAfterTax,
                //
                // 摘要:
                //     外币折算汇率
                ExchangeRate = self.ExchangeRate,
                //
                // 摘要:
                //     除权除息日
                ExdividendDate = self.ExdividendDate,
                //
                // 摘要:
                //     红利/配股终止日
                ExpirationDate = self.ExpirationDate,
                //
                // 摘要:
                //     转增比例（10转增）
                IncreaseRate = self.IncreaseRate,
                //
                // 摘要:
                //     发放对象
                IssuingObject = self.IssuingObject,
                //
                // 摘要:
                //     最后交易日
                LastTradingDay = self.LastTradingDay,
                ////
                //// 摘要:
                ////     交易市场
                //Market = self.Market,
                //
                // 摘要:
                //     税前红利（10派）（报价币种）
                PreTaxDividend = self.PreTaxDividend,
                //
                // 摘要:
                //     股权登记日
                RegisterDate = self.RegisterDate,
                //
                // 摘要:
                //     盈余公积金转增比例（10转增）
                ReserveSurplusIncreaseRate = self.ReserveSurplusIncreaseRate,
                //
                // 摘要:
                //     股东大会决议公告日期
                ResolutionOfShareholdersMeetingDate = self.ResolutionOfShareholdersMeetingDate,
                //
                // 摘要:
                //     每股拆细数
                ShareSplitCount = self.ShareSplitCount,
                ////
                //// 摘要:
                ////     简称
                //ShortName = self.ShortName,
                //
                // 摘要:
                //     红利/配股起始日（送、转股到账日)
                StartOrArriveDate = self.StartOrArriveDate,
                //
                // 摘要:
                //     实际配股数 (万股)
                TotalDispatch = self.TotalDispatch,
                //
                // 摘要:
                //     转配价
                TransferredAllottedPrice = self.TransferredAllottedPrice,
                //
                // 摘要:
                //     转配比例
                TransferredAllottedRate = self.TransferredAllottedRate,
                //
                // 摘要:
                //     分红配股类型
                Type = self.Type
            };

            return outputData;
        }
    }
}
