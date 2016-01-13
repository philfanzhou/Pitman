using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ore.Infrastructure.MarketData;

namespace Pitman.Infrastructure.FileDatabase
{
    public class StockProfileDataRepository
    {
        public void Add(IStockProfile data)
        {
            using (var file = StockProfileFile.CreateOrOpen())
            {
                StockProfileDataItem dataItem = data.Convert();
                file.Add(dataItem);
            }
        }

        public IEnumerable<IStockProfile> GetDataAll()
        {
            string filePath = PathHelper.StockProfileFile;

            List<StockProfileDataItem> result = new List<StockProfileDataItem>();
            if (File.Exists(filePath))
            {
                var file = new StockProfileFile(filePath);
                result.AddRange(file.ReadAll().Distinct());
            }

            return result.Cast<IStockProfile>();
        }

        public IStockProfile GetData(string stockCode)
        {
            string filePath = PathHelper.StockProfileFile;

            if (File.Exists(filePath))
            {
                var file = new StockProfileFile(filePath);
                var lstAll = file.ReadAll().Distinct();
                var it = lstAll.SingleOrDefault(x => x.CodeA == stockCode);

                if (string.IsNullOrEmpty(it.CodeA.Trim()))
                    return null;

                return it;
            }

            return null;
        }

        public IEnumerable<IStockProfile> GetData(IEnumerable<string> stockCodes)
        {
            string filePath = PathHelper.StockProfileFile;
            if (File.Exists(filePath))
            {
                var file = new StockProfileFile(filePath);
                var lstSel = from it in file.ReadAll().Distinct()
                             where stockCodes.Contains(it.CodeA)
                             select it;
                return lstSel.Cast<IStockProfile>();
            }

            return null;
        }

        public bool Exists(string stockCode)
        {
            return GetData(stockCode) != null;
        }
    }

    internal static class StockProfileExt
    {
        public static StockProfileDataItem Convert(this IStockProfile self)
        {
            StockProfileDataItem outputData = new StockProfileDataItem
            {
                //
                // 摘要:
                //     会计师事务所
                AccountingFirm = self.AccountingFirm,
                //
                // 摘要:
                //     区域
                Area = self.Area,
                //
                // 摘要:
                //     董秘
                BoardSecretary = self.BoardSecretary,
                //
                // 摘要:
                //     工商登记
                BusinessRegistration = self.BusinessRegistration,
                //
                // 摘要:
                //     董事长
                Chairman = self.Chairman,
                //
                // 摘要:
                //     A股交易代码
                CodeA = self.CodeA,
                //
                // 摘要:
                //     B股交易代码
                CodeB = self.CodeB,
                //
                // 摘要:
                //     H股交易代码
                CodeH = self.CodeH,
                //
                // 摘要:
                //     公司简介
                CompanyProfile = self.CompanyProfile,
                //
                // 摘要:
                //     联系电话
                ContactNumber = self.ContactNumber,
                //
                // 摘要:
                //     电子信箱
                Email = self.Email,
                //
                // 摘要:
                //     公司英文名称
                EnglishName = self.EnglishName,
                //
                // 摘要:
                //     成立日期
                EstablishmentDate = self.EstablishmentDate,
                //
                // 摘要:
                //     证券交易所
                Exchange = self.Exchange,
                //
                // 摘要:
                //     传真
                Fax = self.Fax,
                //
                // 摘要:
                //     公司名称
                FullName = self.FullName,
                //
                // 摘要:
                //     总经理
                GeneralManager = self.GeneralManager,
                //
                // 摘要:
                //     独立董事
                IndependentDirectors = self.IndependentDirectors,
                //
                // 摘要:
                //     所属行业
                Industry = self.Industry,
                //
                // 摘要:
                //     律师事务所
                LawOffice = self.LawOffice,
                //
                // 摘要:
                //     法人代表
                LegalRepresentative = self.LegalRepresentative,
                //
                // 摘要:
                //     上市日期
                ListDate = self.ListDate,
                //
                // 摘要:
                //     曾用名
                NameUsedBefore = self.NameUsedBefore,
                //
                // 摘要:
                //     雇员人数
                NumberOfEmployees = self.NumberOfEmployees,
                //
                // 摘要:
                //     管理人员人数
                NumberOfManagement = self.NumberOfManagement,
                //
                // 摘要:
                //     办公地址
                OfficeAddress = self.OfficeAddress,
                //
                // 摘要:
                //     主营业务范围
                PrimeBusiness = self.PrimeBusiness,
                //
                // 摘要:
                //     注册地址
                RegisteredAddress = self.RegisteredAddress,
                //
                // 摘要:
                //     注册资本(元)
                RegisteredCapital = self.RegisteredCapital,
                //
                // 摘要:
                //     证券事务代表
                SecuritiesAffairsRepresentatives = self.SecuritiesAffairsRepresentatives,
                //
                // 摘要:
                //     A股证券简称
                ShortNameA = self.ShortNameA,
                //
                // 摘要:
                //     B股证券简称
                ShortNameB = self.ShortNameB,
                //
                // 摘要:
                //     B股证券简称
                ShortNameH = self.ShortNameH,
                //
                // 摘要:
                //     公司网址
                Website = self.Website,
                //
                // 摘要:
                //     邮政编码
                ZipCode = self.ZipCode
            };

            return outputData;
        }
    }
}
