using AlgorithmsDataStructures2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace School.UnitTests.ADS2
{
    public class BalancedBSTTests
    {
        [Fact]
        public void BalancedBST_Built()
        {
            var inputArray = new int[] {3, 4, 6, 5, 9, 8, 7 };
            var tree = new BalancedBST(); 
            tree.GenerateTree(inputArray);

            Assert.True(tree.Root.Level == 0);
            Assert.True(tree.Root.LeftChild.Level == 1);
            Assert.True(tree.Root.RightChild.Level == 1);

            Assert.True(tree.Root.RightChild.NodeKey >= tree.Root.NodeKey);
            Assert.True(tree.Root.LeftChild.NodeKey < tree.Root.NodeKey);

            Assert.True(tree.Root.LeftChild.LeftChild.Level == 2);
            Assert.True(tree.Root.LeftChild.RightChild.Level == 2);

            Assert.True(tree.Root.RightChild.RightChild.NodeKey >= tree.Root.RightChild.NodeKey);
            Assert.True(tree.Root.RightChild.LeftChild.NodeKey < tree.Root.RightChild.NodeKey);
        }

        [Fact]
        public void Tree_Balanced()
        {
            var inputArray = new int[] { 3, 4, 6, 5, 9, 8, 7 };
            var tree = new BalancedBST();
            tree.GenerateTree(inputArray);

            var result = tree.IsBalanced(tree.Root);

            Assert.True(result);
        }

        [Fact]
        public void Tree_Unbalanced()
        {
            var inputArray = new int[] { 3, 4, 6, 5, 9 };
            var tree = new BalancedBST();
            tree.GenerateTree(inputArray);

            tree.Root.LeftChild.LeftChild = new BSTNode(2, tree.Root.LeftChild);
            tree.Root.LeftChild.LeftChild.LeftChild = new BSTNode(1, tree.Root.LeftChild.LeftChild);
            tree.Root.LeftChild.LeftChild.LeftChild.LeftChild = new BSTNode(0, tree.Root.LeftChild.LeftChild.LeftChild);

            var result = tree.IsBalanced(tree.Root);

            Assert.False(result);
        }
    }
}
