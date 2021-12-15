//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace AdventOfCode.Solutions.Year2021
//{

//	class Day15 : ASolution
//	{

//		public Day15() : base(15, 2021, "Chiton")
//		{

//		}

//		protected override string SolvePartOne()
//		{
//			var inputLines = System.IO.File.ReadLines("inputs/Day15.txt").ToList();

//			var gridXSize = inputLines[0].Length;
//			var gridYSize = inputLines.Count;
//			var grid = new int[gridYSize, gridXSize];
//			var i = 0;
//			foreach (var line in inputLines)
//			{
//				var j = 0;
//				foreach (var position in line.Select(ch => ch - '0'))
//				{
//					grid[i, j] = position;
//					j++;
//				}
//				i++;
//			}

//			var min = FindMin(grid, new Tuple<int, int>(0, 0), new Tuple<int, int>(gridXSize - 1, gridYSize - 1));

//			return min.ToString();
//		}

//		protected override string SolvePartTwo()
//		{
//			var inputLines = System.IO.File.ReadLines("inputs/Day15.txt").ToList();

//			var lineLength = inputLines[0].Length;
//			var columnLength = inputLines.Count;
//			for (var k = 0; k < 4; k++)
//			{
//				for (var y = 0; y < columnLength; y++)
//				{
//					for (var x = 0; x < lineLength; x++)
//					{
//						var riskLevel = Convert.ToInt32(inputLines[y][x + k * lineLength] - '0');

//						inputLines[y] += riskLevel == 9 ? 1.ToString() : (riskLevel + 1).ToString();
//					}
//				}
//			}

//			lineLength = inputLines[0].Length;
//			for (var k = 0; k < 4; k++)
//			{
//				for (var y = 0; y < columnLength; y++)
//				{
//					var newLine = "";

//					for (var x = 0; x < lineLength; x++)
//					{
//						var riskLevel = Convert.ToInt32(inputLines[y + k * columnLength][x] - '0');

//						newLine += riskLevel == 9 ? 1.ToString() : (riskLevel + 1).ToString();
//					}

//					inputLines.Add(newLine);
//				}
//			}

//			var gridXSize = inputLines[0].Length;
//			var gridYSize = inputLines.Count;
//			var grid = new int[gridYSize, gridXSize];
//			var i = 0;
//			foreach (var line in inputLines)
//			{
//				var j = 0;
//				foreach (var position in line.Select(ch => ch - '0'))
//				{
//					grid[i, j] = position;
//					j++;
//				}
//				i++;
//			}

//			var min = FindMin(grid, new Tuple<int, int>(0, 0), new Tuple<int, int>(gridXSize - 1, gridYSize - 1));

//			return min.ToString();
//		}

//		private int FindMin(int[,] indexWeights, Tuple<int, int> src, Tuple<int, int> dst)
//		{
//			var allNodes = new List<Node>(indexWeights.GetLength(0) * indexWeights.GetLength(1));
//			var graph = GenerateGraph(indexWeights, allNodes);

//			var queue = new Queue<Node>();
//			var currentNode = graph[src.Item1, src.Item2];

//			currentNode.Distance = 0;

//			queue.Enqueue(currentNode);
//			while (queue.Count > 0)
//			{
//				currentNode = queue.Dequeue();
//				currentNode.Visited = true;

//				if (currentNode.XCoord == dst.Item1 && currentNode.YCoord == dst.Item2)
//					break;

//				foreach (var neighbor in currentNode.Neighbors)
//				{
//					neighbor.Distance = Math.Min(neighbor.Distance,
//												 currentNode.Distance + indexWeights[neighbor.XCoord, neighbor.YCoord]);
//				}

//				var nonVisitedMinNode = allNodes.Where(a => !a.Visited)
//					.Aggregate((currMin, currNode) => currMin.Distance < currNode.Distance ? currMin : currNode);

//				queue.Enqueue(nonVisitedMinNode);
//			}

//			return graph[dst.Item1, dst.Item2].Distance;
//		}

//		private class Node
//		{
//			public Node(int xCoord, int yCoord)
//			{
//				XCoord = xCoord;
//				YCoord = yCoord;

//				Distance = int.MaxValue;
//				Visited = false;
//				Neighbors = new List<Node>();
//			}

//			public int XCoord { get; set; }
//			public int YCoord { get; set; }
//			public int Distance { get; set; }
//			public bool Visited { get; set; }
//			public List<Node> Neighbors { get; set; }
//		}

//		private Node[,] GenerateGraph(int[,] weight, List<Node> allNodes)
//		{
//			var nodes = new Node[weight.GetLength(0), weight.GetLength(1)];
//			for (var i = 0; i < weight.GetLength(0); i++)
//			{
//				for (var j = 0; j < weight.GetLength(1); j++)
//				{
//					nodes[i, j] = new Node(i, j);
//					allNodes.Add(nodes[i, j]);
//				}
//			}

//			for (var i = 0; i < weight.GetLength(0); i++)
//			{
//				for (var j = 0; j < weight.GetLength(1); j++)
//				{
//					if (0 <= i - 1)
//						nodes[i, j].Neighbors.Add(nodes[i - 1, j]);

//					if (weight.GetLength(0) > i + 1)
//						nodes[i, j].Neighbors.Add(nodes[i + 1, j]);

//					if (0 <= j - 1)
//						nodes[i, j].Neighbors.Add(nodes[i, j - 1]);

//					if (weight.GetLength(1) > j + 1)
//						nodes[i, j].Neighbors.Add(nodes[i, j + 1]);
//				}
//			}

//			return nodes;
//		}
//	}
//}
