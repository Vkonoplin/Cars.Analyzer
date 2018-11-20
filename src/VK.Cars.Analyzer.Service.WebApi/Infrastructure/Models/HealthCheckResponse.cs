using System;
using System.Collections.Generic;
using VK.Cars.Analyzer.Service.WebApi.Model;

namespace VK.Cars.Analyzer.Service.WebApi.Models
{
    public class HealthCheckResponse
    {
        public bool IsOnline { get; set; }

        public List<HealthCheckResult> HealthChecks { get; set; }

        public string MachineName => Environment.MachineName;

        public string Build => Environment.GetEnvironmentVariable("BUILD_VERSION");
    }
}
