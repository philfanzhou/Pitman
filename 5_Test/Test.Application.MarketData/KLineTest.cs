using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ore.Infrastructure.MarketData;
using Pitman.Application.MarketData;
using Pitman.Distributed.DataTransferObject;
using Pitman.Domain.FileStructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Test.Application.MarketData
{
    [TestClass]
    public class KLineTest
    {
        //
        private IEnumerable<IStockKLine> ExampleStockKLineDay(DateTime bgnDay, DateTime endDay)
        {
            List<IStockKLine> example = new List<IStockKLine>();
            
            while (bgnDay <= endDay)
            {
                if (bgnDay.DayOfWeek != DayOfWeek.Saturday && bgnDay.DayOfWeek != DayOfWeek.Sunday)
                {
                    example.Add(new StockKLineDto
                    {
                        Amount = 5176270700,
                        Close = 18.83,
                        Time = bgnDay,
                        High = 18.99,
                        Low = 17.62,
                        Open = 17.92,
                        Volume = 280927290
                    });
                }
                bgnDay = bgnDay.AddDays(1);
            }

            return example;
        }
        //
        private IEnumerable<IStockKLine> ExampleStockKLineMin1(DateTime bgnDay, DateTime endDay)
        {
            List<IStockKLine> example = new List<IStockKLine>();
            
            while (bgnDay <= endDay)
            {
                if (bgnDay.DayOfWeek != DayOfWeek.Saturday && bgnDay.DayOfWeek != DayOfWeek.Sunday)
                {
                    DateTime bgnAm = new DateTime(bgnDay.Year, bgnDay.Month, bgnDay.Day, 9, 0, 0);
                    DateTime endAm = new DateTime(bgnDay.Year, bgnDay.Month, bgnDay.Day, 11, 30, 0);
                    while (bgnAm <= endAm)
                    {
                        example.Add(new StockKLineDto
                        {
                            Amount = 1945900,
                            Close = 17.79,
                            Time = bgnAm,
                            High = 17.79,
                            Low = 17.78,
                            Open = 17.79,
                            Volume = 109401
                        });
                        bgnAm = bgnAm.AddMinutes(1);
                    }

                    DateTime bgnPm = new DateTime(bgnDay.Year, bgnDay.Month, bgnDay.Day, 13, 0, 0);
                    DateTime endPm = new DateTime(bgnDay.Year, bgnDay.Month, bgnDay.Day, 15, 0, 0);
                    while (bgnPm <= endPm)
                    {
                        example.Add(new StockKLineDto
                        {
                            Amount = 1945900,
                            Close = 17.79,
                            Time = bgnPm,
                            High = 17.79,
                            Low = 17.78,
                            Open = 17.79,
                            Volume = 109401
                        });
                        bgnPm = bgnPm.AddMinutes(1);
                    }
                }
                bgnDay = bgnDay.AddDays(1);
            }

            return example;
        }
        //
        private IEnumerable<IStockKLine> ExampleStockKLineMin5(DateTime bgnDay, DateTime endDay)
        {
            List<IStockKLine> example = new List<IStockKLine>();
            
            while (bgnDay <= endDay)
            {
                if (bgnDay.DayOfWeek != DayOfWeek.Saturday && bgnDay.DayOfWeek != DayOfWeek.Sunday)
                {
                    DateTime bgnAm = new DateTime(bgnDay.Year, bgnDay.Month, bgnDay.Day, 9, 0, 0);
                    DateTime endAm = new DateTime(bgnDay.Year, bgnDay.Month, bgnDay.Day, 11, 30, 0);
                    while (bgnAm <= endAm)
                    {
                        example.Add(new StockKLineDto
                        {
                            Amount = 60122500,
                            Close = 18.19,
                            Time = bgnAm,
                            High = 18.26,
                            Low = 18.17,
                            Open = 18.26,
                            Volume = 3299037
                        });
                        bgnAm = bgnAm.AddMinutes(5);
                    }

                    DateTime bgnPm = new DateTime(bgnDay.Year, bgnDay.Month, bgnDay.Day, 13, 0, 0);
                    DateTime endPm = new DateTime(bgnDay.Year, bgnDay.Month, bgnDay.Day, 15, 0, 0);
                    while (bgnPm <= endPm)
                    {
                        example.Add(new StockKLineDto
                        {
                            Amount = 60122500,
                            Close = 18.19,
                            Time = bgnPm,
                            High = 18.26,
                            Low = 18.17,
                            Open = 18.26,
                            Volume = 3299037
                        });
                        bgnPm = bgnPm.AddMinutes(5);
                    }
                }
                bgnDay = bgnDay.AddDays(1);
            }

            return example;
        }

        private List<StockKLineDto> GetKLineUpdates(List<IStockKLine> insertDatas)
        {
            List<StockKLineDto> kLineUpdates = new List<StockKLineDto>();
            foreach (StockKLineDto it in insertDatas)
            {
                it.Low = 1.0;
                kLineUpdates.Add(it);
            }
            return kLineUpdates;
        }
        
        private void CleanupFiles(List<string> dataFiles)
        {
            if (dataFiles == null)
                return;

            foreach (var file in dataFiles)
            {
                if (File.Exists(file))
                {
                    File.Delete(file);
                }
            }
        }
        
        //
        // 摘要:
        //     日线
        [TestMethod]
        public void TestMethod_Day()
        {
            string stockCode_600036 = "600036";
            string stockCode_000400 = "000400";
            DateTime startTime = new DateTime(2014, 1, 1);
            DateTime endTime = new DateTime(2015, 12, 31);
            List<IStockKLine> insertDatas = ExampleStockKLineDay(startTime, endTime).ToList();

            //var kLineFileInfos_600036 = DataFiles.GetKLineFileInfo(KLineType.Day, stockCode_600036, startTime, endTime);
            //List<string> dataFiles_600036 = kLineFileInfos_600036.Select(p=>p.FullPath).ToList();
            List<string> dataFiles_600036 = new List<string> { new Day1KLineFile(stockCode_600036).GetFilePath() };
            CleanupFiles(dataFiles_600036);

            //var kLineFileInfos_000400 = DataFiles.GetKLineFileInfo(KLineType.Day, stockCode_000400, startTime, endTime);
            //List<string> dataFiles_000400 = kLineFileInfos_000400.Select(p => p.FullPath).ToList();
            List<string> dataFiles_000400 = new List<string> { new Day1KLineFile(stockCode_000400).GetFilePath() };
            CleanupFiles(dataFiles_000400);

            var appService = new KLineAppService();

            #region // 测试插入数据
            appService.Add(KLineType.Day, stockCode_600036, insertDatas);
            Assert.IsTrue(appService.Exists(KLineType.Day, stockCode_600036, insertDatas[insertDatas.Count - 1]));

            int count = 100;
            for (int i = 0; i < count; i++)
            {
                appService.Add(KLineType.Day, stockCode_000400, insertDatas[i]);
            }
            Assert.IsTrue(appService.Exists(KLineType.Day, stockCode_000400, insertDatas[count -1]));
            #endregion

            #region // 测试更新数据
            List<StockKLineDto> kLineUpdates = GetKLineUpdates(insertDatas);
            appService.Update(KLineType.Day, stockCode_600036, kLineUpdates);
            Assert.IsTrue(appService.Exists(KLineType.Day, stockCode_600036, kLineUpdates[0]));

            StockKLineDto kLineUpdate = insertDatas[0] as StockKLineDto;
            kLineUpdate.Open = 0;
            appService.Update(KLineType.Day, stockCode_000400, kLineUpdate);
            kLineUpdate.Close = 100;
            appService.Update(KLineType.Day, stockCode_000400, kLineUpdate);
            Assert.IsTrue(appService.Exists(KLineType.Day, stockCode_000400, kLineUpdate));            
            #endregion

            #region // 测试读取数据
            var securities_600036 = appService.Get(KLineType.Day, stockCode_600036, insertDatas[0].Time, insertDatas[insertDatas.Count - 1].Time).ToList();
            Assert.IsNotNull(securities_600036);
            Assert.IsTrue(securities_600036.Count == insertDatas.Count);
            Assert.AreEqual(kLineUpdates[0].Low, securities_600036[0].Low);

            var securities_000400 = appService.Get(KLineType.Day, stockCode_000400, insertDatas[0].Time, insertDatas[count - 1].Time).ToList();
            Assert.IsNotNull(securities_000400);
            Assert.IsTrue(securities_000400.Count == count);
            Assert.AreEqual(kLineUpdate.Open, securities_000400[0].Open);
            Assert.AreEqual(kLineUpdate.Close, securities_000400[0].Close);
            #endregion
        }
        ////
        //// 摘要:
        ////     周线
        //[TestMethod]
        //public void TestMethod_Week()
        //{
        //}
        ////
        //// 摘要:
        ////     月线
        //[TestMethod]
        //public void TestMethod_Month()
        //{
        //}
        ////
        //// 摘要:
        ////     季线
        //[TestMethod]
        //public void TestMethod_Quarter()
        //{
        //}
        ////
        //// 摘要:
        ////     年线
        //[TestMethod]
        //public void TestMethod_Year()
        //{
        //}
        //
        // 摘要:
        //     1分钟线
        [TestMethod]
        public void TestMethod_Min1()
        {
            string stockCode_600036 = "600036";
            string stockCode_000400 = "000400";
            DateTime startTime = new DateTime(2015, 1, 1);
            DateTime endTime = new DateTime(2015, 1, 31);
            List<IStockKLine> insertDatas = ExampleStockKLineMin1(startTime, endTime).ToList();

            //var kLineFileInfos_600036 = DataFiles.GetKLineFileInfo(KLineType.Min1, stockCode_600036, startTime, endTime);
            //List<string> dataFiles_600036 = kLineFileInfos_600036.Select(p => p.FullPath).ToList();
            List<string> dataFiles_600036 = new Min1KLineFile(stockCode_600036).GetFilePath(startTime, endTime).ToList();
            CleanupFiles(dataFiles_600036);

            //var kLineFileInfos_000400 = DataFiles.GetKLineFileInfo(KLineType.Min1, stockCode_000400, startTime, endTime);
            //List<string> dataFiles_000400 = kLineFileInfos_000400.Select(p => p.FullPath).ToList();
            List<string> dataFiles_000400 = new Min1KLineFile(stockCode_000400).GetFilePath(startTime, endTime).ToList();
            CleanupFiles(dataFiles_000400);

            var appService = new KLineAppService();

            #region // 测试插入数据
            appService.Add(KLineType.Min1, stockCode_600036, insertDatas);
            Assert.IsTrue(appService.Exists(KLineType.Min1, stockCode_600036, insertDatas[insertDatas.Count - 1]));

            int count = 100;
            for (int i = 0; i < count; i++)
            {
                appService.Add(KLineType.Min1, stockCode_000400, insertDatas[i]);
            }
            Assert.IsTrue(appService.Exists(KLineType.Min1, stockCode_000400, insertDatas[count - 1]));
            #endregion

            #region // 测试更新数据
            List<StockKLineDto> kLineUpdates = GetKLineUpdates(insertDatas);
            //此种方式实在慢的可以
            //appService.Update(KLineType.Min1, stockCode_600036, kLineUpdates);
            //Assert.IsTrue(appService.Exists(KLineType.Min1, stockCode_600036, kLineUpdates[kLineUpdates.Count - 1]));
            appService.Update(KLineType.Min1, stockCode_600036, kLineUpdates[0]);
            Assert.IsTrue(appService.Exists(KLineType.Min1, stockCode_600036, kLineUpdates[kLineUpdates.Count - 1]));

            StockKLineDto kLineUpdate = kLineUpdates[0];
            kLineUpdate.Open = 0;
            appService.Update(KLineType.Min1, stockCode_000400, kLineUpdate);
            kLineUpdate.Close = 100;
            appService.Update(KLineType.Min1, stockCode_000400, kLineUpdate);
            Assert.IsTrue(appService.Exists(KLineType.Min1, stockCode_000400, kLineUpdate));
            #endregion

            #region // 测试读取数据
            var securities_600036 = appService.Get(KLineType.Min1, stockCode_600036, insertDatas[0].Time, insertDatas[insertDatas.Count - 1].Time).ToList();
            Assert.IsNotNull(securities_600036);
            Assert.IsTrue(securities_600036.Count == insertDatas.Count);
            Assert.AreEqual(insertDatas[0].Low, securities_600036[0].Low);

            var securities_000400 = appService.Get(KLineType.Min1, stockCode_000400, insertDatas[0].Time, insertDatas[count - 1].Time).ToList();
            Assert.IsNotNull(securities_000400);
            Assert.IsTrue(securities_000400.Count == count);
            Assert.AreEqual(kLineUpdate.Open, securities_000400[0].Open);
            Assert.AreEqual(kLineUpdate.Close, securities_000400[0].Close);
            #endregion
        }
        //
        // 摘要:
        //     5分钟线
        [TestMethod]
        public void TestMethod_Min5()
        {
            string stockCode_600036 = "600036";
            string stockCode_000400 = "000400";
            DateTime startTime = new DateTime(2015, 1, 1);
            DateTime endTime = new DateTime(2015, 1, 1);            
            List<IStockKLine> insertDatas = ExampleStockKLineMin5(startTime, endTime).ToList();

            //var kLineFileInfos_600036 = DataFiles.GetKLineFileInfo(KLineType.Min5, stockCode_600036, startTime, endTime);
            //List<string> dataFiles_600036 = kLineFileInfos_600036.Select(p => p.FullPath).ToList();
            List<string> dataFiles_600036 = new Min5KLineFile(stockCode_600036).GetFilePath(startTime, endTime).ToList();
            CleanupFiles(dataFiles_600036);

            //var kLineFileInfos_000400 = DataFiles.GetKLineFileInfo(KLineType.Min5, stockCode_000400, startTime, endTime);
            //List<string> dataFiles_000400 = kLineFileInfos_000400.Select(p => p.FullPath).ToList();
            List<string> dataFiles_000400 = new Min5KLineFile(stockCode_000400).GetFilePath(startTime, endTime).ToList();
            CleanupFiles(dataFiles_000400);

            var appService = new KLineAppService();

            #region// 测试插入数据
            appService.Add(KLineType.Min5, stockCode_600036, insertDatas);
            Assert.IsTrue(appService.Exists(KLineType.Min5, stockCode_600036, insertDatas[insertDatas.Count - 1]));

            int count = insertDatas.Count/2;
            for (int i = 0; i < count; i++)
            {
                appService.Add(KLineType.Min5, stockCode_000400, insertDatas[i]);
            }
            Assert.IsTrue(appService.Exists(KLineType.Min5, stockCode_000400, insertDatas[count - 1]));
            #endregion

            #region// 测试更新数据
            List<StockKLineDto> kLineUpdates = GetKLineUpdates(insertDatas);
            //此种方式实在慢的可以
            //appService.Update(KLineType.Min5, stockCode_600036, kLineUpdates);
            //Assert.IsTrue(appService.Exists(KLineType.Min5, stockCode_600036, kLineUpdates[kLineUpdates.Count - 1]));
            appService.Update(KLineType.Min5, stockCode_600036, kLineUpdates[0]);
            Assert.IsTrue(appService.Exists(KLineType.Min5, stockCode_600036, kLineUpdates[kLineUpdates.Count - 1]));

            StockKLineDto kLineUpdate = kLineUpdates[0];
            kLineUpdate.Open = 0;
            appService.Update(KLineType.Min5, stockCode_000400, kLineUpdate);
            kLineUpdate.Close = 100;
            appService.Update(KLineType.Min5, stockCode_000400, kLineUpdate);
            Assert.IsTrue(appService.Exists(KLineType.Min5, stockCode_000400, kLineUpdate));            
            #endregion

            #region// 测试读取数据
            var securities_600036 = appService.Get(KLineType.Min5, stockCode_600036, insertDatas[0].Time, insertDatas[insertDatas.Count - 1].Time).ToList();
            Assert.IsNotNull(securities_600036);
            Assert.IsTrue(securities_600036.Count == insertDatas.Count);
            Assert.AreEqual(kLineUpdates[0].Low, securities_600036[0].Low);

            var securities_000400 = appService.Get(KLineType.Min5, stockCode_000400, insertDatas[0].Time, insertDatas[count - 1].Time).ToList();
            Assert.IsNotNull(securities_000400);
            Assert.IsTrue(securities_000400.Count == count);
            Assert.AreEqual(kLineUpdate.Open, securities_000400[0].Open);
            Assert.AreEqual(kLineUpdate.Close, securities_000400[0].Close);
            #endregion
        }
        ////
        //// 摘要:
        ////     15分钟线
        //[TestMethod]
        //public void TestMethod_Min15()
        //{
        //}
        ////
        //// 摘要:
        ////     30分钟线
        //[TestMethod]
        //public void TestMethod_Min30()
        //{
        //}
        ////
        //// 摘要:
        ////     60分钟线
        //[TestMethod]
        //public void TestMethod_Min60()
        //{
        //}
    }
}
