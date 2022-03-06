// Decompiled with JetBrains decompiler
// Type: Sitecore.DevEx.Extensibility.Indexing.Commands.IndexSchemaArgs
// Assembly: Sitecore.DevEx.Extensibility.Indexing, Version=4.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4DCA9AAF-B319-477E-884B-8741A816EFA0
// Assembly location: C:\inetpub\wwwroot\2022-Compostable-DXP-Private\.sitecore\package-cache\nuget\Sitecore.DevEx.Extensibility.Indexing.4.1.0\plugin\Sitecore.DevEx.Extensibility.Indexing.dll

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Primo.DevEx.Extensibility.Indexing.Tasks;
using Sitecore.Devex.Client.Cli.Extensibility.Subcommands;

namespace Primo.DevEx.Extensibility.Indexing.Commands
{
  [ExcludeFromCodeCoverage]
  public class IndexSchemaArgs : IndexTaskOptions, IVerbosityArgs
  {
    public List<string> Indexes { get; set; }
  }
}
