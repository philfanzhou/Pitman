using System;

namespace Pitman.Domain.FileStructure
{
    public class KLineFileInfo
    {
        private DateTime _startTime;
        private DateTime _endTime;

        /// <summary>
        /// 文件的FullPath
        /// </summary>
        public string FullPath { get; internal set; }

        /// <summary>
        /// 文件管理数据的起始时间
        /// </summary>
        public DateTime StartTime
        {
            get { return _startTime; }
            internal set { _startTime = value.Date; }
        }

        /// <summary>
        /// 文件管理数据的结束时间
        /// </summary>
        public DateTime EndTime
        {
            get { return _endTime; }
            internal set { _endTime = value.Date.AddHours(23).AddMinutes(59).AddSeconds(59); }
        }

        /// <summary>
        /// 判断指定时间是否在当前文件的管理范围内
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public bool ContainsTime(DateTime time)
        {
            return (_startTime < time) && (time < _endTime);
        }
    }
}
