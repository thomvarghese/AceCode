using System.Collections.Generic;

namespace DSConcepts
{
    public class VerticalOrderTraversal
    {
        int level;
        Dictionary<int, List<int>> verticalMap = new Dictionary<int, List<int>>();
        public Node VerticalOrder(Node root, int level)
        {
            if (root == null) return null;
            //recursively go the leftmost while substracting 1 as we move each level
            Node x = VerticalOrder(root.Left, --level);
            if (x == null) level++; // ie we are at extreme left
            //store the node value to a hastable
            if (verticalMap.ContainsKey(level))
            {
                var list = verticalMap[level];
                list.Add(root.Value);
                verticalMap.Remove(level);
                verticalMap.Add(level, list);
            }
            else
            {
                var list = new List<int> { root.Value };
                verticalMap.Add(level, list);
            }
            return VerticalOrder(root.Right, level);
        }
    }

    public class Node
    {
        public Node Left { get; set; }
        public Node Right { get; set; }
        public int Value;

    }
}
