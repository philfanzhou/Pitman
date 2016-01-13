using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ore.Infrastructure.MarketData;

namespace Pitman.Infrastructure.FileDatabase
{
    public class SecurityDataRepository
    {
        public void Add(ISecurity data)
        {
            using (var file = SecurityFile.CreateOrOpen())
            {
                SecurityItem dataItem = data.Convert();
                file.Add(dataItem);
            }
        }

        public IEnumerable<ISecurity> GetDataAll()
        {
            string filePath = PathHelper.SecurityFile;

            List<SecurityItem> result = new List<SecurityItem>();
            if (File.Exists(filePath))
            {
                var file = new SecurityFile(filePath);
                result.AddRange(file.ReadAll().Distinct());
            }

            return result.Cast<ISecurity>();
        }

        public ISecurity GetData(string stockCode)
        {
            string filePath = PathHelper.SecurityFile;

            if (File.Exists(filePath))
            {
                var file = new SecurityFile(filePath);
                var lstAll = file.ReadAll().Distinct();
                var it = lstAll.SingleOrDefault(x => x.Code == stockCode);

                if (string.IsNullOrEmpty(it.Code.Trim()))
                    return null;

                return it;
            }

            return null;
        }

        public IEnumerable<ISecurity> GetData(IEnumerable<string> stockCodes)
        {
            string filePath = PathHelper.SecurityFile;
            if (File.Exists(filePath))
            {
                var file = new SecurityFile(filePath);
                var lstSel = from it in file.ReadAll().Distinct()
                             where stockCodes.Contains(it.Code)
                             select it;
                return lstSel.Cast<ISecurity>();
            }

            return null;
        }

        public bool Exists(string stockCode)
        {
            return GetData(stockCode) != null;
        }        
    }

    internal static class SecurityExt
    {
        public static SecurityItem Convert(this ISecurity self)
        {
            SecurityItem outputData = new SecurityItem
            {
                Code = self.Code,
                ShortName = self.ShortName,
                Market = self.Market,
                Type = self.Type
            };

            return outputData;
        }
    }
}
