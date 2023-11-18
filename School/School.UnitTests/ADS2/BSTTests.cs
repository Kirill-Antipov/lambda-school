using AlgorithmsDataStructures2;
using System.Collections.Generic;
using Xunit;

namespace School.UnitTests.ADS2
{
    public class BSTTests
    {
        [Fact]
        public void Tree_Created()
        {
            var root = new BSTNode<int>(0, 0, null);
            var tree = new BST<int>(root);

            var result = tree.FindNodeByKey(0);

            Assert.True(result.NodeHasKey);
        }

        [Fact]
        public void Not_Existing_Node_Not_Found_Right()
        {
            var root = new BSTNode<int>(0, 0, null);
            var tree = new BST<int>(root);

            tree.AddKeyValue(1, 1);

            var result = tree.FindNodeByKey(2);

            Assert.False(result.NodeHasKey);
            Assert.False(result.ToLeft);
        }

        [Fact]
        public void Not_Existing_Node_Not_Found_Left()
        {
            var root = new BSTNode<int>(2, 0, null);
            var tree = new BST<int>(root);

            tree.AddKeyValue(1, 1);

            var result = tree.FindNodeByKey(0);

            Assert.False(result.NodeHasKey);
            Assert.True(result.ToLeft);
        }

        [Fact]
        public void Right_And_Left_Nodes_Added_To_Tree()
        {
            var root = new BSTNode<int>(2, 0, null);
            var tree = new BST<int>(root);

            var result = tree.AddKeyValue(1, 1);

            Assert.True(result);
            Assert.NotNull(root.LeftChild);

            result = tree.AddKeyValue(3, 1);

            Assert.True(result);
            Assert.NotNull(root.RightChild);
        }

        [Fact]
        public void Duplicate_Node_Not_Added()
        {
            var root = new BSTNode<int>(2, 0, null);
            var tree = new BST<int>(root);

            var result = tree.AddKeyValue(2, 1);

            Assert.False(result);
        }

        [Fact]
        public void Count_Returns_Number_Of_Nodes()
        {
            var root = new BSTNode<int>(2, 0, null);
            var tree = new BST<int>(root);

            tree.AddKeyValue(1, 1);
            tree.AddKeyValue(3, 1);
            tree.AddKeyValue(5, 1);
            tree.AddKeyValue(7, 1);

            Assert.Equal(5, tree.Count());
        }

        [Fact]
        public void Min_Key_Found()
        {
            var root = new BSTNode<int>(2, 0, null);
            var tree = new BST<int>(root);

            tree.AddKeyValue(1, 1);
            tree.AddKeyValue(3, 1);
            tree.AddKeyValue(5, 1);
            tree.AddKeyValue(7, 1);

            var result = tree.FinMinMax(root, false);

            Assert.Equal(1, result.NodeKey);
        }

        [Fact]
        public void Min_Key_Found_In_Subtree()
        {
            var root = new BSTNode<int>(2, 0, null);
            var tree = new BST<int>(root);

            tree.AddKeyValue(1, 1);
            tree.AddKeyValue(3, 1);
            tree.AddKeyValue(5, 1);
            tree.AddKeyValue(7, 1);

            var result = tree.FinMinMax(root.RightChild, false);

            Assert.Equal(3, result.NodeKey);
        }

        [Fact]
        public void Max_Key_Found()
        {
            var root = new BSTNode<int>(2, 0, null);
            var tree = new BST<int>(root);

            tree.AddKeyValue(1, 1);
            tree.AddKeyValue(3, 1);
            tree.AddKeyValue(5, 1);
            tree.AddKeyValue(7, 1);

            var result = tree.FinMinMax(root, true);

            Assert.Equal(7, result.NodeKey);
        }

        [Fact]
        public void Max_Key_Found_In_Subtree()
        {
            var root = new BSTNode<int>(2, 0, null);
            var tree = new BST<int>(root);

            tree.AddKeyValue(1, 1);
            tree.AddKeyValue(-1, 1);
            tree.AddKeyValue(3, 1);
            tree.AddKeyValue(5, 1);
            tree.AddKeyValue(7, 1);

            var result = tree.FinMinMax(root.LeftChild, true);

            Assert.Equal(1, result.NodeKey);
        }

        [Fact]
        public void Cant_Delete_Node_When_Not_Exists()
        {
            var root = new BSTNode<int>(2, 0, null);
            var tree = new BST<int>(root);

            tree.AddKeyValue(1, 1);
            tree.AddKeyValue(3, 1);
            tree.AddKeyValue(5, 1);
            tree.AddKeyValue(7, 1);

            var result = tree.DeleteNodeByKey(666);

            Assert.False(result);
        }

        [Fact]
        public void Left_Leaf_Deleted()
        {
            var root = new BSTNode<int>(2, 0, null);
            var tree = new BST<int>(root);

            tree.AddKeyValue(1, 1);
            tree.AddKeyValue(3, 1);
            tree.AddKeyValue(5, 1);
            tree.AddKeyValue(7, 1);

            var result = tree.DeleteNodeByKey(1);

            Assert.True(result);
            Assert.Null(root.LeftChild);
        }

