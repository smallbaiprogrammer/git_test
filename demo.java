class Solution {
    int depth = 100000;
    public int minDepth(TreeNode root) {
        if(root == null){
            return 0;
        }
        dfs(root,0);
        return depth;
    }
    void dfs(TreeNode root,int depth){
        if( root.left == null && root.right == null){
            this.depth = Math.min(depth+1,this.depth);
        }
        if(depth > this.depth){
            return;
        }
        if(root.left!=null){
            dfs(root.left,depth+1);
        }
        if(root.right!=null){
            dfs(root.right,depth+1);
        }

    }
}