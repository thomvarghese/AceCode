using System;
using System.Collections.Generic;

namespace MiscApp
{
    class Program
    {
        static void Main(string[] args)
        {

            string s = "jack hgh kite go drunk whiskey help";
            List<string> wordsToExclude = new List<String>() { "help" };
            var y = MostCommon.MostCommonWords(s, wordsToExclude);
            foreach (var str in y)
                Console.WriteLine(str);
            Console.ReadLine();


            var list = new List<string>()
            {
                "al 9 2 3 1",
                "g1 Act car",
                "zo 4 4 7",
                "abl jsf KEY dog",
                "a8 act zoo"
            };

            var res = SortLogs.SortLogEntries(list);
        }
    }
}