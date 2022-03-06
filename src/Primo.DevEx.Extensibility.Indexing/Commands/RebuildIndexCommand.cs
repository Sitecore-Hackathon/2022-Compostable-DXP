// Decompiled with JetBrains decompiler
// Type: Sitecore.DevEx.Extensibility.Indexing.Commands.RebuildIndexCommand
// Assembly: Sitecore.DevEx.Extensibility.Indexing, Version=4.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4DCA9AAF-B319-477E-884B-8741A816EFA0
// Assembly location: C:\inetpub\wwwroot\2022-Compostable-DXP-Private\.sitecore\package-cache\nuget\Sitecore.DevEx.Extensibility.Indexing.4.1.0\plugin\Sitecore.DevEx.Extensibility.Indexing.dll

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Primo.DevEx.Extensibility.Indexing.Tasks;
using Sitecore.Devex.Client.Cli.Extensibility.Subcommands;
using Sitecore.DevEx.Client.Tasks;

namespace Primo.DevEx.Extensibility.Indexing.Commands
{
  [ExcludeFromCodeCoverage]
  public class RebuildIndexCommand : SubcommandBase<RebuildIndexTask, IndexSchemaArgs>
  {
    public RebuildIndexCommand(IServiceProvider container)
      : base("rebuild", "Rebuild all indexes", container)
    {
      this.AddOption(ArgOptions.EnvironmentName);
      this.AddOption(ArgOptions.Config);
      this.AddOption(ArgOptions.Indexes);
      this.AddOption(ArgOptions.Verbose);
      this.AddOption(ArgOptions.Trace);
    }

    protected override async Task<int> Handle(RebuildIndexTask task, IndexSchemaArgs args)
    {
      ((TaskOptionsBase) args).Validate();
      await task.Execute(args).ConfigureAwait(false);
      return 0;
    }
  }
}
