using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Node<T>
    {
        public T value;
        public Node<T> next, prev;

        public Node(T _value)
        {
            value = _value;
            next = null;
            prev = null;
        }
    }

    public class OrderedList<T>
    {
        public Node<T> head, tail;
        private bool _ascending;

        public OrderedList(bool asc)
        {
            head = null;
            tail = null;
            _ascending = asc;
        }

        public int Compare(T v1, T v2)
        {
            var a = v1 as IComparable;
            var b = v2 as IComparable;

            return _ascending ? a.CompareTo(b) : b.CompareTo(a);
        }

        public void Add(T value)
        {
            var newNode = new Node<T>(value);

            if (head == null)
            {
                head = tail = newNode;
                return;
            }

            if (Compare(value, head.value) < 0)
            {
                newNode.next = head;
                head = newNode;
                return;
            }

            var node = head;
            while (node.next != null && Compare(value, node.next.value) >= 0)
            {
                node = node.next;
            }

            newNode.next = node.next;
            node.next = newNode;

            if (newNode.next == null)
            {
                tail = newNode;
            }
        }

        public Node<T> Find(T val)
        {
            var node = head;
            while (node != null)
            {
                var result = Compare(val, node.value);

                if (result == 0)
                {
                    return node;
                }

                if (_ascending && result == -1)
                {
                    return null;
                }

                if (!_ascending && result == 1)
                {
                    return null;
                }

                node = node.next;
            }

            return null;
        }

        public void Delete(T val)
        {
            if (head == null)
            {
                return;
            }

            if (Compare(val, head.value) == 0)
            {
                head = head.next;
                return;
            }

            var node = head;
            while (node.next != null && Compare(val, node.next.value) != 0)
            {
                node = node.next;
            }

            if (node.next != null)
            {
                node.next = node.next.next;

                if (node.next == null)
                {
                    tail = node;
                }

                return;
            }
        }

        public void Clear(bool asc)
        {
            _ascending = asc;

            var node = head;
            while (node != null)
            {
                var next = node.next;
                node.next = null;
                node = next;
            }

            head = null;
            tail = null;
        }

        public int Count()
        {
            int count = 0;
            var node = head;

            while (node != null)
            {
                count++;
                node = node.next;
            }

            return count;
        }

        List<Node<T>> GetAll()
        {
            List<Node<T>> r = new List<Node<T>>();
            Node<T> node = head;
            while (node != null)
            {
                r.Add(node);
                node = node.next;
            }
            return r;
        }
    }

}