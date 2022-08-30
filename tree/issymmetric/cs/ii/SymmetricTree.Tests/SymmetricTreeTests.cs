using System.Collections;
using System.Collections.Generic;
using SymmetricTreeLib;
using Xunit;

namespace SymmetricTreeTests;

public class SymmetricTreeTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        var root = new TreeNode(5);
        root.left = new TreeNode(2);
        root.left.left = new TreeNode(3);
        root.left.right = new TreeNode(4);
        root.right = new TreeNode(2);
        root.right.left = new TreeNode(4);
        root.right.right = new TreeNode(3);


        var root1 = new TreeNode(1);
        root1.left = new TreeNode(2);
        root1.left.right = new TreeNode(3);
        root1.right = new TreeNode(2);
        root1.right.right = new TreeNode(3);

        var root3 = new TreeNode(5);

        var root4 = new TreeNode(7);
        root4.left = new TreeNode(1);
        root4.right = new TreeNode(1);

        var root5 = new TreeNode(3);
        root5.left = new TreeNode(2);

        var root6 = new TreeNode(7);
        root6.left = new TreeNode(1);
        root6.right = new TreeNode(2);

        var root7 = new TreeNode(2);
        root7.left = new TreeNode(3);
        root7.left.left = new TreeNode(4);
        root7.left.right = new TreeNode(5);
        root7.right = new TreeNode(3);
        root7.right.right = new TreeNode(5);

        yield return new object[] { root, true };
        yield return new object[] { root1, false };
        yield return new object[] { root3, true };
        yield return new object[] { root4, true };
        yield return new object[] { root5, false };
        yield return new object[] { root6, false };
        yield return new object[] { root7, false };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class SymmetricTreeTests
{
    [Theory]
    [ClassData(typeof(SymmetricTreeTestData))]
    public void Test1(TreeNode root, bool expected)
    {
        var obj = new SymmetricTree();

        var actual = obj.IsSymmetric(root);

        Assert.Equal(expected, actual);
    }
}
