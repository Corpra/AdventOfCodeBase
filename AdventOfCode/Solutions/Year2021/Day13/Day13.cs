//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace AdventOfCode.Solutions.Year2021
//{

//	class Day13 : ASolution
//	{

//		public Day13() : base(13, 2021, "Transparent Origami")
//		{

//		}

//		protected override string SolvePartOne()
//		{
//			var inputLines = System.IO.File.ReadLines("inputs/Day13.txt").ToList();
//			var marks = inputLines.Where(l => !l.Contains("fold") && l.Contains(",")).Select(line => line.Split(',')).ToList();
//			var instructions = inputLines.Where(l => l.Contains("fold")).Select(line => line.Split("fold along ")[1].Split('=')).ToList();

//			var grid = new List<List<bool>>();
//			var xMax = marks.Select(mark => Convert.ToInt32(mark[0])).Max();
//			var yMax = marks.Select(mark => Convert.ToInt32(mark[1])).Max();

//			for (var y = 0; y <= yMax; y++)
//			{
//				var line = new List<bool>();

//				for (var x = 0; x <= xMax; x++)
//				{
//					line.Add(marks.Any(mark => mark[0] == x.ToString() && mark[1] == y.ToString()));
//				}

//				grid.Add(line);
//			}

//			foreach (var instruction in instructions.Take(1))
//			{
//				if (instruction[0] == "x")
//				{
//					var newXMax = Convert.ToInt32(instruction[1]);
//					for (var x = 0; x < newXMax; x++)
//					{
//						for (var y = 0; y < grid.Count; y++)
//						{
//							if (!grid[y][x] && grid[y][newXMax * 2 - x])
//							{
//								grid[y][x] = true;
//							}
//						}
//					}

//					for (var x = grid[0].Count - 1; x >= newXMax; x--)
//					{
//						foreach (var line in grid)
//						{
//							line.RemoveAt(x);
//						}
//					}
//				}
//				if (instruction[0] == "y")
//				{
//					var newYMax = Convert.ToInt32(instruction[1]);
//					for (var y = 0; y < newYMax; y++)
//					{
//						for (var x = 0; x < grid[y].Count; x++)
//						{
//							if (!grid[y][x] && grid[newYMax * 2 - y][x])
//							{
//								grid[y][x] = true;
//							}
//						}

//						grid.RemoveAt(newYMax * 2 - y);
//					}

//					for (var y = grid.Count - 1; y >= newYMax; y--)
//					{
//						grid.RemoveAt(y);
//					}
//				}
//			}

//			var result = 0;

//			foreach (var line in grid)
//			{
//				result += line.Count(dot => dot);
//			}

//			return result.ToString();
//		}

//		protected override string SolvePartTwo()
//		{
//			var inputLines = System.IO.File.ReadLines("inputs/Day13.txt").ToList();
//			var marks = inputLines.Where(l => !l.Contains("fold") && l.Contains(",")).Select(line => line.Split(',')).ToList();
//			var instructions = inputLines.Where(l => l.Contains("fold")).Select(line => line.Split("fold along ")[1].Split('=')).ToList();

//			var grid = new List<List<bool>>();
//			var xMax = marks.Select(mark => Convert.ToInt32(mark[0])).Max();
//			var yMax = marks.Select(mark => Convert.ToInt32(mark[1])).Max();

//			for (var y = 0; y <= yMax; y++)
//			{
//				var line = new List<bool>();

//				for (var x = 0; x <= xMax; x++)
//				{
//					line.Add(marks.Any(mark => mark[0] == x.ToString() && mark[1] == y.ToString()));
//				}

//				grid.Add(line);
//			}

//			foreach (var instruction in instructions)
//			{
//				if (instruction[0] == "x")
//				{
//					var newXMax = Convert.ToInt32(instruction[1]);
//					for (var x = 0; x < newXMax; x++)
//					{
//						for (var y = 0; y < grid.Count; y++)
//						{
//							if (!grid[y][x] && grid[y][newXMax * 2 - x])
//							{
//								grid[y][x] = true;
//							}
//						}
//					}

//					for (var x = grid[0].Count - 1; x >= newXMax; x--)
//					{
//						foreach (var line in grid)
//						{
//							line.RemoveAt(x);
//						}
//					}
//				}
//				if (instruction[0] == "y")
//				{
//					var newYMax = Convert.ToInt32(instruction[1]);
//					for (var y = 0; y < newYMax; y++)
//					{
//						for (var x = 0; x < grid[y].Count; x++)
//						{
//							if (!grid[y][x] && grid[newYMax * 2 - y][x])
//							{
//								grid[y][x] = true;
//							}
//						}

//						grid.RemoveAt(newYMax * 2 - y);
//					}

//					for (var y = grid.Count - 1; y >= newYMax; y--)
//					{
//						grid.RemoveAt(y);
//					}
//				}
//			}

//			foreach (var line in grid)
//			{
//				Console.WriteLine(string.Join("", line.Select(dot => dot ? "#" : ".")));
//			}

//			Console.WriteLine("");

//			return null;
//		}
//	}
//}
