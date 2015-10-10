using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ore.Infrastructure.MarketData.Implementation
{
    public class OrgPercentData
    {
        /// <summary>
        /// 股票代码
        /// </summary>
        public string Code
        {
            get;
            set;
        }

        /// <summary>
        /// 交易日：2015-07-03
        /// </summary>
        public DateTime Day
        {
            get;
            set;
        }

        /// <summary>
        /// 机构参与度（%） : 45
        /// </summary>
        public float Value
        {
            get;
            set;
        }

        /// <summary>
        /// 主力净流入
        /// </summary>
        public double Zhuli
        {
            get;
            set;
        }

        /// <summary>
        /// 超大单流入
        /// </summary>
        public double Chaoda
        {
            get;
            set;
        }

        public OrgPercentData(string code, string dataStr)
        {
            this.Code = code;
            this.Day = Convert.ToDateTime(dataStr.Substring(dataStr.IndexOf("数据日期") + 5, 10)).Date;
            this.Value = float.Parse(dataStr.Substring(dataStr.IndexOf("机构参与度为") + 6, 10).Split('%')[0]);
            this.Zhuli = double.Parse(dataStr.Substring(dataStr.IndexOf("主力净流入") + 5, 100).Split('>')[1].Split('<')[0]);
            this.Chaoda = double.Parse(dataStr.Substring(dataStr.IndexOf("超大单流入") + 5, 100).Split('>')[1].Split('<')[0]);
        }
    }
}
