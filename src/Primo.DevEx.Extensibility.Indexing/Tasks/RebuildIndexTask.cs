// Decompiled with JetBrains decompiler
// Type: Sitecore.DevEx.Extensibility.Indexing.Tasks.RebuildIndexTask
// Assembly: Sitecore.DevEx.Extensibility.Indexing, Version=4.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4DCA9AAF-B319-477E-884B-8741A816EFA0
// Assembly location: C:\inetpub\wwwroot\2022-Compostable-DXP-Private\.sitecore\package-cache\nuget\Sitecore.DevEx.Extensibility.Indexing.4.1.0\plugin\Sitecore.DevEx.Extensibility.Indexing.dll

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Sitecore.DevEx.Client.Logging;
using Sitecore.DevEx.Configuration.Models;
using Sitecore.DevEx.Indexing.Client.Models;
using Sitecore.DevEx.Indexing.Client.Services;
using Spectre.Console;

namespace Primo.DevEx.Extensibility.Indexing.Tasks
{
    public class RebuildIndexTask : IndexSchemaTaskBase
    {
        private readonly IRebuildIndexService _schemeService;

        protected override string TaskStartText => "Rebuilding";

        protected override string TaskEndText => "The search indexes have been rebuilt";

        protected override string AllFailedText => "The search indexes rebuilding have been failed";

        public RebuildIndexTask(
          ILogger<RebuildIndexTask> logger,
          IEnvironmentConfigurationProvider configurationProvider,
          IIndexStatusService indexStatusService,
          IRebuildIndexService schemeService)
          : base((ILogger)logger, configurationProvider, indexStatusService)
        {
            this._schemeService = schemeService;
        }

        protected override Task<IEnumerable<IndexResultModel>> GetResultModelList(
          EnvironmentConfiguration configuration,
          IEnumerable<string> indexNames)
        {
            return this._schemeService.RebuildIndexAsync(configuration, indexNames);
        }

        protected new void ShowLog(IEnumerable<IndexResultModel> models)
        {
            
            
            

            //ColorLogExtensions.LogConsoleInformation(this.Logger, model.IndexName + " [" + model.StateName + "] " + str, new ConsoleColor?(consoleColor), new ConsoleColor?());
        }

        protected override void ShowOutput(IEnumerable<IndexResultModel> resultModels)
        {
            
                this.ShowLog(resultModels);
        }

        protected override void ShowLog(IndexResultModel model)
        {
            throw new NotImplementedException();
        }
    }
}
