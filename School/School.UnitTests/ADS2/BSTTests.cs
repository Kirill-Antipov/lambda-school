using AlgorithmsDataStructures2;
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
        public void Left_Child_Deleted()
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
    }
}
