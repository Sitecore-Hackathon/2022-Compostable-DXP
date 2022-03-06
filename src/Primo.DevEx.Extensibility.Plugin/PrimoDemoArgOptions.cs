using System;
using System.Collections.Generic;
using System.CommandLine;
using System.Text;

namespace Primo.DevEx.Extensibility.Hackathon
{
    public static class PrimoDemoArgOptions
    {
        public static readonly Option Verbose = new Option(new[] { CommonResources.VerboseOptionName, CommonResources.VerboseOptionAlias }, CommonResources.VerboseOptionDesc)
        {
            Argument = new Argument<bool>(() => false)
        };

        public static readonly Option Trace = new Option(new[] { CommonResources.TraceOptionName, CommonResources.TraceOptionAlias }, CommonResources.TraceOptionDesc)
        {
            Argument = new Argument<bool>(() => false)
        };
    }
}
