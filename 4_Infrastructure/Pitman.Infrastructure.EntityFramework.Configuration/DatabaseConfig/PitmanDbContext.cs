using Framework.Infrastructure.Repository.EntityFramework;
using System.Data.Entity;

namespace Pitman.Infrastructure.EntityFramework.Configuration
{
    internal sealed class PitmanDbContext : SqlServerDbContext
    {
        private static readonly ConnectionConfig sqlServer = new ConnectionConfig
        {
            Server = @"(localdb)\projects",
            Database = "Stock",
            TrustedConnection = true
        };

        //private static readonly ConnectionConfig mySql = new ConnectionConfig
        //{
        //    Server = "localhost",
        //    Port = "3306",
        //    Database = "UserContextDb",
        //    Uid = "root",
        //    Password = "123456"
        //};

        public PitmanDbContext()
            //: base(mySql)
            : base(sqlServer)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Import Models
            modelBuilder.Configurations.Add(new OrgPercentConfig());

            // TO DO : Add others
            //modelBuilder.Configurations.Add(new OtherConfigType());
        }
    }
}
