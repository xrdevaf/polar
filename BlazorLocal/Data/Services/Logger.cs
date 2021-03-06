﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorLocal.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BlazorLocal.Data.Services
{
    public class Logger : ILogger
    {
        private object _lock = new object();
        private IPushNotificationsQueue _pr { get; }
        private readonly IHttpContextAccessor _httpContextAccessor;
        public Logger(IPushNotificationsQueue pr, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _pr = pr;
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel > LogLevel.Information;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (formatter != null && IsEnabled(logLevel))
            {
                lock (_lock)
                {
                    var login_state = state.ToString().Split('*');
                    LogMessageEntry message = new LogMessageEntry()
                    {
                        ErrorMsg = (login_state.Length > 1 ? login_state[1] + Environment.NewLine : "") + exception?.Message + exception?.InnerException?.Message,
                        UserData = login_state.Length > 1 ? login_state[0] : "Unknown",
                        ErrorLevel = (int)logLevel,
                        ErrorContext = (login_state.Length > 2 ? login_state[2] : "") + (exception?.StackTrace ?? "")
                    };
                    if (string.IsNullOrEmpty(message.ErrorMsg)) message.ErrorMsg = formatter(state, exception);
                    _pr.Enqueue(message);
                    Console.WriteLine(formatter(state, exception) + Environment.NewLine);
                }
            }
        }
    }
}
