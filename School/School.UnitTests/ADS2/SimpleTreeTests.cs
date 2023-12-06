using AlgorithmsDataStructures2;
using System.Linq;
using Xunit;
using School.ADS2;

namespace School.UnitTests.ADS2
{
    public class SimpleTreeTests
    {
        [Fact]
        public void ChildNode_Added() 
        {
            var root = new SimpleTreeNode<int>(1, null);
            var tree = new SimpleTree<int>(root);

            tree.AddChild(tree.Root, new SimpleTreeNode<int>(2, null));
            tree.AddChild(tree.Root, new SimpleTreeNode<int>(2, null));

            Assert.NotNull(tree.Root.Children);
            Assert.True(tree.Root.Children.Count() == 2);
        }

        [Fact]
        public void Node_Deleted()
        {
            var root = new SimpleTreeNode<int>(1, null);
            var tree = new SimpleTree<int>(root);
            var nodeToDelete = new SimpleTreeNode<int>(3, null);

            tree.AddChild(tree.Root, new SimpleTreeNode<int>(2, null));
            tree.AddChild(tree.Root, nodeToDelete);
            tree.AddChild(nodeToDelete, new SimpleTreeNode<int>(4, null));

            tree.DeleteNode(nodeToDelete);

            Assert.True(tree.Root.Children.Count() == 1);
            Assert.True(tree.Root.Children.First().NodeValue == 2);
        }

        [Fact]
        public void GetAllNodes_Returns_Correct_Result()
        {
            var root = new SimpleTreeNode<int>(1, null);
            var tree = new SimpleTree<int>(root);

            tree.AddChild(tree.Root, new SimpleTreeNode<int>(2, null));
            tree.AddChild(tree.Root, new SimpleTreeNode<int>(2, null));

            tree.AddChild(tree.Root.Children.First(), new SimpleTreeNode<int>(3, null));
            tree.AddChild(tree.Root.Children.Last(), new SimpleTreeNode<int>(3, null));

            tree.AddChild(tree.Root.Children.First().Children.First(), new SimpleTreeNode<int>(4, null));
            tree.AddChild(tree.Root.Children.First().Children.First().Children.First(), new SimpleTreeNode<int>(5, null));

            var result = tree.GetAllNodes();

            Assert.True(result.Count() == 7);
        }

        [Fact]
        public void Nodes_Found_By_Value()
        {
            var root = new SimpleTreeNode<int>(1, null);
            var tree = new SimpleTree<int>(root);

            tree.AddChild(tree.Root, new SimpleTreeNode<int>(2, null));
            tree.AddChild(tree.Root, new SimpleTreeNode<int>(3, null));

            tree.AddChild(tree.Root.Children.First(), new SimpleTreeNode<int>(3, null));
            tree.AddChild(tree.Root.Children.Last(), new SimpleTreeNode<int>(4, null));

            tree.AddChild(tree.Root.Children.First().Children.First(), new SimpleTreeNode<int>(4, null));
            tree.AddChild(tree.Root.Children.First().Children.First().Children.First(), new SimpleTreeNode<int>(3, null));

            var result = tree.FindNodesByValue(3);

            Assert.True(result.Count() == 3);

            foreach (var node in result)
            {
                Assert.True(node.NodeValue == 3);
            }
        }

        [Fact]
        public void Node_Correctly_Moved()
        {
            var root = new SimpleTreeNode<int>(1, null);
            var tree = new SimpleTree<int>(root);

            tree.AddChild(tree.Root, new SimpleTreeNode<int>(2, null));
            tree.AddChild(tree.Root, new SimpleTreeNode<int>(3, null));

            var oldParent = new SimpleTreeNode<int>(3, null);
            tree.AddChild(tree.Root.Children.First(), oldParent);
            tree.AddChild(tree.Root.Children.Last(), new SimpleTreeNode<int>(4, null));

            var nodeToMove = new SimpleTreeNode<int>(4, null);
            tree.AddChild(tree.Root.Children.First().Children.First(), nodeToMove);
            tree.AddChild(tree.Root.Children.First().Children.First().Children.First(), new SimpleTreeNode<int>(3, null));

            tree.MoveNode(nodeToMove, tree.Root);

            Assert.True(tree.Root.Children.Count() == 3);
            Assert.True(oldParent.Children.Count() == 0);
            Assert.True(tree.Root.Children.Last().Children.Count() == 1);
        }

