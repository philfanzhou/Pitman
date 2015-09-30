﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Pitman.Infrastructure.MarketData.API;
using System.Linq;
using Pitman.Application.MarketData;
using Pitman.Domain.MarketData;

namespace Test.Domain.MarketData
{
    [TestClass]
    public class IntradayInfoTest
    {

        [TestMethod]
        public void TestRealTimeDataToIntradayData()
        {
            List<string> dataSource = GetSourceDate().ToList();

            List<SinaRealTimeData> realTimeDataList = dataSource.Select(
                str => new SinaRealTimeData(str)).ToList();

            IntradayInfo info = new IntradayInfo(new DateTime(2015, 9, 8));
            foreach (var item in realTimeDataList)
            {
                info.Add(RealTimeItemConverter.Convert(item));
            }

            Assert.IsTrue(info.Items.Count() == 6);

            IntradayData data1300 = info.Items.ToList()[2];
            Assert.AreEqual(0, data1300.Time.Minute);
            Assert.AreEqual(16.18, data1300.Price);
            Assert.AreEqual(16.26, data1300.AveragePrice);
            Assert.AreEqual(0.02, data1300.Change);
            Assert.AreEqual(0.12, data1300.ChangeRate);
            Assert.AreEqual(390744, data1300.IntradayVolume);
            Assert.AreEqual(6327356, data1300.IntradayAmount);

            IntradayData data1301 = info.Items.ToList()[3];
            Assert.AreEqual(1, data1301.Time.Minute);
            Assert.AreEqual(16.24, data1301.Price);
            Assert.AreEqual(16.26, data1301.AveragePrice);
            Assert.AreEqual(0.08, data1301.Change);
            Assert.AreEqual(0.50, data1301.ChangeRate);
            Assert.AreEqual(176704, data1301.IntradayVolume);
            Assert.AreEqual(2861000, data1301.IntradayAmount);


            IntradayData data1302 = info.Items.ToList()[4];
            Assert.AreEqual(2, data1302.Time.Minute);
            Assert.AreEqual(16.18, data1302.Price);
            Assert.AreEqual(16.26, data1302.AveragePrice);
            Assert.AreEqual(0.02, data1302.Change);
            Assert.AreEqual(0.12, data1302.ChangeRate);
            Assert.AreEqual(126729, data1302.IntradayVolume);
            Assert.AreEqual(2056903, data1302.IntradayAmount);

            IntradayData data1504 = info.Items.ToList()[5];
            Assert.AreEqual(4, data1504.Time.Minute);
        }