        [Fact]
        public void Right_Leaf_Deleted()
        {
            var root = new BSTNode<int>(2, 0, null);
            var tree = new BST<int>(root);

            tree.AddKeyValue(1, 1);
            tree.AddKeyValue(3, 1);
            tree.AddKeyValue(5, 1);
            tree.AddKeyValue(7, 1);

            var result = tree.DeleteNodeByKey(7);

            Assert.True(result);
            Assert.Null(root.RightChild.RightChild.RightChild);
        }

        [Fact]
        public void Node_With_Children_Deleted()
        {
            var root = new BSTNode<int>(20, 0, null);
            var tree = new BST<int>(root);

            tree.AddKeyValue(10, 1);
            tree.AddKeyValue(9, 1);
            tree.AddKeyValue(8, 1);
            tree.AddKeyValue(16, 1);
            tree.AddKeyValue(15, 1);
            tree.AddKeyValue(17, 1);
            tree.AddKeyValue(30, 1);
            tree.AddKeyValue(18, 1);
            tree.AddKeyValue(50, 1);
            tree.AddKeyValue(70, 1);

            var result = tree.DeleteNodeByKey(10);

            Assert.True(result);
            Assert.True(root.LeftChild.NodeKey == 15);
        }

        [Fact]
        public void Can_Go_Wide_Through_Tree()
        {
            var root = new BSTNode<int>(6, 0, null);
            var tree = new BST<int>(root);

            tree.AddKeyValue(4, 1);
            tree.AddKeyValue(3, 1);
            tree.AddKeyValue(5, 1);
            tree.AddKeyValue(8, 1);
            tree.AddKeyValue(7, 1);
            tree.AddKeyValue(9, 1);

            var expectedResult = new int[] { 6, 4 , 8, 3, 5, 7, 9 };

            var result = tree.WideAllNodes().ToArray();

            for (int i = 0; i < expectedResult.Length; i++)
            {
                Assert.Equal(expectedResult[i], result[i].NodeKey);
            }
        }

        [Fact]
        public void Can_Go_Deep_Through_Tree_InOrder()
        {
            var root = new BSTNode<int>(6, 0, null);
            var tree = new BST<int>(root);

            tree.AddKeyValue(4, 1);
            tree.AddKeyValue(3, 1);
            tree.AddKeyValue(5, 1);
            tree.AddKeyValue(8, 1);
            tree.AddKeyValue(7, 1);
            tree.AddKeyValue(9, 1);

            var expectedResult = new int[] { 3, 4, 5, 6, 7, 8, 9 };

            var result = tree.DeepAllNodes(0).ToArray();

            for (int i = 0; i < expectedResult.Length; i++)
            {
                Assert.Equal(expectedResult[i], result[i].NodeKey);
            }
        }

        [Fact]
        public void Can_Go_Deep_Through_Tree_PostOrder()
        {
            var root = new BSTNode<int>(6, 0, null);
            var tree = new BST<int>(root);

            tree.AddKeyValue(4, 1);
            tree.AddKeyValue(3, 1);
            tree.AddKeyValue(5, 1);
            tree.AddKeyValue(8, 1);
            tree.AddKeyValue(7, 1);
            tree.AddKeyValue(9, 1);

            var expectedResult = new int[] { 3, 5, 4, 7, 9, 8, 6 };

            var result = tree.DeepAllNodes(1).ToArray();

            for (int i = 0; i < expectedResult.Length; i++)
            {
                Assert.Equal(expectedResult[i], result[i].NodeKey);
            }
        }

        [Fact]
        public void Can_Go_Deep_Through_Tree_PreOrder()
        {
            var root = new BSTNode<int>(6, 0, null);
            var tree = new BST<int>(root);

            tree.AddKeyValue(4, 1);
            tree.AddKeyValue(3, 1);
            tree.AddKeyValue(5, 1);
            tree.AddKeyValue(8, 1);
            tree.AddKeyValue(7, 1);
            tree.AddKeyValue(9, 1);

            var expectedResult = new int[] { 6, 4, 3, 5, 8, 7, 9 };

            var result = tree.DeepAllNodes(2).ToArray();

            for (int i = 0; i < expectedResult.Length; i++)
            {
                Assert.Equal(expectedResult[i], result[i].NodeKey);
            }
        }

        [Fact]
        public void Tree_Inverted()
        {
            var root = new BSTNode<int>(6, 0, null);
            var tree = new BST<int>(root);

            tree.AddKeyValue(4, 1);
            tree.AddKeyValue(3, 1);
            tree.AddKeyValue(5, 1);
            tree.AddKeyValue(8, 1);
            tree.AddKeyValue(7, 1);
            tree.AddKeyValue(9, 1);

            tree.Invert();

            var expectedResult = new int[] { 6, 8, 4, 9, 7, 5, 3 };

            var result = tree.WideAllNodes().ToArray();

            for (int i = 0; i < expectedResult.Length; i++)
            {
                Assert.Equal(expectedResult[i], result[i].NodeKey);
            }
        }
    }
}
