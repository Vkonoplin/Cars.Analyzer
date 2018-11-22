using Microsoft.EntityFrameworkCore;
using VK.Cars.Analyzer.Service.WebApi.Db.Entities;

namespace VK.Cars.Analyzer.Service.WebApi.Db
{
    public class DbSqlContext : DbContext
    {
        public DbSqlContext(DbContextOptions<DbSqlContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<HealthCheckDataEntity>();
        }
    }
}
