using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Sitecore.Devex.Client.Cli.Extensibility;
using Sitecore.Devex.Client.Cli.Extensibility.Subcommands;
using Sitecore.Devex;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using Sitecore.DevEx.Configuration;
using System.Net.Http.Headers;
using Primo.DevEx.Extensibility.Hackathon.HelloWorld;
using Primo.DevEx.Extensibility.Hackathon.HelloWorld.ShowStyles;
using Primo.DevEx.Extensibility.Hackathon.Configuration;

namespace Primo.DevEx.Extensibility.Hackathon
{
    public class PrimoDemoExtension : ISitecoreCliExtension
    {
        public IEnumerable<ISubcommand> AddCommands(IServiceProvider container)
        {
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            PrimoDemoCommand symCommand = new PrimoDemoCommand(CommonResources.PrimoCmdName, CommonResources.PrimoCmdDesc);

            // Hello World
            HelloWorldCommand helloCommand = container.GetRequiredService<HelloWorldCommand>();
            helloCommand.AddCommand(container.GetRequiredService<ShowStylesCommand>());
            symCommand.AddCommand(helloCommand);

            return new ISubcommand[] { symCommand };
        }

        public void AddConfiguration(IConfigurationBuilder configBuilder)
        {
            // Configuration specific to this plugin
        }

        public void AddServices(IServiceCollection serviceCollection)
        {
            if (serviceCollection == null)
            {
                throw new ArgumentNullException(nameof(serviceCollection));
            }

            serviceCollection.AddSingleton<HelloWorldCommand>();
            serviceCollection.AddSingleton<ShowStylesCommand>();

            // Dependency injection support for Sitecore CLI configuration settings
            serviceCollection.TryAddTransient<IEnvironmentConfigurationProvider, EnvironmentConfigurationProvider>();
        }
    }
}
