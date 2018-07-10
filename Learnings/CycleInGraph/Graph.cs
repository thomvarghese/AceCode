using System.Collections.Generic;
using System.Linq;

namespace CycleInGraph
{
    public class Node
    {
        public string Value;
        public List<Node> Children;

        public Node(string value)
        {
            Value = value;
            Children = new List<Node>();
        }
        public void AddEdge(Node n)
        {
            Children.Add(n);
        }
    }
    public class Graph
    {
        public List<Node> Nodes;

        public bool HasCycle()
        {
            if (Nodes == null || !Nodes.Any()) return false;

            var visitedNodes = new HashSet<Node>();
            var completedNodes = new HashSet<Node>();

            foreach (Node n in Nodes)
            {
                if (HasCycleDfs(n, visitedNodes, completedNodes))
                    return true;
            }
            return false;
        }

        private static bool HasCycleDfs(Node node, HashSet<Node> visitedNodes, HashSet<Node> completedNodes)
        {

            if (visitedNodes.Contains(node))
            {
                if (completedNodes.Contains(node))
                    return false;
                return true;
            }
            visitedNodes.Add(node);

            foreach (Node n in node.Children)
            {
                if (HasCycleDfs(n, visitedNodes, completedNodes))
                    return true;
            }

            completedNodes.Add(node);
            return false;
        }
    }
}
