using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ore.Infrastructure.MarketData;

namespace Pitman.Infrastructure.FileDatabase
{
    public class ParticipationDataRepository
    {
        public void Add(string stockCode, IParticipation data)
        {
            using (var file = ParticipationFile.CreateOrOpen(stockCode))
            {
                ParticipationDataItem dataItem = data.Convert();
                file.Add(dataItem);
            }
        }

        public IEnumerable<IParticipation> GetData(string stockCode)
        {
            string filepath = string.Format(@"{0}\{1}.dat", PathHelper.ParticipationFolder, stockCode);

            List<ParticipationDataItem> result = new List<ParticipationDataItem>();
            if (File.Exists(filepath))
            {
                var file = new ParticipationFile(filepath);
                result.AddRange(file.ReadAll());
            }

            return result.Cast<IParticipation>();
        }

        public IParticipation GetLatest(string stockCode)
        {
            string filepath = string.Format(@"{0}\{1}.dat", PathHelper.ParticipationFolder, stockCode);
            if (File.Exists(filepath))
            {
                var file = new ParticipationFile(filepath);
                var result = from it in file.ReadAll()
                             orderby it.Time descending  
                             select it;
                IParticipation fst = result.First();
                if (fst != null)
                    return fst;
            }

            return null;
        }

        //public bool Exists(IParticipation participation)
        //{
        //    var lstAll = GetData(participation.Code);
        //    var query = from it in lstAll
        //                where it.Code == participation.Code &&
        //                it.CostPrice1Day == participation.CostPrice1Day &&
        //                it.CostPrice20Day == participation.CostPrice20Day &&
        //                it.MainForceInflows == participation.MainForceInflows &&
        //                it.SuperLargeInflows == participation.SuperLargeInflows &&
        //                it.Time == participation.Time &&
        //                it.Value == participation.Value
        //                select it;
        //    return (query != null && query.Count() > 0);
        //}
    }

    internal static class ParticipationExt
    {
        public static ParticipationDataItem Convert(this IParticipation self)
        {
            ParticipationDataItem outputData = new ParticipationDataItem
            {
                ////
                //// 摘要:
                ////     挂牌代码
                //Code = self.Code,
                //
                // 摘要:
                //     最近1日主力成本
                CostPrice1Day = self.CostPrice1Day,
                //
                // 摘要:
                //     最近20日主力成本
                CostPrice20Day = self.CostPrice20Day,
                //
                // 摘要:
                //     主力净流入
                MainForceInflows = self.MainForceInflows,
                //
                // 摘要:
                //     超大单流入
                SuperLargeInflows = self.SuperLargeInflows,
                //
                // 摘要:
                //     日期与时间
                Time = self.Time,
                //
                // 摘要:
                //     机构参与度（%） : 45
                Value = self.Value
            };

            return outputData;
        }
    }
}
