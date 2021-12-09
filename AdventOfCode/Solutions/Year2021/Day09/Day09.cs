//using System.Collections.Generic;
//using System.Linq;

//namespace AdventOfCode.Solutions.Year2021
//{

//	class Day09 : ASolution
//	{

//		public Day09() : base(09, 2021, "Smoke Basin")
//		{

//		}

//		protected override string SolvePartOne()
//		{
//			var inputLines = System.IO.File.ReadLines("inputs/Day09.txt").ToList();
//			var locationLines = inputLines.Select(x => x.Select(ch => ch - '0').ToList()).ToList();

//			var result = 0;

//			for (var i = 0; i < locationLines.Count; i++)
//			{
//				var index = 0;
//				foreach (var location in locationLines[i])
//				{
//					var lowPoint = !(i > 0 && locationLines[i - 1][index] <= location);

//					if (i < locationLines.Count - 1 && locationLines[i + 1][index] <= location)
//						lowPoint = false;

//					if (index > 0 && locationLines[i][index - 1] <= location)
//						lowPoint = false;

//					if (index < locationLines[i].Count - 1 && locationLines[i][index + 1] <= location)
//						lowPoint = false;

//					if (lowPoint)
//						result += location + 1;

//					index++;
//				}
//			}

//			return result.ToString();
//		}

//		protected override string SolvePartTwo()
//		{
//			var inputLines = System.IO.File.ReadLines("inputs/Day09.txt").ToList();
//			var locationLines = inputLines.Select(x => x.Select(ch => ch - '0').ToList()).ToList();

//			var basins = new List<int>();

//			var scannedNodes = new List<string>();

//			for (var i = 0; i < locationLines.Count; i++)
//			{
//				var index = 0;
//				foreach (var location in locationLines[i])
//				{
//					var lowPoint = !(i > 0 && locationLines[i - 1][index] <= location);

//					if (i < locationLines.Count - 1 && locationLines[i + 1][index] <= location)
//						lowPoint = false;

//					if (index > 0 && locationLines[i][index - 1] <= location)
//						lowPoint = false;

//					if (index < locationLines[i].Count - 1 && locationLines[i][index + 1] <= location)
//						lowPoint = false;

//					if (lowPoint)
//					{
//						var beforeScan = scannedNodes.Count;
//						scannedNodes.Add($"{index},{i}");
//						CrawlLowPoint(locationLines, index, i, scannedNodes);
//						basins.Add(scannedNodes.Count - beforeScan);
//					}

//					index++;
//				}
//			}

//			return basins.OrderByDescending(x => x).Take(3).Aggregate((a, b) => a * b).ToString();
//		}

//		private List<string> CrawlLowPoint(List<List<int>> locationLines, int x, int y, List<string> scannedNodes, bool print = false)
//		{

//			if (y < locationLines.Count)
//			{
//				if (!scannedNodes.Contains($"{x - 1},{y}") && x > 0 &&
//					locationLines[y][x - 1] > locationLines[y][x] && locationLines[y][x - 1] < 9)
//				{
//					scannedNodes.Add($"{x - 1},{y}");
//					scannedNodes = CrawlLowPoint(locationLines, x - 1, y, scannedNodes, print);
//				}

//				if (!scannedNodes.Contains($"{x + 1},{y}") && x < locationLines[y].Count - 1 &&
//					locationLines[y][x + 1] > locationLines[y][x] && locationLines[y][x + 1] < 9)
//				{
//					scannedNodes.Add($"{x + 1},{y}");
//					scannedNodes = CrawlLowPoint(locationLines, x + 1, y, scannedNodes, print);
//				}

//				if (!scannedNodes.Contains($"{x},{y - 1}") && x < locationLines[y].Count &&
//					y > 0 && locationLines[y - 1][x] > locationLines[y][x] && locationLines[y - 1][x] < 9)
//				{
//					scannedNodes.Add($"{x},{y - 1}");
//					scannedNodes = CrawlLowPoint(locationLines, x, y - 1, scannedNodes, print);
//				}

//				if (!scannedNodes.Contains($"{x},{y + 1}") && y < locationLines.Count - 1 &&
//					locationLines[y + 1][x] > locationLines[y][x] && locationLines[y + 1][x] < 9)
//				{
//					scannedNodes.Add($"{x},{y + 1}");
//					scannedNodes = CrawlLowPoint(locationLines, x, y + 1, scannedNodes, print);
//				}
//			}

//			return scannedNodes;
//		}
//	}
//}
