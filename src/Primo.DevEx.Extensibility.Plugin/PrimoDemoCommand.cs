using Sitecore.Devex.Client.Cli.Extensibility.Subcommands;
using System;
using System.Collections.Generic;
using System.CommandLine;
using System.Text;
using System.Threading.Tasks;

namespace Primo.DevEx.Extensibility.Hackathon
{
    public class PrimoDemoCommand : Command, ISubcommand
    {
        public PrimoDemoCommand(string name, string description = null) : base(name, description)
        {
            Initialize();
        }

        public virtual void Initialize()
        {
            //AddAlias(CommonResources.PraxisCmdAlias);
        }
    }
}
