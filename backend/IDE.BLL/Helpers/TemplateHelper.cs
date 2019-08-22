using System;
using System.Collections.Generic;
using System.Text;

namespace IDE.BLL.Helpers
{
    public class TemplateHelper
    {
        public static string CSharpCsprojTemplate()
        {
            return "<Project Sdk=\"Microsoft.NET.Sdk\">\n\n <PropertyGroup>\n    <OutputType>Exe</OutputType>\n" +
                   "    <TargetFramework>netcoreapp2.2</TargetFramework>\n  </PropertyGroup>\n\n</Project>";
        }

        public static string CSharpProgramTemplate()
        {
            return "using System;\n\nnamespace ConsoleApp1\n{\n    class Program\n    {\n" +
                   "        static void Main(string[] args)\n        {\n            Console.WriteLine(\"Hello World!\");\n" +
                   "        }\n    }\n}\n";
        }
    }
}
