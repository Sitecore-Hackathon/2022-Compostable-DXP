// Decompiled with JetBrains decompiler
// Type: Sitecore.DevEx.Extensibility.Indexing.Tasks.IndexStatisticTaskOptions
// Assembly: Sitecore.DevEx.Extensibility.Indexing, Version=4.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4DCA9AAF-B319-477E-884B-8741A816EFA0
// Assembly location: C:\inetpub\wwwroot\2022-Compostable-DXP-Private\.sitecore\package-cache\nuget\Sitecore.DevEx.Extensibility.Indexing.4.1.0\plugin\Sitecore.DevEx.Extensibility.Indexing.dll

using Sitecore.DevEx.Client.Tasks;

namespace Primo.DevEx.Extensibility.Indexing.Tasks
{
  public class IndexStatisticTaskOptions : TaskOptionsBase
  {
    public string Config { get; set; }

    public string EnvironmentName { get; set; }

    public bool Verbose { get; set; }

    public bool Trace { get; set; }

    public override void Validate()
    {
      this.Require("Config");
      this.Default("EnvironmentName", (object) "default");
    }
  }
}
