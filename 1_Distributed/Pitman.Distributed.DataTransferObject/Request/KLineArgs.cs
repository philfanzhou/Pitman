using System;
using System.Runtime.Serialization;

namespace Pitman.Distributed.DataTransferObject
{
    [DataContract]
    public class KLineArgs
    {
        [DataMember(Name = "stockCode")]
        public string StockCode { get; set; }

        [DataMember(Name = "startDate")]
        private DateTimeDto startDate = new DateTimeDto();
        public DateTime StartDate
        {
            get { return startDate.Value; }
            set { startDate.Value = value; }
        }

        [DataMember(Name = "endDate")]
        private DateTimeDto endDate = new DateTimeDto();
        public DateTime EndDate
        {
            get { return endDate.Value; }
            set { endDate.Value = value; }
        }
    }
}
