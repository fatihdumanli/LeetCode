using System;
using System.Collections.Generic;
using Common;

namespace LevelOrderTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            var treeNode = new TreeNode(20);
            treeNode.left = new TreeNode(14);
            treeNode.left.left = new TreeNode(10);
            treeNode.left.left.left = new TreeNode(7);
            treeNode.left.right = new TreeNode(15);
            treeNode.left.right.right = new TreeNode(16);
            treeNode.left.left.right = new TreeNode(11);

            treeNode.right = new TreeNode(22);
            treeNode.right.left = new TreeNode(21);
            treeNode.right.right = new TreeNode(25);

            var result = LevelOrderTraversal(treeNode);
            
        }

        static IList<IList<int>> LevelOrderTraversal(TreeNode root)
        {
            var levelOrderTraversal = new List<IList<int>>();

            if (root == null)
                return levelOrderTraversal;
            
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            
            levelOrderTraversal.Add(new List<int>()
            {
                root.val
            });
            
            var subList = new List<TreeNode>();

            while (queue.Count > 0)
            {
                var popped = queue.Dequeue();
                
                if(popped.left != null)
                    subList.Add(popped.left);
                
                if(popped.right != null)
                    subList.Add(popped.right);
                
                if (queue.Count == 0)
                {
                    var tempList = new List<int>();
                    foreach (var item in subList)
                    {
                        tempList.Add(item.val);
                        queue.Enqueue(item);
                    }
                    if(tempList.Count > 0)
                        levelOrderTraversal.Add(tempList);
                    subList.Clear();
                }
            }
            
            return levelOrderTraversal;
        }
    }
}
