using System.Collections.Generic;

namespace GraphConcepts
{
    public class GraphNode<T> : Node<T>
    {
        //weights can be used specify the weight associated with traversing from the GraphNode to Neighbours[i].
        private List<int> _weights;

        public GraphNode() : base()
        {
        }

        public GraphNode(T value) : base(value)
        {
        }

        public GraphNode(T value, NodeList<T> neighbours) : base(value, neighbours)
        {
        }

        public GraphNode(T value, NodeList<T> neighbours, List<int> weights) : base(value, neighbours)
        {
            _weights = weights;
        }

        public new NodeList<T> Neighbors
        {
            get
            {
                if (base.Neighbours == null)
                    base.Neighbours = new NodeList<T>();
                return base.Neighbours;
            }
        }

        public List<int> Weights
        {
            get
            {
                if (_weights == null)
                    _weights = new List<int>();

                return _weights;
            }
        }


    }
}
