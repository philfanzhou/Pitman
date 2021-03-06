﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Pitman.Application.Import
{
    internal class Eastmoney
    {
        internal static string OrgPercentUrl = "http://data.eastmoney.com/stockcomment/{0}.html";

        internal static string GetDataFromUrl(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.Timeout = 5000;
            request.Proxy = null;

            try
            {
                WebResponse response = request.GetResponse();

                try
                {
                    Stream stream = response.GetResponseStream();
                    StreamReader streamReader = new StreamReader(stream, Encoding.GetEncoding("gb2312"));
                    return streamReader.ReadToEnd();
                }
                finally
                {
                    if (response != null)
                    {
                        response.Close();
                        response = null;
                    }
                }
            }
            catch
            {
                //访问Url的过程中出现网络异常
                return null;
            }
            finally
            {
                if (request != null)
                {
                    request.Abort();
                    request = null;
                }
            }
        }
    }
}
