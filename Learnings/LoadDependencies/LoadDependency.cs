using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDependencies
{

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
            
            //Create the graph of nodes and the list of all nodes
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
                //first string is the name of the lib and the subsequent ones are the dependencies
                //create the node and add it to the all nodes collection
                if (!allNodes.ContainsKey(lib[0]))
                {
                    allNodes.Add(lib[0], new Node(lib[0]));
                }
                Node node = allNodes[lib[0]];

                // Set the dependencies for the newly created node - which are the subsequent strings
                for (int i = 1; i < lib.Count; i++)
                {
                    node.Dependencies.Add(lib[i]);
                    var dependentNode = new Node(lib[i]);
                    //while creating the dependent nodes, add it to the all nodes list.
                    if (!allNodes.ContainsKey(dependentNode.Name))
                        allNodes.Add(dependentNode.Name, dependentNode);
                }
                // finally add the node to the graph.
                // the graph have only the nodes in the list of libs to be loaded - and not its dependencies
                graph.nodes.Add(node);
            }
            return graph;
        }

        private static bool LoadDeps(Node node, List<string> result, Dictionary<string, Node> allNodes,
                                     HashSet<Node> visitedNodes, HashSet<Node> completedNodes)
        {
            //checking if the node is already visited.
            //if the node is already visited and is not completed, then it implies that there is a cycle.
            if (visitedNodes.Contains(node) && !completedNodes.Contains(node))
            {
                return true;
            }
            //Mark the current node as visited.
            visitedNodes.Add(node);

            //Doing a DFS and loading the dependencies
            if (node.Dependencies.Any())
            {
                foreach (var dep in node.Dependencies)
                {
                    var dependentNode = allNodes[dep];

                    //if the dependent node is not already loaded, load it recursively
                    if (!result.Contains(dependentNode.Name))
                    {
                        var hasCycle = LoadDeps(dependentNode, result, allNodes, visitedNodes, completedNodes);
                        if (hasCycle)
                            return true; // returning that a cycle has been detected.
                    }
                }
            }

            //After loading all its dependencies via DFS, load the current node
            if (!result.Contains(node.Name))
                result.Add(node.Name);

            //Mark the node as completed (visited and completed) 
            completedNodes.Add(node);

            return false; // returning false to imply that no cycle has been detected.
        }


        //Another way to detect cycle - seperate method using DFS to detect cycle 
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
