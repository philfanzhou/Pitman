using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitman.Application.Import
{
    internal class Common
    {
        internal static string StartDateInputStr = "20140701";

        internal static DateTime GetCurrentDataDate()
        {
            DateTime dtCurrent = DateTime.Now;
            if (dtCurrent.Hour < 8)
            {
                dtCurrent = dtCurrent.AddDays(-1);
            }
            return dtCurrent;
        }

        internal static string GetPetchDateStr(int value)
        {
            if (value < 10)
            {
                return "0" + value;
            }
            else
            {
                return value.ToString();
            }
        }

        internal static bool IsDateTime(string value)
        {
            try
            {
                Convert.ToDateTime(value);
                return true;
            }
            catch
            {
                return false;
            }
        }

        internal static bool IsFloat(string value)
        {
            try
            {
                Convert.ToSingle(value);
                return true;
            }
            catch
            {
                return false;
            }
        }

        internal static string GetInputDateFormat(DateTime dt)
        {
            return string.Format("{0}{1}{2}", dt.Year, Common.GetPetchDateStr(dt.Month), Common.GetPetchDateStr(dt.Day));
        }

        internal static string GetOutputDateFormat(DateTime dt)
        {
            return string.Format("{0}-{1}-{2}", dt.Year, Common.GetPetchDateStr(dt.Month), Common.GetPetchDateStr(dt.Day));
        }

        internal static DateTime GetDateFromOutput(string strTradeDate)
        {
            return new DateTime(int.Parse(strTradeDate.Split('-')[0]), int.Parse(strTradeDate.Split('-')[1]), int.Parse(strTradeDate.Split('-')[2]));
        }

        internal static List<T> GetListCopy<T>(List<T> oldList)
        {
            T[] newArr = new T[oldList.Count];
            oldList.CopyTo(newArr);
            return newArr.ToList();
        }
    }
}
