using Sitecore.DevEx.Client.Tasks;
using System;
using System.Collections.Generic;
using System.Text;
using Primo.DevEx.Extensibility.Hackathon;
using Primo.DevEx.Extensibility.Hackathon.HelloWorld.Data;

namespace Primo.DevEx.Extensibility.Hackathon.HelloWorld
{
    public class HelloWorldTaskOptions : PrimoBaseTaskOptions
    {
        public string Style { get; set; }
        public string Message { get; set; }

        public override void Validate()
        {
            //Setup required command options
            Require(nameof(Message));

            // Input validation
            ValidateStyle(Style);
        }

        private void ValidateStyle(string style)
        {
            if (!OutputStyles.AllStyles.Contains(style))
            {
                throw new TaskValidationException(string.Format(HelloWorldResources.InvalidStyleOption, style));
            }
        }
    }
}
