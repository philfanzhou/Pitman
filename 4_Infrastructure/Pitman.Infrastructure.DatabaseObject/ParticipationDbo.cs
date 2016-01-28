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
}
