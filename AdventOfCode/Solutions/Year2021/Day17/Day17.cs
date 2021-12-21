//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace AdventOfCode.Solutions.Year2021
//{

//	class Day17 : ASolution
//	{

//		public Day17() : base(17, 2021, "Trick Shot")
//		{

//		}

//		protected override string SolvePartOne()
//		{
//			var input = System.IO.File.ReadAllText("C:/Projects/Advent of code/AdventOfCodeBase/AdventOfCode/inputs/Day17.txt");

//			var xRange = input.Replace("target area: x=", "").Split(", y=")[0].Split("..").Select(x => Convert.ToInt32(x)).ToList();
//			var yRange = input.Replace("target area: x=", "").Split(", y=")[1].Split("..").Select(y => Convert.ToInt32(y)).ToList();

//			var testThese = new List<Tuple<int, int>>();

//			var possibleXValues = new List<int>();

//			for (var x = 0; x <= xRange.Max(); x++)
//			{
//				if (TestX(x, xRange[0], xRange[1]))
//					possibleXValues.Add(x);
//			}

//			foreach (var possibleXValue in possibleXValues)
//			{
//				var yValues = GetYValues(possibleXValue, xRange[0], xRange[1], yRange[0], yRange[1]);

//				foreach (var yValue in yValues)
//				{
//					testThese.Add(new Tuple<int, int>(possibleXValue, yValue));
//				}
//			}

//			var height = 0;
//			foreach (var tuple in testThese)
//			{
//				var h = GetHeight(tuple.Item1, tuple.Item2, xRange[0], xRange[1], yRange[0], yRange[1]);

//				if (h > height)
//					height = h;
//			}

//			return height.ToString();
//		}

//		protected override string SolvePartTwo()
//		{
//			var input = System.IO.File.ReadAllText("C:/Projects/Advent of code/AdventOfCodeBase/AdventOfCode/inputs/Day17.txt");

//			var xRange = input.Replace("target area: x=", "").Split(", y=")[0].Split("..").Select(x => Convert.ToInt32(x)).ToList();
//			var yRange = input.Replace("target area: x=", "").Split(", y=")[1].Split("..").Select(y => Convert.ToInt32(y)).ToList();

//			var testThese = new List<Tuple<int, int>>();

//			var possibleXValues = new List<int>();

//			for (var x = 0; x <= xRange.Max(); x++)
//			{
//				if (TestX(x, xRange[0], xRange[1]))
//					possibleXValues.Add(x);
//			}

//			foreach (var possibleXValue in possibleXValues)
//			{
//				var yValues = GetYValues(possibleXValue, xRange[0], xRange[1], yRange[0], yRange[1]);

//				foreach (var yValue in yValues)
//				{
//					testThese.Add(new Tuple<int, int>(possibleXValue, yValue));
//				}
//			}

//			return testThese.Count.ToString();
//		}

//		private List<int> GetYValues(int x, int minX, int maxX, int minY, int maxY)
//		{
//			var result = new List<int>();

//			var y = minY;

//			while (y < 2000)
//			{
//				if (TestXAndY(x, y, minX, maxX, minY, maxY))
//				{
//					result.Add(y);
//				}

//				y++;
//			}

//			return result;
//		}

//		private int GetHeight(int x, int y, int minX, int maxX, int minY, int maxY)
//		{
//			var height = 0;
//			var posX = 0;
//			var posY = 0;

//			while (posY >= minY)
//			{
//				if (posX >= minX && posX <= maxX && posY >= minY && posY <= maxY)
//					return height;

//				posX += x;
//				posY += y;

//				if (posY > height)
//					height = posY;

//				if (x < 0)
//					x++;
//				if (x > 0)
//					x--;

//				y--;
//			}

//			return height;
//		}

//		private bool TestXAndY(int x, int y, int minX, int maxX, int minY, int maxY)
//		{
//			var posX = 0;
//			var posY = 0;

//			while (posY >= minY)
//			{
//				if (posX >= minX && posX <= maxX && posY >= minY && posY <= maxY)
//					return true;

//				posX += x;
//				posY += y;

//				if (x < 0)
//					x++;
//				if (x > 0)
//					x--;

//				y--;
//			}

//			return false;
//		}

//		private bool TestX(int x, int minX, int maxX)
//		{
//			var position = 0;

//			var count = 1000;

//			while (count > 0)
//			{
//				position += x;

//				if (position >= minX && position <= maxX)
//					return true;

//				if (position > maxX)
//					return false;

//				x--;
//				count--;
//			}

//			return false;
//		}
//	}
//}
