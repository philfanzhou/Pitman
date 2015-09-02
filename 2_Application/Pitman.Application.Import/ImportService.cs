using Pitman.Infrastructure.IRepository;
using Pitman.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitman.Application.Import
{
    public class ImportService
    {
        public static IEquRepository EquService
        {
            get 
            {
                return new EquRepository();
            }
        }

        public static IMktEqudRepository MktEqudService
        {
            get 
            {
                return new MktEqudRepository();
            }
        }

        public static IMktIdxdRepository MktIdxdService
        {
            get 
            {
                return new MktIdxdRepository();
            }
        }

        public static IOrgPercentRepository OrgPercentService
        {
            get 
            {
                return new OrgPercentRepository();
            }
        }
    }
}
