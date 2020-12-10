using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace BlazorLocal.Data.Services
{
    public class LoggerProvider : ILoggerProvider
    {
        private IPushNotificationsQueue _pr { get; }
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoggerProvider(IPushNotificationsQueue pr, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _pr = pr;
        }
        public ILogger CreateLogger(string categoryName) => new Logger(_pr, _httpContextAccessor);

        public void Dispose()
        {
        }
    }
}
