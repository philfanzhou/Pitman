﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.SQLCE
{
    [TestClass]
    public class UnitTest1
    {
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

        [TestMethod]
        public void TestMethod1()
        {
            SQLCEWrapper _sqlCeWrapper = new SQLCEWrapper();
            _sqlCeWrapper.CreateDatabase();

            _sqlCeWrapper.CreateKLineTable();

            DateTime startTime = new DateTime(2015, 1, 1);
            DateTime endTime = new DateTime(2015, 12, 31);
            List<IStockKLine> kLines = ExampleStockKLineMin1(startTime, endTime).ToList();
            System.Diagnostics.Debug.Print(string.Format("KLine data count is {0}", kLines.Count));
            _sqlCeWrapper.InsertIntoDatas(kLines);

            string p_strSQL = "SELECT * FROM KLineTable;";
            DataSet dataSet = _sqlCeWrapper.SelectDataSet(p_strSQL);

            if (dataSet != null && dataSet.Tables.Count > 0)
            {
                foreach (DataTable table in dataSet.Tables)
                    System.Diagnostics.Debug.Print(string.Format("table Rows count is {0}", table.Rows.Count));
            }
            
            _sqlCeWrapper.DeleteDatabase();
        }
    }
}