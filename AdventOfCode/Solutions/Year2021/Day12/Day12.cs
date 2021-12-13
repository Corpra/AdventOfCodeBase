//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace AdventOfCode.Solutions.Year2021
//{

//	class Day12 : ASolution
//	{

//		public Day12() : base(12, 2021, "Passage Pathing")
//		{

//		}

//		protected override string SolvePartOne()
//		{
//			var inputLines = System.IO.File.ReadLines("inputs/Day12.txt").ToList();
//			var connections = inputLines.Select(line => line.Split('-')).ToList();

//			var startingPaths = connections.Where(path => path[0] == "start" || path[1] == "start");

//			var paths = new List<string>();

//			foreach (var startingPath in startingPaths)
//			{
//				paths.Add(startingPath[0] == "start"
//					? string.Join("-", startingPath)
//					: string.Join("-", startingPath.Reverse()));
//			}

//			paths = TakeStep(paths, connections);

//			return paths.Count.ToString();
//		}

//		protected override string SolvePartTwo()
//		{
//			var inputLines = System.IO.File.ReadLines("inputs/Day12.txt").ToList();
//			var connections = inputLines.Select(line => line.Split('-')).ToList();

//			var startingPaths = connections.Where(path => path[0] == "start" || path[1] == "start");

//			var paths = new List<string>();

//			foreach (var startingPath in startingPaths)
//			{
//				paths.Add(startingPath[0] == "start"
//					? string.Join("-", startingPath)
//					: string.Join("-", startingPath.Reverse()));
//			}

//			paths = TakeStep2Step(paths, connections);

//			return paths.Count.ToString();
//		}

//		private List<string> TakeStep(List<string> paths, List<string[]> connections)
//		{
//			var newPaths = new List<string>();

//			foreach (var path in paths.Where(p => !p.Contains("end")))
//			{
//				foreach (var connection in connections.Where(c => c[0] == path.Split('-').Last() && c[1] != "start"))
//				{
//					if (path.Split('-').Where(node => node.All(char.IsLower)).All(v => v != connection[1]))
//					{
//						var newPath = "";
//						newPath += $"{path}-{connection[1]}";
//						newPaths.Add(newPath);
//					}
//				}
//				foreach (var connection in connections.Where(c => c[1] == path.Split('-').Last() && c[0] != "start"))
//				{
//					if (path.Split('-').Where(node => node.All(char.IsLower)).All(v => v != connection[0]))
//					{
//						var newPath = "";
//						newPath += $"{path}-{connection[0]}";
//						newPaths.Add(newPath);
//					}
//				}
//			}

//			foreach (var path in paths.Where(p => p.Contains("end")))
//			{
//				newPaths.Add(path);
//			}

//			if (newPaths.All(p => p.Contains("end")))
//			{
//				return newPaths;
//			}

//			return TakeStep(newPaths, connections);
//		}

//		private List<string> TakeStep2Step(List<string> paths, List<string[]> connections)
//		{
//			var newPaths = new List<string>();

//			foreach (var path in paths.Where(p => !p.Contains("end")))
//			{
//				var smallCaves = path.Split('-').Where(node => node.All(char.IsLower)).ToList();
//				var fullOnMultiSmallCaves = smallCaves.Any(smallCave => smallCaves.Count(s => s == smallCave) > 1);

//				foreach (var connection in connections.Where(c => c[0] == path.Split('-').Last() && c[1] != "start"))
//				{
//					if (!(connection[1].All(char.IsLower) && path.Contains(connection[1]) && fullOnMultiSmallCaves))
//					{
//						var newPath = "";
//						newPath += $"{path}-{connection[1]}";
//						newPaths.Add(newPath);
//					}
//				}
//				foreach (var connection in connections.Where(c => c[1] == path.Split('-').Last() && c[0] != "start"))
//				{
//					if (!(connection[0].All(char.IsLower) && path.Contains(connection[0]) && fullOnMultiSmallCaves))
//					{
//						var newPath = "";
//						newPath += $"{path}-{connection[0]}";
//						newPaths.Add(newPath);
//					}
//				}
//			}

//			foreach (var path in paths.Where(p => p.Contains("end")))
//			{
//				newPaths.Add(path);
//			}

//			if (newPaths.All(p => p.Contains("end")))
//			{
//				return newPaths;
//			}

//			return TakeStep2Step(newPaths, connections);
//		}
//	}
//}
