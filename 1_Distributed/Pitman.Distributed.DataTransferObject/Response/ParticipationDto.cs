using Ore.Infrastructure.MarketData;
using System;
using System.Runtime.Serialization;

namespace Pitman.Distributed.DataTransferObject
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

    public static class ParticipationConverter
    {
        public static ParticipationDto ToDto(this IParticipation self)
        {
            ParticipationDto outputData = new ParticipationDto
            {
                CostPrice1Day = self.CostPrice1Day,
                CostPrice20Day = self.CostPrice20Day,
                MainForceInflows = self.MainForceInflows,
                SuperLargeInflows = self.SuperLargeInflows,
                Time = self.Time,
                Value = self.Value,
            };

            return outputData;
        }
    }
}
