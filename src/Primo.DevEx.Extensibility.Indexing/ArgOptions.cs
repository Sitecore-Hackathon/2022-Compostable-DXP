// Decompiled with JetBrains decompiler
// Type: Sitecore.DevEx.Extensibility.Indexing.ArgOptions
// Assembly: Sitecore.DevEx.Extensibility.Indexing, Version=4.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4DCA9AAF-B319-477E-884B-8741A816EFA0
// Assembly location: C:\inetpub\wwwroot\2022-Compostable-DXP-Private\.sitecore\package-cache\nuget\Sitecore.DevEx.Extensibility.Indexing.4.1.0\plugin\Sitecore.DevEx.Extensibility.Indexing.dll

using System;
using System.Collections.Generic;
using System.CommandLine;
using System.Diagnostics.CodeAnalysis;

namespace Primo.DevEx.Extensibility.Indexing
{
  [ExcludeFromCodeCoverage]
  internal static class ArgOptions
  {
    internal static readonly Option Config = new Option(new string[2]
    {
      "--config",
      "-c"
    }, "Path to root sitecore.json directory (default: cwd)")
    {
      Argument = (Argument) new Argument<string>((Func<string>) (() => Environment.CurrentDirectory))
    };
    internal static readonly Option Indexes = new Option(new string[2]
    {
      "--indexes",
      "-i"
    }, "Populates provided index names")
    {
      Argument = (Argument) new Argument<List<string>>((Func<List<string>>) (() => new List<string>()))
    };
    internal static readonly Option EnvironmentName = new Option(new string[2]
    {
      "--environment-name",
      "-n"
    }, "Named Sitecore environment to use. Default: 'default'.")
    {
      Argument = (Argument) new Argument<string>()
    };
    internal static readonly Option Verbose = new Option(new string[2]
    {
      "--verbose",
      "-v"
    }, "Write some additional diagnostic and performance data")
    {
      Argument = (Argument) new Argument<bool>((Func<bool>) (() => false))
    };
    internal static readonly Option Trace = new Option(new string[2]
    {
      "--trace",
      "-t"
    }, "Write more additional diagnostic and performance data")
    {
      Argument = (Argument) new Argument<bool>((Func<bool>) (() => false))
    };
  }
}
