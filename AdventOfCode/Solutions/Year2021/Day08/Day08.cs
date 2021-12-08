using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solutions.Year2021
{

	class Day08 : ASolution
	{

		public Day08() : base(08, 2021, "Seven Segment Search")
		{

		}

		protected override string SolvePartOne()
		{
			var inputLines = System.IO.File.ReadLines("inputs/Day08.txt").ToList();
			var outputLines = inputLines.Select(x => x.Split(" | ")[1]).ToList();
			var outputValues = outputLines.Select(x => x.Split(' ')).ToList();

			var result = 0;

			foreach (var outputValue in outputValues)
			{
				foreach (var value in outputValue)
				{
					switch (value.Length)
					{
						case 2:
							result++;
							break;
						case 3:
							result++;
							break;
						case 4:
							result++;
							break;
						case 7:
							result++;
							break;
					}
				}
			}

			return result.ToString();
		}

		protected override string SolvePartTwo()
		{
			var inputLines = System.IO.File.ReadLines("inputs/Day08.txt").ToList();
			var entryLines = inputLines.Select(x => x.Split(" | ")[0]).ToList();
			var entryValues = entryLines.Select(x => x.Split(' ')).ToList();
			var outputLines = inputLines.Select(x => x.Split(" | ")[1]).ToList();
			var outputValues = outputLines.Select(x => x.Split(' ')).ToList();

			var result = 0;

			for (var i = 0; i < inputLines.Count; i++)
			{
				var one = new List<char>();
				var four = new List<char>();
				var seven = new List<char>();
				var eight = new List<char>();

				foreach (var entryValue in entryValues[i])
				{
					if (entryValue.Length == 2 && one.Count == 0) {
						one = entryValue.ToCharArray().ToList();
					}
					if (entryValue.Length == 4 && four.Count == 0) {
						four = entryValue.ToCharArray().ToList();
					}
					if (entryValue.Length == 3 && seven.Count == 0) {
						seven = entryValue.ToCharArray().ToList();
					}
					if (entryValue.Length == 7 && eight.Count == 0) {
						eight = entryValue.ToCharArray().ToList();
					}
				}

				var lineResult = "";
				foreach (var outputValue in outputValues[i])
				{
					switch (outputValue.Length)
					{
						case 2:
							lineResult += "1";
							break;
						case 3:
							lineResult += "7";
							break;
						case 4:
							lineResult += "4";
							break;
						case 5:
						{
							var chars = outputValue.ToCharArray();
							if (seven.All(x => chars.Contains(x)))
							{
								lineResult += "3";
							}
							else if (four.Count(x => chars.Contains(x)) == 3)
							{
								lineResult += "5";
							}
							else
							{
								lineResult += "2";
							}

							break;
						}
						case 6:
						{
							var chars = outputValue.ToCharArray();
							if (four.All(x => chars.Contains(x)))
							{
								lineResult += "9";
							}
							else if (seven.All(x => chars.Contains(x)))
							{
								lineResult += "0";
							}
							else
							{
								lineResult += "6";
							}

							break;
						}
						case 7:
							lineResult += "8";
							break;
					}
				}

				result += Convert.ToInt32(lineResult);
			}

			return result.ToString();
		}
	}
}
