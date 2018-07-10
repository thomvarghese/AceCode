using System.Collections.Generic;

namespace TreeProblems
{
    public static class VerticalOrderTraversal
    {
        public static Dictionary<int, List<int>> VerticalOrder(TreeNode root)
        {
            Dictionary<int, List<int>> verticalMap = new Dictionary<int, List<int>>();
            int level = 0;

            VerticalOrder(root, level, verticalMap);
            return verticalMap;
        }
        private static TreeNode VerticalOrder(TreeNode root, int level, Dictionary<int, List<int>> verticalMap)
        {
            if (root == null) return null;
            //recursively go the leftmost while substracting 1 as we move each level
            TreeNode x = VerticalOrder(root.left, --level, verticalMap);
            if (x == null) level++; // ie we are at extreme left
            //store the node value to a hastable
            if (verticalMap.ContainsKey(level))
            {
                verticalMap[level].Add(root.val);
                //var levelList = verticalMap[level];
                //levelList.Add(root.val);
                //verticalMap.Remove(level);
                //verticalMap.Add(level, levelList);
            }
            else
            {
                verticalMap.Add(level, new List<int> { root.val });
            }
            return VerticalOrder(root.right, ++level, verticalMap);
        }
    }
}
