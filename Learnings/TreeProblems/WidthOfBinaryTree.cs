using System;
using System.Collections.Generic;

namespace TreeProblems
{
    public class WidthOfBinaryTree
    {
        public int WidthOfTree(TreeNode root)
        {
            if (root == null) return 0;
            Queue<TreeNode> q = new Queue<TreeNode>();
            Dictionary<TreeNode, int> d = new Dictionary<TreeNode, int>();
            q.Enqueue(root);
            d.Add(root, 1);
            int maxWidth = 0;
            int count = 0;
            while (q.Count > 0)
            {
                int start = 0, end = 0;
                int level = q.Count;
                for (int i = 0; i < level; i++)
                {
                    TreeNode node = q.Dequeue();
                    if (i == 0)
                        start = d[node];
                    if (i == level - 1)
                        end = d[node];
                    if (node.left != null)
                    {
                        q.Enqueue(node.left);
                        d.Add(node.left, 2 * d[node]);
                    }
                    if (node.right != null)
                    {
                        q.Enqueue(node.right);
                        d.Add(node.right, 2 * d[node] + 1);
                    }
                }
                count = end - start + 1;
                maxWidth = Math.Max(maxWidth, count);
            }
            return maxWidth;
        }
    }
}
