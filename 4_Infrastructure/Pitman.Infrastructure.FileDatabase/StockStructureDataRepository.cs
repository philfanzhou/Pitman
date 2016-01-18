using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ore.Infrastructure.MarketData;

namespace Pitman.Infrastructure.FileDatabase
{
    public class StockStructureDataRepository
    {
        public void Add(string stockCode, IStockStructure data)
        {
            using (var file = StockStructureFile.CreateOrOpen(stockCode))
            {
                StockStructureDataItem dataItem = data.Convert();
                file.Add(dataItem);
            }
        }

        public IEnumerable<IStockStructure> GetData(string stockCode)
        {
            string filePath = string.Format(@"{0}\{1}.dat", PathHelper.StockStructureFolder, stockCode);

            List<StockStructureDataItem> result = new List<StockStructureDataItem>();
            if (File.Exists(filePath))
            {
                var file = new StockStructureFile(filePath);
                result.AddRange(file.ReadAll());
            }

            return result.Cast<IStockStructure>();
        }

        public IEnumerable<IStockStructure> GetData(IEnumerable<string> stockCodes)
        {
            string fileFolder = PathHelper.StockStructureFolder;
            if (!Directory.Exists(fileFolder))
                return null;

            List<StockStructureDataItem> result = new List<StockStructureDataItem>();
            foreach (var it in stockCodes)
            {
                string fileName = string.Format(@"{0}\{1}.dat", fileFolder, it);
                if (File.Exists(fileName))
                {
                    var file = new StockStructureFile(fileName);
                    result.AddRange(file.ReadAll());
                }
            }

            return result.Cast<IStockStructure>();
        }

        public IEnumerable<IStockStructure> GetDataAll()
        {
            string fileFolder = PathHelper.StockStructureFolder;
            if (!Directory.Exists(fileFolder))
                return null;

            List<StockStructureDataItem> result = new List<StockStructureDataItem>();
            DirectoryInfo dir = new DirectoryInfo(fileFolder);
            foreach (var it in dir.GetFiles())
            {
                var file = new StockStructureFile(it.FullName);
                result.AddRange(file.ReadAll());
            }

            return result.Cast<IStockStructure>();
        }

        public bool Exists(string stockCode)
        {
            string filePath = string.Format(@"{0}\{1}.dat", PathHelper.StockStructureFolder, stockCode);
            return File.Exists(filePath);
        }
    }

    internal static class StockStructureExt
    {
        public static StockStructureDataItem Convert(this IStockStructure self)
        {
            StockStructureDataItem outputData = new StockStructureDataItem
            {
                ////
                //// 摘要:
                ////     代码
                //Code = self.Code,
                //
                // 摘要:
                //     变动日期
                DateOfChange = self.DateOfChange,
                //
                // 摘要:
                //     公告日期
                DateOfDeclaration = self.DateOfDeclaration,
                //
                // 摘要:
                //     境内法人股
                DomesticLegalPersonShares = self.DomesticLegalPersonShares,
                //
                // 摘要:
                //     境内发起人股
                DomesticSponsorsShares = self.DomesticSponsorsShares,
                //
                // 摘要:
                //     高管股
                ExecutiveShares = self.ExecutiveShares,
                //
                // 摘要:
                //     基金持股
                FundsShares = self.FundsShares,
                //
                // 摘要:
                //     一般法人股
                GeneralLegalPersonShares = self.GeneralLegalPersonShares,
                //
                // 摘要:
                //     内部职工股
                InternalStaffShares = self.InternalStaffShares,
                ////
                //// 摘要:
                ////     交易市场
                //Market = self.Market,
                //
                // 摘要:
                //     优先股
                PreferredStock = self.PreferredStock,
                //
                // 摘要:
                //     募集法人股
                RaiseLegalPersonShares = self.RaiseLegalPersonShares,
                //
                // 摘要:
                //     变更原因
                Reason = self.Reason,
                //
                // 摘要:
                //     限售A股
                RestrictedSharesA = self.RestrictedSharesA,
                //
                // 摘要:
                //     限售B股
                RestrictedSharesB = self.RestrictedSharesB,
                //
                // 摘要:
                //     流通A股
                SharesA = self.SharesA,
                //
                // 摘要:
                //     流通B股
                SharesB = self.SharesB,
                //
                // 摘要:
                //     流通H股
                SharesH = self.SharesH,
                ////
                //// 摘要:
                ////     简称
                //ShortName = self.ShortName,
                //
                // 摘要:
                //     国有法人股
                StateOwnedLegalPersonShares = self.StateOwnedLegalPersonShares,
                //
                // 摘要:
                //     国家股
                StateShares = self.StateShares,
                //
                // 摘要:
                //     战略投资者持股
                StrategicInvestorsShares = self.StrategicInvestorsShares,
                //
                // 摘要:
                //     总股本
                TotalShares = self.TotalShares,
                //
                // 摘要:
                //     转配股
                TransferredAllottedShares = self.TransferredAllottedShares
            };

            return outputData;
        }
    }
}
