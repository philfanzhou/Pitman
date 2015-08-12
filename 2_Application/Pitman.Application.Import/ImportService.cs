using Framework.Infrastructure.Repository;
using Pitman.Infrastructure.EntityFramework.Configuration;
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
        public static void Initialize()
        {
            DatabaseHelper.Initialize(true);
        }

        public static List<string> GetAllCodes()
        {
            //先做测试
            return new List<string>() { "600000", "000001"};
        }

        public static List<OrgPercent> GetOrgList(string lastTradeDay)
        {
            using (IRepositoryContext context = RepositoryContext.Create())
            {
                var repository = context.GetRepository<Repository<OrgPercent>>();
                IEnumerable<OrgPercent> allOrgs = repository.GetAll().Where(p => p.Day == lastTradeDay);
                if (allOrgs.Count() == 0) return new List<OrgPercent>();
                else return allOrgs.ToList();
            }
        }

        public static bool AddNewOrg(OrgPercent org)
        {
            using (IRepositoryContext context = RepositoryContext.Create())
            {
                var repository = context.GetRepository<Repository<OrgPercent>>();
                repository.Add(org);
                return true;
            }
        }
    }
}
