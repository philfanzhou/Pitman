using System;
using System.Runtime.Serialization;

namespace Pitman.Distributed.Dto
{
    [DataContract(Name = "dateTimeDto")]
    public class DateTimeDto
    {
        [DataMember(Name = "strValue")]
        private string strValue = "1970-01-01 00:00:00";

        public DateTime Value
        {
            get { return DateTime.Parse(strValue); }
            set { strValue = value.ToString("yyyy-MM-dd HH:mm:ss"); }
        }
    }
}
