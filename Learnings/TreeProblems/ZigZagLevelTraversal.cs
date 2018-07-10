using System.Collections.Generic;

namespace TreeProblems
{
    public class ZigZagLevelTraversal
    {
        public static IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null) return result;
            Stack<TreeNode> st1 = new Stack<TreeNode>();
            Stack<TreeNode> st2 = new Stack<TreeNode>();
            st1.Push(root);
            //var currentStack = st1;
            //var nextStack = st2;
            while (st1.Count != 0)
            {
                var list = new List<int>();
                while (st1.Count > 0)
                {                    
                    var node = st1.Pop();
                    list.Add(node.val);
                    if (node.right != null) st2.Push(node.right);
                    if (node.left != null) st2.Push(node.left);
                }
                result.Add(list);

                list = new List<int>();
                while (st2.Count > 0)
                {                    
                    var node = st2.Pop();
                    list.Add(node.val);
                    
                    if (node.left != null) st1.Push(node.left);
                    if (node.right != null) st1.Push(node.right);
                }
                if (list.Count > 0)
                    result.Add(list);

            }
            return result;
        }

        public IList<IList<int>> ZigzagOrder(TreeNode root)
        {
            IList<IList<int>> lists = new List<IList<int>>();
            Stack<TreeNode> stack = new Stack<TreeNode>();

            if (root != null) stack.Push(root);
            bool forward = true;

            while (stack.Count > 0)
            {
                lists.Add(new List<int>());
                Stack<TreeNode> nextStack = new Stack<TreeNode>();

                while (stack.Count > 0)
                {
                    TreeNode n = stack.Pop();
                    lists[lists.Count - 1].Add(n.val);

                    if (forward)
                    {
                        if (n.left != null) nextStack.Push(n.left);
                        if (n.right != null) nextStack.Push(n.right);
                    }
                    else
                    {
                        if (n.right != null) nextStack.Push(n.right);
                        if (n.left != null) nextStack.Push(n.left);
                    }
                }

                forward = !forward;
                stack = nextStack;
            }

            return lists;
        }
    }
}
