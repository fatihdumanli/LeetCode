using TreeHeightLib;
using Xunit;

namespace TreeHeightTests;

public class TreeHeightTests
{
    [Fact]
    public void TestsShouldReturn3AsTreeHeight()
    {
        var root = new TreeNode(3);
        root.left = new TreeNode(9);
        root.right = new TreeNode(20);
        root.right.left = new TreeNode(15);
        root.right.right = new TreeNode(7);

        var treeHeight = new TreeHeight();
        var actual = treeHeight.MaxDepth(root);

        Assert.Equal(3, actual);
    }

    [Fact]
    public void TestShouldReturn1AsTreeHeight()
    {
        var root = new TreeNode(5);

        var treeHeight = new TreeHeight();
        var actual = treeHeight.MaxDepth(root);

        Assert.Equal(1, actual);
    }

    [Fact]
    public void TestShouldReturn2AsTreeHeight()
    {
        var root = new TreeNode(5);
        root.left = new TreeNode(2);

        var treeHeight = new TreeHeight();
        var actual = treeHeight.MaxDepth(root);

        Assert.Equal(2, actual);
    }

}
