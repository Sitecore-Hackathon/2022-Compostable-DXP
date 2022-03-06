// Decompiled with JetBrains decompiler
// Type: Sitecore.DevEx.Extensibility.Indexing.Tasks.DefaultIndexStatisticRenderer
// Assembly: Sitecore.DevEx.Extensibility.Indexing, Version=4.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4DCA9AAF-B319-477E-884B-8741A816EFA0
// Assembly location: C:\inetpub\wwwroot\2022-Compostable-DXP-Private\.sitecore\package-cache\nuget\Sitecore.DevEx.Extensibility.Indexing.4.1.0\plugin\Sitecore.DevEx.Extensibility.Indexing.dll

using System;
using System.Globalization;
using Microsoft.Extensions.Logging;
using Sitecore.DevEx.Client.Logging;
using Sitecore.DevEx.Indexing.Client.Models;

namespace Primo.DevEx.Extensibility.Indexing.Tasks
{
  public class DefaultIndexStatisticRenderer : IIndexStatisticRenderer
  {
    private readonly ILogger<DefaultIndexStatisticRenderer> _logger;

    public DefaultIndexStatisticRenderer(ILogger<DefaultIndexStatisticRenderer> logger) => this._logger = logger;

    public void Render(IndexingStatistics statistics)
    {
      ColorLogExtensions.LogConsoleInformation((ILogger) this._logger, statistics.Name, new ConsoleColor?(ConsoleColor.Green), new ConsoleColor?());
      ColorLogExtensions.LogConsoleInformation((ILogger) this._logger, "Rebuild Time: " + this.FormatBuildTime(statistics.RebuildTime), new ConsoleColor?(), new ConsoleColor?());
      ColorLogExtensions.LogConsoleInformation((ILogger) this._logger, "Last Updated: " + this.FormatLastUpdated(statistics.LastUpdated), new ConsoleColor?(), new ConsoleColor?());
      ColorLogExtensions.LogConsoleInformation((ILogger) this._logger, "Approximate Throughput: " + this.FormatThroughputTime(statistics.RebuildThroughputTime), new ConsoleColor?(), new ConsoleColor?());
      ColorLogExtensions.LogConsoleInformation((ILogger) this._logger, "Has Deletions: " + this.FormatBoolean(statistics.HasDeletions), new ConsoleColor?(), new ConsoleColor?());
      ColorLogExtensions.LogConsoleInformation((ILogger) this._logger, "Out of Date: " + this.FormatBoolean(statistics.OutOfDateIndex), new ConsoleColor?(), new ConsoleColor?());
      ColorLogExtensions.LogConsoleInformation((ILogger) this._logger, "Document Count: " + this.FormatLong(statistics.NumberOfDocuments), new ConsoleColor?(), new ConsoleColor?());
      ColorLogExtensions.LogConsoleInformation((ILogger) this._logger, "Number of Fields: " + this.FormatLong((long) statistics.NumberOfFields), new ConsoleColor?(), new ConsoleColor?());
      ColorLogExtensions.LogConsoleInformation((ILogger) this._logger, "Number of Terms: " + this.FormatLong(statistics.NumberOfTerms), new ConsoleColor?(), new ConsoleColor?());
      ColorLogExtensions.LogConsoleInformation((ILogger) this._logger, Environment.NewLine, new ConsoleColor?(), new ConsoleColor?());
    }

    private string FormatBuildTime(int? buildTimeMs)
    {
      if (buildTimeMs.HasValue)
      {
        int? nullable = buildTimeMs;
        int num = 0;
        if (!(nullable.GetValueOrDefault() == num & nullable.HasValue))
        {
          double totalSeconds = TimeSpan.FromMilliseconds((double) buildTimeMs.Value).TotalSeconds;
          if (totalSeconds < 120.0)
            return totalSeconds.ToString("##.#", (IFormatProvider) CultureInfo.InvariantCulture) + " seconds";
          if (totalSeconds >= 120.0 && totalSeconds < 3600.0)
            return TimeSpan.FromMilliseconds((double) buildTimeMs.Value).TotalMinutes.ToString("##.#", (IFormatProvider) CultureInfo.InvariantCulture) + " minutes";
          return totalSeconds >= 3600.0 ? TimeSpan.FromMilliseconds((double) buildTimeMs.Value).TotalHours.ToString("##.#", (IFormatProvider) CultureInfo.InvariantCulture) + " hours" : totalSeconds.ToString("##.#", (IFormatProvider) CultureInfo.InvariantCulture) + " seconds";
        }
      }
      return " Never Run ";
    }

    private string FormatLastUpdated(DateTime? lastUpdated) => !lastUpdated.HasValue ? " Never Run " : lastUpdated.Value.ToShortDateString() + " - " + lastUpdated.Value.ToShortTimeString() + " (UTC)";

    private string FormatBoolean(bool value) => value.ToString();

    private string FormatThroughputTime(float rebuildThroughputTime) => rebuildThroughputTime.ToString("##.#", (IFormatProvider) CultureInfo.InvariantCulture) + " items per second";

    private string FormatLong(long value) => value.ToString((IFormatProvider) CultureInfo.InvariantCulture);
  }
}
