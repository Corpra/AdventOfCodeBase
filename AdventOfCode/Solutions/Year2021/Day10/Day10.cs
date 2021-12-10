//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace AdventOfCode.Solutions.Year2021
//{

//	class Day10 : ASolution
//	{

//		public Day10() : base(10, 2021, "Syntax Scoring")
//		{

//		}

//		private Dictionary<char, int> _points = new()
//		{
//			{ ')', 3 },
//			{ ']', 57 },
//			{ '}', 1197 },
//			{ '>', 25137 }
//		};

//		private Dictionary<char, int> _pointsProblemTwo = new()
//		{
//			{ '(', 1 },
//			{ '[', 2 },
//			{ '{', 3 },
//			{ '<', 4 }
//		};

//		protected override string SolvePartOne()
//		{
//			var inputLines = System.IO.File.ReadLines("inputs/Day10.txt").ToList();

//			var result = 0;

//			foreach (var inputLine in inputLines)
//			{
//				var openBrackets = new List<char>();

//				var exitLine = false;

//				foreach (var c in inputLine)
//				{
//					switch (c)
//					{
//						case ')':
//							if (openBrackets.Last() == '(')
//								openBrackets.RemoveAt(openBrackets.Count - 1);
//							else
//							{
//								result += _points[c];
//								exitLine = true;
//							}

//							break;
//						case ']':
//							if (openBrackets.Last() == '[')
//								openBrackets.RemoveAt(openBrackets.Count - 1);
//							else
//							{
//								result += _points[c];
//								exitLine = true;
//							}
//							break;
//						case '}':
//							if (openBrackets.Last() == '{')
//								openBrackets.RemoveAt(openBrackets.Count - 1);
//							else
//							{
//								result += _points[c];
//								exitLine = true;
//							}
//							break;
//						case '>':
//							if (openBrackets.Last() == '<')
//								openBrackets.RemoveAt(openBrackets.Count - 1);
//							else
//							{
//								result += _points[c];
//								exitLine = true;
//							}
//							break;
//						default:
//							openBrackets.Add(c);
//							break;
//					}

//					if (exitLine)
//						break;
//				}
//			}

//			return result.ToString();
//		}

//		protected override string SolvePartTwo()
//		{
//			var inputLines = System.IO.File.ReadLines("inputs/Day10.txt").ToList();

//			var scores = new List<long>();

//			foreach (var inputLine in inputLines)
//			{
//				var openBrackets = new List<char>();

//				var corruptedLine = false;

//				foreach (var c in inputLine)
//				{
//					switch (c)
//					{
//						case ')':
//							if (openBrackets.Last() == '(')
//								openBrackets.RemoveAt(openBrackets.Count - 1);
//							else
//								corruptedLine = true;
//							break;
//						case ']':
//							if (openBrackets.Last() == '[')
//								openBrackets.RemoveAt(openBrackets.Count - 1);
//							else
//								corruptedLine = true;
//							break;
//						case '}':
//							if (openBrackets.Last() == '{')
//								openBrackets.RemoveAt(openBrackets.Count - 1);
//							else
//								corruptedLine = true;
//							break;
//						case '>':
//							if (openBrackets.Last() == '<')
//								openBrackets.RemoveAt(openBrackets.Count - 1);
//							else
//								corruptedLine = true;
//							break;
//						default:
//							openBrackets.Add(c);
//							break;
//					}

//					if (corruptedLine)
//						break;
//				}

//				if (!corruptedLine)
//				{
//					long lineResult = 0;

//					openBrackets.Reverse();

//					foreach (var openBracket in openBrackets)
//					{
//						lineResult = lineResult * 5 + _pointsProblemTwo[openBracket];
//					}

//					scores.Add(lineResult);
//				}
//			}

//			return scores.OrderBy(x => x).ElementAt(scores.Count / 2).ToString();
//		}
//	}
//}
