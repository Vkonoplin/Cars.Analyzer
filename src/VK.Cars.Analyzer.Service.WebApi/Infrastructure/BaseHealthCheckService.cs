using System.Collections.Generic;
using VK.Cars.Analyzer.Service.WebApi.Model;

namespace VK.Cars.Analyzer.Service.WebApi.Infrastructure
{
    public class BaseHealthCheckService
    {
        public virtual List<HealthCheckResult> ExecuteHealthchecks()
        {
            return new List<HealthCheckResult> { new HealthCheckResult { Passed = true, Message = "Service is alive", CheckType = "Service" } };
        }
    }
}
