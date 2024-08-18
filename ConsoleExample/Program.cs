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
            string temp = "My name is #Name#, #Name#";

            IRegexTemp tp = RegexTempFactory.Create("test", new TempEngineBuilderConfig
            {
                Pattern = "#(\\S*)#",
                Template = temp,
            });

            var paramBuilder = tp.CreateParamBuilder();

            paramBuilder.IfExist("Name", new List<string> { "Luke", "stranger" }, ValueSetOption.MultipleInOrder);

            var tm = paramBuilder.Build();

            string result = tp.Execute(tm);

            Console.WriteLine(result);

            Console.ReadLine();
        }
    }
}
