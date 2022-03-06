using Microsoft.Extensions.Logging;
using System;
using Sitecore.DevEx.Client.Logging;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;
using System.Security.Principal;
using System.Security.Claims;
using System.Collections;
using System.Collections.Generic;
using Primo.DevEx.Extensibility.Hackathon.HelloWorld.Data;

namespace Primo.DevEx.Extensibility.Hackathon.HelloWorld
{
    public class HelloWorldTask
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger<HelloWorldTask> _logger;

        public HelloWorldTask(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory ?? throw new ArgumentNullException(nameof(loggerFactory));
            _logger = _loggerFactory.CreateLogger<HelloWorldTask>();
        }

        public async Task Execute(HelloWorldTaskOptions options)
        {
            LogExecuteStart(options);
            ValidateOptions(options);
            await SayHello(options);

        }

        private void ValidateOptions(HelloWorldTaskOptions options)
        {
            _logger.LogTrace(HelloWorldResources.TraceValidationBegin);
            options.Validate();
            _logger.LogTrace(HelloWorldResources.TraceValidationComplete);
        }

        private async Task SayHello(HelloWorldTaskOptions options)
        {
            switch (options.Style)
            {
                case OutputStyles.Plain:
                    _logger.LogConsoleInformation(options.Message);
                    break;

                case OutputStyles.WordArt:
                    AnsiConsole.Write(new FigletText(options.Message).LeftAligned().Color(Color.Red));
                    break;

                default:
                    _logger.LogConsoleInformation(options.Message);
                    break;
            }

            // Render Sitecore Hackathon Logo
            if (options.Message.ToLower() == "sitecore hackathon")
            {
                RenderSitecoreHackathon();
            }
        }

        private void RenderSitecoreHackathon()
        {
            foreach (string line in HelloWorldResources.SitecoreHackathonLogo.Split(Environment.NewLine))
            {
                AnsiConsole.MarkupLine(ConvertToAsciiMarkupForSitecoreHackathon(line));
            }
        }

        private string ConvertToAsciiMarkupForSitecoreHackathon(string line)
        {
            if (string.IsNullOrEmpty(line))
                return string.Empty;

            // @ = Transparent (Black)
            // * = #FBD951
            // # = #DC143C
            const string atSymbolColor = "[black]";
            const string asterikSymbolColor = "[#FBD951]";
            const string hashtagSymbolColor = "[#DC143C]";
            const string markupClosure = "[/]";

            List<string> segments = new List<string>();
            StringBuilder segmentBuilder = new StringBuilder();

            int position = 0;
            char current = line[0];

            while (position < line.Length)
            {
                char symbol = line[position];

                if (current == symbol)
                {
                    segmentBuilder.Append(symbol);
                }
                else
                {
                    current = symbol;
                    segments.Add(segmentBuilder.ToString());
                    segmentBuilder.Clear();
                    segmentBuilder.Append(symbol);
                }

                position++;
            }

            segments.Add(segmentBuilder.ToString());

            segmentBuilder.Clear();
            foreach (string segment in segments)
            {
                switch (segment[0])
                {
                    case '@':
                        segmentBuilder.Append(atSymbolColor).Append(segment).Append(markupClosure);
                        break;

                    case '*':
                        segmentBuilder.Append(asterikSymbolColor).Append(segment).Append(markupClosure);
                        break;

                    case '#':
                        segmentBuilder.Append(hashtagSymbolColor).Append(segment).Append(markupClosure);
                        break;

                    default:
                        segmentBuilder.Append(segment);
                        break;
                }
            }

            return segmentBuilder.ToString();
        }

        private void LogExecuteStart(HelloWorldTaskOptions options)
        {
            _logger.LogDebug(HelloWorldResources.VerboseHelloWorldTaskBeginHeader);
            _logger.LogDebug(string.Format(HelloWorldResources.VerboseHelloWorldTaskMessageOption, options.Message));
            _logger.LogDebug(string.Format(HelloWorldResources.VerboseHelloWorldTaskStyleOption, options.Style));

        }
    }
}
