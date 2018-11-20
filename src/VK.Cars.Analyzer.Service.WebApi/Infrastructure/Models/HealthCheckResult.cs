namespace VK.Cars.Analyzer.Service.WebApi.Model
{
    public class HealthCheckResult
    {
        public string Message { get; set; }

        public string CheckType { get; set; }

        public bool Passed { get; set; }
    }
}
