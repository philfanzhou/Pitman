using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Pitman.Distributed.Dto
{
    [DataContract]
    public class KLineArgs
    {
        [DataMember(Name = "stockCode")]
        public string StockCode { get; set; }

        [DataMember(Name = "startDate")]
        public DateTime StartDate { get; set; }

        [DataMember(Name = "endDate")]
        public DateTime EndDate { get; set; }
    }
}
