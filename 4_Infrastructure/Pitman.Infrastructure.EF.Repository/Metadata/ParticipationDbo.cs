using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ore.Infrastructure.MarketData;

namespace Pitman.Infrastructure.EF.Repository
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
