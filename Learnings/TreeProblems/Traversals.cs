using System.Collections.Generic;

namespace TreeProblems
{
    public static class Traversals
    {

        public static IList<int> PreorderTraversal(TreeNode root)
        {
            IList<int> list = new List<int>();
            Stack<TreeNode> rights = new Stack<TreeNode>();
            while (root != null)
            {
                list.Add(root.val);
                if (root.right != null)
                {
                    rights.Push(root.right);
                }
                root = root.left;
                if (root == null && rights.Count > 0)
                {
                    root = rights.Pop();
                }
            }
            return list;
        }

        public static IList<int> InorderTraversal(TreeNode root)
        {
            IList<int> list = new List<int>();

            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode cur = root;

            while (cur != null || stack.Count > 0)
            {
                while (cur != null)
                {
                    stack.Push(cur);
                    cur = cur.left;
                }
                cur = stack.Pop();
                list.Add(cur.val);
                cur = cur.right;
            }

            return list;
        }

        public static IList<int> PostorderTraversal(TreeNode root)
        {
            Stack<TreeNode> s1 = new Stack<TreeNode>();
            Stack<TreeNode> s2 = new Stack<TreeNode>();
            List<int> res = new List<int>();
            if (root != null)
                s1.Push(root);
            while (s1.Count > 0)
            {
                TreeNode node = s1.Pop();
                s2.Push(node);

                if (node.left != null)
                    s1.Push(node.left);
                if (node.right != null)
                    s1.Push(node.right);
            }

            while (s2.Count > 0)
            {
                res.Add(s2.Pop().val);
            }
            return res;
        }
    }
}
