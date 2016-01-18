﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitman.Infrastructure.EF.Repository
{
    internal class ParticipationConfig : EntityTypeConfiguration<ParticipationDbo>
    {
        public ParticipationConfig()
        {
            /// <summary>
            /// 日期与时间
            /// </summary>
            this.HasKey(p => p.Time);

            /// <summary>
            /// 机构参与度（%） : 45
            /// </summary>
            this.Property(p => p.Value).IsRequired();

            /// <summary>
            /// 主力净流入
            /// </summary>
            this.Property(p => p.MainForceInflows).IsRequired();

            /// <summary>
            /// 超大单流入
            /// </summary>
            this.Property(p => p.SuperLargeInflows).IsRequired();

            /// <summary>
            /// 最近1日主力成本
            /// </summary>
            this.Property(p => p.CostPrice1Day).IsRequired();

            /// <summary>
            /// 最近20日主力成本
            /// </summary>
            this.Property(p => p.CostPrice20Day).IsRequired();
        }
    }
}
