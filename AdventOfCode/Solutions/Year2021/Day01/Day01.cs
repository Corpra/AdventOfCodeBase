using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solutions.Year2021
{

	class Day01 : ASolution
	{

		public Day01() : base(01, 2021, "Sonar Sweep")
		{

		}

		protected override string SolvePartOne()
		{
			var result = 0;
			var prevLineVal = 100000;

			foreach (var line in System.IO.File.ReadLines("inputs/Day01.txt"))
			{
				var lineVal = Convert.ToInt32(line);
				if (prevLineVal < lineVal)
					result++;

				prevLineVal = lineVal;
			}

			return result.ToString();
		}

		protected override string SolvePartTwo()
		{
			var result = 0;
			var index = 0;

			var setA = new List<int>();
			var setB = new List<int>();
			var setC = new List<int>();

			var prevSetValA = 0;
			var prevSetValB = 0;
			var prevSetValC = 0;

			foreach (var line in System.IO.File.ReadLines("inputs/Day01.txt"))
			{
				var lineVal = Convert.ToInt32(line);

				setA.Add(lineVal);

				if (setA.Count == 3)
				{
					if (prevSetValC > 0 && setA.Sum() > prevSetValC)
						result++;

					prevSetValA = setA.Sum();
					setA.Clear();
				}

				if (index > 0)
					setB.Add(lineVal);
				
				if (setB.Count == 3)
				{
					if (prevSetValA > 0 && setB.Sum() > prevSetValA)
						result++;

					prevSetValB = setB.Sum();
					setB.Clear();
				}

				if (index > 1)
					setC.Add(lineVal);

				if (setC.Count == 3)
				{
					if (prevSetValB > 0 && setC.Sum() > prevSetValB)
						result++;

					prevSetValC = setC.Sum();
					setC.Clear();
				}

				index++;
			}

			return result.ToString();
		}
	}
}
