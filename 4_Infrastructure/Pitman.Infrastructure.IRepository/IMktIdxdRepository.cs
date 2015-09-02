using Pitman.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitman.Infrastructure.IRepository
{
    public interface IMktIdxdRepository
    {
        string GetLastTradeDateByCode(string code);

        string GetLastTradeDateByTime(string dateTime);

        string GetNextTradeDateByTime(string dateTime);

        bool Insert(MktIdxd mktIdxd);

        bool Insert(List<MktIdxd> mktIdxdList);
    }
}
