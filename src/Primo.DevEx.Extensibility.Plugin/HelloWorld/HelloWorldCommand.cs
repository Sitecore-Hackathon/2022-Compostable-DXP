using Sitecore.Devex.Client.Cli.Extensibility.Subcommands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Primo.DevEx.Extensibility.Hackathon;
using Primo.DevEx.Extensibility.Hackathon.HelloWorld.Data;


namespace Primo.DevEx.Extensibility.Hackathon.HelloWorld
{
    public class HelloWorldCommand : SubcommandBase<HelloWorldTask, HelloWorldTaskOptions>
    {
        public HelloWorldCommand(IServiceProvider container) : base(HelloWorldResources.CommandName, HelloWorldResources.CommandDesc, container)
        {
            // Add the Hello World options for the "hello" command
            AddOption(HelloWorldArgOptions.Message);
            AddOption(HelloWorldArgOptions.Style);
            AddOption(PrimoDemoArgOptions.Verbose);
            AddOption(PrimoDemoArgOptions.Trace);
        }

        /// <summary>
        /// Processes the command.
        /// </summary>
        /// <param name="task"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        protected override async Task<int> Handle(HelloWorldTask task, HelloWorldTaskOptions args)
        {
            args.Validate();
            await task.Execute(args).ConfigureAwait(false);

            return 0;
        }
    }
}
