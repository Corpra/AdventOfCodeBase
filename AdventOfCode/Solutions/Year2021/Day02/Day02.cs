using System;

namespace AdventOfCode.Solutions.Year2021
{

	class Day02 : ASolution
	{

		public Day02() : base(02, 2021, "")
		{

		}

		protected override string SolvePartOne()
		{
			var horizontalPos = 0;
			var depth = 0;

			foreach (var line in System.IO.File.ReadLines("inputs/Day02.txt"))
			{
				var splitLine = line.Split(' ');
				var command = splitLine[0];
				var value = Convert.ToInt32(splitLine[1]);

				switch (command)
				{
					case "forward":
						horizontalPos += value;
						break;
					case "up":
						depth -= value;
						break;
					case "down":
						depth += value;
						break;
				}
			}

			var result = horizontalPos * depth;

			Console.WriteLine("The answer is {0}.", result);

			return result.ToString();
		}

		protected override string SolvePartTwo()
		{
			return null;
		}
	}
}
