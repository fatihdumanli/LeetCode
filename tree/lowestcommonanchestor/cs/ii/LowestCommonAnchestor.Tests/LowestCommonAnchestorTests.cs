using System.Collections;
using System.Collections.Generic;
using LowestCommonAnchestorLib;
using Xunit;

namespace LowestCommonAnchestorTests;

public class LowestCommonAnchestorTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        var root = new TreeNode(3);
        root.left = new TreeNode(5);
        root.right = new TreeNode(1);
        root.right.left = new TreeNode(0);
        root.right.right = new TreeNode(8);
        root.left.left = new TreeNode(6);
        root.left.right = new TreeNode(2);
        root.left.left.left = new TreeNode(7);
        root.left.left.right = new TreeNode(4);

        yield return new object[] { root, root.left, root.right, root };
        yield return new object[] { root, root.left.right, root.right.right, root };

        yield return new object[] { root, root.left.right, root.left.left, root.left };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
public class LowestCommonAnchestorTests
{
    [Theory]
    [ClassData(typeof(LowestCommonAnchestorTestData))]   
    public void Test1(TreeNode root, TreeNode p, TreeNode q, TreeNode expected)
    {
        var obj = new LowestCommonAnchestor();

        var actual = obj.LowestCommonAncestor(root, p, q);

        Assert.Equal(expected, actual);
    }
}
