using Microsoft.Extensions.Logging;
using Primo.DevEx.Extensibility.Hackathon.HelloWorld.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Primo.DevEx.Extensibility.Hackathon.HelloWorld.ShowStyles
{
    public class ShowStylesTask
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger<ShowStylesTask> _logger;

        public ShowStylesTask(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory ?? throw new ArgumentNullException(nameof(loggerFactory));
            _logger = _loggerFactory.CreateLogger<ShowStylesTask>();
        }

        public async Task Execute(ShowStylesTaskOptions options)
        {
            LogExecuteStart(options);
            ValidateOptions(options);
            await DisplayStyles(options);
        }
        private void ValidateOptions(ShowStylesTaskOptions options)
        {
            _logger.LogTrace(HelloWorldResources.TraceValidationBegin);
            options.Validate();
            _logger.LogTrace(HelloWorldResources.TraceValidationComplete);
        }

        private void LogExecuteStart(ShowStylesTaskOptions options)
        {
            _logger.LogDebug(HelloWorldResources.VerboseShowStylesTaskBeginHeader);
        }

        private async Task DisplayStyles(ShowStylesTaskOptions options)
        {
            foreach (string style in OutputStyles.AllStyles)
            {
                _logger.LogInformation(style);
            }
        }
    }
}
