using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Infrastructure.MemoryMap;

namespace Pitman.Infrastructure.FileDatabase
{
    internal class ParticipationFile
        : ConcurrentFile<MarketDataFileHeader, ParticipationDataItem>
    {
        private static int maxCount = 22 * 12 * 30;//考虑每天一条数据，最大预估30年数据

        #region Constructor

        internal ParticipationFile(string fullPath) : base(fullPath) { }
        private ParticipationFile(string fullPath, MarketDataFileHeader header) : base(fullPath, header) { }

        #endregion

        internal static ParticipationFile CreateOrOpen(string stockCode)
        {
            string filePath = string.Format(@"{0}\{1}.dat", PathHelper.ParticipationFolder, stockCode);
            if (File.Exists(filePath))
            {
                return new ParticipationFile(filePath);
            }
            else
            {
                MarketDataFileHeader header = new MarketDataFileHeader
                {
                    DataCount = 0,
                    MaxDataCount = maxCount,
                    DataType = DataType.RealTime,
                    StartDay = DateTime.Now,
                    EndDay = DateTime.Now
                };
                return new ParticipationFile(filePath, header);
            }
        }
    }
}
