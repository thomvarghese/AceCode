using System;

namespace TreeProblems
{
    public static class MaxAndMinDepths
    {
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
