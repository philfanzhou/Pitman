using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitman.Infrastructure.Repository
{
    internal class SqlHelper
    {
        public static string SqlConStr = @"Data Source=QUANTUM1234;Initial Catalog=TestStock;User ID=sa;Password=Admin1234;MultipleActiveResultSets=true";
    }
}
