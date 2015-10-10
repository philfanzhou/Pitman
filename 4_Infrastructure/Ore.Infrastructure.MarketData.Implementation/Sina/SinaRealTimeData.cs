using System;

namespace Ore.Infrastructure.MarketData.Implementation
{
    public class SinaRealTimeData
    {
        /// <summary>
        /// 代码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 今开
        /// </summary>
        public double TodayOpen { get; set; }

        /// <summary>
        /// 昨收
        /// </summary>
        public double YesterdayClose { get; set; }

        /// <summary>
        /// 成交价
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// 最高
        /// </summary>
        public double High { get; set; }

        /// <summary>
        /// 最低
        /// </summary>
        public double Low { get; set; }

        /// <summary>
        /// 成交量
        /// </summary>
        public double Volume { get; set; }

        /// <summary>
        /// 成交额
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// 卖五价
        /// </summary>
        public double SellFivePrice { get; set; }

        /// <summary>
        /// 卖五量
        /// </summary>
        public double SellFiveVolume { get; set; }

        /// <summary>
        /// 卖四价
        /// </summary>
        public double SellFourPrice { get; set; }

        /// <summary>
        /// 卖四量
        /// </summary>
        public double SellFourVolume { get; set; }

        /// <summary>
        /// 卖三价
        /// </summary>
        public double SellThreePrice { get; set; }

        /// <summary>
        /// 卖三量
        /// </summary>
        public double SellThreeVolume { get; set; }

        /// <summary>
        /// 卖二价
        /// </summary>
        public double SellTwoPrice { get; set; }

        /// <summary>
        /// 卖二量
        /// </summary>
        public double SellTwoVolume { get; set; }

        /// <summary>
        /// 卖一价
        /// </summary>
        public double SellOnePrice { get; set; }

        /// <summary>
        /// 卖一量
        /// </summary>
        public double SellOneVolume { get; set; }

        /// <summary>
        /// 买一价
        /// </summary>
        public double BuyOnePrice { get; set; }

        /// <summary>
        /// 买一量
        /// </summary>
        public double BuyOneVolume { get; set; }

        /// <summary>
        /// 买二价
        /// </summary>
        public double BuyTwoPrice { get; set; }

        /// <summary>
        /// 买二量
        /// </summary>
        public double BuyTwoVolume { get; set; }

        /// <summary>
        /// 买三价
        /// </summary>
        public double BuyThreePrice { get; set; }

        /// <summary>
        /// 买三量
        /// </summary>
        public double BuyThreeVolume { get; set; }

        /// <summary>
        /// 买四价
        /// </summary>
        public double BuyFourPrice { get; set; }

        /// <summary>
        /// 买四量
        /// </summary>
        public double BuyFourVolume { get; set; }

        /// <summary>
        /// 买五价
        /// </summary>
        public double BuyFivePrice { get; set; }

        /// <summary>
        /// 买五量
        /// </summary>
        public double BuyFiveVolume { get; set; }

        /// <summary>
        /// 日期与时间
        /// </summary>
        public DateTime Time { get; set; }

        public SinaRealTimeData(string strData)
        {
            strData = strData.Remove(0, 11);
            this.Code = strData.Substring(0, 8);

            int startIndex = strData.IndexOf("\"") + 1;
            int length = strData.LastIndexOf("\"") - startIndex;
            strData = strData.Substring(startIndex, length);

            string[] fields = strData.Split(',');

            this.Name = fields[0];
            this.TodayOpen = Convert.ToDouble(fields[1]);
            this.YesterdayClose = Convert.ToDouble(fields[2]);
            this.Price = Convert.ToDouble(fields[3]);
            this.High = Convert.ToDouble(fields[4]);
            this.Low = Convert.ToDouble(fields[5]);
            this.Volume = Convert.ToDouble(fields[8]);
            this.Amount = Convert.ToDouble(fields[9]);

            this.BuyOneVolume = Convert.ToDouble(fields[10]);
            this.BuyOnePrice = Convert.ToDouble(fields[11]);

            this.BuyTwoVolume = Convert.ToDouble(fields[12]);
            this.BuyTwoPrice = Convert.ToDouble(fields[13]);

            this.BuyThreeVolume = Convert.ToDouble(fields[14]);
            this.BuyThreePrice = Convert.ToDouble(fields[15]);

            this.BuyFourVolume = Convert.ToDouble(fields[16]);
            this.BuyFourPrice = Convert.ToDouble(fields[17]);

            this.BuyFiveVolume = Convert.ToDouble(fields[18]);
            this.BuyFivePrice = Convert.ToDouble(fields[19]);

            this.SellOneVolume = Convert.ToDouble(fields[20]);
            this.SellOnePrice = Convert.ToDouble(fields[21]);

            this.SellTwoVolume = Convert.ToDouble(fields[22]);
            this.SellTwoPrice = Convert.ToDouble(fields[23]);

            this.SellThreeVolume = Convert.ToDouble(fields[24]);
            this.SellThreePrice = Convert.ToDouble(fields[25]);

            this.SellFourVolume = Convert.ToDouble(fields[26]);
            this.SellFourPrice = Convert.ToDouble(fields[27]);

            this.SellFiveVolume = Convert.ToDouble(fields[28]);
            this.SellFivePrice = Convert.ToDouble(fields[29]);

            this.Time = Convert.ToDateTime(fields[30] + " " + fields[31]);
        }
    }
}
