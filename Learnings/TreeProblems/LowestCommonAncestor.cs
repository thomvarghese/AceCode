using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeProblems
{
    public static class LowestCommonAncestor
    {
        public static TreeNode LCA(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null)
                return null;
            if (root == p || root == q)
                return root;

            TreeNode left = LCA(root.left, p, q);
            TreeNode right = LCA(root.right, p, q);

            if (left != null && right != null)
                return root;

            return left != null ? left : right;
        }
    }
}
