using System;

namespace Pitman.Metadata
{
    /// <summary>
    /// 机构参与度
    /// </summary>
    public class OrgPercent
    {
        public int ID
        {
            get;
            set;
        }

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
        public string Day
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
    }
}
