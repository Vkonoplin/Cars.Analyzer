using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VK.Cars.Analyzer.Service.WebApi.Db;
using VK.Cars.Analyzer.Service.WebApi.Db.Entities;

namespace VK.Cars.Analyzer.Service.WebApi.Business.Repositories
{
    public class HealthCheckRepository : IHealthCheckRepository
    {
        private readonly DbSqlContext _contex;

        public HealthCheckRepository(DbSqlContext context)
        {
            _contex = context;
        }

        public async Task<HealthCheckDataEntity> Create(HealthCheckDataEntity entity)
        {
            _contex.Set<HealthCheckDataEntity>().Add(entity);
            await _contex.SaveChangesAsync();

            return entity;
        }

        public async Task<int> Delete(HealthCheckDataEntity entity)
        {
            _contex.Set<HealthCheckDataEntity>().Remove(entity);
            return await _contex.SaveChangesAsync();
        }

        public async Task<HealthCheckDataEntity> GetById(int id)
        {
            return await _contex.Set<HealthCheckDataEntity>().FirstAsync(r => r.Id == id);
        }

        public async Task<HealthCheckDataEntity> Update(HealthCheckDataEntity entity)
        {
            _contex.Set<HealthCheckDataEntity>().Update(entity);
            await _contex.SaveChangesAsync();
            return entity;
        }
    }
}
