using System;
using Done.AlgorithmsDataStructures;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class LinkedList
    {
        public Node head;
        public Node tail;

        public LinkedList()
        {
            head = null;
            tail = null;
        }

        public void AddInTail(Node _item)
        {
            if (head == null)
            {
                head = _item;
            }
            else
            {
                tail.next = _item;
            }

            tail = _item;
        }

        public Node Find(int _value)
        {
            Node node = head;

            while (node != null)
            {
                if (node.value == _value)
                {
                    return node;
                }

                node = node.next;
            }

            return null;
        }

        public List<Node> FindAll(int _value)
        {
            List<Node> nodes = new List<Node>();

            Node node = head;

            while (node != null)
            {
                if (node.value == _value)
                {
                    nodes.Add(node);
                }

                node = node.next;
            }

            return nodes;
        }

        public bool Remove(int _value)
        {
            if (head == null)
            {
                return false;
            }

            if (head.value == _value)
            {
                head = head.next;

                if (head == null)
                {
                    tail = null;
                }

                return true;
            }

            Node node = head;
            while (node.next != null)
            {
                if (node.next.value == _value)
                {
                    node.next = node.next.next;

                    if (node.next == null)
                    {
                        tail = node;
                    }

                    return true;
                }

                node = node.next;
            }

            return false;
        }

        public void RemoveAll(int _value)
        {
            while (Remove(_value)) { }
        }

        public void Clear()
        {
            Node node = head;
            while (node != null)
            {
                Node next = node.next;
                node.next = null;
                node = next;
            }

            head = null;
            tail = null;
        }

        public int Count()
        {
            int count = 0;
            Node node = head;

            while (node != null)
            {
                count++;
                node = node.next;
            }

            return count;
        }

        public void InsertAfter(Node _nodeAfter, Node _nodeToInsert)
        {
            if (_nodeAfter == null || _nodeAfter == tail)
            {
                AddInTail(_nodeToInsert);
                return;
            }

            _nodeToInsert.next = _nodeAfter.next;
            _nodeAfter.next = _nodeToInsert;
        }

    }
}