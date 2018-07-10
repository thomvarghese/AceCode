using System;
using System.Collections.Generic;

namespace TreeProblems
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(3);
            TreeNode d11 = new TreeNode(2);
            TreeNode d12 = new TreeNode(4);
            root.left = d11;
            root.right = d12;

            TreeNode d21 = new TreeNode(1);
            TreeNode d22 = new TreeNode(8);
            TreeNode d23 = new TreeNode(10);
            d11.left = d21;
            d12.left = d22;
            d12.right = d23;
            TreeNode d31 = new TreeNode(11);
            d21.right = d31;
            TreeNode d41 = new TreeNode(13);
            d31.left = d41;

            TreeNode d51 = new TreeNode(15);            
            TreeNode d52 = new TreeNode(17);
            d41.left = d51;
            d41.right = d52;
            /*
             *                   3
             *               2       4 
             *             1       8   10
             *               11
             *             13  
             *          15    17
             * */
            //rightside = 3,4,10,11,13,17
            //leftside = 3,2,1,11,13,15
            
            var rightValues = TreeSideView.RightSideViewDfs(root);
            foreach (var i in rightValues)
                Console.WriteLine(i + ", ");
            Console.ReadLine();

            var leftValues = TreeSideView.LeftSideViewDfs(root);
            foreach (var i in leftValues)
                Console.WriteLine(i + ", ");
            Console.ReadLine();

            var levels = LevelOrderTraversal.LevelOrder(root);
            foreach (var level in levels)
            {
                foreach (var i in level)
                    Console.Write(i + " ");
                Console.WriteLine();
            }

            Console.ReadLine();

            var zzlevels = ZigZagLevelTraversal.ZigzagLevelOrder(root);
            foreach (var level in zzlevels)
            {
                foreach (var i in level)
                    Console.Write(i + " ");
                Console.WriteLine();
            }


            Dictionary<int, List<int>> verticalLevels = VerticalOrderTraversal.VerticalOrder(root);
            var keyList = new List<int>();
            foreach (var key in verticalLevels.Keys)
            {
                keyList.Add(key);
            }
            keyList.Sort();
            for(int i=0; i < keyList.Count; i++)
            {
                Console.Write(keyList[i] + " : ");
                foreach (var v in verticalLevels[keyList[i]])
                    Console.Write(v + " ");
                Console.WriteLine();
            }
            
           Console.ReadLine();
        }
    }
}
