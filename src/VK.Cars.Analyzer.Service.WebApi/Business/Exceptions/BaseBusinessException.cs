using System;

namespace VK.Cars.Analyzer.Service.WebApi.Business.Exceptions
{
    public class BaseBusinessException : Exception
    {
        private readonly string _errorCode;

        public BaseBusinessException(string errorCode)
        {
            _errorCode = errorCode;
        }

        public string GetErrorCode()
        {
            return _errorCode;
        }

        public object Data { get; set; }
    }
}
