using Pitman.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitman.Infrastructure.IRepository
{
    public interface IMktEqudRepository
    {
        string GetLastTradeDate(string code);        

        bool Insert(MktEqud mktEqud);

        bool Insert(List<MktEqud> mktEqudList);

        List<MktEqud> GetAllMktEquds(string sqlWhere);
    }
}
