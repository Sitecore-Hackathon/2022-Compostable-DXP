using Sitecore.Devex.Client.Cli.Extensibility.Subcommands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Primo.DevEx.Extensibility.Hackathon;
using Primo.DevEx.Extensibility.Hackathon.HelloWorld.Data;


namespace Primo.DevEx.Extensibility.Hackathon.HelloWorld.ShowStyles
{
    public class ShowStylesCommand : SubcommandBase<ShowStylesTask, ShowStylesTaskOptions>
    {
        public ShowStylesCommand(IServiceProvider container) : base(HelloWorldResources.ShowStylesCommandName, HelloWorldResources.ShowStylesCommandName, container)
        {
            // Add the Hello World options for the "hello" command
            AddOption(PrimoDemoArgOptions.Verbose);
            AddOption(PrimoDemoArgOptions.Trace);
        }

        /// <summary>
        /// Processes the command.
        /// </summary>
        /// <param name="task"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        protected override async Task<int> Handle(ShowStylesTask task, ShowStylesTaskOptions args)
        {
            args.Validate();
            await task.Execute(args).ConfigureAwait(false);

            return 0;
        }
    }
}
