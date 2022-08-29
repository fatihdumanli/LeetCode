using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace PathSumLib.Tests;

public class HasPathSumTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        var root = new TreeNode(5);
        root.left = new TreeNode(4);
        root.left.left = new TreeNode(11);
        root.left.left.left = new TreeNode(7);
        root.left.left.right = new TreeNode(2);

        root.right = new TreeNode(8);
        root.right.left = new TreeNode(13);
        root.right.right = new TreeNode(4);
        root.right.right.right = new TreeNode(1);

        var root2 = new TreeNode(1);
        root2.left = new TreeNode(2);


        var root3 = new TreeNode(1);

        yield return new object[] { root, 22, true };
        yield return new object[] { root, 5, false };
        yield return new object[] { root, 9, false };
        yield return new object[] { root, 13, false };
        yield return new object[] { root, 18, true };
        yield return new object[] { root, 26, true };
        yield return new object[] { root, 12, false };
        yield return new object[] { root, 9, false };
        yield return new object[] { root, 10, false };
        yield return new object[] { root, 27, true };
        yield return new object[] { root2, 1, false };
        yield return new object[] { root2, 2, false };
        yield return new object[] { root2, 3, true };
        yield return new object[] { root2, 4, false };
        yield return new object[] { root3, 1, true };
        yield return new object[] { root3, 0, false };
        yield return new object[] { null, 5, false };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class PathSumTests
{
    private static TreeNode root = new TreeNode(5);

    [Theory]
    [ClassData(typeof(HasPathSumTestData))]
    public void Test1_ShouldReturnTrue(TreeNode root, int targetSum, bool expected)
    {
        var pathSum = new PathSum();
        pathSum.HasPathSum(root, targetSum);

        var actual = pathSum.HasPathSum(root, targetSum);

        Assert.Equal(expected, actual);
    }
}
