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
        
        
    }
}
