using System;
using System.Collections.Generic;

namespace TreeProblems
{

    public class TreeSideView
    {
        public static List<int> RightSideViewUsingLevelOrderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            if (root == null) return result;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while(queue.Count > 0)
            {
                int size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    TreeNode cur = queue.Dequeue();
                    if (i == 0)
                        result.Add(cur.val);
                    if (cur.right != null)
                        queue.Enqueue(cur.right);
                    if (cur.left != null)
                        queue.Enqueue(cur.left);
                    //For the left side view, just enqueue the left child first.
                }
            }
            return result;
        }


        public static List<int> RightSideViewDfs(TreeNode root)
        {
            Dictionary<int, int> rightmostValueAtDepth = new Dictionary<int, int>();
            int max_depth = -1;

            /* These two stacks are always synchronized, providing an implicit
             * association values with the same offset on each stack. */
            Stack<TreeNode> nodeStack = new Stack<TreeNode>();
            Stack<int> depthStack = new Stack<int>();
            nodeStack.Push(root);
            depthStack.Push(0);

            while (nodeStack.Count != 0)
            {
                TreeNode node = nodeStack.Pop();
                int depth = depthStack.Pop();

                if (node != null)
                {
                    max_depth = Math.Max(max_depth, depth);

                    /* The first node that we encounter at a particular depth contains
                    * the correct value. */
                    if (!rightmostValueAtDepth.ContainsKey(depth))
                    {
                        rightmostValueAtDepth.Add(depth, node.val);
                    }

                    nodeStack.Push(node.left);
                    nodeStack.Push(node.right);
                    depthStack.Push(depth + 1);
                    depthStack.Push(depth + 1);
                }
            }

            /* Construct the solution based on the values that we end up with at the
             * end. */
            List<int> rightView = new List<int>();
            for (int depth = 0; depth <= max_depth; depth++)
            {
                rightView.Add(rightmostValueAtDepth[depth]);
            }

            return rightView;
        }


        public static List<int> LeftSideViewDfs(TreeNode root)
        {
            Dictionary<int, int> rightmostValueAtDepth = new Dictionary<int, int>();
            int max_depth = -1;

            /* These two stacks are always synchronized, providing an implicit
             * association values with the same offset on each stack. */
            Stack<TreeNode> nodeStack = new Stack<TreeNode>();
            Stack<int> depthStack = new Stack<int>();
            nodeStack.Push(root);
            depthStack.Push(0);

            while (nodeStack.Count != 0)
            {
                TreeNode node = nodeStack.Pop();
                int depth = depthStack.Pop();

                if (node != null)
                {
                    max_depth = Math.Max(max_depth, depth);

                    /* The first node that we encounter at a particular depth contains
                    * the correct value. */
                    if (!rightmostValueAtDepth.ContainsKey(depth))
                    {
                        rightmostValueAtDepth.Add(depth, node.val);
                    }

                    nodeStack.Push(node.right);
                    nodeStack.Push(node.left);
                    depthStack.Push(depth + 1);
                    depthStack.Push(depth + 1);
                }
            }

            /* Construct the solution based on the values that we end up with at the
             * end. */
            List<int> rightView = new List<int>();
            for (int depth = 0; depth <= max_depth; depth++)
            {
                rightView.Add(rightmostValueAtDepth[depth]);
            }

            return rightView;
        }
    }
}
