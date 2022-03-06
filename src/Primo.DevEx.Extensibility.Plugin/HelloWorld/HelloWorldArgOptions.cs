using System;
using System.Collections.Generic;
using System.CommandLine;
using System.Text;
using Primo.DevEx.Extensibility.Hackathon.HelloWorld.Data;

namespace Primo.DevEx.Extensibility.Hackathon.HelloWorld
{
    public class HelloWorldArgOptions
    {
        public static readonly Option Style = CreateStyleOption();

        private static Option CreateStyleOption()
        {
            Option style = new Option(new[] { HelloWorldResources.StyleOptionName, HelloWorldResources.StyleOptionAlias }, HelloWorldResources.StyleOptionDesc);
            Argument styleArg = new Argument<string>(() => HelloWorldResources.StyleOptionDefaultValue);

            // TODO: Get auto suggestions working
            //styleArg.AddSuggestions(new[] { "asparagus", "broccoli", "carrot" });

            style.Argument = styleArg;
            return style;
        }

        public static readonly Option Message = new Option(new[] { HelloWorldResources.MessageOptionName, HelloWorldResources.MessageOptionAlias }, HelloWorldResources.MessageOptionDesc)
        {
            Argument = new Argument<string>(() => HelloWorldResources.MessageDefaultValue)
        };
    }
}
