//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace AdventOfCode.Solutions.Year2021
//{

//	class Day11 : ASolution
//	{

//		public Day11() : base(11, 2021, "Dumbo Octopus")
//		{

//		}

//		protected override string SolvePartOne()
//		{
//			var inputLines = System.IO.File.ReadLines("inputs/Day11.txt").ToList();

//			var grid = inputLines.Select(x => x.Select(ch => ch - '0').ToList()).ToList();

//			var result = 0;

//			for (var i = 0; i < 100; i++)
//			{
//				var flashedNodes = new List<Tuple<int, int>>();

//				for (var y = 0; y < grid.Count; y++)
//				{
//					for (var x = 0; x < grid[y].Count; x++)
//					{
//						if (!flashedNodes.Any(t => t.Item1 == y && t.Item2 == x))
//						{
//							if (grid[y][x] == 9)
//							{
//								grid[y][x] = 0;
//								flashedNodes.Add(new Tuple<int, int>(y, x));
//								result++;

//								result += IncreaseAdjacentNodes(grid, flashedNodes, y, x);
//							}
//							else
//							{
//								grid[y][x] += 1;
//							}
//						}
//					}
//				}
//			}

//			return result.ToString();
//		}

//		protected override string SolvePartTwo()
//		{
//			var inputLines = System.IO.File.ReadLines("inputs/Day11.txt").ToList();

//			var grid = inputLines.Select(x => x.Select(ch => ch - '0').ToList()).ToList();

//			var result = 0;

//			var turn = 0;

//			while (result == 0)
//			{
//				var flashedNodes = new List<Tuple<int, int>>();

//				for (var y = 0; y < grid.Count; y++)
//				{
//					for (var x = 0; x < grid[y].Count; x++)
//					{
//						if (!flashedNodes.Any(t => t.Item1 == y && t.Item2 == x))
//						{
//							if (grid[y][x] == 9)
//							{
//								grid[y][x] = 0;
//								flashedNodes.Add(new Tuple<int, int>(y, x));

//								IncreaseAdjacentNodes(grid, flashedNodes, y, x);
//							}
//							else
//							{
//								grid[y][x] += 1;
//							}
//						}
//					}
//				}

//				turn++;

//				if (flashedNodes.Count == 100)
//				{
//					result = turn;
//				}
//			}

//			return result.ToString();
//		}

//		private int IncreaseAdjacentNodes(List<List<int>> grid, List<Tuple<int, int>> flashedNodes, int y, int x)
//		{
//			var result = 0;

//			var visited = new List<Tuple<int, int>>();
//			for (var i = -1; i < 2; i++)
//			{
//				for (var j = -1; j < 2; j++)
//				{
//					try
//					{
//						if (!flashedNodes.Any(t => t.Item1 == y + i && t.Item2 == x) &&
//							!visited.Any(t => t.Item1 == y + i && t.Item2 == x))
//						{
//							visited.Add(new Tuple<int, int>(y + i, x));

//							if (grid[y + i][x] == 9)
//							{
//								grid[y + i][x] = 0;
//								result++;
//								flashedNodes.Add(new Tuple<int, int>(y + i, x));

//								result += IncreaseAdjacentNodes(grid, flashedNodes, y + i, x);
//							}
//							else
//							{
//								grid[y + i][x] += 1;
//							}
//						}
//					}
//					catch
//					{
//					}

//					try
//					{
//						if (!flashedNodes.Any(t => t.Item1 == y + i && t.Item2 == x + j) &&
//							!visited.Any(t => t.Item1 == y + i && t.Item2 == x + j))
//						{
//							visited.Add(new Tuple<int, int>(y + i, x + j));
//							if (grid[y + i][x + j] == 9)
//							{
//								grid[y + i][x + j] = 0;
//								result++;
//								flashedNodes.Add(new Tuple<int, int>(y + i, x + j));

//								result += IncreaseAdjacentNodes(grid, flashedNodes, y + i, x + j);
//							}
//							else
//							{
//								grid[y + i][x + j] += 1;
//							}
//						}
//					}
//					catch
//					{

//					}

//					try
//					{
//						if (!flashedNodes.Any(t => t.Item1 == y && t.Item2 == x + j) &&
//							!visited.Any(t => t.Item1 == y && t.Item2 == x + j))
//						{
//							visited.Add(new Tuple<int, int>(y, x + j));
//							if (grid[y][x + j] == 9)
//							{
//								grid[y][x + j] = 0;
//								result++;
//								flashedNodes.Add(new Tuple<int, int>(y, x + j));

//								result += IncreaseAdjacentNodes(grid, flashedNodes, y, x + j);
//							}
//							else
//							{
//								grid[y][x + j] += 1;
//							}
//						}
//					}
//					catch
//					{

//					}
//				}
//			}

//			return result;
//		}
//	}
//}
