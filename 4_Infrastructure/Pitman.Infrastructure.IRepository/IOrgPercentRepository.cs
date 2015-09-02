using Pitman.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitman.Infrastructure.IRepository
{
    public interface IOrgPercentRepository
    {
        List<OrgPercent> GetOrgPercentByWhere(string sqlWhere);

        bool Insert(OrgPercent orgPercent);
    }
}
