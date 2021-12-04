using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solutions.Year2021
{

	class Day04 : ASolution
	{

		public Day04() : base(04, 2021, "Giant Squid")
		{

		}

		protected override string SolvePartOne()
		{
			var inputLines = System.IO.File.ReadLines("inputs/Day04.txt").ToList();
			var drawNumbers = inputLines[0].Split(',').ToList();

			var boards = SetUpBoards(inputLines);

			foreach (var drawNumber in drawNumbers)
			{
				foreach (var board in boards)
				{
					for (var i = 0; i < 5; i++)
					{
						board.Rows[i] = board.Rows[i].Select(number => number.Value == drawNumber ? new Number(drawNumber, true) : number).ToList();
					}
				}

				var winningBoards = CheckForWinningBoards(boards);
				if (winningBoards.Count > 0)
					return CalculateBoard(winningBoards.First(), Convert.ToInt32(drawNumber)).ToString();
			}

			return null;
		}

		protected override string SolvePartTwo()
		{
			var inputLines = System.IO.File.ReadLines("inputs/Day04.txt").ToList();
			var drawNumbers = inputLines[0].Split(',').ToList();

			var boards = SetUpBoards(inputLines);

			var index = 0;
			var lastDrawnNumberIndexThatWon = 0;

			foreach (var drawNumber in drawNumbers)
			{
				foreach (var board in boards)
				{
					for (var i = 0; i < 5; i++)
					{
						board.Rows[i] = board.Rows[i].Select(number => number.Value == drawNumber ? new Number(drawNumber, true) : number).ToList();
					}
				}

				var winningBoards = CheckForWinningBoards(boards);
				if (winningBoards.Count > 0)
				{
					lastDrawnNumberIndexThatWon = index;

					foreach (var winningBoard in winningBoards)
					{
						var indexOfWinningBoard = boards.IndexOf(winningBoard);
						boards[indexOfWinningBoard].HasWon = true;
					}
				}

				index++;
			}

			index = 0;
			boards = SetUpBoards(inputLines);

			foreach (var drawNumber in drawNumbers)
			{
				foreach (var board in boards)
				{
					for (var i = 0; i < 5; i++)
					{
						board.Rows[i] = board.Rows[i].Select(number => number.Value == drawNumber ? new Number(drawNumber, true) : number).ToList();
					}
				}

				var winningBoards = CheckForWinningBoards(boards);
				if (winningBoards.Count > 0)
				{
					foreach (var winningBoard in winningBoards)
					{
						var indexOfWinningBoard = boards.IndexOf(winningBoard);
						boards[indexOfWinningBoard].HasWon = true;
					}

					if (index == lastDrawnNumberIndexThatWon)
						return CalculateBoard(winningBoards.Last(), Convert.ToInt32(drawNumber)).ToString();
				}

				index++;
			}

			return null;
		}

		private List<Board> SetUpBoards(List<string> inputLines)
		{
			var index = 0;
			var boards = new List<Board>();
			var currentBoard = new Board
			{
				Rows = new List<List<Number>>()
			};

			foreach (var line in inputLines)
			{
				if (index > 0 && line.Length > 1)
				{
					var thisLine = line.Replace("  ", " ");
					if (thisLine.StartsWith(" "))
						thisLine = thisLine.Substring(1, thisLine.Length - 1);

					var numbers = thisLine.Replace("  ", " ").Split(' ').Select(x => new Number(x));

					currentBoard.Rows.Add(numbers.ToList());

					if (currentBoard.Rows.Count == 5)
					{
						boards.Add(currentBoard);
						currentBoard = new Board
						{
							Rows = new List<List<Number>>()
						};
					}
				}

				index++;
			}

			return boards;
		}

		private int CalculateBoard(Board winningBoard, int lastNumberDrawn)
		{
			var unmarkedNumbersSum = winningBoard.Rows.Sum(row => row.Sum(x => x.Marked ? 0 : Convert.ToInt32(x.Value)));

			return unmarkedNumbersSum * lastNumberDrawn;
		}

		private List<Board> CheckForWinningBoards(List<Board> boards)
		{
			var result = new List<Board>();
			foreach (var board in boards)
			{
				if (!board.HasWon
					&& (board.Rows.Any(row => row.All(val => val.Marked))
					|| board.Col1.All(val => val.Marked)
					|| board.Col2.All(val => val.Marked)
					|| board.Col3.All(val => val.Marked)
					|| board.Col4.All(val => val.Marked)
					|| board.Col5.All(val => val.Marked)))
				{ 
					result.Add(board);
				}
			}

			return result;
		}

		private void PrintBoards(List<Board> boards)
		{
			foreach (var board in boards)
			{
				foreach (var row in board.Rows)
				{
					Console.WriteLine(string.Join(",", row.Select(x => x.Value + (x.Marked ? "[x]" : "[ ]"))));
				}

				Console.WriteLine();
			}
		}

		private void PrintBoard(Board board)
		{
			foreach (var row in board.Rows)
			{
				Console.WriteLine(string.Join(",", row.Select(x => x.Value + (x.Marked ? "[x]" : "[ ]"))));
			}

			Console.WriteLine();
		}

		private class Board
		{
			public bool HasWon { get; set; }
			public List<List<Number>> Rows { get; set; }
			public List<Number> Col1 => Rows.Select(row => row.ElementAt(0)).ToList();
			public List<Number> Col2 => Rows.Select(row => row.ElementAt(1)).ToList();
			public List<Number> Col3 => Rows.Select(row => row.ElementAt(2)).ToList();
			public List<Number> Col4 => Rows.Select(row => row.ElementAt(3)).ToList();
			public List<Number> Col5 => Rows.Select(row => row.ElementAt(4)).ToList();
		}

		private class Number
		{
			public string Value { get; set; }
			public bool Marked { get; set; }

			public Number(string value, bool marked = false)
			{
				Value = value;
				Marked = marked;
			}
		}
	}
}
