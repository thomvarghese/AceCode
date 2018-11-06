using System.Collections.Generic;

namespace TreeProblems
{
    /*
     * Given a binary tree where every node has a unique value, and a target key k, find the value of the nearest leaf node to target k in the tree.
       Here, nearest to a leaf means the least number of edges travelled on the binary tree to reach any leaf of the tree. Also, a node is called a leaf if it has no children.
       In the following examples, the input tree is represented in flattened form row by row. The actual root tree given will be a TreeNode object.

       Example 1:
        Input:
        root = [1, 3, 2], k = 1
        Diagram of binary tree:
                  1
                 / \
                3   2

        Output: 2 (or 3)

        Input:  root = [1,2,3,4,null,null,null,5,null,6], k = 2
        Diagram of binary tree:
                     1
                    / \
                   2   3
                  /
                 4
                /
               5
              /
             6

        Output: 3

        Approach 1 :Instead of a binary tree, convert the tree to a general graph.
        We could find the shortest path to a leaf using breadth-first search.

        Create a graph/dictionary for each node for it's neigbors ( parent and children). We can use dfs to create that).
        For the given example, it (Dictionary) should look like

        1: null, 2, 3
        2: 1, 4
        4: 2, 5
        5: 4, 6
        6: 5
        3: 1
        
        if any key (node) has 2 neighbors, then its not a leaf.
        if any node has one neigbor, then its a leaf.
        Then do a BFS from the target node (2) and check if it's a leaf. 
        2 has 2 neigbors (1,4), the bfs queue will look like this.
        2 -> 1 -> 4 -> 2 -> 3
     */
    public static class ClosestLeafToTarget
    {

        public static TreeNode ClosestLeaf(TreeNode root, int target)
        {
            if (root == null || target == 0) return null;
            var map = new Dictionary<TreeNode, List<TreeNode>>();

            //Do a dfs and create the map of neighbors
            CreateMapOfNeighbors(map, root, null);

            //Now perfrom a BFS - using queue - from the node where we want to find the closest leaf. 
            //Also maintain a visited map/set
            Queue<TreeNode> queue = new Queue<TreeNode>();
            HashSet<TreeNode> visited = new HashSet<TreeNode>();

            //find the node to start the BFS
            foreach (TreeNode node in map.Keys)
            {
                if (node.val == target)
                {
                    queue.Enqueue(node);
                    visited.Add(node);
                    break;
                }
            }

            //While doing the BFS, check if count of neighbors is <= 1, if so its a leaf 
            while (queue.Count > 0)
            {
                var n = queue.Dequeue();
                if (n != null)
                { 
                if (map[n].Count <= 1)
                    return n;
                foreach (TreeNode n1 in map[n])
                {
                    if (!visited.Contains(n1))
                    {
                        queue.Enqueue(n1);
                        visited.Add(n1);
                    }
                }
                }

            }
            return null;
        }
        private static void CreateMapOfNeighbors(Dictionary<TreeNode, List<TreeNode>> dict, TreeNode node, TreeNode parent)
        {
            if (node != null)
            {
                //Parent and 2 children are the possible neighbors - parent will be null for the root
                //So add current node as the neighbor to parent and add parent as the neighbor to current node
                //Perform that with a DFS - recursively.
                if (!dict.ContainsKey(node))
                    dict.Add(node, new List<TreeNode>());
                if (parent != null && !dict.ContainsKey(parent))
                    dict.Add(parent, new List<TreeNode>());

                dict[node].Add(parent);
                if (parent != null)
                    dict[parent].Add(node);

                if (node.left != null)
                    CreateMapOfNeighbors(dict, node.left, node);
                if (node.right != null)
                    CreateMapOfNeighbors(dict, node.right, node);
            }
        }

    }   

}
