using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public static class WeightedGraph
    {
        public static string[] Vertices
        { get; private set; }

        public static AdjacencyNode[] AdjacencyList
        { get; private set; }

        static WeightedGraph()
        {
            Vertices = new string[] { "a", "b", "c", "d", "e" };
#if SET1
            var forA = new AdjacencyNode()
            {
                Index = 1,
                Cost = 7,
                Next = new AdjacencyNode()
                {
                    Index = 2,
                    Cost = 3,
                    Next = null
                }
            };
            var forB = new AdjacencyNode()
            {
                Index = 0,
                Cost = 7,
                Next = new AdjacencyNode()
                {
                    Index = 2,
                    Cost = 1,
                    Next = new AdjacencyNode()
                    {
                        Index = 3,
                        Cost = 2,
                        Next = new AdjacencyNode()
                        {
                            Index = 4,
                            Cost = 6,
                            Next = null
                        }
                    }
                }
            };
            var forC = new AdjacencyNode()
            {
                Index = 0,
                Cost = 3,
                Next = new AdjacencyNode()
                {
                    Index = 1,
                    Cost = 1,
                    Next = new AdjacencyNode()
                    {
                        Index = 3,
                        Cost = 2,
                        Next = null
                    }
                }
            };
            var forD = new AdjacencyNode()
            {
                Index = 1,
                Cost = 2,
                Next = new AdjacencyNode()
                {
                    Index = 2,
                    Cost = 2,
                    Next = new AdjacencyNode()
                    {
                        Index = 4,
                        Cost = 4,
                        Next = null
                    }
                }
            };
            var forE = new AdjacencyNode()
            {
                Index = 1,
                Cost = 6,
                Next = new AdjacencyNode()
                {
                    Index = 3,
                    Cost = 4,
                    Next = null
                }
            };
#else
            var forA = new AdjacencyNode()
            {
                Index = 1,
                Cost = 2,
                Next = new AdjacencyNode()
                {
                    Index = 3,
                    Cost = 1,
                    Next = new AdjacencyNode()
                    {
                        Index = 4,
                        Cost = 15
                    }
                }
            };
            var forB = new AdjacencyNode()
            {
                Index = 0,
                Cost = 2,
                Next = new AdjacencyNode()
                {
                    Index = 2,
                    Cost = 3,
                    Next = null
                }
            };
            var forC = new AdjacencyNode()
            {
                Index = 1,
                Cost = 3,
                Next = new AdjacencyNode()
                {
                    Index = 3,
                    Cost = 2,
                    Next = new AdjacencyNode()
                    {
                        Index = 4,
                        Cost = 4,
                        Next = null
                    }
                }
            };
            var forD = new AdjacencyNode()
            {
                Index = 0,
                Cost = 1,
                Next = new AdjacencyNode()
                {
                    Index = 2,
                    Cost = 2,
                    Next = new AdjacencyNode()
                    {
                        Index = 4,
                        Cost = 10,
                        Next = null
                    }
                }
            };
            var forE = new AdjacencyNode()
            {
                Index = 0,
                Cost = 15,
                Next = new AdjacencyNode()
                {
                    Index = 2,
                    Cost = 4,
                    Next = new AdjacencyNode()
                    {
                        Index = 3,
                        Cost = 20,
                        Next = null
                    }
                }
            };
#endif
            AdjacencyList = new AdjacencyNode[] { forA, forB, forC, forD, forE };
        }

        public static void ShortestPath(string startingPoint, string endingPoint)
        {
            // Pre-Init
            int[] calculatedCosts = new int[Vertices.Length],
                previousIndices = new int[Vertices.Length];
            bool[] isNodeVisited = new bool[Vertices.Length];
            var unvisitedVertexIndices = new List<int>(Vertices.Length - 1);

            // Init
            var start = Array.IndexOf(Vertices, startingPoint);
            var end = Array.IndexOf(Vertices, endingPoint);
            for (var i = 0; i < calculatedCosts.Length; i++)
            {
                calculatedCosts[i] = int.MaxValue;
            }
            calculatedCosts[start] = 0;
            previousIndices[start] = start;
            unvisitedVertexIndices.Add(start);

            // Solve
            while (unvisitedVertexIndices.Count > 0)
            {
                var current = unvisitedVertexIndices.GetMinCostVertex(calculatedCosts);
                unvisitedVertexIndices.Remove(current);
                AdjacencyNode node = AdjacencyList[current];
                while (node != null)
                {
                    if (!isNodeVisited[node.Index])
                    {
                        unvisitedVertexIndices.Add(node.Index);
                    }
                    var temp = calculatedCosts[current] + node.Cost;
                    if (temp < calculatedCosts[node.Index])
                    {
                        calculatedCosts[node.Index] = temp;
                        previousIndices[node.Index] = current;
                    }
                    node = node.Next;
                }
                isNodeVisited[current] = true;
            }
            return;
        }

        public static int GetMinCostVertex(this List<int> list, int[] calculatedCosts)
        {
            var minIndex = list.First();
            var minCost = int.MaxValue;
            foreach(var index in list)
            {
                int temp = calculatedCosts[index];
                if(temp < minCost)
                {
                    minCost = temp;
                    minIndex = index;
                }
            }
            return minIndex;
        }
    }

    public class AdjacencyNode
    {
        public int Index
        { get; set; }
        public int Cost
        { get; set; }
        public AdjacencyNode Next
        { get; set; }
    }
}
