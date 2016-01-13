using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Infrastructure.MemoryMap;
using Ore.Infrastructure.MarketData;

namespace Pitman.Infrastructure.FileDatabase
{
    internal struct ParticipationDataItem: IParticipation
    {
        /// <summary>
        /// 挂牌代码
        /// </summary>
        private String64 code;
        public string Code
        {
            get
            {
                return code.Value;
            }
            set
            {
                code.Value = value;
            }
        }

        /// <summary>
        /// 日期与时间
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// 机构参与度（%） : 45
        /// </summary>
        public double Value { get; set; }

        /// <summary>
        /// 主力净流入
        /// </summary>
        public double MainForceInflows { get; set; }

        /// <summary>
        /// 超大单流入
        /// </summary>
        public double SuperLargeInflows { get; set; }

        /// <summary>
        /// 最近1日主力成本
        /// </summary>
        public double CostPrice1Day { get; set; }

        /// <summary>
        /// 最近20日主力成本
        /// </summary>
        public double CostPrice20Day { get; set; }
    }
}
