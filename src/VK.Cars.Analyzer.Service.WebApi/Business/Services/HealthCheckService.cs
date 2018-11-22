using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VK.Cars.Analyzer.Service.WebApi.Business.Repositories;
using VK.Cars.Analyzer.Service.WebApi.Db.Entities;
using VK.Cars.Analyzer.Service.WebApi.Infrastructure;
using VK.Cars.Analyzer.Service.WebApi.Model;

namespace VK.Cars.Analyzer.Service.WebApi.Business.Services
{
    public class HealthCheckService : BaseHealthCheckService
    {
        private const string CheckType = "SqlDb";
        private readonly IHealthCheckRepository _healthCheckRepository;

        public HealthCheckService(IHealthCheckRepository healthCheckRepository)
        {
            _healthCheckRepository = healthCheckRepository;
        }

        public override async Task<List<HealthCheckResult>> ExecuteHealthchecks()
        {
            var result = await base.ExecuteHealthchecks();
            var testData =
                new HealthCheckDataEntity() { UpdateDate = DateTime.UtcNow };

            bool success = true;

            try
            {
                testData = await _healthCheckRepository.Create(testData);
            }
            catch (Exception)
            {
                result.Add(new HealthCheckResult()
                {
                    CheckType = CheckType,
                    Passed = false,
                    Message = "Create command test failed"
                });
                success = false;
            }

            try
            {
                testData = await _healthCheckRepository.Update(testData);
            }
            catch (Exception)
            {
                result.Add(new HealthCheckResult()
                {
                    CheckType = CheckType,
                    Passed = false,
                    Message = "Update command test failed"
                });
                success = false;
            }

            try
            {
                testData = await _healthCheckRepository.GetById(testData.Id);
            }
            catch (Exception)
            {
                result.Add(new HealthCheckResult()
                {
                    CheckType = CheckType,
                    Passed = false,
                    Message = "Get by id command test failed"
                });
                success = false;
            }

            if (success)
            {
                result.Add(
                    new HealthCheckResult()
                    {
                        CheckType = CheckType,
                        Message =
                            $"Database is alive.The entity with Id={testData.Id} was created at {testData.UpdateDate}",
                        Passed = true
                    });
            }

            return result;
        }
    }
}
