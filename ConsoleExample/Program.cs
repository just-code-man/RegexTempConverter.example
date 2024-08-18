using Luke.RegexTempConverter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string temp = "My name is #Name#";

            IRegexTemp tp = RegexTempFactory.Greate("test", new TempEngineBuilderConfig
            {
                Pattern = "#(\\S*)#",
                Template = temp,
            });

            var paramBuilder = tp.CreateParamBuilder();

            paramBuilder.IfExist("Name", "Luke");

            var tm = paramBuilder.Build();

            string result = tp.Execute(tm);

            Console.WriteLine(result);

            Console.ReadLine();
        }
    }
}
