using System.Collections.Generic;

namespace DSConcepts
{
    //Definition for a binary tree node.
    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class BinaryTreePaths
    {
        public IList<string> GetBinaryTreePaths(TreeNode root)
        {
            IList<string> result = new List<string>();
            if (root == null) return result;
            PrintPaths(root, "", result);
            return result;
        }

        private void PrintPaths(TreeNode root, string path, IList<string> result)
        {
            if (root == null) return;

            path = (!string.IsNullOrEmpty(path)) ? path + "->" + root.val.ToString() : root.val.ToString();

            if (root.left == null && root.right == null)
            {
                result.Add(path);
                return;
            }
            if (root.left != null)
                PrintPaths(root.left, path, result);
            if (root.right != null)
                PrintPaths(root.right, path, result);

        }

        public IList<IList<int>> GetBinaryTreePathsToSum(TreeNode root, int sum)
        {

            IList<IList<int>> result = new List<IList<int>>();
            if (root == null) return result;
            PrintPathsToSum(root, sum, new List<int>(), result);
            return result;
        }

        private void PrintPathsToSum(TreeNode root, int sum, IList<int> paths, IList<IList<int>> result)
        {
            if (root == null) return;
            paths.Add(root.val);

            if (root.left == null && root.right == null && sum == root.val)
            {
                result.Add(new List<int>(paths));
                paths.RemoveAt(paths.Count - 1);
                return;
            }
            else
            {
                //if(root.left != null)
                PrintPathsToSum(root.left, sum - root.val, paths, result);
                //if (root.right != null)
                PrintPathsToSum(root.right, sum - root.val, paths, result);
            }
            paths.RemoveAt(paths.Count - 1);
        }

    }
}