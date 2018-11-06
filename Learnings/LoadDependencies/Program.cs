using System;
using System.Collections.Generic;
using System.Linq;

namespace LoadDependencies
{
    class Program
    {
        static void Main(string[] args)
        {
            List<List<string>> list = new List<List<string>>()
            {
                new List<string>(){"L1","L2","L3" },
                new List<string>(){"L2","L4","L5","L1","L6" },
                new List<string>(){"L5","L6","L3" }
            };

            foreach (var lib in list)
            {
                foreach (var v in lib)
                    Console.Write(v + "  ");
                Console.WriteLine();
            }

            Console.ReadLine();

            var res = LoadDependency.LoadDependencies(list);

            foreach (var v in res)
                Console.Write(v + "  ");
            Console.ReadLine();

        }
    }
}

