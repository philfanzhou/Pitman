using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ore.Infrastructure.MarketData;
using Pitman.Application.MarketData;
using Pitman.Distributed.Dto;
using Pitman.Domain.FileStructure;
using System.IO;
using System.Linq;

namespace Test.Application.MarketData
{
    [TestClass]
    public class SecurityTest
    {
        [TestMethod]
        public void TestSecurity()
        {
            string dataFile = DataFiles.GetSecuritiesFile();
            if(File.Exists(dataFile))
            {
                File.Delete(dataFile);
            }

            SecurityDto insertData = new SecurityDto()
            {
                Code = "600036",
                ShortName = "招商银行招商银行招商银行",
                Market = Market.XSHG,
                Type = SecurityType.Sotck
            };

            var appService = new SecurityAppService();

            // 测试插入数据
            appService.Add(insertData);
            Assert.IsTrue(appService.Exists(insertData));

            // 测试更新数据
            insertData.ShortName = "招商银行";
            appService.Update(insertData);

            insertData.ShortName = "测试测试";
            appService.Update(insertData);

            Assert.IsTrue(appService.Exists(insertData));


            // 测试读取数据
            var securities = appService.GetAll().ToList();
            Assert.IsNotNull(securities);
            Assert.IsTrue(securities.Count == 1);
            Assert.AreEqual(insertData.ShortName, securities[0].ShortName);
        }
    }
}