        private IEnumerable<string> GetSourceDate()
        {
            List<string> strList = new List<string>
            {
                "var hq_str_sh600036=\"招商银行,16.16,16.16,16.20,16.40,16.05,16.20,16.22,33483129,544403720,9122,16.20,262715,16.19,15700,16.18,9100,16.17,122100,16.16,6500,16.22,10500,16.23,41900,16.24,81000,16.25,46900,16.26,2015-09-08,11:35:50,00\";",
                "var hq_str_sh600036=\"招商银行,16.16,16.16,16.20,16.40,16.05,16.20,16.22,33483129,544403720,9122,16.20,262715,16.19,15700,16.18,9100,16.17,122100,16.16,6500,16.22,10500,16.23,41900,16.24,81000,16.25,46900,16.26,2015-09-08,12:59:50,00\";",
                "var hq_str_sh600036=\"招商银行,16.16,16.16,16.20,16.40,16.05,16.20,16.22,33483129,544403720,9122,16.20,262715,16.19,15700,16.18,9100,16.17,122100,16.16,6500,16.22,10500,16.23,41900,16.24,81000,16.25,46900,16.26,2015-09-08,12:59:55,00\";",
                "var hq_str_sh600036=\"招商银行,16.16,16.16,16.20,16.40,16.05,16.20,16.22,33483129,544403720,9122,16.20,262715,16.19,15700,16.18,9100,16.17,122100,16.16,6500,16.22,10500,16.23,41900,16.24,81000,16.25,46900,16.26,2015-09-08,13:00:00,00\";",
                "var hq_str_sh600036=\"招商银行,16.16,16.16,16.20,16.40,16.05,16.19,16.20,33697851,547881168,127215,16.19,19000,16.18,7700,16.17,127500,16.16,37629,16.15,43204,16.20,400,16.21,16100,16.22,10400,16.23,41700,16.24,2015-09-08,13:00:05,00\";",
                "var hq_str_sh600036=\"招商银行,16.16,16.16,16.19,16.40,16.05,16.19,16.20,33711051,548094922,122115,16.19,19000,16.18,7200,16.17,127400,16.16,37129,16.15,50604,16.20,400,16.21,16700,16.22,10400,16.23,41700,16.24,2015-09-08,13:00:10,00\";",
                "var hq_str_sh600036=\"招商银行,16.16,16.16,16.20,16.40,16.05,16.19,16.20,33715151,548161342,119015,16.19,18200,16.18,7200,16.17,127400,16.16,37129,16.15,46604,16.20,400,16.21,20300,16.22,10400,16.23,41700,16.24,2015-09-08,13:00:15,00\";",
                "var hq_str_sh600036=\"招商银行,16.16,16.16,16.20,16.40,16.05,16.19,16.20,33715151,548161342,119015,16.19,18200,16.18,7200,16.17,127400,16.16,37129,16.15,46604,16.20,400,16.21,20300,16.22,10400,16.23,41700,16.24,2015-09-08,13:00:20,00\";",
                "var hq_str_sh600036=\"招商银行,16.16,16.16,16.20,16.40,16.05,16.19,16.20,33723751,548300662,119015,16.19,18200,16.18,7200,16.17,127400,16.16,37129,16.15,63904,16.20,400,16.21,20300,16.22,10400,16.23,41700,16.24,2015-09-08,13:00:25,00\";",
                "var hq_str_sh600036=\"招商银行,16.16,16.16,16.19,16.40,16.05,16.19,16.20,33842073,550216396,10793,16.19,18200,16.18,7200,16.17,127400,16.16,37129,16.15,54404,16.20,400,16.21,20300,16.22,10400,16.23,41700,16.24,2015-09-08,13:00:30,00\";",
                "var hq_str_sh600036=\"招商银行,16.16,16.16,16.19,16.40,16.05,16.19,16.20,33851173,550363725,3693,16.19,18200,16.18,7200,16.17,127400,16.16,37129,16.15,54404,16.20,400,16.21,21100,16.22,10400,16.23,41700,16.24,2015-09-08,13:00:35,00\";",
                "var hq_str_sh600036=\"招商银行,16.16,16.16,16.18,16.40,16.05,16.19,16.20,33858073,550475404,2300,16.19,14993,16.18,7200,16.17,127400,16.16,37129,16.15,55404,16.20,400,16.21,21100,16.22,10400,16.23,41700,16.24,2015-09-08,13:00:40,00\";",
                "var hq_str_sh600036=\"招商银行,16.16,16.16,16.18,16.40,16.05,16.19,16.20,33858073,550475404,2800,16.19,14993,16.18,7200,16.17,127400,16.16,37129,16.15,55404,16.20,400,16.21,21100,16.22,10400,16.23,41700,16.24,2015-09-08,13:00:46,00\";",
                "var hq_str_sh600036=\"招商银行,16.16,16.16,16.18,16.40,16.05,16.18,16.19,33871873,550698716,3993,16.18,27200,16.17,127400,16.16,37129,16.15,5400,16.14,31600,16.19,57204,16.20,400,16.21,21100,16.22,10400,16.23,2015-09-08,13:00:51,00\";",
                "var hq_str_sh600036=\"招商银行,16.16,16.16,16.18,16.40,16.05,16.18,16.19,33873873,550731076,1993,16.18,27200,16.17,127400,16.16,37129,16.15,5400,16.14,33900,16.19,57204,16.20,400,16.21,21100,16.22,10400,16.23,2015-09-08,13:00:56,00\";",
                "var hq_str_sh600036=\"招商银行,16.16,16.16,16.18,16.40,16.05,16.18,16.19,33873873,550731076,1993,16.18,27200,16.17,127400,16.16,37129,16.15,5400,16.14,35600,16.19,50304,16.20,400,16.21,21100,16.22,10400,16.23,2015-09-08,13:01:01,00\";",
                "var hq_str_sh600036=\"招商银行,16.16,16.16,16.18,16.40,16.05,16.18,16.19,33874973,550748875,993,16.18,27200,16.17,127400,16.16,37129,16.15,5400,16.14,29400,16.19,50304,16.20,400,16.21,21100,16.22,10400,16.23,2015-09-08,13:01:06,00\";",
                "var hq_str_sh600036=\"招商银行,16.16,16.16,16.17,16.40,16.05,16.17,16.18,33886373,550933223,16793,16.17,127400,16.16,37129,16.15,5400,16.14,17700,16.13,5300,16.18,19000,16.19,50304,16.20,400,16.21,21100,16.22,2015-09-08,13:01:11,00\";",
                "var hq_str_sh600036=\"招商银行,16.16,16.16,16.18,16.40,16.05,16.17,16.18,33891473,551015721,14793,16.17,127400,16.16,37129,16.15,5400,16.14,17700,16.13,15300,16.18,19000,16.19,49304,16.20,400,16.21,21100,16.22,2015-09-08,13:01:16,00\";",
                "var hq_str_sh600036=\"招商银行,16.16,16.16,16.18,16.40,16.05,16.17,16.18,33906573,551260039,14793,16.17,127400,16.16,37129,16.15,5400,16.14,17700,16.13,20400,16.18,19000,16.19,49304,16.20,400,16.21,17500,16.22,2015-09-08,13:01:21,00\";",
                "var hq_str_sh600036=\"招商银行,16.16,16.16,16.17,16.40,16.05,16.17,16.18,33910573,551324722,32093,16.17,127400,16.16,37129,16.15,5400,16.14,17700,16.13,20100,16.18,19000,16.19,49304,16.20,400,16.21,17500,16.22,2015-09-08,13:01:26,00\";",
                "var hq_str_sh600036=\"招商银行,16.16,16.16,16.18,16.40,16.05,16.17,16.18,33913773,551376478,30093,16.17,127400,16.16,37129,16.15,5400,16.14,17700,16.13,19300,16.18,12100,16.19,50804,16.20,400,16.21,17500,16.22,2015-09-08,13:01:31,00\";",
                "var hq_str_sh600036=\"招商银行,16.16,16.16,16.17,16.40,16.05,16.17,16.18,33929373,551628880,29493,16.17,127400,16.16,37129,16.15,5400,16.14,17700,16.13,11200,16.18,12100,16.19,50804,16.20,400,16.21,17500,16.22,2015-09-08,13:01:36,00\";",
                "var hq_str_sh600036=\"招商银行,16.16,16.16,16.18,16.40,16.05,16.17,16.18,33931273,551659622,29993,16.17,127400,16.16,37129,16.15,5400,16.14,17700,16.13,9300,16.18,4000,16.19,53604,16.20,400,16.21,17500,16.22,2015-09-08,13:01:41,00\";",
                "var hq_str_sh600036=\"招商银行,16.16,16.16,16.19,16.40,16.05,16.17,16.19,33965473,552212791,8393,16.17,127400,16.16,37129,16.15,5400,16.14,17700,16.13,1100,16.19,54504,16.20,400,16.21,14200,16.22,10400,16.23,2015-09-08,13:01:46,00\";",
                "var hq_str_sh600036=\"招商银行,16.16,16.16,16.20,16.40,16.05,16.20,16.21,34021077,553113565,9796,16.20,500,16.18,8393,16.17,127400,16.16,37129,16.15,400,16.21,14200,16.22,10400,16.23,41600,16.24,33200,16.25,2015-09-08,13:01:51,00\";",
                "var hq_str_sh600036=\"招商银行,16.16,16.16,16.24,16.40,16.05,16.22,16.24,34050577,553592076,6100,16.22,500,16.18,8393,16.17,127400,16.16,37129,16.15,40600,16.24,33200,16.25,46900,16.26,100,16.27,17000,16.28,2015-09-08,13:01:56,00\";",
                "var hq_str_sh600036=\"招商银行,16.16,16.16,16.22,16.40,16.05,16.18,16.19,34056677,553691018,500,16.18,13593,16.17,127400,16.16,37129,16.15,5400,16.14,1200,16.19,7500,16.22,40600,16.24,33300,16.25,46900,16.26,2015-09-08,13:02:01,00\";",
                "var hq_str_sh600036=\"招商银行,16.16,16.16,16.19,16.40,16.05,16.21,16.22,34059577,553737940,4300,16.21,12893,16.17,127400,16.16,37129,16.15,5400,16.14,7500,16.22,40600,16.24,33200,16.25,46900,16.26,100,16.27,2015-09-08,13:02:06,00\";",
                "var hq_str_sh600036=\"招商银行,16.16,16.16,16.22,16.40,16.05,16.21,16.24,34071077,553924430,300,16.21,15393,16.17,127400,16.16,37129,16.15,5400,16.14,40600,16.24,33200,16.25,46900,16.26,100,16.27,17000,16.28,2015-09-08,13:02:11,00\";",
                "var hq_str_sh600036=\"招商银行,16.16,16.16,16.24,16.40,16.05,16.18,16.22,34079977,554068927,21000,16.18,26393,16.17,120000,16.16,37129,16.15,5400,16.14,500,16.22,30000,16.23,33000,16.24,33300,16.25,46900,16.26,2015-09-08,13:02:16,00\";",
                "var hq_str_sh600036=\"招商银行,16.16,16.16,16.24,16.40,16.05,16.21,16.22,34079977,554068927,8600,16.21,31000,16.18,26393,16.17,120000,16.16,37129,16.15,500,16.22,30100,16.23,33000,16.24,33300,16.25,46900,16.26,2015-09-08,13:02:21,00\";",
                "var hq_str_sh600036=\"招商银行,16.16,16.16,16.23,16.40,16.05,16.18,16.23,34088277,554203611,31000,16.18,30193,16.17,120000,16.16,37129,16.15,5400,16.14,25300,16.23,33000,16.24,33300,16.25,46600,16.26,100,16.27,2015-09-08,13:02:26,00\";",
                "var hq_str_sh600036=\"招商银行,16.16,16.16,16.24,16.40,16.05,16.22,16.24,34134277,554950338,5600,16.22,31000,16.18,30193,16.17,120000,16.16,37129,16.15,15300,16.24,33300,16.25,46600,16.26,100,16.27,17000,16.28,2015-09-08,13:02:31,00\";",
                "var hq_str_sh600036=\"招商银行,16.16,16.16,16.25,16.40,16.05,16.24,16.25,34162046,555401347,5600,16.24,31,16.21,31000,16.18,30193,16.17,120000,16.16,23300,16.25,46600,16.26,100,16.27,17000,16.28,24918,16.29,2015-09-08,13:02:36,00\";",
                "var hq_str_sh600036=\"招商银行,16.16,16.16,16.25,16.40,16.05,16.18,16.24,34175846,555625326,29331,16.18,30393,16.17,120000,16.16,37129,16.15,5400,16.14,2900,16.24,30000,16.25,46700,16.26,100,16.27,17000,16.28,2015-09-08,13:02:41,00\";",
                "var hq_str_sh600036=\"招商银行,16.16,16.16,16.18,16.40,16.05,16.18,16.22,34177306,555648979,28371,16.18,30393,16.17,119700,16.16,37129,16.15,5400,16.14,500,16.22,8100,16.23,2400,16.24,30000,16.25,46700,16.26,2015-09-08,13:02:46,00\";",
                "var hq_str_sh600036=\"招商银行,16.16,16.16,16.65,16.97,16.05,16.62,16.64,99744306,1648957753,24600,16.62,118200,16.61,143600,16.60,1600,16.59,49000,16.58,5900,16.64,5300,16.65,24700,16.66,9014,16.67,228371,16.68,2015-09-08,15:04:09,00\";"
            };

            return strList;
        }
    }
}
