using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Node
    {
        public int value;
        public Node next, prev;

        public Node(int _value)
        {
            value = _value;
            next = null;
            prev = null;
        }
    }

    public class LinkedList2
    {
        public Node head;
        public Node tail;

        public LinkedList2()
        {
            head = null;
            tail = null;
        }

        public void AddInTail(Node _item)
        {
            if (head == null)
            {
                head = _item;
                head.next = null;
                head.prev = null;
            }
            else
            {
                tail.next = _item;
                _item.prev = tail;
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
            Node node = head;

            while (node != null)
            {
                if (node.value == _value)
                {
                    if (node.prev != null)
                    {
                        node.prev.next = node.next;
                    }
                    else
                    {
                        head = node.next;
                    }

                    if (node.next != null)
                    {
                        node.next.prev = node.prev;
                    }
                    else
                    {
                        tail = node.prev;
                    }

                    node.prev = null;
                    node.next = null;

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
                node.prev = null;
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
            if (_nodeAfter == tail)
            {
                AddInTail(_nodeToInsert);
                return;
            }

            if (_nodeAfter == null)
            {
                _nodeToInsert.next = head;
                head.prev = _nodeToInsert;

                head = _nodeToInsert;
                return;
            }

            _nodeToInsert.next = _nodeAfter.next;
            _nodeToInsert.prev = _nodeAfter;
            if (_nodeAfter.next != null)
            {
                _nodeAfter.next.prev = _nodeToInsert;
            }


            _nodeAfter.next = _nodeToInsert;

        }

    }
}
