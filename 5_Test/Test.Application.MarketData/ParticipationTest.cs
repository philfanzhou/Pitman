using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ore.Infrastructure.MarketData;
using Pitman.Application.MarketData;
using Pitman.Distributed.Dto;
using Pitman.Domain.FileStructure;

namespace Test.Application.MarketData
{
    [TestClass]
    public class ParticipationTest
    {
        private ParticipationDto ExampleParticipation_600036(DateTime day)
        {
            return new ParticipationDto
            {
                CostPrice1Day = 16.37,
                CostPrice20Day = 17.62,
                MainForceInflows = -18890.18,
                SuperLargeInflows = -13224.41,
                Time = day,
                Value = 37.97
            };
        }

        [TestMethod]
        public void TestMethod1()
        {
            string stockCode = "600036";
            var insertData = ExampleParticipation_600036(DateTime.Now);

            string dataFile = DataFiles.GetParticipationFile(stockCode);
            if (File.Exists(dataFile))
            {
                File.Delete(dataFile);
            }

            var appService = new ParticipationAppService();

            // 测试插入数据
            appService.Add(stockCode, insertData);
            Assert.IsTrue(appService.Exists(stockCode, insertData));

            // 测试更新数据
            insertData.CostPrice1Day = 100.00;
            appService.Update(stockCode, insertData);

            insertData.CostPrice20Day = 200.00;
            appService.Update(stockCode, insertData);

            Assert.IsTrue(appService.Exists(stockCode, insertData));

            // 测试读取数据
            var participations = appService.Get(stockCode).ToList();
            Assert.IsNotNull(participations);
            Assert.IsTrue(participations.Count == 1);
            Assert.AreEqual(insertData.Time, participations[0].Time);
            Assert.AreEqual(insertData.CostPrice1Day, participations[0].CostPrice1Day);
            Assert.AreEqual(insertData.CostPrice20Day, participations[0].CostPrice20Day);
        }
    }
}
