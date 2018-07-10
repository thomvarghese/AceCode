using System;
using System.Collections.Generic;

namespace CycleInGraph
{
    class Program
    {
        static void Main(string[] args)
        {            
            Node a1 = new Node("a1");
            Node a2 = new Node("a2");
            Node a3 = new Node("a3");
            Node a4 = new Node("a4");
            Node b1 = new Node("b1");
            Node b2 = new Node("b2");
            Node b3 = new Node("b3");

            var graph = new Graph();
            graph.Nodes = new List<Node>() { a1, a2, a3, a4, b1, b2, b3 };
            a1.AddEdge(a2);
            a1.AddEdge(a3);
            a2.AddEdge(a3);
            a3.AddEdge(a4);
            a3.AddEdge(b1);
            a4.AddEdge(b1);

            if (graph.HasCycle())
                Console.WriteLine("Cycle Detected");
            else

                Console.WriteLine("No Cycle");

            Console.ReadLine();

        }
       
    }    
    
}
