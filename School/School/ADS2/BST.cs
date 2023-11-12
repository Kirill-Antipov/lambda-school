﻿using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class BSTNode<T>
    {
        public int NodeKey;
        public T NodeValue;
        public BSTNode<T> Parent;
        public BSTNode<T> LeftChild;
        public BSTNode<T> RightChild;

        public BSTNode(int key, T val, BSTNode<T> parent)
        {
            NodeKey = key;
            NodeValue = val;
            Parent = parent;
            LeftChild = null;
            RightChild = null;
        }
    }

    public class BSTFind<T>
    {
        public BSTNode<T> Node;

        public bool NodeHasKey;

        public bool ToLeft;

        public BSTFind() { Node = null; }
    }

    public class BST<T>
    {
        BSTNode<T> Root;

        public BST(BSTNode<T> node)
        {
            Root = node;
        }

        public BSTFind<T> FindNodeByKey(int key)
        {
            BSTFind<T> findResult = new BSTFind<T>();
            FindNodeByKey(Root, key, findResult);
            return findResult;
        }

        public bool AddKeyValue(int key, T val)
        {
            BSTFind<T> findResult = FindNodeByKey(key);

            if (findResult.NodeHasKey)
            {
                return false;
            }

            BSTNode<T> newNode = new BSTNode<T>(key, val, findResult.Node);

            if (findResult.Node == null)
            {
                Root = newNode;
                return true;
            }

            if (findResult.ToLeft)
            {
                findResult.Node.LeftChild = newNode;
                return true;
            }

            findResult.Node.RightChild = newNode;

            return true;
        }

        public BSTNode<T> FinMinMax(BSTNode<T> FromNode, bool FindMax)
        {
            if (FromNode == null)
                return null;

            return FindMax ? FindMaxRecursive(FromNode) : FindMinRecursive(FromNode);
        }

        public bool DeleteNodeByKey(int key)
        {
            BSTFind<T> findResult = FindNodeByKey(key);

            if (!findResult.NodeHasKey)
            {
                return false;
            }

            BSTNode<T> currentNode = findResult.Node;

            if (currentNode.LeftChild == null && currentNode.RightChild == null && currentNode.Parent == null)
            {
                Root = null;
                return true;
            }

            if (currentNode.LeftChild == null && currentNode.RightChild == null && currentNode.Parent.LeftChild == currentNode)
            {
                currentNode.Parent.LeftChild = null;
                return true;
            }

            if (currentNode.LeftChild == null && currentNode.RightChild == null && currentNode.Parent.RightChild == currentNode)
            {
                currentNode.Parent.RightChild = null;
                return true;
            }

            if (currentNode.LeftChild != null && currentNode.RightChild != null)
            {
                BSTNode<T> successor = FinMinMax(currentNode.RightChild, false);
                currentNode.NodeKey = successor.NodeKey;
                currentNode.NodeValue = successor.NodeValue;
                DeleteNodeByKey(successor.NodeKey);
            }

            BSTNode<T> child = currentNode.LeftChild ?? currentNode.RightChild;

            if (currentNode.Parent == null)
            {
                Root = child;
                child.Parent = currentNode.Parent;

                return true;
            }
            
            if (currentNode.Parent.LeftChild == currentNode)
            {
                currentNode.Parent.LeftChild = child;
                child.Parent = currentNode.Parent;

                return true;
            }

            currentNode.Parent.RightChild = child;
            child.Parent = currentNode.Parent;

            return true;
        }

        public int Count()
        {
            return CountNodes(Root);
        }

        private void FindNodeByKey(BSTNode<T> currentNode, int key, BSTFind<T> findResult)
        {
            if (currentNode == null)
                return;

            if (key == currentNode.NodeKey)
            {
                findResult.Node = currentNode;
                findResult.NodeHasKey = true;
                return;
            }

            if (key < currentNode.NodeKey && currentNode.LeftChild == null)
            {
                findResult.ToLeft = true;
                findResult.Node = currentNode;
                return;
            }

            if (key < currentNode.NodeKey)
            {
                findResult.ToLeft = true;

                FindNodeByKey(currentNode.LeftChild, key, findResult);
            }

            findResult.ToLeft = false;

            if (currentNode.RightChild == null)
            {
                findResult.Node = currentNode;
                return;
            }

            FindNodeByKey(currentNode.RightChild, key, findResult);
        }

        private BSTNode<T> FindMinRecursive(BSTNode<T> node)
        {
            return node.LeftChild == null ? node : FindMinRecursive(node.LeftChild);
        }

        private BSTNode<T> FindMaxRecursive(BSTNode<T> node)
        {
            return node.RightChild == null ? node : FindMaxRecursive(node.RightChild);
        }

        private int CountNodes(BSTNode<T> node)
        {
            if (node == null)
                return 0;

            return 1 + CountNodes(node.LeftChild) + CountNodes(node.RightChild);
        }
    }
}