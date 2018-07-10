using System;
using System.Collections.Generic;

namespace TreeProblems
{

    public class TreeSideView
    {

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
