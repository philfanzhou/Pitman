using Framework.Infrastructure.MemoryMappedFile;
using System;

namespace Pitman.Infrastructure.RealTimeData.Repository
{
    internal struct RealTimeFileHeader : IMemoryMappedFileHeader
    {
        public int DataCount { get; set; }

        public int MaxDataCount { get; set; }

        public DataType DataType { get; set; }

        public DateTime StartDay { get; set; }

        public DateTime EndDay { get; set; }
    }
}
