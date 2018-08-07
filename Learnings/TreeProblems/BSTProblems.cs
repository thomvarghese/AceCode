namespace TreeProblems
{
    public class BSTProblems
    {
        public TreeNode InsertNode(TreeNode root, TreeNode node)
        {
            if (root == null) return node;
            if (root.val > node.val)
            {
                root.left = InsertNode(root.left, node);
            }
            else
            {
                root.right = InsertNode(root.right, node);
            }
            return root;
        }

        public TreeNode InsertIterative(TreeNode root, TreeNode node)
        {
            if (root == null) return node;
            TreeNode parent = null;
            TreeNode curr = root;
            while (curr != null)
            {
                parent = curr;
                if (curr.val > node.val)
                    curr = curr.left;
                else
                    curr = curr.right;
            }

            if (parent.val > node.val)
                parent.left = node;
            else
                parent.right = node;

            return root;
        }

        //Lookup a value from BST
        public TreeNode Lookup(TreeNode root, int data)
        {
            if (root == null) return null;
            if (root.val == data) return root;
            if (root.val >= data)
                return Lookup(root.left, data);
            else
                return Lookup(root.right, data);

        }

        public TreeNode DeleteNode(TreeNode root, int data)
        {
            //The BST property need to be preserved
            //When a leafNode is deleted, the BST properties are not violated & its safe to delete leafs.
            //if a node with one child/subtree is deleted, just join the child to the parent of the deleted node
            //if a node with 2 children is deleted, then replace the node with the minimum in its right subtree
            //All the values on the right should always be greater than the replaced node.

            if (root == null) return null;
            //recur down the tree
            if (root.val > data)
                root.left = DeleteNode(root.left, data);
            else if (root.val < data)
                root.right = DeleteNode(root.right, data);
            else
            {
                //this is the node to be deleted
                if (root.left == null)
                    return root.right;
                else if (root.right == null)
                    return root.left;
                else
                {
                    //replace the current node value with the minimum value from the right subtree
                    root.val = FindMinimumValue(root.right);
                    //Delete the minimum value from the right subtree.
                    root.right = DeleteNode(root.right, root.val);
                }
            }

            return root;
        }

        public int FindMinimumValue(TreeNode root)
        {
            if (root == null) return 0;
            while (root.left != null)
                root = root.left;
            return root.val;
        }

        public bool IsValidBST(TreeNode root)
        {
            if (root == null) return true;
            return IsBST(root, int.MinValue, int.MaxValue);
        }

        private bool IsBST(TreeNode root, int min, int max)
        {
            if (root.val > max || root.val <= min) return false;
            return IsBST(root.left, min, root.val) &&
                    IsBST(root.right, root.val, max);
        }
    }
}
