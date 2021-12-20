//using System;
//using System.Linq;

//namespace AdventOfCode.Solutions.Year2021
//{

//	class Day20 : ASolution
//	{

//		public Day20() : base(20, 2021, "Trench Map")
//		{

//		}

//		protected override string SolvePartOne()
//		{
//			var inputLines = System.IO.File.ReadLines("C:/Projects/Advent of code/AdventOfCodeBase/AdventOfCode/inputs/Day20.txt").ToList();

//			var algorithm = inputLines[0];

//			var gridXSize = inputLines[2].Length;
//			var gridYSize = inputLines.Count - 2;
//			var grid = new char[gridXSize * 3, gridYSize * 3];
//			var yy = gridYSize;
//			foreach (var line in inputLines.Skip(2))
//			{
//				var x = gridXSize;
//				foreach (var position in line)
//				{
//					grid[x, yy] = position;
//					x++;
//				}
//				yy++;
//			}

//			for (int y = 0; y < gridYSize * 3; y++)
//			{
//				for (int x = 0; x < gridXSize * 3; x++)
//				{
//					if (grid[x, y] != '.' && grid[x, y] != '#')
//						grid[x, y] = '.';
//				}
//			}

//			for (int l = 0; l < 2; l++)
//			{
//				var newGrid = new char[gridXSize * 3, gridYSize * 3];

//				for (int y = 0; y < gridYSize * 3; y++)
//				{
//					for (int x = 0; x < gridXSize * 3; x++)
//					{
//						newGrid[x, y] = '.';
//					}
//				}

//				for (int y = 0; y < gridYSize * 3; y++)
//				{
//					for (int x = 0; x < gridXSize * 3; x++)
//					{
//						var x11 = x == 0 ? (y == 0 ? grid[x, y] : grid[x, y - 1]) : (y == 0 ? grid[x - 1, y] : grid[x - 1, y - 1]);
//						var x12 = y == 0 ? grid[x, y] : grid[x, y - 1];
//						var x13 = y == 0 ? (x == (gridXSize * 3 - 1) ? grid[x, y] : grid[x + 1, y]) : (x == (gridXSize * 3 - 1) ? grid[x, y - 1] : grid[x + 1, y - 1]);
//						var x21 = x == 0 ? grid[x, y] : grid[x - 1, y];
//						var x22 = grid[x, y];
//						var x23 = x == (gridXSize * 3 - 1) ? grid[x, y] : grid[x + 1, y];
//						var x31 = x == 0 ? (y == (gridYSize * 3 - 1) ? grid[x, y] : grid[x, y + 1]) : (y == (gridYSize * 3 - 1) ? grid[x - 1, y] : grid[x - 1, y + 1]);
//						var x32 = y == gridYSize * 3 - 1 ? grid[x, y] : grid[x, y + 1];
//						var x33 = y == gridYSize * 3 - 1 ? (x == (gridXSize * 3 - 1) ? grid[x, y] : grid[x + 1, y]) : (x == (gridXSize * 3 - 1) ? grid[x, y + 1] : grid[x + 1, y + 1]);
//						var binary = $"{GetNumber(x11)}{GetNumber(x12)}{GetNumber(x13)}{GetNumber(x21)}{GetNumber(x22)}{GetNumber(x23)}{GetNumber(x31)}{GetNumber(x32)}{GetNumber(x33)}";

//						var index = Convert.ToInt32(binary, 2);

//						newGrid[x, y] = algorithm[index];
//					}
//				}

//				grid = newGrid;
//			}

//			var result = 0;
//			foreach (var c in grid)
//			{
//				if (c == '#')
//					result++;
//			}

//			return result.ToString();
//		}

//		protected override string SolvePartTwo()
//		{
//			var inputLines = System.IO.File.ReadLines("C:/Projects/Advent of code/AdventOfCodeBase/AdventOfCode/inputs/Day20.txt").ToList();

//			var algorithm = inputLines[0];

//			var gridXSize = inputLines[2].Length;
//			var gridYSize = inputLines.Count - 2;
//			var grid = new char[gridXSize * 3, gridYSize * 3];
//			var yy = gridYSize;
//			foreach (var line in inputLines.Skip(2))
//			{
//				var x = gridXSize;
//				foreach (var position in line)
//				{
//					grid[x, yy] = position;
//					x++;
//				}
//				yy++;
//			}

//			for (int y = 0; y < gridYSize * 3; y++)
//			{
//				for (int x = 0; x < gridXSize * 3; x++)
//				{
//					if (grid[x, y] != '.' && grid[x, y] != '#')
//						grid[x, y] = '.';
//				}
//			}

//			for (int l = 0; l < 50; l++)
//			{
//				var newGrid = new char[gridXSize * 3, gridYSize * 3];

//				for (int y = 0; y < gridYSize * 3; y++)
//				{
//					for (int x = 0; x < gridXSize * 3; x++)
//					{
//						newGrid[x, y] = '.';
//					}
//				}

//				for (int y = 0; y < gridYSize * 3; y++)
//				{
//					for (int x = 0; x < gridXSize * 3; x++)
//					{
//						var x11 = x == 0 ? (y == 0 ? grid[x, y] : grid[x, y - 1]) : (y == 0 ? grid[x - 1, y] : grid[x - 1, y - 1]);
//						var x12 = y == 0 ? grid[x, y] : grid[x, y - 1];
//						var x13 = y == 0 ? (x == (gridXSize * 3 - 1) ? grid[x, y] : grid[x + 1, y]) : (x == (gridXSize * 3 - 1) ? grid[x, y - 1] : grid[x + 1, y - 1]);
//						var x21 = x == 0 ? grid[x, y] : grid[x - 1, y];
//						var x22 = grid[x, y];
//						var x23 = x == (gridXSize * 3 - 1) ? grid[x, y] : grid[x + 1, y];
//						var x31 = x == 0 ? (y == (gridYSize * 3 - 1) ? grid[x, y] : grid[x, y + 1]) : (y == (gridYSize * 3 - 1) ? grid[x - 1, y] : grid[x - 1, y + 1]);
//						var x32 = y == gridYSize * 3 - 1 ? grid[x, y] : grid[x, y + 1];
//						var x33 = y == gridYSize * 3 - 1 ? (x == (gridXSize * 3 - 1) ? grid[x, y] : grid[x + 1, y]) : (x == (gridXSize * 3 - 1) ? grid[x, y + 1] : grid[x + 1, y + 1]);
//						var binary = $"{GetNumber(x11)}{GetNumber(x12)}{GetNumber(x13)}{GetNumber(x21)}{GetNumber(x22)}{GetNumber(x23)}{GetNumber(x31)}{GetNumber(x32)}{GetNumber(x33)}";

//						var index = Convert.ToInt32(binary, 2);

//						newGrid[x, y] = algorithm[index];
//					}
//				}

//				grid = newGrid;
//			}

//			var result = 0;
//			foreach (var c in grid)
//			{
//				if (c == '#')
//					result++;
//			}

//			return result.ToString();
//		}

//		private string GetNumber(char sign)
//		{
//			if (sign == '.')
//				return "0";
//			return "1";
//		}
//	}
//}
