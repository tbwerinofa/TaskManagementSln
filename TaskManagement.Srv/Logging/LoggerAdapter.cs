﻿using Microsoft.Extensions.Logging;
using TaskManagement.Application.Logging;

namespace TaskManagement.Srv.Logging;
public class LoggerAdapter<T> : IAppLogger<T>
{
    private readonly ILogger<T> _logger;
    public LoggerAdapter(ILoggerFactory logger)
    {
        _logger = logger.CreateLogger<T>();
    }
    public void LogInformation(string message, params object[] args)
    {
        _logger.LogInformation(message, args);
    }
    public void LogWarning(string message, params object[] args)
    {
        _logger.LogWarning(message, args);
    }
}