using Infrastructure.Databases.Database.Entities;
using Infrastructure.Databases.EntityFramework;
using System.Data.Entity;

namespace Infrastructure.Databases.Database.Context
{
    public class DatabaseContext : ContextBase
    {
        public DbSet<User> Users { get; set; }

        public DbSet<UserLog> UsersLogs { get; set; }

        public DbSet<UserRole> UsersRoles { get; set; }

        protected override void OnModelCreatingCustom(DbModelBuilder modelBuilder)
        {
            System.Data.Entity.Database.SetInitializer(new MigrateDatabaseToLatestVersion<DatabaseContext, DatabaseContextMigration>());
        }
    }
}