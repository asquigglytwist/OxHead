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

        public static void Test()
        {
            Console.WriteLine("IsCircular:  ", IsCircular());
            Console.WriteLine("Before Reversing:");
            Print();
            Reverse();
            Console.WriteLine("After Reversing:");
            Print();
        }

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

        public static void Print()
        {
            Console.WriteLine("Iterative:");
            PrintHelperIterative(HeadNode);
            Console.WriteLine();
            Console.WriteLine("Recursive:");
            PrintHelperRecursive(HeadNode2);
            Console.WriteLine();
        }

        static void PrintHelperIterative(LinkedListNode<int> headNode)
        {
            var node = headNode;
            while (node != null)
            {
                Console.Write("{0} -> ", node.Data);
                node = node.Next;
            }
        }

        static void PrintHelperRecursive(LinkedListNode<int> node)
        {
            if (node != null)
            {
                Console.Write("{0} -> ", node.Data);
                if (node.Next != HeadNode && node.Next != HeadNode2)
                {
                    PrintHelperRecursive(node.Next);
                }
            }
        }

        static void Reverse()
        {
            ReverseHelperIterative(HeadNode);
            five.Next = null;
            HeadNode2 = ReverseHelperRecursive(HeadNode2);
        }

        static void ReverseHelperIterative(LinkedListNode<int> headNode)
        {
            LinkedListNode<int> currNode = headNode, prevNode = null, nextNode = null;
            while (currNode != null)
            {
                nextNode = currNode.Next;
                currNode.Next = prevNode;
                prevNode = currNode;
                currNode = nextNode;
            }
            HeadNode = prevNode;
        }

        // [BIB]:  https://stackoverflow.com/questions/14080758/reversing-a-linkedlist-recursively-in-c
        static LinkedListNode<int> ReverseHelperRecursive(LinkedListNode<int> node)
        {
            if (node == null)
            {
                return null;
            }
            if (node.Next == null || node.Next == HeadNode || node.Next == HeadNode2)
            {
                return node;
            }
            var rest = ReverseHelperRecursive(node.Next);
            node.Next.Next = node;
            node.Next = null;
            return rest;
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

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
