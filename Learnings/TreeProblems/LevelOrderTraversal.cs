using System.Collections.Generic;

namespace TreeProblems
{
    public static class LevelOrderTraversal
    {
        public static IList<IList<int>> LevelOrder(TreeNode root)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            IList<IList<int>> result = new List<IList<int>>();

            if (root == null) return result;
            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                int levelNum = queue.Count;
                List<int> subList = new List<int>();
                for (int i = 0; i < levelNum; ++i)
                {
                    TreeNode node = queue.Dequeue();
                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);
                    subList.Add(node.val);
                }               
                result.Add(subList);
            }
            return result;
        }

        //public static IList<IList<int>> LevelOrderReverse(TreeNode root)
        //{
        //    IList<IList<int>> result = new List<IList<int>>(); // LinkedList - addFirst(), add(), remove() and removeLast()
        //    RecursiveLevelOrderBottom(root, 0, result);
        //    return result;
        //}

        //private static void RecursiveLevelOrderBottom(TreeNode root, int height, IList<IList<int>> result)
        //{
        //    if (root == null)
        //    { // Base case
        //        return;
        //    }

        //    if (height == result.Count)
        //    { // Create a new list for current level
        //        result.Add(new List<int>());
        //    }
        //    else if (height < result.Count)
        //    { // Move the list for current level from tail to head
        //        result.addFirst(result.removeLast());
        //    }

        //    /* Postorder traversal */
        //    recursiveLevelOrderBottom(root.left, height + 1, result); // Recursive steps
        //    recursiveLevelOrderBottom(root.right, height + 1, result);
        //    // Add root value to the list for current level, then move it from head to tail since we are about to backtrack
        //    result.peek().add(root.val);
        //    result.add(result.remove());
        //}

    }
}
