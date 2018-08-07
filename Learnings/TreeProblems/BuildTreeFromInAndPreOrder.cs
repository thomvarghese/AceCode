using System.Collections.Generic;

namespace TreeProblems
{
    public class BuildTreeFromInAndPreOrder
    {

        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            if (inorder == null || preorder == null)
                return null;
            if (inorder.Length != preorder.Length)
                return null;
            Dictionary<int, int> inOrderIndices = new Dictionary<int, int>();
            for (int i = 0; i < inorder.Length; i++)
                inOrderIndices.Add(inorder[i], i);

            return BuildTree(inorder, 0, inorder.Length - 1,
                             preorder, 0, preorder.Length - 1, inOrderIndices);

        }

        private TreeNode BuildTree(int[] inorder, int inStart, int inEnd,
                                   int[] preorder, int preStart, int preEnd,
                                   Dictionary<int, int> inOrderIndices)
        {
            if (inStart > inEnd || preStart > preEnd)
                return null;
            //last one in the postOrder is root 
            var treeNode = new TreeNode(preorder[preStart]);
            var inOrderRootIndex = inOrderIndices[preorder[preStart]];
            treeNode.left = BuildTree(inorder, inStart, inOrderRootIndex - 1,
                                      preorder, preStart + 1, preStart + inOrderRootIndex - inStart,
                                      inOrderIndices);

            treeNode.right = BuildTree(inorder, inOrderRootIndex + 1, inEnd,
                                       preorder, preStart + inOrderRootIndex - inStart + 1, preEnd,
                                       inOrderIndices);
            return treeNode;
        }
    }
}
