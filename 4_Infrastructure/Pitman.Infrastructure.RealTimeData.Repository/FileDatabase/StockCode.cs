using System;
using System.Collections.Generic;

namespace Pitman.Infrastructure.RealTimeData.Repository
{
    internal struct StockCode
    {
        private byte byte0;
        private byte byte1;
        private byte byte2;
        private byte byte3;
        private byte byte4;
        private byte byte5;
        private byte byte6;
        private byte byte7;
        private byte byte8;
        private byte byte9;

        private int dataLength;

        public string Code
        {
            get
            {
                return GetValue();
            }
            set
            {
                SetValue(value);
            }
        }

        private void SetValue(string value)
        {
            if (null == value)
            {
                dataLength = -1;
            }
            else if(value == string.Empty)
            {
                dataLength = 0;
            }
            else
            {
                byte[] data = System.Text.Encoding.GetEncoding("GBK").GetBytes(value);
                if (data.Length > 10)
                {
                    throw new ArgumentOutOfRangeException("value");
                }

                dataLength = data.Length;

                byte0 = dataLength > 0 ? data[0] : byte.MaxValue;
                byte1 = dataLength > 1 ? data[1] : byte.MaxValue;
                byte2 = dataLength > 2 ? data[2] : byte.MaxValue;
                byte3 = dataLength > 3 ? data[3] : byte.MaxValue;
                byte4 = dataLength > 4 ? data[4] : byte.MaxValue;
                byte5 = dataLength > 5 ? data[5] : byte.MaxValue;
                byte6 = dataLength > 6 ? data[6] : byte.MaxValue;
                byte7 = dataLength > 7 ? data[7] : byte.MaxValue;
                byte8 = dataLength > 8 ? data[8] : byte.MaxValue;
                byte9 = dataLength > 9 ? data[9] : byte.MaxValue;
            }
        }

        private string GetValue()
        {
            if(dataLength == -1)
            {
                return null;
            }
            else if(dataLength == 0)
            {
                return string.Empty;
            }
            else
            {
                List<byte> fieldList = new List<byte> { byte0, byte1, byte2, byte3, byte4, byte5, byte6, byte7, byte8, byte9 };
                List<byte> byteList = new List<byte>();
                for(int i = 0; i < dataLength; i++)
                {
                    byteList.Add(fieldList[i]);
                }

                return System.Text.Encoding.GetEncoding("GBK").GetString(byteList.ToArray());
            }
        }
    }
}
