using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            //DataStructures.WeightedGraph.ShortestPath("a", "e");
            //Shikamaru.TSP.NaiveSolution("w");
            DataStructures.BinTree.Test();
            //Console.WriteLine(DataStructures.LinkedList.IsCircular());
            //DataStructures.LinkedList.Test();
            GetChEx();
        }

        static void GetChEx()
        {
            Console.WriteLine("{0}Press any key to continue...", Environment.NewLine);
            Console.ReadKey(true);
        }
    }
}
