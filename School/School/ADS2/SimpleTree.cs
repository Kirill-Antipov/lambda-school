using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class SimpleTreeNode<T>
    {
        public T NodeValue;
        public SimpleTreeNode<T> Parent;
        public List<SimpleTreeNode<T>> Children;

        public SimpleTreeNode(T val, SimpleTreeNode<T> parent)
        {
            NodeValue = val;
            Parent = parent;
            Children = null;
        }
    }

    public class SimpleTree<T>
    {
        public SimpleTreeNode<T> Root;

        public SimpleTree(SimpleTreeNode<T> root)
        {
            Root = root;
        }

        public void AddChild(SimpleTreeNode<T> ParentNode, SimpleTreeNode<T> NewChild)
        {
            if (ParentNode == null)
            {
                return;
            }

            if (ParentNode.Children == null)
            {
                ParentNode.Children = new List<SimpleTreeNode<T>>();
            }

            ParentNode.Children.Add(NewChild);
            NewChild.Parent = ParentNode;
        }

        public void DeleteNode(SimpleTreeNode<T> NodeToDelete)
        {
            SimpleTreeNode<T> parentNode = NodeToDelete.Parent;
            parentNode?.Children.Remove(NodeToDelete);
        }

        public List<SimpleTreeNode<T>> GetAllNodes()
        {
            List<SimpleTreeNode<T>> result = new List<SimpleTreeNode<T>>();
            GetAllNodesRecursive(Root, result);
            return result;
        }

        public List<SimpleTreeNode<T>> FindNodesByValue(T val)
        {
            List<SimpleTreeNode<T>> result = new List<SimpleTreeNode<T>>();
            FindNodesByValueRecursive(Root, val, result);
            return result;
        }

        public void MoveNode(SimpleTreeNode<T> OriginalNode, SimpleTreeNode<T> NewParent)
        {
            if (OriginalNode == null || NewParent == null)
            {
                return;
            }

            DeleteNode(OriginalNode);

            AddChild(NewParent, OriginalNode);
        }

        public int Count()
        {
            return GetAllNodes().Count;
        }

        public int LeafCount()
        {
            List<SimpleTreeNode<T>> allNodes = GetAllNodes();
            int leafCount = 0;

            foreach (var node in allNodes)
            {
                if (node.Children == null || node.Children.Count == 0)
                {
                    leafCount++;
                }
            }

            return leafCount;
        }

        public List<T> EvenTrees()
        {
            List<T> nodesToRemove = new List<T>();
            CountChildren(Root, nodesToRemove);
            return nodesToRemove;
        }

        private void GetAllNodesRecursive(SimpleTreeNode<T> node, List<SimpleTreeNode<T>> result)
        {
            if (node == null)
            {
                return;
            }

            result.Add(node);
            if (node.Children != null)
            {
                foreach (var child in node.Children)
                {
                    GetAllNodesRecursive(child, result);
                }
            }
        }

        private void FindNodesByValueRecursive(SimpleTreeNode<T> node, T val, List<SimpleTreeNode<T>> result)
        {
            if (node == null)
            {
                return;
            }

            if (node.NodeValue.Equals(val))
            {
                result.Add(node);
            }

            if (node.Children != null)
            {
                foreach (var child in node.Children)
                {
                    FindNodesByValueRecursive(child, val, result);
                }
            }
        }

        private int CountChildren(SimpleTreeNode<T> node, List<T> nodesToRemove)
        {
            if (node == null)
            {
                return 0;
            }

            int childrenCount = 1;

            if (node.Children != null)
            {
                foreach (var child in node.Children)
                {
                    childrenCount += CountChildren(child, nodesToRemove);
                }
            }

            if (childrenCount % 2 == 0 && node.Parent != null)
            {
                nodesToRemove.Add(node.Parent.NodeValue);
                nodesToRemove.Add(node.NodeValue);
            }

            return childrenCount;
        }
    }
}