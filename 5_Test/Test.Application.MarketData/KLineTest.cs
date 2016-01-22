using System;
using System.Collections.Generic;
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
    public class KLineTest
    {
        //2014~2015
        private IEnumerable<IStockKLine> ExampleStockKLineDay_600036()
        {
            List<IStockKLine> example = new List<IStockKLine>();

            DateTime bgnDay = new DateTime(2014, 1, 1);
            DateTime endDay = new DateTime(2015, 12, 31);
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
        //2015
        private IEnumerable<IStockKLine> ExampleStockKLineDay_000400()
        {
            List<IStockKLine> example = new List<IStockKLine>();

            DateTime bgnDay = new DateTime(2015, 1, 1);
            DateTime endDay = new DateTime(2015, 12, 31);
            while (bgnDay <= endDay)
            {
                if (bgnDay.DayOfWeek != DayOfWeek.Saturday && bgnDay.DayOfWeek != DayOfWeek.Sunday)
                {
                    example.Add(new StockKLineDto
                    {
                        Amount = 1100802350,
                        Close = 32.05,
                        Time = bgnDay,
                        High = 32.21,
                        Low = 30.5,
                        Open = 30.9,
                        Volume = 34821362
                    });
                }
                bgnDay = bgnDay.AddDays(1);
            }

            return example;
        }
        //2015
        private IEnumerable<IStockKLine> ExampleStockKLineMin1_600036()
        {
            List<IStockKLine> example = new List<IStockKLine>();

            DateTime bgnDay = new DateTime(2015, 1, 1);
            DateTime endDay = new DateTime(2015, 12, 31);
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
        //2015
        private IEnumerable<IStockKLine> ExampleStockKLineMin5_600036()
        {
            List<IStockKLine> example = new List<IStockKLine>();

            DateTime bgnDay = new DateTime(2015, 1, 1);
            DateTime endDay = new DateTime(2015, 12, 31);
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
        //2015
        private IEnumerable<IStockKLine> ExampleStockKLineMin5_000400()
        {
            List<IStockKLine> example = new List<IStockKLine>();

            DateTime bgnDay = new DateTime(2015, 1, 1);
            DateTime endDay = new DateTime(2015, 12, 31);
            while (bgnDay <= new DateTime(2015, 12, 31))
            {
                if (bgnDay.DayOfWeek != DayOfWeek.Saturday && bgnDay.DayOfWeek != DayOfWeek.Sunday)
                {
                    DateTime bgnAm = new DateTime(bgnDay.Year, bgnDay.Month, bgnDay.Day, 9, 0, 0);
                    DateTime endAm = new DateTime(bgnDay.Year, bgnDay.Month, bgnDay.Day, 11, 30, 0);
                    while (bgnAm <= endAm)
                    {
                        example.Add(new StockKLineDto
                        {
                            Amount = 10433224,
                            Close = 19.34,
                            Time = bgnAm,
                            High = 19.38,
                            Low = 19.26,
                            Open = 19.35,
                            Volume = 539815
                        });
                        bgnAm = bgnAm.AddMinutes(5);
                    }

                    DateTime bgnPm = new DateTime(bgnDay.Year, bgnDay.Month, bgnDay.Day, 13, 0, 0);
                    DateTime endPm = new DateTime(bgnDay.Year, bgnDay.Month, bgnDay.Day, 15, 0, 0);
                    while (bgnPm <= endPm)
                    {
                        example.Add(new StockKLineDto
                        {
                            Amount = 10433224,
                            Close = 19.34,
                            Time = bgnPm,
                            High = 19.38,
                            Low = 19.26,
                            Open = 19.35,
                            Volume = 539815
                        });
                        bgnPm = bgnPm.AddMinutes(5);
                    }
                }
                bgnDay = bgnDay.AddDays(1);
            }

            return example;
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
        public void TestMethodAdd_Day()
        {
            string stockCode = "600036";
            List<IStockKLine> insertDatas = ExampleStockKLineDay_600036().ToList();

            List<string> dataFiles = DataFiles.GetKLineFiles(KLineType.Day, stockCode, new DateTime(2014, 1, 1), new DateTime(2015, 12, 31)).ToList();
            CleanupFiles(dataFiles);

            var appService = new KLineAppService();

            // 测试插入数据
            foreach (var kLine in insertDatas)
            {
                appService.Add(KLineType.Day, stockCode, kLine);
            }
            //foreach (var kLine in insertDatas)
            //{
            //    Assert.IsTrue(appService.Exists(KLineType.Day, stockCode, kLine));
            //}
            Assert.IsTrue(appService.Exists(KLineType.Day, stockCode, insertDatas[100]));            
        }
        [TestMethod]
        public void TestMethodUpdate_Day()
        {
            string stockCode = "600036";
            List<IStockKLine> insertDatas = ExampleStockKLineDay_600036().ToList();
            
            var appService = new KLineAppService();            

            // 测试更新数据
            StockKLineDto kLineUpdate = insertDatas[0] as StockKLineDto;
            kLineUpdate.Open = 0;
            appService.Update(KLineType.Day, stockCode, kLineUpdate);

            kLineUpdate.Close = 100;
            appService.Update(KLineType.Day, stockCode, kLineUpdate);

            Assert.IsTrue(appService.Exists(KLineType.Day, stockCode, kLineUpdate));
        }
        [TestMethod]
        public void TestMethodRead_Day()
        {
            string stockCode = "600036";
            List<IStockKLine> insertDatas = ExampleStockKLineDay_600036().ToList();
            
            var appService = new KLineAppService();
            
            // 测试读取数据
            var securities = appService.Get(KLineType.Day, stockCode, insertDatas[0].Time, insertDatas[insertDatas.Count - 1].Time).ToList();
            Assert.IsNotNull(securities);
            Assert.IsTrue(securities.Count == insertDatas.Count);
            Assert.AreEqual(insertDatas[0].Open, securities[0].Open);
            Assert.AreEqual(insertDatas[0].Close, securities[0].Close);
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
        public void TestMethodAdd_Min1()
        {
            string stockCode = "600036";
            List<IStockKLine> insertDatas = ExampleStockKLineMin1_600036().ToList();

            List<string> dataFiles = DataFiles.GetKLineFiles(KLineType.Min1, stockCode, new DateTime(2014, 1, 1), new DateTime(2015, 12, 31)).ToList();
            CleanupFiles(dataFiles);

            var appService = new KLineAppService();

            DateTime dtDebug = DateTime.Now;
            // 测试插入数据
            foreach (var kLine in insertDatas)
            {
                dtDebug = DateTime.Now;
                appService.Add(KLineType.Min1, stockCode, kLine);
                System.Diagnostics.Debug.Print("=========>" + (DateTime.Now - dtDebug).TotalMilliseconds.ToString());
            }
            //foreach (var kLine in insertDatas)
            //{
            //    Assert.IsTrue(appService.Exists(KLineType.Min1, stockCode, kLine));
            //}
            Assert.IsTrue(appService.Exists(KLineType.Min1, stockCode, insertDatas[100]));            
        }
        [TestMethod]
        public void TestMethodUpdate_Min1()
        {
            string stockCode = "600036";
            List<IStockKLine> insertDatas = ExampleStockKLineMin1_600036().ToList();
            
            var appService = new KLineAppService();
            
            // 测试更新数据
            StockKLineDto kLineUpdate = insertDatas[0] as StockKLineDto;
            kLineUpdate.Open = 0;
            appService.Update(KLineType.Min1, stockCode, kLineUpdate);

            kLineUpdate.Close = 100;
            appService.Update(KLineType.Min1, stockCode, kLineUpdate);

            Assert.IsTrue(appService.Exists(KLineType.Min1, stockCode, kLineUpdate));            
        }
        [TestMethod]
        public void TestMethodRead_Min1()
        {
            string stockCode = "600036";
            List<IStockKLine> insertDatas = ExampleStockKLineMin1_600036().ToList();
            
            var appService = new KLineAppService();
            
            // 测试读取数据
            var securities = appService.Get(KLineType.Min1, stockCode, insertDatas[0].Time, insertDatas[insertDatas.Count - 1].Time).ToList();
            Assert.IsNotNull(securities);
            Assert.IsTrue(securities.Count == insertDatas.Count);
            Assert.AreEqual(insertDatas[0].Open, securities[0].Open);
            Assert.AreEqual(insertDatas[0].Close, securities[0].Close);
        }
        //
        // 摘要:
        //     5分钟线
        [TestMethod]
        public void TestMethodAdd_Min5()
        {
            string stockCode = "600036";
            List<IStockKLine> insertDatas = ExampleStockKLineMin5_600036().ToList();

            List<string> dataFiles = DataFiles.GetKLineFiles(KLineType.Min5, stockCode, new DateTime(2014, 1, 1), new DateTime(2015, 12, 31)).ToList();
            CleanupFiles(dataFiles);

            var appService = new KLineAppService();

            DateTime dtDebug = DateTime.Now;
            // 测试插入数据
            foreach (var kLine in insertDatas)
            {
                dtDebug = DateTime.Now;
                appService.Add(KLineType.Min5, stockCode, kLine);
                System.Diagnostics.Debug.Print("=========>" + (DateTime.Now - dtDebug).TotalMilliseconds.ToString());
            }
            //foreach (var kLine in insertDatas)
            //{
            //    Assert.IsTrue(appService.Exists(KLineType.Min5, stockCode, kLine));
            //}
            Assert.IsTrue(appService.Exists(KLineType.Min5, stockCode, insertDatas[100]));
        }
        [TestMethod]
        public void TestMethodUpdate_Min5()
        {
            string stockCode = "600036";
            List<IStockKLine> insertDatas = ExampleStockKLineMin5_600036().ToList();

            var appService = new KLineAppService();

            // 测试更新数据
            StockKLineDto kLineUpdate = insertDatas[0] as StockKLineDto;
            kLineUpdate.Open = 0;
            appService.Update(KLineType.Min5, stockCode, kLineUpdate);

            kLineUpdate.Close = 100;
            appService.Update(KLineType.Min5, stockCode, kLineUpdate);

            Assert.IsTrue(appService.Exists(KLineType.Min5, stockCode, kLineUpdate));
        }
        [TestMethod]
        public void TestMethodRead_Min5()
        {
            string stockCode = "600036";
            List<IStockKLine> insertDatas = ExampleStockKLineMin5_600036().ToList();

            var appService = new KLineAppService();

            // 测试读取数据
            var securities = appService.Get(KLineType.Min5, stockCode, insertDatas[0].Time, insertDatas[insertDatas.Count - 1].Time).ToList();
            Assert.IsNotNull(securities);
            Assert.IsTrue(securities.Count == insertDatas.Count);
            Assert.AreEqual(insertDatas[0].Open, securities[0].Open);
            Assert.AreEqual(insertDatas[0].Close, securities[0].Close);
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
