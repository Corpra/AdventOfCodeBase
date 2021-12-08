using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solutions.Year2021
{

	class Day06 : ASolution
	{

		public Day06() : base(06, 2021, "Lanternfish")
		{

		}

		protected override string SolvePartOne()
		{
			//var inputLines = System.IO.File.ReadLines("inputs/Day06.txt").ToList();

			//var fishes = inputLines[0].Split(',').Select(x => Convert.ToInt32(x)).ToList();

			//for (var i = 0; i < 80; i++)
			//{
			//	var numberOfFishes = fishes.Count;
			//	for (var j = 0; j < numberOfFishes; j++) {
			//		if (fishes[j] > 0) {
			//			fishes[j]--;
			//		} else {
			//			fishes[j] = 6;
			//			fishes.Add(8);
			//		}
			//	}
			//}

			//return fishes.Count.ToString();
			return null;
		}

		protected override string SolvePartTwo()
		{
			//var inputLines = System.IO.File.ReadLines("inputs/Day06.txt").ToList();

			//var allFishes = inputLines[0].Split(',').Select(x => Convert.ToInt64(x)).ToList();

			//var fishes = new List<long>();

			//for (var i = 0; i < 9; i++) {
			//	fishes.Add(allFishes.Count(x => x == i));
			//}

			//for (var i = 0; i < 256; i++)
			//{
			//	var newFishes = new List<long>();

			//	for (int j = 1; j < 9; j++)
			//	{
			//		newFishes.Add(fishes[j]);
			//	}

			//	var numberOfBirthingFishes = fishes[0];
			//	newFishes.Add(numberOfBirthingFishes);
			//	newFishes[6] += numberOfBirthingFishes;

			//	fishes = newFishes;
			//}

			//return fishes.Sum(x => x).ToString();
			return null;
		}
	}
}
