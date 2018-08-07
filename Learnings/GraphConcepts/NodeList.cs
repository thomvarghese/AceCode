using System.Collections.ObjectModel;
using System.Linq;

namespace GraphConcepts
{
    public class NodeList<T> : Collection<Node<T>>
    {
        public NodeList() : base() { }

        public NodeList(int initialSize)
        {
            // Add the specified number of items
            for (int i = 0; i < initialSize; i++)
                base.Items.Add(default(Node<T>));
        }

        public Node<T> FindByValue(T value)
        {
            // search the list for the value
            return Items.FirstOrDefault(node => node.Value.Equals(value));
        }
    }
}
