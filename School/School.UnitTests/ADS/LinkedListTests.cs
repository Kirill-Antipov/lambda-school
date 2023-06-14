using AlgorithmsDataStructures;
using School.ADS;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using Xunit;

namespace School.UnitTests.ADS
{
    public class LinkedListTests
    {
        [Theory]
        [InlineData(3, 1, true, 0, 2, 2)]//removed | no head/tail updates
        [InlineData(3, 3, false, 0, 2, 3)]//not removed | no head/tail updates        
        [InlineData(2, 0, true, 1, 1, 1)]//removed | head update / no tail updates
        [InlineData(2, 1, true, 0, 0, 1)]//removed | no head update / tail updates
        public void Remove_Deletes_Node_By_Value(int numberOfElements, int valueToRemove, bool removed, int head, int tail, int resultCount)
        {
            LinkedList sut = CreateLinkedList(numberOfElements);

            var result = sut.Remove(valueToRemove);

            Assert.True(result == removed);
            Assert.True(sut.Count() == resultCount);
            Assert.True(sut.head.value == head);
            Assert.True(sut.tail.value == tail);
        }

        [Fact]
        public void Remove_On_Empty_List_Correct()
        {
            var sut = new LinkedList();

            var result = sut.Remove(1);

            Assert.False(result);
        }

        [Fact]
        public void EmptyList_On_Remove_Of_Single_Element()
        {
            var sut = new LinkedList();
            sut.AddInTail(new Node(1));

            var result = sut.Remove(1);

            Assert.True(result);
            Assert.True(sut.Count() == 0);
        }

        [Fact]
        public void RemoveAll_Deletes_All_Nodes_With_Specified_Value()
        {
            var sut = new LinkedList();

            sut.AddInTail(new Node(1));
            sut.AddInTail(new Node(2));
            sut.AddInTail(new Node(3));
            sut.AddInTail(new Node(1));
            sut.AddInTail(new Node(4));
            sut.AddInTail(new Node(1));
            sut.AddInTail(new Node(1));

            sut.RemoveAll(1);

            Assert.True(sut.head.value == 2);
            Assert.True(sut.tail.value == 4);
            Assert.True(sut.Count() == 3);
        }

        [Fact]
        public void EmptyList_On_Removal_Of_All_Elements()
        {
            var sut = new LinkedList();
            sut.AddInTail(new Node(1));
            sut.AddInTail(new Node(1));
            sut.AddInTail(new Node(1));

            sut.RemoveAll(1);

            Assert.True(sut.Count() == 0);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(3)]
        public void Count_Has_CorrectResult(int numberOfElements)
        {
            var sut = CreateLinkedList(numberOfElements);

            var result = sut.Count();

            Assert.True(result == numberOfElements);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(3)]
        public void Clear_Results_With_EmptyList(int numberOfElements)
        {
            var sut = CreateLinkedList(numberOfElements);

            sut.Clear();

            Assert.True(sut.Count() == 0);
            Assert.True(sut.head == null);
            Assert.True(sut.tail == null);
        }

        [Fact]
        public void FindAll_Results_In_EmptyList_When_NothingFound()
        {
            var sut = CreateLinkedList(5);

            var result = sut.FindAll(10);

            Assert.True(result.Count() == 0);
        }

        [Theory]
        [InlineData(4, 3)]
        [InlineData(2, 1)]
        public void FindAll_Gets_All_Nodes_With_Specified_Value(int valueToFind, int resultCount)
        {
            var sut = new LinkedList();
            sut.AddInTail(new Node(1));
            sut.AddInTail(new Node(2));
            sut.AddInTail(new Node(4));
            sut.AddInTail(new Node(3));
            sut.AddInTail(new Node(4));
            sut.AddInTail(new Node(4));

            var result = sut.FindAll(valueToFind);

            Assert.True(result.Count() == resultCount);
            Assert.True(result.All(node => node.value == valueToFind));
        }

        [Fact]
        public void InsertAfter_Works_Correctly_On_EmptyList()
        {
            var sut = new LinkedList();
            sut.InsertAfter(null, new Node(0));

            Assert.True(sut.head == sut.tail);
            Assert.True(sut.head.value == 0);
        }

        [Fact]
        public void InsertAfter_Works_Correctly_On_Head()
        {
            var sut = new LinkedList();
            sut.AddInTail(new Node(0));
            sut.AddInTail(new Node(2));

            sut.InsertAfter(sut.head, new Node(1));

            Assert.True(sut.Count() == 3);
            Assert.True(sut.head.next.value == 1);
        }

        [Fact]
        public void InsertAfter_Works_Correctly_On_Tail()
        {
            var sut = new LinkedList();
            sut.AddInTail(new Node(0));
            sut.AddInTail(new Node(1));

            sut.InsertAfter(sut.tail, new Node(2));

            Assert.True(sut.Count() == 3);
            Assert.True(sut.tail.value == 2);
            Assert.True(sut.head.next.value == 1);
        }

        [Fact]
        public void InsertAfter_Works_Correctly_Among()
        {
            var sut = new LinkedList();
            sut.AddInTail(new Node(0));
            var nodeAfter = new Node(1);
            sut.AddInTail(nodeAfter);
            sut.AddInTail(new Node(3));

            sut.InsertAfter(nodeAfter, new Node(2));

            Assert.True(sut.Count() == 4);
            Assert.True(nodeAfter.next.value == 2);
            Assert.True(nodeAfter.next.next.value == 3);
        }

        [Fact]
        public void Combine_Produces_LinkedList_With_SummedValues_Of_Supplied()
        {
            var linkedList1 = CreateLinkedList(3);
            var linkedList2 = CreateLinkedList(3);

            var result = LinkedListExtensions.CombineBySummingNodePairs(linkedList1, linkedList2);

            Assert.True(result.Count() == 3);
            Assert.True(result.head.value == 0);
            Assert.True(result.head.next.value == 2);
            Assert.True(result.tail.value == 4);

        }

        private static LinkedList CreateLinkedList(int numberOfElements)
        {
            var linkedList = new LinkedList();

            for (int i = 0; i < numberOfElements; i++)
            {
                linkedList.AddInTail(new Node(i));
            }
            
            return linkedList;
        }
    }
}
