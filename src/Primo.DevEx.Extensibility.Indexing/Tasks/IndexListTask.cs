// Decompiled with JetBrains decompiler
// Type: Sitecore.DevEx.Extensibility.Indexing.Tasks.IndexListTask
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
using Sitecore.DevEx.Indexing.Client.Services;

namespace Primo.DevEx.Extensibility.Indexing.Tasks
{
  public class IndexListTask
  {
    private readonly ILogger<IndexListTask> _logger;
    private readonly IIndexListService _indexListService;
    private readonly IEnvironmentConfigurationProvider _configurationProvider;

    public IndexListTask(
      IIndexListService indexListService,
      ILogger<IndexListTask> logger,
      IEnvironmentConfigurationProvider configurationProvider)
    {
      this._indexListService = indexListService;
      this._logger = logger;
      this._configurationProvider = configurationProvider;
    }

    public async Task Execute(IndexTaskOptions args)
    {
      EnvironmentConfiguration configurationAsync = await this._configurationProvider.GetEnvironmentConfigurationAsync(args.Config, args.EnvironmentName);
      Stopwatch stopwatch = Stopwatch.StartNew();
      List<string> list = (await this._indexListService.GetIndexListAsync(configurationAsync).ConfigureAwait(false)).ToList<string>();
      this._logger.LogTrace(string.Format("Indexes: Loaded in {0}ms ({1} indexes).", (object) stopwatch.ElapsedMilliseconds, (object) list.Count));
      ColorLogExtensions.LogConsoleInformation((ILogger) this._logger, "Indexes list:", new ConsoleColor?(ConsoleColor.Yellow), new ConsoleColor?());
      foreach (string str in list)
        ColorLogExtensions.LogConsoleInformation((ILogger) this._logger, str, new ConsoleColor?(ConsoleColor.Green), new ConsoleColor?());
      stopwatch = (Stopwatch) null;
    }
  }
}
