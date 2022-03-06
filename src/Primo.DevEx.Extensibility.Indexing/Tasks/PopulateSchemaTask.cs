// Decompiled with JetBrains decompiler
// Type: Sitecore.DevEx.Extensibility.Indexing.Tasks.PopulateSchemaTask
// Assembly: Sitecore.DevEx.Extensibility.Indexing, Version=4.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4DCA9AAF-B319-477E-884B-8741A816EFA0
// Assembly location: C:\inetpub\wwwroot\2022-Compostable-DXP-Private\.sitecore\package-cache\nuget\Sitecore.DevEx.Extensibility.Indexing.4.1.0\plugin\Sitecore.DevEx.Extensibility.Indexing.dll

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Sitecore.DevEx.Client.Logging;
using Sitecore.DevEx.Configuration.Models;
using Sitecore.DevEx.Indexing.Client.Models;
using Sitecore.DevEx.Indexing.Client.Services;

namespace Primo.DevEx.Extensibility.Indexing.Tasks
{
  public class PopulateSchemaTask : IndexSchemaTaskBase
  {
    private readonly IPopulateSchemeService _schemeService;

    protected override string TaskStartText => "Populating";

    protected override string TaskEndText => "The search indexes have been populated";

    protected override string AllFailedText => "The search indexes populating have been failed";

    public PopulateSchemaTask(
      ILogger<PopulateSchemaTask> logger,
      IEnvironmentConfigurationProvider configurationProvider,
      IIndexStatusService indexStatusService,
      IPopulateSchemeService schemeService)
      : base((ILogger) logger, configurationProvider, indexStatusService)
    {
      this._schemeService = schemeService;
    }

    protected override Task<IEnumerable<IndexResultModel>> GetResultModelList(
      EnvironmentConfiguration configuration,
      IEnumerable<string> indexNames)
    {
      return this._schemeService.PopulateSchemaAsync(configuration, indexNames);
    }

    protected override void ShowLog(IndexResultModel model)
    {
      ConsoleColor consoleColor;
      switch (model.StateCode)
      {
        case IndexingState.NotFound:
        case IndexingState.IndexNotFound:
        case IndexingState.Failed:
          consoleColor = ConsoleColor.Red;
          break;
        case IndexingState.Running:
        case IndexingState.Completed:
          consoleColor = ConsoleColor.Green;
          break;
        default:
          throw new ArgumentOutOfRangeException("StateCode", "There is no color definition for the index state.");
      }
      ColorLogExtensions.LogConsoleInformation(this.Logger, model.IndexName + " [" + model.StateName + "]", new ConsoleColor?(consoleColor), new ConsoleColor?());
    }
  }
}
