using Ore.Infrastructure.MarketData;
using System;
using System.Runtime.Serialization;

namespace Pitman.Distributed.Dto
{
    [DataContract(Name = "participation")]
    public class ParticipationDto : IParticipation
    {
        [DataMember(Name = "time")]
        private DateTimeDto time = new DateTimeDto();
        public DateTime Time
        {
            get { return time.Value; }
            set { time.Value = value; }
        }

        [DataMember(Name = "costPrice1Day")]
        public double CostPrice1Day { get; set; }

        [DataMember(Name = "costPrice20Day")]
        public double CostPrice20Day { get; set; }

        [DataMember(Name = "mainForceInflows")]
        public double MainForceInflows { get; set; }

        [DataMember(Name = "superLargeInflows")]
        public double SuperLargeInflows { get; set; }

        [DataMember(Name = "value")]
        public double Value { get; set; }
    }
}
