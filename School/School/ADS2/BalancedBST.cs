using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class BSTNode
    {
        public int NodeKey;
        public BSTNode Parent;
        public BSTNode LeftChild;
        public BSTNode RightChild;
        public int Level;

        public BSTNode(int key, BSTNode parent)
        {
            NodeKey = key;
            Parent = parent;
            LeftChild = null;
            RightChild = null;
        }
    }

    public class BalancedBST
    {
        public BSTNode Root;

        public BalancedBST()
        {
            Root = null;
        }

        public void GenerateTree(int[] a)
        {
            Array.Sort(a);
            Root = BuildBalancedBST(a, 0, a.Length - 1, null, 0);
        }

        public bool IsBalanced(BSTNode root_node)
        {
            if (root_node == null)
            {
                return true;
            }

            int leftHeight = CalculateHeight(root_node.LeftChild);
            int rightHeight = CalculateHeight(root_node.RightChild);

            if (Math.Abs(leftHeight - rightHeight) <= 1 && IsBalanced(root_node.LeftChild) && IsBalanced(root_node.RightChild))
            {
                return true;
            }

            return false;
        }

        private BSTNode BuildBalancedBST(int[] sortedArray, int start, int end, BSTNode parent, int level)
        {
            if (start > end)
            {
                return null;
            }

            int mid = (start + end) / 2;
            BSTNode newNode = new BSTNode(sortedArray[mid], parent)
            {
                Level = level
            };

            newNode.LeftChild = BuildBalancedBST(sortedArray, start, mid - 1, newNode, level + 1);
            newNode.RightChild = BuildBalancedBST(sortedArray, mid + 1, end, newNode, level + 1);

            return newNode;
        }

        private int CalculateHeight(BSTNode node)
        {
            if (node == null)
            {
                return 0;
            }

            int leftHeight = CalculateHeight(node.LeftChild);
            int rightHeight = CalculateHeight(node.RightChild);

            return Math.Max(leftHeight, rightHeight) + 1;
        }
    }
}