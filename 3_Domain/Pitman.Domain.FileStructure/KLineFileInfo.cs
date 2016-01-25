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
        //public string FullPath { get; internal set; }
        public string FullPath { get; set; }

        /// <summary>
        /// 文件管理数据的起始时间
        /// </summary>
        //public DateTime StartTime
        //{
        //    get { return _startTime; }
        //    internal set { _startTime = value.Date; }
        //}
        public DateTime StartTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }

        /// <summary>
        /// 文件管理数据的结束时间
        /// </summary>
        //public DateTime EndTime
        //{
        //    get { return _endTime; }
        //    internal set { _endTime = value.Date.AddHours(23).AddMinutes(59).AddSeconds(59); }
        //}
        public DateTime EndTime
        {
            get { return _endTime; }
            set { _endTime = value; }
        }

        public KLineFileInfo()
        {
            _startTime = DateTime.MinValue;
            _endTime = DateTime.MaxValue;
        }

        public KLineFileInfo(int bgnYear, int endYear)
        {
            _startTime = BeginYear(bgnYear);
            _endTime = EndYear(endYear);
        }

        public KLineFileInfo(int bgnYear, int endYear, string fullPath)
        {
            _startTime = BeginYear(bgnYear);
            _endTime = EndYear(endYear);
            FullPath = fullPath;
        }

        public KLineFileInfo(DateTime startTime, DateTime endTime, string fullPath)
        {
            _startTime = startTime;
            _endTime = endTime;
            FullPath = fullPath;
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

        internal static DateTime BeginYear(int year)
        {
            return new DateTime(year, DateTime.MinValue.Month, DateTime.MinValue.Day, DateTime.MinValue.Hour, DateTime.MinValue.Minute, DateTime.MinValue.Second);
        }

        internal static DateTime EndYear(int year)
        {
            return new DateTime(year, DateTime.MaxValue.Month, DateTime.MaxValue.Day, DateTime.MaxValue.Hour, DateTime.MaxValue.Minute, DateTime.MaxValue.Second);
        }
    }

    internal static class DateTimeEx
    {
        internal static DateTime BeginYear(this DateTime self)
        {
            return new DateTime(self.Year, DateTime.MinValue.Month, DateTime.MinValue.Day, DateTime.MinValue.Hour, DateTime.MinValue.Minute, DateTime.MinValue.Second);
        }        

        internal static DateTime EndYear(this DateTime self)
        {
            return new DateTime(self.Year, DateTime.MaxValue.Month, DateTime.MaxValue.Day, DateTime.MaxValue.Hour, DateTime.MaxValue.Minute, DateTime.MaxValue.Second);
        }
    }
}
