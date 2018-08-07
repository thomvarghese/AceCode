using System.Collections.Generic;

namespace TreeProblems
{

    public class BuildTreeFromInAndPostOrder
    {
        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            if (inorder == null || postorder == null)
                return null;
            if (inorder.Length != postorder.Length)
                return null;
            Dictionary<int, int> inOrderIndices = new Dictionary<int, int>();
            for (int i = 0; i < inorder.Length; i++)
                inOrderIndices.Add(inorder[i], i);

            return BuildTree(inorder, 0, inorder.Length - 1,
                                                    postorder, 0, postorder.Length - 1, inOrderIndices);

        }

        private TreeNode BuildTree(int[] inorder, int inStart, int inEnd,
                                                          int[] postorder, int postStart, int postEnd,
                                                          Dictionary<int, int> inOrderIndices)
        {
            if (inStart > inEnd || postStart > postEnd)
                return null;
            //last one in the postOrder is root 
            var treeNode = new TreeNode(postorder[postEnd]);
            var inOrderRootIndex = inOrderIndices[postorder[postEnd]];
            treeNode.left = BuildTree(inorder, inStart, inOrderRootIndex - 1,
                                      postorder, postStart, postStart + inOrderRootIndex - inStart - 1,
                                      inOrderIndices);

            treeNode.right = BuildTree(inorder, inOrderRootIndex + 1, inEnd,
                                       postorder, postStart + inOrderRootIndex - inStart, postEnd - 1,
                                       inOrderIndices);
            return treeNode;
        }
    }
}