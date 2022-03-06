using System;
using System.Collections.Generic;
using System.Text;

namespace Primo.DevEx.Extensibility.Hackathon.HelloWorld.Data
{
    public static class OutputStyles
    {
        public const string Plain = "plain";
        public const string WordArt = "wordart";

        public static List<string> AllStyles = new List<string>() { Plain, WordArt };
    }
}
