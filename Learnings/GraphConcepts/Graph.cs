using System.Collections.Generic;
using System.Linq;

namespace GraphConcepts
{
    public class Graph<T>
    {
        private NodeList<T> nodeSet;
        private NodeList<T> nonRoots;

        public Graph() : this(null)
        {
        }

        public Graph(NodeList<T> nodeSet)
        {
            this.nodeSet = nodeSet ?? new NodeList<T>();
        }

        public void AddNode(GraphNode<T> node)
        {
            nodeSet.Add(node);
        }
        public void AddNode(Node<T> node)
        {
            nodeSet.Add(node);
        }

        public void AddDirectedEdge(GraphNode<T> from, GraphNode<T> to, int weight = 0)
        {
            from.Neighbors.Add(to);
            from.Weights.Add(weight);
            if (this.nonRoots == null)
                nonRoots = new NodeList<T>();
            nonRoots.Add(to);
        }

        public bool Contains(T value)
        {
            return nodeSet.FindByValue(value) != null;
        }

        public bool Remove(T value)
        {
            GraphNode<T> nodeToRemove = (GraphNode<T>)nodeSet.FindByValue(value);
            if (nodeToRemove == null)
                return false;
            return RemoveGraphNode(nodeToRemove);
        }

        private bool RemoveGraphNode(GraphNode<T> nodeToRemove)
        {
            nodeSet.Remove(nodeToRemove);
            nonRoots.Remove(nodeToRemove);
            // enumerate through each node in the nodeSet, removing edges to this node
            foreach (var node in nodeSet)
            {
                var gnode = (GraphNode<T>)node;
                int index = gnode.Neighbors.IndexOf(nodeToRemove);
                if (index != -1)
                {
                    // remove the reference to the node and associated cost
                    gnode.Neighbors.RemoveAt(index);
                    gnode.Weights.RemoveAt(index);
                }
            }

            return true;
        }

        public NodeList<T> Nodes
        {
            get { return nodeSet; }
        }

        public int Count
        {
            get { return nodeSet.Count; }
        }


        public IEnumerable<Node<T>> RootNodes
        {
            get { return nodeSet.Where(node => !nonRoots.Contains(node)); }
        }


        //A graph can have many roots. This will traverse from one of the root in the graph.
        public IEnumerable<Node<T>> BreadthFirstTraversal<T>(Node<T> start)
        {
            var queue = new Queue<Node<T>>();
            queue.Enqueue(start);


            while (queue.Count != 0)
            {
                var current = queue.Dequeue();
                yield return current;
                if (current.Neighbours != null)
                {
                    foreach (var neighbour in current.Neighbours)
                    {
                        queue.Enqueue(neighbour);
                    }
                }
            }
        }

        //A graph can have many roots. This will traverse from one of the root in the graph.
        public IEnumerable<Node<T>> DepthFirstTraversal<T>(Node<T> start)
        {
            var visited = new HashSet<Node<T>>();
            var stack = new Stack<Node<T>>();

            stack.Push(start);

            while (stack.Count != 0)
            {
                var current = stack.Pop();
                visited.Add(current);
                yield return current;
                if (current.Neighbours != null)
                {
                    var neighbours = current.Neighbours.Where(node => !visited.Contains(node));
                    // Reverse to maintain the left-to-right order
                    foreach (var neighbour in neighbours.Reverse())
                    {
                        stack.Push(neighbour);
                    }
                }
            }
        }
    }
}
