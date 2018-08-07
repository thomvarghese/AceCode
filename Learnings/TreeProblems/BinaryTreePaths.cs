using System.Collections.Generic;

namespace TreeProblems
{
    public static class BinaryTreePaths
    {
        public static List<string> GetBinaryTreePaths(TreeNode root)
        {
            List<string> result = new List<string>();
            if (root == null) return result;
            PrintPaths(root, "", result);
            return result;
        }

        private static void PrintPaths(TreeNode root, string path, IList<string> result)
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

        public static List<List<int>> GetBinaryTreePathsToSum(TreeNode root, int sum)
        {

            List<List<int>> result = new List<List<int>>();
            if (root == null) return result;
            PrintPathsToSum(root, sum, new List<int>(), result);
            return result;
        }

        private static void PrintPathsToSum(TreeNode root, int sum, List<int> paths, List<List<int>> result)
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
