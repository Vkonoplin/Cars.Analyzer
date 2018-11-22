using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using VK.Cars.Analyzer.Service.WebApi.Db;

namespace VK.Cars.Analyzer.Service.WebApi
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DbSqlContext>
    {
        public DbSqlContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", true)
                .Build();
            var builder = new DbContextOptionsBuilder<DbSqlContext>();
            var connectionString = configuration.GetConnectionString("Sql");
            builder.UseSqlServer(connectionString);
            return new DbSqlContext(builder.Options);
        }
    }
}
