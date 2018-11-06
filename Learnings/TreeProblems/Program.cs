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

            Console.WriteLine("****RightSide View ****");
            var rightValues = TreeSideView.RightSideViewDfs(root);
            foreach (var i in rightValues)
                Console.WriteLine(i + " ");
            Console.ReadLine();


            Console.WriteLine("****LeftSide View ****");
            var leftValues = TreeSideView.LeftSideViewDfs(root);
            foreach (var i in leftValues)
                Console.WriteLine(i + ", ");
            Console.ReadLine();

            Console.WriteLine("****Level Order****");
            var levels = LevelOrderTraversal.LevelOrder(root);
            foreach (var level in levels)
            {
                foreach (var i in level)
                    Console.Write(i + " ");
                Console.WriteLine();
            }

            Console.ReadLine();

            Console.WriteLine("****Zig Zag Order****");
            var zzlevels = ZigZagLevelTraversal.ZigzagLevelOrder(root);
            foreach (var level in zzlevels)
            {
                foreach (var i in level)
                    Console.Write(i + " ");
                Console.WriteLine();
            }


            Console.WriteLine("\n****Vertical Order****");
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
            Console.WriteLine("\n****TopView ****");
            var topView = BottomAndTopView.TopView(root);
            foreach (var i in topView)
                Console.Write(i + ", ");

            Console.WriteLine("\n\n****BottomView ****");
            var bottomView = BottomAndTopView.BottomView(root);
            foreach (var i in bottomView)
                Console.Write(i + " ");
            Console.ReadLine();


            Console.WriteLine("\n\n****Closest Leaf to Target ****");
            /*Diagram of binary tree:
                     1
                    / \
                   2   3
                  /
                 4
                /
               5
              /
             6
            Input: 2
            Output: 3
            */

            TreeNode r = new TreeNode(1);
            TreeNode t2 = new TreeNode(2);
            TreeNode t3 = new TreeNode(3);
            r.left = t2; r.right = t3;
            TreeNode t4 = new TreeNode(4);
            TreeNode t5 = new TreeNode(5);
            TreeNode t6 = new TreeNode(6);
            t2.left = t4; t4.left = t5; t5.left = t6;

            var closestleaft = ClosestLeafToTarget.ClosestLeaf(r, 2);
            Console.WriteLine("Closest Leaf is " + closestleaft);
            Console.ReadLine();

        }
    }
}
