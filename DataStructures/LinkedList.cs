using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public static class LinkedList
    {
        static LinkedListNode<int> HeadNode = new LinkedListNode<int>(-999,
            new LinkedListNode<int>(0,
                new LinkedListNode<int>(1,
                    new LinkedListNode<int>(2,
                        new LinkedListNode<int>(3,
                            new LinkedListNode<int>(4))))));
        static LinkedListNode<int> five = new LinkedListNode<int>(5),
            four = new LinkedListNode<int>(4, five),
            three = new LinkedListNode<int>(3, four),
            two = new LinkedListNode<int>(2, three),
            one = new LinkedListNode<int>(1, two),
            zero = new LinkedListNode<int>(0, one);
        static LinkedListNode<int> HeadNode2 = new LinkedListNode<int>(-100, zero);

        public static bool IsCircular()
        {
            five.Next = HeadNode2;
            return IsCircularIterative(HeadNode2);
            //return IsCircularIterative(HeadNode);
        }

        static bool IsCircularIterative(LinkedListNode<int> headNode)
        {
            LinkedListNode<int> slow = headNode, fast = headNode;
            while (slow != null && fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
                if (slow == fast)
                {
                    return true;
                }
            }
            return false;
        }
    }

    public class LinkedListNode<T> where T : struct, IComparable, IFormattable, IConvertible
    {
        public T Data
        { get; set; }
        public LinkedListNode<T> Next
        { get; set; }

        public LinkedListNode(T data, LinkedListNode<T> next = null)
        {
            Data = data;
            Next = next;
        }
    }
}
