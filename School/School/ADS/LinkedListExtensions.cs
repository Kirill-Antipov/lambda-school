using AlgorithmsDataStructures;
using Done.AlgorithmsDataStructures;
using System;

namespace School.ADS
{
    public static class LinkedListExtensions
    {
        public static LinkedList CombineBySummingNodePairs(LinkedList linkedList1, LinkedList linkedList2)
        {
            if (linkedList1 == null)
                throw new ArgumentNullException(nameof(linkedList1)); 
            if (linkedList2 == null)
                throw new ArgumentNullException(nameof(linkedList2));

            if (linkedList1.Count() != linkedList2.Count())
            {
                throw new Exception("Linked lists of equal sizes must be supplied");
            }

            return Sum(linkedList1.head, linkedList2.head, new LinkedList());
        }

        private static LinkedList Sum(Node node1, Node node2, LinkedList result)
        {
            if (node1 == null)
            {
                return result;
            }

            var sumNode = new Node(node1.value + node2.value);
            result.AddInTail(sumNode);

            return Sum(node1.next, node2.next, result);
        }
    }
}
