using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shikamaru
{
    public static class TSP
    {
        static Dictionary<string, Dictionary<string, int>> AdjacencyMatrix;
        static TSPTreeNode Root;
        static string StartingCity;

        public static List<string> CitiesList
        {
            get
            {
                return AdjacencyMatrix.Keys.ToList();
            }
        }

        static TSP()
        {
            AdjacencyMatrix = new Dictionary<string, Dictionary<string, int>>();
            AdjacencyMatrix["w"] = new Dictionary<string, int>()
            {
                { "w", 0 },
                { "x", 6 },
                { "y", 1 },
                { "z", 3 }
            };
            AdjacencyMatrix["x"] = new Dictionary<string, int>()
            {
                { "w", 6 },
                { "x", 0 },
                { "y", 4 },
                { "z", 3 }
            };
            AdjacencyMatrix["y"] = new Dictionary<string, int>()
            {
                { "w", 1 },
                { "x", 4 },
                { "y", 0 },
                { "z", 2 }
            };
            AdjacencyMatrix["z"] = new Dictionary<string, int>()
            {
                { "w", 3 },
                { "x", 3 },
                { "y", 2 },
                { "z", 0 }
            };
        }

        public static void NaiveSolution(string startingCity)
        {
            var cities = CitiesList.Clone();
            Root = new TSPTreeNode
            {
                NodeName = startingCity,
                Cost = AdjacencyMatrix[startingCity][startingCity]
            };
            cities.Remove(startingCity);
            StartingCity = startingCity;
            ConstructTree(cities.Clone(), Root);
            var overAllMinCost = GetMinCost(Root);
            Console.WriteLine("Overall min cost is {0}.", overAllMinCost);
        }

        private static long GetMinCost(TSPTreeNode tspTreeNode)
        {
            var minCost = long.MaxValue;
            var calcCost = minCost;
            if (tspTreeNode.Children.IsNullOrEmpty())
            {
                calcCost = AdjacencyMatrix[tspTreeNode.NodeName][StartingCity] + tspTreeNode.Cost;
                if (calcCost < minCost)
                {
                    minCost = calcCost;
                }
            }
            else
            {
                foreach(var childNode in tspTreeNode.Children)
                {
                    calcCost = GetMinCost(childNode) + tspTreeNode.Cost;
                    if (calcCost < minCost)
                    {
                        minCost = calcCost;
                    }
                }
            }
            return minCost;
        }

        private static void ConstructTree(List<string> list, TSPTreeNode currentCity)
        {
            if (!list.Empty())
            {
                if(currentCity.Children == null)
                {
                    currentCity.Children = new List<TSPTreeNode>(list.Count);
                }
                foreach(var city in list)
                {
                    var cityNode = new TSPTreeNode
                    {
                        NodeName = city,
                        Cost = AdjacencyMatrix[currentCity.NodeName][city]
                    };
                    currentCity.Children.Add(cityNode);
                    var listWithoutOneCity = list.Clone();
                    listWithoutOneCity.Remove(city);
                    ConstructTree(listWithoutOneCity, cityNode);
                }
            }
        }
    }

    public class TSPTreeNode
    {
        public string NodeName
        { get; set; }
        public int Cost
        { get; set; }
        public List<TSPTreeNode> Children
        { get; set; }

        public override string ToString()
        {
            return string.Format("To \"{0}\" at cost {1} with {2} children.", NodeName, Cost, Children.Count);
        }
    }

    static class Extensions
    {
        // [BIB]:  https://stackoverflow.com/questions/222598/how-do-i-clone-a-generic-list-in-c
        public static List<T> Clone<T>(this List<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }

        public static bool Empty<T>(this List<T> list)
        {
            return list.Count < 1;
        }

        public static bool IsNullOrEmpty<T>(this List<T> list)
        {
            return ((list == null) || list.Empty());
        }
    }
}
