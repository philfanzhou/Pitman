using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ore.Infrastructure.MarketData;
using Pitman.Infrastructure.FileDatabase;

namespace Test.Infrastructure.FileDatabase
{
    [TestClass]
    public class TestStockKLine
    {
        //2014~2015
        private IEnumerable<IStockKLine> ExampleStockKLineDay_600036()
        {
            List<IStockKLine> example = new List<IStockKLine>();

            DateTime bgnDay = new DateTime(2014, 1, 1);
            DateTime endDay = new DateTime(2015, 12, 31);
            while(bgnDay <= endDay)
            {
                if (bgnDay.DayOfWeek != DayOfWeek.Saturday && bgnDay.DayOfWeek != DayOfWeek.Sunday)
                {
                    example.Add(new StockKLineDataItem
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
                    example.Add(new StockKLineDataItem
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
                        example.Add(new StockKLineDataItem
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
                        example.Add(new StockKLineDataItem
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
                        example.Add(new StockKLineDataItem
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
                        example.Add(new StockKLineDataItem
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
                        example.Add(new StockKLineDataItem
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
                        example.Add(new StockKLineDataItem
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

        private List<string> ExampleStockCodes()
        {
            List<string> stockCodes = new List<string>();
            stockCodes.Add("600518");//康美药业
            stockCodes.Add("600036");//招商银行
            stockCodes.Add("600298");//安琪酵母
            stockCodes.Add("601933");//永辉超市
            stockCodes.Add("600660");//福耀玻璃
            stockCodes.Add("600196");//复星医药
            stockCodes.Add("300118");//东方日升
            stockCodes.Add("000400");//许继电气

            return stockCodes;
        }

        private bool FileExists(string stockCode, KLineType kLineType, DateTime dt)
        {
            string filepath = PathHelper.GetKLineDataFilePath(stockCode, kLineType, dt);

            return System.IO.File.Exists(filepath);
        }

        private bool FolderExists(string stockCode, KLineType kLineType)
        {
            string folderpath = string.Format(@"{0}\{1}\{2}\", PathHelper.StockKLineFolder, stockCode, kLineType.ToString());

            return System.IO.Directory.Exists(folderpath);
        }

        [TestMethod]
        public void TestMethod1()
        {
            var exampleDay_600036 = ExampleStockKLineDay_600036();//2年：522
            var exampleDay_000400 = ExampleStockKLineDay_000400();//1年：261
            List<string> stockCodes = ExampleStockCodes();

            var repository = new StockKLineDataRepository();

            #region 日K线

            foreach(var it in exampleDay_600036)
            {
                if (!repository.Exists("600036", KLineType.Daily, it.Time))
                    repository.Add("600036", KLineType.Daily, it);
            }

            foreach (var it in exampleDay_000400)
            {
                if (!repository.Exists("000400", KLineType.Daily, it.Time))
                    repository.Add("000400", KLineType.Daily, it);
            }

            var dataDay_600036_20140111 = repository.GetData("600036", KLineType.Daily, new DateTime(2014, 1, 11));//周末没有数据
            Assert.IsNull(dataDay_600036_20140111);
            var dataDay_600036_20141013 = repository.GetData("600036", KLineType.Daily, new DateTime(2014, 10, 13));
            Assert.IsNotNull(dataDay_600036_20141013);
            Assert.IsTrue(dataDay_600036_20141013.Time == new DateTime(2014, 10, 13));

            var dataDay_000400_20151011 = repository.GetData("000400", KLineType.Daily, new DateTime(2015, 10, 11));//周末没有数据
            Assert.IsNull(dataDay_000400_20151011);
            var dataDay_000400_20151012 = repository.GetData("000400", KLineType.Daily, new DateTime(2015, 10, 12));
            Assert.IsNotNull(dataDay_000400_20151012);
            Assert.IsTrue(dataDay_000400_20151012.Time == new DateTime(2015, 10, 12));

            var dataDay_600036_20140101_20151231 = repository.GetData("600036", KLineType.Daily, new DateTime(2014, 1, 1), new DateTime(2015, 12, 31)).ToList();
            Assert.IsNotNull(dataDay_600036_20140101_20151231);
            Assert.IsTrue(dataDay_600036_20140101_20151231.Count == exampleDay_600036.Count());
            Assert.IsTrue(dataDay_600036_20140101_20151231[4].Time == new DateTime(2014, 1, 7));

            var dataDay_000400_20150101_20151231 = repository.GetData("000400", KLineType.Daily, new DateTime(2015, 1, 1), new DateTime(2015, 12, 31)).ToList();
            Assert.IsNotNull(dataDay_000400_20150101_20151231);
            Assert.IsTrue(dataDay_000400_20150101_20151231.Count == exampleDay_000400.Count());
            Assert.IsTrue(dataDay_000400_20150101_20151231[6].Time == new DateTime(2015, 1, 9));

            var latestDay = repository.GetLatest(stockCodes, KLineType.Daily).ToList();
            Assert.IsNotNull(latestDay);
            Assert.IsTrue(latestDay.Count == 2);
            Assert.IsTrue(latestDay[0].Time == new DateTime(2015, 12, 31));
            Assert.IsTrue(latestDay[1].Time == new DateTime(2015, 12, 31));

            #endregion            
        }

        [TestMethod]
        public void TestMethod2()
        {
            var exampleMin1_600036 = ExampleStockKLineMin1_600036();//1年:70992
            List<string> stockCodes = ExampleStockCodes();

            var repository = new StockKLineDataRepository();

            #region 1分钟线

            if (!FolderExists("600036", KLineType.Min1))
            {
                foreach (var it in exampleMin1_600036)
                {
                    //if (!repository.Exists("600036", KLineType.Min1, it.Time))//加上判断之后,效率太低了
                    repository.Add("600036", KLineType.Min1, it);
                }
            }

            Assert.IsFalse(repository.Exists("600036", KLineType.Min1, new DateTime(2015, 1, 11, 10, 30, 00)));
            var dataMin1_600036_201501111030 = repository.GetData("600036", KLineType.Min1, new DateTime(2015, 1, 11, 10, 30, 00));//周末没有数据
            Assert.IsNull(dataMin1_600036_201501111030);

            Assert.IsTrue(repository.Exists("600036", KLineType.Min1, new DateTime(2015, 10, 13, 10, 30, 00)));
            var dataMin1_600036_201510131030 = repository.GetData("600036", KLineType.Min1, new DateTime(2015, 10, 13, 10, 30, 00));
            Assert.IsNotNull(dataMin1_600036_201510131030);
            Assert.IsTrue(dataMin1_600036_201510131030.Time == new DateTime(2015, 10, 13, 10, 30, 00));

            var dataMin1_600036_20150101_20151231 = repository.GetData("600036", KLineType.Min1, new DateTime(2015, 1, 1, 9, 0, 0), new DateTime(2015, 12, 31, 15, 0, 0)).ToList();
            Assert.IsNotNull(dataMin1_600036_20150101_20151231);
            Assert.IsTrue(dataMin1_600036_20150101_20151231.Count == exampleMin1_600036.Count());
            Assert.IsTrue(dataMin1_600036_20150101_20151231[10].Time == new DateTime(2015, 1, 1, 9, 10, 0));

            var latestMin1 = repository.GetLatest(stockCodes, KLineType.Min1).ToList();
            Assert.IsNotNull(latestMin1);
            Assert.IsTrue(latestMin1.Count == 1);
            Assert.IsTrue(latestMin1[0].Time == new DateTime(2015, 12, 31, 15, 0, 0));

            #endregion
        }

        [TestMethod]
        public void TestMethod3()
        {
            var exampleMin5_600036 = ExampleStockKLineMin5_600036();//1年：14616
            var exampleMin5_000400 = ExampleStockKLineMin5_000400();//1年：14616
            List<string> stockCodes = ExampleStockCodes();

            var repository = new StockKLineDataRepository();

            #region 5分钟K线

            if (!FolderExists("600036", KLineType.Min5))
            {
                foreach (var it in exampleMin5_600036)
                {
                    //if (!repository.Exists("600036", KLineType.Min5, it.Time))
                        repository.Add("600036", KLineType.Min5, it);
                }
            }

            if (!FolderExists("000400", KLineType.Min5))
            {
                foreach (var it in exampleMin5_000400)
                {
                    //if (!repository.Exists("000400", KLineType.Min5, it.Time))
                        repository.Add("000400", KLineType.Min5, it);
                }
            }

            Assert.IsFalse(repository.Exists("600036", KLineType.Min5, new DateTime(2015, 1, 11, 10, 55, 0)));
            var dataMin5_600036_201501111055 = repository.GetData("600036", KLineType.Min5, new DateTime(2015, 1, 11, 10, 55, 0));//周末没有数据
            Assert.IsNull(dataMin5_600036_201501111055);

            Assert.IsTrue(repository.Exists("600036", KLineType.Min5, new DateTime(2015, 10, 13, 10, 55, 0)));
            var dataMin5_600036_201510131055 = repository.GetData("600036", KLineType.Min5, new DateTime(2015, 10, 13, 10, 55, 0));
            Assert.IsNotNull(dataMin5_600036_201510131055);
            Assert.IsTrue(dataMin5_600036_201510131055.Time == new DateTime(2015, 10, 13, 10, 55, 0));

            var dataMin5_000400_201510111335 = repository.GetData("000400", KLineType.Min5, new DateTime(2015, 10, 11, 13, 35, 0));//周末没有数据
            Assert.IsNull(dataMin5_000400_201510111335);
            var dataMin5_000400_201510121335 = repository.GetData("000400", KLineType.Min5, new DateTime(2015, 10, 12, 13, 35, 0));
            Assert.IsNotNull(dataMin5_000400_201510121335);
            Assert.IsTrue(dataMin5_000400_201510121335.Time == new DateTime(2015, 10, 12, 13, 35, 0));

            var dataMin5_600036_20150101_20151231 = repository.GetData("600036", KLineType.Min5, new DateTime(2015, 1, 1, 9, 0, 0), new DateTime(2015, 12, 31, 15, 0, 0)).ToList();
            Assert.IsNotNull(dataMin5_600036_20150101_20151231);
            Assert.IsTrue(dataMin5_600036_20150101_20151231.Count == exampleMin5_600036.Count());
            Assert.IsTrue(dataMin5_600036_20150101_20151231[1].Time == new DateTime(2015, 1, 1, 9, 5, 0));

            var dataMin5_000400_20150101_20151231 = repository.GetData("000400", KLineType.Min5, new DateTime(2015, 1, 1, 9, 0, 0), new DateTime(2015, 12, 31, 15, 0, 0)).ToList();
            Assert.IsNotNull(dataMin5_000400_20150101_20151231);
            Assert.IsTrue(dataMin5_000400_20150101_20151231.Count == exampleMin5_000400.Count());
            Assert.IsTrue(dataMin5_000400_20150101_20151231[2].Time == new DateTime(2015, 1, 1, 9, 10, 0));

            var latestMin5 = repository.GetLatest(stockCodes, KLineType.Min5).ToList();
            Assert.IsNotNull(latestMin5);
            Assert.IsTrue(latestMin5.Count == 2);
            Assert.IsTrue(latestMin5[0].Time == new DateTime(2015, 12, 31, 15, 0, 0));
            Assert.IsTrue(latestMin5[1].Time == new DateTime(2015, 12, 31, 15, 0, 0));

            #endregion
        }
    }
}
