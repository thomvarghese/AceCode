using System;

namespace TreeProblems
{
    public static class IsBalancedTree
    {
        public static bool IsBalanced(TreeNode root)
        {
            if (CheckHeight(root) == -1)
                return false;
            return true;
        }

        private static int CheckHeight(TreeNode root)
        {
            if (root == null) return 0;
            var leftHeight = CheckHeight(root.left);
            if (leftHeight == -1)
                return -1;

            var rightHeight = CheckHeight(root.right);
            if (rightHeight == -1)
                return -1;

            if (Math.Abs(leftHeight - rightHeight) > 1)
                return -1;

            return Math.Max(leftHeight, rightHeight) + 1;
        }


        public static int MaxDepth(TreeNode root)
        {
            if (root == null) return 0;
            int leftMax = root.left == null ? 0 : MaxDepth(root.left);
            int rightMax = root.right == null ? 0 : MaxDepth(root.right);
            return 1 + Math.Max(leftMax, rightMax);
        }

        public static int MinDepth(TreeNode root)
        {
            if (root == null) return 0;
            if (root.right != null && root.left != null)
                return Math.Min(MinDepth(root.left) + 1, MinDepth(root.right) + 1);
            if (root.right != null)
                return MinDepth(root.right) + 1;
            else
                return MinDepth(root.left) + 1;
        }
    }
}
