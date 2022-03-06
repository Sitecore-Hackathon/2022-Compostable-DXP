// Decompiled with JetBrains decompiler
// Type: Sitecore.DevEx.Extensibility.Indexing.Tasks.IndexSchemaTaskBase
// Assembly: Sitecore.DevEx.Extensibility.Indexing, Version=4.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4DCA9AAF-B319-477E-884B-8741A816EFA0
// Assembly location: C:\inetpub\wwwroot\2022-Compostable-DXP-Private\.sitecore\package-cache\nuget\Sitecore.DevEx.Extensibility.Indexing.4.1.0\plugin\Sitecore.DevEx.Extensibility.Indexing.dll

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Primo.DevEx.Extensibility.Indexing.Commands;
using Sitecore.DevEx.Client.Logging;
using Sitecore.DevEx.Configuration.Models;
using Sitecore.DevEx.Indexing.Client.Models;
using Sitecore.DevEx.Indexing.Client.Services;
using Spectre.Console;

namespace Primo.DevEx.Extensibility.Indexing.Tasks
{
    public abstract class IndexSchemaTaskBase
    {
        private const int _jobsRequestDelay = 750;
        private readonly IIndexStatusService _indexStatusService;
        private readonly IEnvironmentConfigurationProvider _configurationProvider;
        protected readonly ILogger Logger;

        protected abstract string TaskStartText { get; }

        protected abstract string TaskEndText { get; }

        protected abstract string AllFailedText { get; }

        protected IndexSchemaTaskBase(
          ILogger logger,
          IEnvironmentConfigurationProvider configurationProvider,
          IIndexStatusService indexStatusService)
        {
            this.Logger = logger;
            this._configurationProvider = configurationProvider;
            this._indexStatusService = indexStatusService;
        }

        public async Task Execute(IndexSchemaArgs options)
        {
            EnvironmentConfiguration environmentConfiguration = await this._configurationProvider.GetEnvironmentConfigurationAsync(options.Config, options.EnvironmentName);
            Stopwatch stopwatch = Stopwatch.StartNew();
            List<IndexResultModel> resultModels = (await this.GetResultModelList(environmentConfiguration, (IEnumerable<string>)options.Indexes)).ToList<IndexResultModel>();
            resultModels.ForEach((Action<IndexResultModel>)(m =>
           {
               if (!string.IsNullOrEmpty(m.Id))
                   return;
               m.Id = Guid.NewGuid().ToString();
           }));
            this.Logger.LogTrace(string.Format("Indexes: {0} request by {1} ms", (object)this.TaskStartText, (object)stopwatch.ElapsedMilliseconds));
            ColorLogExtensions.LogConsoleInformation(this.Logger, this.TaskStartText + ":", new ConsoleColor?(ConsoleColor.Yellow), new ConsoleColor?());
            this.ShowOutput((IEnumerable<IndexResultModel>)resultModels);
            bool isAllFailed = resultModels.All<IndexResultModel>((Func<IndexResultModel, bool>)(m => m.StateCode == IndexingState.IndexNotFound));
            await this.JobProcessingAsync(resultModels, environmentConfiguration);
            stopwatch.Stop();
            //this.UpdateOutPutTitle(isAllFailed);
            ColorLogExtensions.LogConsoleVerbose(this.Logger, string.Format("{0} finished in {1}ms.", (object)this.TaskStartText, (object)stopwatch.ElapsedMilliseconds), new ConsoleColor?(), new ConsoleColor?());
            environmentConfiguration = (EnvironmentConfiguration)null;
            stopwatch = (Stopwatch)null;
            resultModels = (List<IndexResultModel>)null;
        }

        private async Task JobProcessingAsync(
          List<IndexResultModel> resultModels,
          EnvironmentConfiguration environmentConfiguration)
        {
            List<IndexResultModel> notCompletedJobs = resultModels.Where<IndexResultModel>((Func<IndexResultModel, bool>)(m => m.StateCode == IndexingState.Running)).ToList<IndexResultModel>();
            ColorLogExtensions.LogConsoleInformation(this.Logger, "Processing...", new ConsoleColor?(ConsoleColor.Yellow), new ConsoleColor?());
            var table = new Table().LeftAligned();
            await AnsiConsole.Live(table)
                .StartAsync(async ctx =>
                {
                    table.AddColumn("Index Name");
                    table.AddColumn("Status");
                    table.AddColumn("Processed Units");
                    foreach (var model in resultModels)
                    {
                        table.AddRow(model.IndexName, "", model.ProcessedCount.ToString());
                    }
                    while (notCompletedJobs.Any<IndexResultModel>())
                    {
                        List<string> list1 = notCompletedJobs
                            .Select<IndexResultModel, string>((Func<IndexResultModel, string>)(j => j.Id))
                            .ToList<string>();
                        List<IndexResultModel> list2 = (await this.GetJobsStatusAsync(environmentConfiguration, list1))
                            .ToList<IndexResultModel>();
                        list2.ForEach((Action<IndexResultModel>)(j =>
                        {
                            IndexResultModel indexResultModel =
                                resultModels.First<IndexResultModel>((Func<IndexResultModel, bool>)(m => m.Id == j.Id));
                            indexResultModel.StateCode = j.StateCode;
                            indexResultModel.ProcessedCount = j.ProcessedCount;
                            indexResultModel.StateName = j.StateName;
                        }));
                        //this.ShowOutput((IEnumerable<IndexResultModel>)resultModels);

                        for (int i=0; i < resultModels.Count; i++)
                        {
                            var model = resultModels[i];
                            string str = model.ProcessedCount != 0
                                ? string.Format("[units processed: {0}]", (object)model.ProcessedCount)
                                : string.Empty;
                            
                            table.UpdateCell(i, 1, model.StateName);
                            table.UpdateCell(i, 2, model.ProcessedCount.ToString());
                            ctx.Refresh();
                            
                        }

                        notCompletedJobs =
                            list2.Where<IndexResultModel>(
                                    (Func<IndexResultModel, bool>)(m => m.StateCode == IndexingState.Running))
                                .ToList<IndexResultModel>();
                        if (notCompletedJobs.Any<IndexResultModel>())
                            await Task.Delay(750, CancellationToken.None);
                    }
                });
            notCompletedJobs = (List<IndexResultModel>)null;
        }

        protected abstract Task<IEnumerable<IndexResultModel>> GetResultModelList(
          EnvironmentConfiguration configuration,
          IEnumerable<string> indexNames);

        private Task<IEnumerable<IndexResultModel>> GetJobsStatusAsync(
          EnvironmentConfiguration environmentConfiguration,
          List<string> jobsId)
        {
            return this._indexStatusService.GetIndexStatusAsync(environmentConfiguration, (IEnumerable<string>)jobsId);
        }

        private void UpdateOutPutTitle(bool isAllFailed) => ColorLogExtensions.LogConsoleInformation(this.Logger, (isAllFailed ? this.AllFailedText : this.TaskEndText) + ":", new ConsoleColor?(isAllFailed ? ConsoleColor.Red : ConsoleColor.Yellow), new ConsoleColor?());

        protected virtual void ShowOutput(IEnumerable<IndexResultModel> resultModels)
        {
            foreach (IndexResultModel resultModel in resultModels)
                this.ShowLog(resultModel);
        }

        protected abstract void ShowLog(IndexResultModel model);
    }
}
