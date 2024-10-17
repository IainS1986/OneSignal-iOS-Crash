using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;

namespace Core.Services
{

    public class MoasureLogger (string name) : ILogger
    {
        public IDisposable BeginScope<TState>(TState state) => default;

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(
            LogLevel logLevel,
            EventId eventId,
            TState state,
            Exception exception,
            Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
                return;

            Console.WriteLine(formatter(state, exception));
        }
    }

    public class MvxLoggerFactory : ILoggerFactory
    {
        private ILoggerProvider _currentProvider;

        public void AddProvider(ILoggerProvider provider)
        {
            _currentProvider?.Dispose();
            _currentProvider = provider;
        }

        public ILogger CreateLogger(string categoryName)
        {
            // Suppress MvxPlugin.Messenger logs as they are a bit verbose
            if (categoryName == "MvxPlugin.Messenger")
                return null;

            return _currentProvider?.CreateLogger(categoryName);
        }

        public void Dispose()
        {
            _currentProvider?.Dispose();
        }
    }

    public class MvxLoggerProvider : ILoggerProvider
    {
        private readonly ConcurrentDictionary<string, MoasureLogger> _loggers = new ConcurrentDictionary<string, MoasureLogger>();

        public MvxLoggerProvider()
        {
        }

        public ILogger CreateLogger(string categoryName) =>
            _loggers.GetOrAdd(categoryName, name => new MoasureLogger(name));

        public void Dispose()
        {
            _loggers.Clear();
        }
    }
}