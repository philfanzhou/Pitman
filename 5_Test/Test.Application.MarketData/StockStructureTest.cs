using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pitman.Application.MarketData;
using Pitman.Distributed.Dto;
using Pitman.Domain.FileStructure;

namespace Test.Application.MarketData
{
    [TestClass]
    public class StockStructureTest
    {
        private StockStructureDto example()
        {
            return new StockStructureDto()
            {
                /// <summary>
                /// 变动日期
                /// </summary>
                DateOfChange = new DateTime(2016, 1, 15),
                /// <summary>
                /// 公告日期
                /// </summary>
                DateOfDeclaration = new DateTime(2016, 1, 17),
                /// <summary>
                /// 变更原因
                /// </summary>
                Reason = "*******************",

                /// <summary>
                /// 总股本
                /// </summary>
                TotalShares = 0,
                /// <summary>
                /// 流通A股
                /// </summary>
                SharesA = 0,
                /// <summary>
                /// 高管股
                /// </summary>
                ExecutiveShares = 0,
                /// <summary>
                /// 限售A股
                /// </summary>
                RestrictedSharesA = 0,
                /// <summary>
                /// 流通B股
                /// </summary>
                SharesB = 0,
                /// <summary>
                /// 限售B股
                /// </summary>
                RestrictedSharesB = 0,
                /// <summary>
                /// 流通H股
                /// </summary>
                SharesH = 0,
                /// <summary>
                /// 国家股
                /// </summary>
                StateShares = 0,
                /// <summary>
                /// 国有法人股
                /// </summary>
                StateOwnedLegalPersonShares = 0,
                /// <summary>
                /// 境内法人股
                /// </summary>
                DomesticLegalPersonShares = 0,
                /// <summary>
                /// 境内发起人股
                /// </summary>
                DomesticSponsorsShares = 0,
                /// <summary>
                /// 募集法人股
                /// </summary>
                RaiseLegalPersonShares = 0,
                /// <summary>
                /// 一般法人股
                /// </summary>
                GeneralLegalPersonShares = 0,
                /// <summary>
                /// 战略投资者持股
                /// </summary>
                StrategicInvestorsShares = 0,
                /// <summary>
                /// 基金持股
                /// </summary>
                FundsShares = 0,
                /// <summary>
                /// 转配股
                /// </summary>
                TransferredAllottedShares = 0,
                /// <summary>
                /// 内部职工股
                /// </summary>
                InternalStaffShares = 0,
                /// <summary>
                /// 优先股
                /// </summary>
                PreferredStock = 0,
            };
        }

        [TestMethod]
        public void TestMethod1()
        {
            string stockCode = "600036";
            StockStructureDto insertData = example();

            string dataFile = DataFiles.GetStockStructureFile(stockCode);
            if (File.Exists(dataFile))
            {
                File.Delete(dataFile);
            }

            var appService = new StockStructureAppService();

            // 测试插入数据
            appService.Add(stockCode, insertData);
            Assert.IsTrue(appService.Exists(stockCode, insertData));

            // 测试更新数据
            insertData.SharesA = 100;
            appService.Update(stockCode, insertData);

            insertData.Reason = "测试测试";
            appService.Update(stockCode, insertData);

            Assert.IsTrue(appService.Exists(stockCode, insertData));

            // 测试读取数据
            var securities = appService.Get(stockCode).ToList();
            Assert.IsNotNull(securities);
            Assert.IsTrue(securities.Count == 1);
            Assert.AreEqual(insertData.DateOfChange, securities[0].DateOfChange);
            Assert.AreEqual(insertData.SharesA, securities[0].SharesA);
            Assert.AreEqual(insertData.Reason, securities[0].Reason);
        }
    }
}
