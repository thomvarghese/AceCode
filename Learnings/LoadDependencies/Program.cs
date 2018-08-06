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

    public class Node
    {
        public string Name;
        public List<string> Dependencies;
        public Node(string name)
        {
            Name = name;
            Dependencies = new List<string>();
        }
    }

    public class Graph
    {
        public List<Node> nodes;
        public Graph()
        {
            nodes = new List<Node>();
        }
    }
    public static class LoadDependency
    {
        public static List<string> LoadDependencies(List<List<string>> libraries)
        {
            List<string> result = new List<string>();
            Dictionary<string, Node> allNodes = new Dictionary<string, Node>();
            Graph graph = CreateGraphAndAllNodes(libraries, allNodes);

            foreach (var node in graph.nodes)
            {
                if (LoadDeps(node, result, allNodes, new HashSet<Node>(), new HashSet<Node>()))
                {
                    Console.WriteLine("Cycle Detected for " + node.Name);
                }
                else
                    Console.WriteLine("No Cycle Detected for" + node.Name);

            }
            return result;
        }

        private static Graph CreateGraphAndAllNodes(List<List<string>> libraries, Dictionary<string, Node> allNodes)
        {
            var graph = new Graph();
            foreach (var lib in libraries)
            {
                if (!allNodes.ContainsKey(lib[0]))
                {
                    allNodes.Add(lib[0], new Node(lib[0]));
                }
                Node node = allNodes[lib[0]];
                for (int i = 1; i < lib.Count; i++)
                {
                    node.Dependencies.Add(lib[i]);
                    var dependentNode = new Node(lib[i]);
                    if (!allNodes.ContainsKey(dependentNode.Name))
                        allNodes.Add(dependentNode.Name, dependentNode);
                }

                graph.nodes.Add(node);
            }

            return graph;
        }

        private static bool LoadDeps(Node node, List<string> result, Dictionary<string, Node> allNodes,
                                     HashSet<Node> visitedNodes, HashSet<Node> completedNodes)
        {
            if (visitedNodes.Contains(node))
            {
                if(!completedNodes.Contains(node))
                    return true;
            }
            visitedNodes.Add(node);
            if (node.Dependencies.Any())
            {
                foreach (var dep in node.Dependencies)
                {
                    var dependentNode = allNodes[dep];
                    if (!result.Contains(dependentNode.Name))
                    {
                        var hasCycle = LoadDeps(dependentNode, result, allNodes, visitedNodes, completedNodes);
                        if (hasCycle)
                            return true;
                    }
                }
            }

            if (!result.Contains(node.Name))
                result.Add(node.Name);

            completedNodes.Add(node);
            return false;
        }

        private static bool HasCycleDfs(Node node, Dictionary<string, Node> allNodes, 
                                        HashSet<Node> visitedNodes, HashSet<Node> completedNodes)
        {

            if (visitedNodes.Contains(node))
            {
                if (completedNodes.Contains(node))
                    return false;
                return true;
            }
            visitedNodes.Add(node);

            foreach (var dep in node.Dependencies)
            {
                var dependentNode = allNodes[dep];
                if (HasCycleDfs(dependentNode, allNodes, visitedNodes, completedNodes))
                    return true;
            }

            completedNodes.Add(node);
            return false;
        }

    }    
   
}

