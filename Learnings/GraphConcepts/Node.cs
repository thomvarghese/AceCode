namespace GraphConcepts
{
    public class Node<T>
    {
        public Node()
        {
        }

        public Node(T data) : this(data, null)
        {
        }

        public Node(T data, NodeList<T> neighbours)
        {
            this.Value = data;
            this.Neighbours = neighbours;
        }

        public T Value { get; set; }

        public NodeList<T> Neighbours { get; set; }
    }
}
