using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public static class BinTree
    {
        static BinTreeNode<int> leftSubTree = new BinTreeNode<int>(7,
                new BinTreeNode<int>(5),
                new BinTreeNode<int>(9,
                    new BinTreeNode<int>(8)));

        public static void Test()
        {
            Console.WriteLine("IsValidBST: {0}", IsValidBST());
            Travere(TraversalMethods.BFSLevelOrder);
            Travere(TraversalMethods.DFSInOrder);
            Travere(TraversalMethods.DFSPreOrder);
            Travere(TraversalMethods.DFSPostOrder);
        }

        static BinTreeNode<int> rightSubTree = new BinTreeNode<int>(15,
                new BinTreeNode<int>(11),
                new BinTreeNode<int>(29,
                    new BinTreeNode<int>(25)));
        static BinTreeNode<int> Root = new BinTreeNode<int>(10, leftSubTree, rightSubTree);
        static SortedDictionary<int, StringBuilder> sbLinePerDepth;

        public static void PrintTree()
        {
            sbLinePerDepth = new SortedDictionary<int, StringBuilder>();
            PrintHelperRecursive(Root, 0);
            foreach(var sb in sbLinePerDepth)
            {
#if DEBUG
                var temp = sb.ToString();
#endif
                Console.WriteLine(sb.ToString());
            }
        }

        static void PrintHelperRecursive(BinTreeNode<int> node, int depth)
        {
            if (node == null)
            {
                return;
            }
            PrintHelperRecursive(node.Left, depth + 1);
            PrintHelperRecursive(node.Right, depth + 1);
            if (!sbLinePerDepth.TryGetValue(depth, out var sbTemp))
            {
                sbLinePerDepth[depth] = new StringBuilder(string.Format("{0}:  ", depth));
            }
            sbLinePerDepth[depth].AppendFormat("\t{0}", node.Data);
#if DEBUG
            var temp = sbLinePerDepth[depth].ToString();
#endif
        }

        public static bool IsValidBST()
        {
            return IsValidBSTRecursive(Root, int.MinValue, int.MaxValue);
        }

        // [BIB]:  https://stackoverflow.com/questions/499995/how-do-you-validate-a-binary-search-tree
        static bool IsValidBSTRecursive(BinTreeNode<int> node, int min, int max)
        {
            if (node== null)
            {
                return true;
            }
            if (node.Data > min && IsValidBSTRecursive(node.Left, min, node.Data) && IsValidBSTRecursive(node.Right, node.Data, max))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void Travere(TraversalMethods traversalMethod)
        {
            Console.WriteLine(traversalMethod.ToString());
            switch (traversalMethod)
            {
                case TraversalMethods.BFSLevelOrder:
                    TraverseBFSLevelOrder();
                    break;
                case TraversalMethods.DFSInOrder:
                    TraverseDFSInOrder(Root);
                    break;
                case TraversalMethods.DFSPreOrder:
                    TraverseDFSPreOrder(Root);
                    break;
                case TraversalMethods.DFSPostOrder:
                    TraverseDFSPostOrder(Root);
                    break;
                default:
                    break;
            }
            Console.WriteLine();
        }

        private static void TraverseBFSLevelOrder()
        {
            var nodesToVisit = new Queue<BinTreeNode<int>>();
            nodesToVisit.Enqueue(Root);
            while (nodesToVisit.Count > 0)
            {
                var temp = nodesToVisit.Dequeue();
                if (temp == null)
                {
                    continue;
                }
                nodesToVisit.Enqueue(temp.Left);
                nodesToVisit.Enqueue(temp.Right);
                Console.Write(temp.DataAsPrintableString());
            }
        }

        private static void TraverseDFSInOrder(BinTreeNode<int> node)
        {
            if (node == null)
            {
                return;
            }
            TraverseDFSInOrder(node.Left);
            Console.Write(node.DataAsPrintableString());
            TraverseDFSInOrder(node.Right);
        }

        private static void TraverseDFSPreOrder(BinTreeNode<int> node)
        {
            if (node == null)
            {
                return;
            }
            Console.Write(node.DataAsPrintableString());
            TraverseDFSPreOrder(node.Left);
            TraverseDFSPreOrder(node.Right);
        }

        private static void TraverseDFSPostOrder(BinTreeNode<int> node)
        {
            if (node == null)
            {
                return;
            }
            TraverseDFSPostOrder(node.Left);
            TraverseDFSPostOrder(node.Right);
            Console.Write(node.DataAsPrintableString());
        }
    }

    public class BinTreeNode<T> where T : struct, IComparable, IFormattable, IConvertible
    {
        public T Data
        { get; set; }
        public BinTreeNode<T> Left
        { get; set; }
        public BinTreeNode<T> Right
        { get; set; }

        public BinTreeNode(T data, BinTreeNode<T> left = null, BinTreeNode<T> right = null)
        {
            Data = data;
            Left = left;
            Right = right;
        }

        public override string ToString()
        {
            return Data.ToString();
        }

        public string DataAsPrintableString()
        {
            return string.Format("{0}, ", Data);
        }
    }

    public enum TraversalMethods
    {
        BFSLevelOrder,
        DFSInOrder,
        DFSPreOrder,
        DFSPostOrder
    }
}
