using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitman.Infrastructure.SqlCe.Repository
{
    public class SecurityRepository : SqlCeRepository
    {
        public SecurityRepository(string fullPath) : base(fullPath) { }

        protected override void OnDbCreating()
        {
            throw new NotImplementedException();
        }
    }
}
