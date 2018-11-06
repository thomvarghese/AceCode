using System.Collections.Generic;
using System.Linq;

namespace TreeProblems
{
    public static class BottomAndTopView
    {
        //Bottom and top view lists can be created by doing a vertical order traversal(and level order)
        //From the vertical list, take the first ones for the top view and the last ones for the bottom view
        public static List<int> TopView(TreeNode root)
        {
            Dictionary<int, List<int>> verticalMap = new Dictionary<int, List<int>>();
            int level = 0;
            var result = new List<int>();
            VerticalOrder(root, level, verticalMap);
            var keyList = verticalMap.Keys.ToList();
            keyList.Sort();
            foreach (var v in keyList)
                result.Add(verticalMap[v].ElementAt(0));
            return result;
        }

        public static List<int> BottomView(TreeNode root)
        {
            Dictionary<int, List<int>> verticalMap = new Dictionary<int, List<int>>();
            int level = 0;
            var result = new List<int>();
            VerticalOrder(root, level, verticalMap);
            var keyList = verticalMap.Keys.ToList();
            keyList.Sort();
            foreach (var v in keyList)
            {
                result.Add(verticalMap[v].LastOrDefault());
            }
            return result;
        }

        private static TreeNode VerticalOrder(TreeNode root, int level, Dictionary<int, List<int>> verticalMap)
        {
            if (root == null) return null;

            if (verticalMap.ContainsKey(level))
            {
                verticalMap[level].Add(root.val);
            }
            else
            {
                verticalMap.Add(level, new List<int> { root.val });
            }
            //recursively go the leftmost while substracting 1 as we move each level
            TreeNode x = VerticalOrder(root.left, --level, verticalMap);
            if (x == null) level++; // ie we are at extreme left
                                    //store the node value to a hastable

            return VerticalOrder(root.right, ++level, verticalMap);
        }
    }
}
