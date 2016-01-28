using Ore.Infrastructure.MarketData;
using System;

namespace Pitman.Infrastructure.DatabaseObject
{
    public class ParticipationDbo : IParticipation
    {
        public double CostPrice1Day { get; set; }

        public double CostPrice20Day { get; set; }

        public double MainForceInflows { get; set; }

        public double SuperLargeInflows { get; set; }

        public DateTime Time { get; set; }

        public double Value { get; set; }
    }

    public static class ParticipationConverter
    {
        public static ParticipationDbo ToDbo(this IParticipation self)
        {
            ParticipationDbo outputData = new ParticipationDbo
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
