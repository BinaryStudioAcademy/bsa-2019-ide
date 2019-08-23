using System;
using System.Collections.Generic;
using System.Text;

namespace IDE.BLL.Helpers
{
    public class TemplateHelper
    {
        public static string CSharpCsprojTemplate() =>
                   "<Project Sdk=\"Microsoft.NET.Sdk\">\n\n <PropertyGroup>\n    <OutputType>Exe</OutputType>\n" +
                   "    <TargetFramework>netcoreapp2.2</TargetFramework>\n  </PropertyGroup>\n\n</Project>";

        public static string CSharpProgramTemplate(string projectName) =>
                   "using System;\n\nnamespace " + projectName + "\n{\n    class Program\n    {\n" +
                   "        static void Main(string[] args)\n        {\n            Console.WriteLine(\"Hello World!\");\n" +
                   "        }\n    }\n}\n";

        public static string GoProgramTemplate() =>
                  "package main\n\nimport \"fmt\"\n\nfunc main(){  \n  fmt.Println(\"Hello, World\")\n}";

        public static string JsProgramTemplate() =>
            "alert(\"Hello, World!\");";
        
    }
}
