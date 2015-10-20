using Framework.Infrastructure.MemoryMap;
using System;

namespace Pitman.Infrastructure.FileDatabase
{
    internal struct MarketDataFileHeader : IMemoryMappedFileHeader
    {
        public int DataCount { get; set; }

        public int MaxDataCount { get; set; }

        public DataType DataType { get; set; }

        public DateTime StartDay { get; set; }

        public DateTime EndDay { get; set; }
    }
}
