using Microsoft.EntityFrameworkCore;

namespace VK.Cars.Analyzer.Service.WebApi.Db
{
    public class DbSqlContex : DbContext
    {
        public DbSqlContex(DbContextOptions<DbSqlContex> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
