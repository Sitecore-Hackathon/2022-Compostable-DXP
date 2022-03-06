using Sitecore.Devex.Client.Cli.Extensibility.Subcommands;
using Sitecore.DevEx.Client.Tasks;
using System;
using System.Collections.Generic;
using System.Text;

namespace Primo.DevEx.Extensibility.Hackathon
{
    public abstract class PrimoBaseTaskOptions : TaskOptionsBase, IVerbosityArgs
    {
        public bool Verbose { get; set; }
        public bool Trace { get; set; }
    }
}
