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
    }
}
