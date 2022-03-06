// Decompiled with JetBrains decompiler
// Type: Sitecore.DevEx.Extensibility.Indexing.Tasks.IndexStatisticListTask
// Assembly: Sitecore.DevEx.Extensibility.Indexing, Version=4.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4DCA9AAF-B319-477E-884B-8741A816EFA0
// Assembly location: C:\inetpub\wwwroot\2022-Compostable-DXP-Private\.sitecore\package-cache\nuget\Sitecore.DevEx.Extensibility.Indexing.4.1.0\plugin\Sitecore.DevEx.Extensibility.Indexing.dll

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Sitecore.DevEx.Client.Logging;
using Sitecore.DevEx.Configuration.Models;
using Sitecore.DevEx.Indexing.Client.Models;
using Sitecore.DevEx.Indexing.Client.Services;

namespace Primo.DevEx.Extensibility.Indexing.Tasks
{
  public class IndexStatisticListTask
  {
    private readonly ILogger _logger;
    private readonly IIndexListService _indexListService;
    private readonly IEnvironmentConfigurationProvider _configurationProvider;
    private readonly IIndexStatisticRenderer _statisticRenderer;

    public IndexStatisticListTask(
      IIndexListService indexListService,
      ILogger<IndexStatisticListTask> logger,
      IEnvironmentConfigurationProvider configurationProvider,
      IIndexStatisticRenderer statisticRenderer)
    {
      this._indexListService = indexListService;
      this._logger = (ILogger) logger;
      this._configurationProvider = configurationProvider;
      this._statisticRenderer = statisticRenderer;
    }

    public async Task Execute(IndexStatisticTaskOptions args)
    {
      EnvironmentConfiguration configurationAsync = await this._configurationProvider.GetEnvironmentConfigurationAsync(args.Config, args.EnvironmentName);
      Stopwatch stopwatch = Stopwatch.StartNew();
      List<IndexingStatistics> list = (await this._indexListService.GetIndexStatisticsListAsync(configurationAsync).ConfigureAwait(false)).ToList<IndexingStatistics>();
      stopwatch.Stop();
      this._logger.LogTrace(string.Format("Index statistics: Loaded in {0}ms ({1} statistics).", (object) stopwatch.ElapsedMilliseconds, (object) list.Count));
      ColorLogExtensions.LogConsoleInformation(this._logger, "Index statistics:", new ConsoleColor?(ConsoleColor.Yellow), new ConsoleColor?());
      foreach (IndexingStatistics statistics in list)
        this._statisticRenderer.Render(statistics);
      stopwatch = (Stopwatch) null;
    }
  }
}
