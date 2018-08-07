namespace TreeProblems
{
    public class MirrorAndHeightOfBinaryTree
    {
        public void Mirror(TreeNode root)
        {
            if (root == null) return;
            //go all the way to the left most and then swap it with right;
            Mirror(root.left);
            Mirror(root.right);
            //swap left and right
            TreeNode temp = root.left;
            root.left = root.right;
            root.right = temp;
        }

        public bool IsMirror(TreeNode r1, TreeNode r2)
        {
            if (r1 == null && r2 == null) return true;
            if (r1 == null || r2 == null) return false;

            if (r1.val == r2.val)
            {
                if (IsMirror(r1.left, r2.right) &&
                    IsMirror(r1.right, r2.left))
                    return true;
            }
            return false;
        }

        public int Height(TreeNode root)
        {
            if (root == null) return 0;
            int leftHeight = Height(root.left);
            int rightHeight = Height(root.right);
            return (leftHeight > rightHeight) ? 1 + leftHeight : 1 + rightHeight;
        }
    }
}
