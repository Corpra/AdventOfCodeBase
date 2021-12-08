using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solutions.Year2021
{

	class Day05 : ASolution
	{

		public Day05() : base(05, 2021, "Hydrothermal Venture")
		{

		}

		protected override string SolvePartOne()
		{
			//var inputLines = System.IO.File.ReadLines("inputs/Day05.txt").ToList();

			//var board = CreateBoard();

			//var coordinates = inputLines.Select(i => new Coordinate(i));

			//var straightCoordinates = coordinates.Where(c => c.X1 == c.X2 || c.Y1 == c.Y2);

			//foreach (var coordinate in straightCoordinates)
			//{
			//	var x = coordinate.X1;
			//	var y = coordinate.Y1;

			//	if (coordinate.X1 < coordinate.X2)
			//	{
			//		for (var i = 0; i <= coordinate.X2 - coordinate.X1; i++)
			//		{
			//			board[x][y]++;
			//			x++;
			//		}
			//	}

			//	if (coordinate.X1 > coordinate.X2)
			//	{
			//		for (var i = 0; i <= coordinate.X1 - coordinate.X2; i++)
			//		{
			//			board[x][y]++;
			//			x--;
			//		}
			//	}

			//	if (coordinate.Y1 < coordinate.Y2)
			//	{
			//		for (var i = 0; i <= coordinate.Y2 - coordinate.Y1; i++)
			//		{
			//			board[x][y]++;
			//			y++;
			//		}
			//	}

			//	if (coordinate.Y1 > coordinate.Y2)
			//	{
			//		for (var i = 0; i <= coordinate.Y1 - coordinate.Y2; i++)
			//		{
			//			board[x][y]++;
			//			y--;
			//		}
			//	}
			//}

			//var result = board.Sum(column => column.Count(point => point >= 2));

			//return result.ToString();
			return null;
		}

		protected override string SolvePartTwo()
		{
			//var inputLines = System.IO.File.ReadLines("inputs/Day05.txt").ToList();

			//var board = CreateBoard();

			//var coordinates = inputLines.Select(i => new Coordinate(i));

			//var straightAndDiagonalCoordinates = coordinates.Where(c => c.X1 == c.X2 || c.Y1 == c.Y2 || (c.X1 - c.X2 > 0 ? c.X1 - c.X2 : c.X2 - c.X1) == (c.Y1 - c.Y2 > 0 ? c.Y1 - c.Y2 : c.Y2 - c.Y1));

			//foreach (var coordinate in straightAndDiagonalCoordinates)
			//{
			//	var x = coordinate.X1;
			//	var y = coordinate.Y1;

			//	if (coordinate.X1 < coordinate.X2 && coordinate.Y1 == coordinate.Y2)
			//	{
			//		for (var i = 0; i <= coordinate.X2 - coordinate.X1; i++)
			//		{
			//			board[x][y]++;
			//			x++;
			//		}
			//	}

			//	if (coordinate.X1 > coordinate.X2 && coordinate.Y1 == coordinate.Y2)
			//	{
			//		for (var i = 0; i <= coordinate.X1 - coordinate.X2; i++)
			//		{
			//			board[x][y]++;
			//			x--;
			//		}
			//	}

			//	if (coordinate.Y1 < coordinate.Y2 && coordinate.X1 == coordinate.X2)
			//	{
			//		for (var i = 0; i <= coordinate.Y2 - coordinate.Y1; i++)
			//		{
			//			board[x][y]++;
			//			y++;
			//		}
			//	}

			//	if (coordinate.Y1 > coordinate.Y2 && coordinate.X1 == coordinate.X2)
			//	{
			//		for (var i = 0; i <= coordinate.Y1 - coordinate.Y2; i++)
			//		{
			//			board[x][y]++;
			//			y--;
			//		}
			//	}

			//	if (coordinate.X1 != coordinate.X2 && coordinate.Y1 != coordinate.Y2)
			//	{
			//		var xDirection = coordinate.X1 < coordinate.X2 ? 1 : 0;
			//		var yDirection = coordinate.Y1 < coordinate.Y2 ? 1 : 0;

			//		board[x][y]++;

			//		while (x != coordinate.X2)
			//		{
			//			x = xDirection == 1 ? x + 1 : x - 1;
			//			y = yDirection == 1 ? y + 1 : y - 1;

			//			board[x][y]++;
			//		}
			//	}
			//}

			//var result = board.Sum(column => column.Count(point => point >= 2));

			//return result.ToString();
			return null;
		}

		private void PrintCommands(IEnumerable<Coordinate> coordinates)
		{
			foreach (var coordinate in coordinates)
			{
				Console.WriteLine($"{coordinate.X1},{coordinate.Y1} -> {coordinate.X2},{coordinate.Y2}");
			}
		}

		private void PrintBoard(List<List<int>> board)
		{
			var rows = new List<string>();

			for (var i = 0; i < 10; i++)
			{
				rows.Add("");
			}

			foreach (var column in board)
			{
				var index = 0;
				foreach (var point in column)
				{
					rows[index] += point == 0 ? "." : point.ToString();
					index++;
				}
			}

			foreach (var row in rows)
			{
				Console.WriteLine(row);
			}
		}

		private List<List<int>> CreateBoard(bool isExample = false)
		{
			var result = new List<List<int>>();

			for (var i = 0; i < (isExample ? 10 : 1000); i++)
			{
				var column = new List<int>();
				for (var j = 0; j < (isExample ? 10 : 1000); j++)
				{
					column.Add(0);
				}
				result.Add(column);
			}

			return result;
		}

		private class Coordinate
		{
			public int X1 { get; set; }
			public int Y1 { get; set; }
			public int X2 { get; set; }
			public int Y2 { get; set; }

			public Coordinate(string input)
			{
				var points = input.Split(" -> ");
				var firstPoint = points[0].Split(",");
				var secondPoint = points[1].Split(",");

				X1 = Convert.ToInt32(firstPoint[0]);
				Y1 = Convert.ToInt32(firstPoint[1]);
				X2 = Convert.ToInt32(secondPoint[0]);
				Y2 = Convert.ToInt32(secondPoint[1]);
			}
		}
	}
}