        [Fact]
        public void Count_Returns_Number_Of_Nodes()
        {
            var root = new SimpleTreeNode<int>(1, null);
            var tree = new SimpleTree<int>(root);

            tree.AddChild(tree.Root, new SimpleTreeNode<int>(2, null));
            tree.AddChild(tree.Root, new SimpleTreeNode<int>(2, null));

            tree.AddChild(tree.Root.Children.First(), new SimpleTreeNode<int>(3, null));
            tree.AddChild(tree.Root.Children.Last(), new SimpleTreeNode<int>(3, null));

            tree.AddChild(tree.Root.Children.First().Children.First(), new SimpleTreeNode<int>(4, null));
            tree.AddChild(tree.Root.Children.First().Children.First().Children.First(), new SimpleTreeNode<int>(5, null));

            var result = tree.Count();

            Assert.True(result == 7);
        }

        [Fact]
        public void LeafCount_Returns_Number_Of_Leaves()
        {
            var root = new SimpleTreeNode<int>(1, null);
            var tree = new SimpleTree<int>(root);

            tree.AddChild(tree.Root, new SimpleTreeNode<int>(2, null));
            tree.AddChild(tree.Root, new SimpleTreeNode<int>(2, null));

            tree.AddChild(tree.Root.Children.First(), new SimpleTreeNode<int>(3, null));
            tree.AddChild(tree.Root.Children.Last(), new SimpleTreeNode<int>(3, null));

            tree.AddChild(tree.Root.Children.First().Children.First(), new SimpleTreeNode<int>(4, null));
            tree.AddChild(tree.Root.Children.First().Children.First().Children.First(), new SimpleTreeNode<int>(5, null));

            var result  = tree.LeafCount();

            Assert.True(result == 2);
        }

        [Fact]
        public void Node_Values_Set_NodeLevel()
        {
            var root = new SimpleTreeNode<int>(1, null);
            var tree = new SimpleTree<int>(root);

            tree.AddChild(tree.Root, new SimpleTreeNode<int>(0, null));
            tree.AddChild(tree.Root, new SimpleTreeNode<int>(0, null));

            tree.AddChild(tree.Root.Children.First(), new SimpleTreeNode<int>(0, null));
            tree.AddChild(tree.Root.Children.Last(), new SimpleTreeNode<int>(0, null));

            tree.AddChild(tree.Root.Children.First().Children.First(), new SimpleTreeNode<int>(0, null));
            tree.AddChild(tree.Root.Children.First().Children.First().Children.First(), new SimpleTreeNode<int>(0, null));

            tree.SetNodesLevel();

            Assert.True(tree.Root.NodeValue == 0);
            Assert.True(tree.Root.Children.First().NodeValue == 1);
            Assert.True(tree.Root.Children.Last().NodeValue == 1);
            Assert.True(tree.Root.Children.First().Children.First().NodeValue == 2);
        }

        [Fact]
        public void Node_Level_Found()
        {
            var root = new SimpleTreeNode<int>(1, null);
            var tree = new SimpleTree<int>(root);

            tree.AddChild(tree.Root, new SimpleTreeNode<int>(0, null));
            tree.AddChild(tree.Root, new SimpleTreeNode<int>(0, null));

            tree.AddChild(tree.Root.Children.First(), new SimpleTreeNode<int>(0, null));
            tree.AddChild(tree.Root.Children.Last(), new SimpleTreeNode<int>(0, null));

            tree.AddChild(tree.Root.Children.First().Children.First(), new SimpleTreeNode<int>(0, null));
            var leaf = new SimpleTreeNode<int>(0, null);
            tree.AddChild(tree.Root.Children.First().Children.First().Children.First(), leaf);

            var result = tree.GetNodeLevel(tree.Root);

            Assert.True(result == 0);

            result = tree.GetNodeLevel(leaf);

            Assert.True(result == 4);
        }

        [Fact]

        public void EvenForest_Found()
        {
            var root = new SimpleTreeNode<int>(1, null);
            var tree = new SimpleTree<int>(root);

            var node2 = new SimpleTreeNode<int>(2, null);
            var node3 = new SimpleTreeNode<int>(3, null);
            var node6 = new SimpleTreeNode<int>(6, null);
            var node8 = new SimpleTreeNode<int>(8, null);

            tree.AddChild(tree.Root, node2);
            tree.AddChild(tree.Root, node3);
            tree.AddChild(tree.Root, node6);

            tree.AddChild(node6, node8);

            tree.AddChild(node8, new SimpleTreeNode<int>(9, null));
            tree.AddChild(node8, new SimpleTreeNode<int>(10, null));

            tree.AddChild(node3, new SimpleTreeNode<int>(4, null));

            tree.AddChild(node2, new SimpleTreeNode<int>(5, null));
            tree.AddChild(node2, new SimpleTreeNode<int>(7, null));

            var result = tree.EvenTrees();

            Assert.Equal(4, result.Count());
            Assert.Equal(1, result.ElementAt(0));
            Assert.Equal(3, result.ElementAt(1));
            Assert.Equal(1, result.ElementAt(2));
            Assert.Equal(6, result.ElementAt(3));
        }
    }
}
