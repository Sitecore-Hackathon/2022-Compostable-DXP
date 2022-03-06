// Decompiled with JetBrains decompiler
// Type: Sitecore.DevEx.Extensibility.Indexing.RegisterExtension
// Assembly: Sitecore.DevEx.Extensibility.Indexing, Version=4.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4DCA9AAF-B319-477E-884B-8741A816EFA0
// Assembly location: C:\inetpub\wwwroot\2022-Compostable-DXP-Private\.sitecore\package-cache\nuget\Sitecore.DevEx.Extensibility.Indexing.4.1.0\plugin\Sitecore.DevEx.Extensibility.Indexing.dll

using System;
using System.Collections.Generic;
using System.CommandLine;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Primo.DevEx.Extensibility.Indexing.Commands;
using Primo.DevEx.Extensibility.Indexing.Tasks;
using Sitecore.Devex.Client.Cli.Extensibility;
using Sitecore.Devex.Client.Cli.Extensibility.Subcommands;
using Sitecore.DevEx.Indexing.Client;
using Sitecore.DevEx.Serialization.Client;

namespace Primo.DevEx.Extensibility.Indexing
{
  public class RegisterExtension : ISitecoreCliExtension
  {
    public IEnumerable<ISubcommand> AddCommands(IServiceProvider container) => (IEnumerable<ISubcommand>) new ISubcommand[1]
    {
      RegisterExtension.CreateIndexCommand(container)
    };

    [ExcludeFromCodeCoverage]
    public void AddConfiguration(IConfigurationBuilder configBuilder)
    {
    }

    public void AddServices(IServiceCollection serviceCollection)
    {
      serviceCollection.AddSerialization().AddSchemaPopulation().AddSingleton<SchemaPopulateCommand>().AddSingleton<IndexListCommand>().AddSingleton<RebuildIndexCommand>().AddSingleton<IndexStatisticListCommand>().AddSingleton<ILogger<PopulateSchemaTask>>((Func<IServiceProvider, ILogger<PopulateSchemaTask>>) (t => t.GetService<ILoggerFactory>().CreateLogger<PopulateSchemaTask>())).AddSingleton<ILogger<IndexListTask>>((Func<IServiceProvider, ILogger<IndexListTask>>) (t => t.GetService<ILoggerFactory>().CreateLogger<IndexListTask>())).AddSingleton<ILogger<RebuildIndexTask>>((Func<IServiceProvider, ILogger<RebuildIndexTask>>) (t => t.GetService<ILoggerFactory>().CreateLogger<RebuildIndexTask>())).AddSingleton<ILogger<IndexStatisticListTask>>((Func<IServiceProvider, ILogger<IndexStatisticListTask>>) (t => t.GetService<ILoggerFactory>().CreateLogger<IndexStatisticListTask>())).AddSingleton<ILogger<DefaultIndexStatisticRenderer>>((Func<IServiceProvider, ILogger<DefaultIndexStatisticRenderer>>) (t => t.GetService<ILoggerFactory>().CreateLogger<DefaultIndexStatisticRenderer>()));
      serviceCollection.TryAddTransient<ITreeSyncOperationExecutor, TreeSyncOperationExecutor>();
      serviceCollection.TryAddTransient<IEnvironmentConfigurationProvider, EnvironmentConfigurationProvider>();
      serviceCollection.TryAddTransient<IIndexStatisticRenderer, DefaultIndexStatisticRenderer>();
    }

    private static ISubcommand CreateIndexCommand(IServiceProvider container)
    {
      IndexesCommand indexesCommand = new IndexesCommand("primo-index", "working with indexes data");
      ((Symbol) indexesCommand).AddAlias("primo-index");
      indexesCommand.AddCommand((Command) container.GetRequiredService<SchemaPopulateCommand>());
      indexesCommand.AddCommand((Command) container.GetRequiredService<IndexListCommand>());
      indexesCommand.AddCommand((Command) container.GetRequiredService<RebuildIndexCommand>());
      indexesCommand.AddCommand((Command) container.GetRequiredService<IndexStatisticListCommand>());
      return (ISubcommand) indexesCommand;
    }
  }
}
