using Microsoft.Extensions.Logging;
using Sitecore.DevEx.Client.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Primo.DevEx.Extensibility.Hackathon.HelloWorld.Data
{
    internal static class AsciiSimpleText
    {
        static string[] alpha1 = new string[26]
        {   a1,
            b1,
            c1,
            d1,
            e1,
            f1,
            g1,
            h1,
            i1,
            j1,
            k1,
            l1,
            m1,
            n1,
            o1,
            p1,
            q1,
            r1,
            s1,
            t1,
            u1,
            v1,
            w1,
            x1,
            y1,
            z1
        };

        static string[] alpha2 = new string[26]
        {   a2,
            b2,
            c2,
            d2,
            e2,
            f2,
            g2,
            h2,
            i2,
            j2,
            k2,
            l2,
            m2,
            n2,
            o2,
            p2,
            q2,
            r2,
            s2,
            t2,
            u2,
            v2,
            w2,
            x2,
            y2,
            z2
        };

        static string[] alpha3 = new string[26]
        {   a3,
            b3,
            c3,
            d3,
            e3,
            f3,
            g3,
            h3,
            i3,
            j3,
            k3,
            l3,
            m3,
            n3,
            o3,
            p3,
            q3,
            r3,
            s3,
            t3,
            u3,
            v3,
            w3,
            x3,
            y3,
            z3
        };

        const string a1 = @"     ";
        const string a2 = @" /\  ";
        const string a3 = @"/--\ ";

        const string b1 = @" _  ";
        const string b2 = @"|_) ";
        const string b3 = @"|_) ";

        const string c1 = @" _ ";
        const string c2 = @"/  ";
        const string c3 = @"\_ ";

        const string d1 = @" _  ";
        const string d2 = @"| \ ";
        const string d3 = @"|_/ ";


        const string e1 = @" _ ";
        const string e2 = @"|_ ";
        const string e3 = @"|_ ";

        const string f1 = @" _ ";
        const string f2 = @"|_ ";
        const string f3 = @"|  ";

        const string g1 = @" __ ";
        const string g2 = @"/__ ";
        const string g3 = @"\_| ";

        const string h1 = @"    ";
        const string h2 = @"|_| ";
        const string h3 = @"| | ";

        const string i1 = @"___ ";
        const string i2 = @" |  ";
        const string i3 = @"_|_ ";

        const string j1 = @"    ";
        const string j2 = @"  | ";
        const string j3 = @"\_| ";

        const string k1 = @"   ";
        const string k2 = @"|/ ";
        const string k3 = @"|\ ";

        const string l1 = @"   ";
        const string l2 = @"|  ";
        const string l3 = @"|_ ";

        const string m1 = @"     ";
        const string m2 = @"|\/| ";
        const string m3 = @"|  | ";

        const string n1 = @"     ";
        const string n2 = @"|\ | ";
        const string n3 = @"| \| ";

        const string o1 = @" _  ";
        const string o2 = @"/ \ ";
        const string o3 = @"\_/ ";

        const string p1 = @" _  ";
        const string p2 = @"|_) ";
        const string p3 = @"|   ";

        const string q1 = @" _  ";
        const string q2 = @"/ \ ";
        const string q3 = @"\_X ";

        const string r1 = @" _  ";
        const string r2 = @"|_) ";
        const string r3 = @"| \ ";

        const string s1 = @" __ ";
        const string s2 = @"(_  ";
        const string s3 = @"__) ";

        const string t1 = @"___ ";
        const string t2 = @" |  ";
        const string t3 = @" |  ";

        const string u1 = @"    ";
        const string u2 = @"| | ";
        const string u3 = @"|_| ";

        const string v1 = @"     ";
        const string v2 = @"\  / ";
        const string v3 = @" \/  ";

        const string w1 = @"       ";
        const string w2 = @"\    / ";
        const string w3 = @" \/\/  ";

        const string x1 = @"   ";
        const string x2 = @"\/ ";
        const string x3 = @"/\ ";

        const string y1 = @"    ";
        const string y2 = @"\_/ ";
        const string y3 = @" |  ";

        const string z1 = @"__ ";
        const string z2 = @" / ";
        const string z3 = @"/_ ";

        internal static string[] GetAsciiString(string text)
        {
            if (text == null)
                return null;

            string alphabet = "abcdefghijklmnopqrstuvwxyz";

            string[] asciiText = new string[3];
            string lineOne = "";
            string lineTwo = "";
            string lineThree = "";


            foreach (char c in text.ToLower().ToCharArray())
            {
                if (char.IsWhiteSpace(c))
                {
                    lineOne += "    ";
                    lineTwo += "    ";
                    lineThree += "    ";
                }

                if (char.IsLetter(c))
                {
                    int index = alphabet.IndexOf(c);
                    lineOne += alpha1[index];
                    lineTwo += alpha2[index];
                    lineThree += alpha3[index];
                }
            }

            asciiText[0] = lineOne;
            asciiText[1] = lineTwo;
            asciiText[2] = lineThree;

            return asciiText;
        }

        internal static void LogAsciiString(string[] asciiString, ILogger logger)
        {
            logger.LogConsoleInformation(asciiString[0]);
            logger.LogConsoleInformation(asciiString[1]);
            logger.LogConsoleInformation(asciiString[2]);
        }
    }
}
