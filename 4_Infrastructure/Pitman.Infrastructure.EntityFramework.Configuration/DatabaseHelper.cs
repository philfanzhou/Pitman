using Framework.Infrastructure.Repository.EntityFramework;

namespace Pitman.Infrastructure.EntityFramework.Configuration
{
    public static class DatabaseHelper
    {
        public static void Initialize(bool clearDatabase)
        {
            DbContextHelper.RegisterDbContext<PitmanDbContext>();

            if(clearDatabase)
            {
                PitmanDbContext dbContext = new PitmanDbContext();
                dbContext.Database.Delete();
                dbContext.Database.Create();
            }
        }
    }
}
