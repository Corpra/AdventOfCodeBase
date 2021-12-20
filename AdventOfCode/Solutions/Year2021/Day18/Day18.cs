//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace AdventOfCode.Solutions.Year2021
//{

//	class Day18 : ASolution
//	{

//		public Day18() : base(18, 2021, "Snailfish")
//		{

//		}

//		private static string currentInputLine;

//		protected override string SolvePartOne()
//		{
//			var inputLines = System.IO.File.ReadLines("C:/Projects/Advent of code/AdventOfCodeBase/AdventOfCode/inputs/Day18.txt").ToList();

//			var result = inputLines[0];

//			foreach (var inputLine in inputLines.Skip(1))
//			{
//				result = $"[{result},{inputLine}]";

//				result = Reduce(result);
//			}

//			currentInputLine = result.Substring(1, result.Length - 1);

//			var pair = new Pair();

//			return pair.Magnitude().ToString();
//		}

//		protected override string SolvePartTwo()
//		{
//			var inputLines = System.IO.File.ReadLines("C:/Projects/Advent of code/AdventOfCodeBase/AdventOfCode/inputs/Day18.txt").ToList();

//			var result = new List<int>();

//			foreach (var inputLine in inputLines)
//			{
//				foreach (var line in inputLines.Where(l => l != inputLine))
//				{
//					var addition = $"[{inputLine},{line}]";

//					var sum = Reduce(addition);

//					currentInputLine = sum.Substring(1, sum.Length - 1);

//					var pair = new Pair();

//					result.Add(pair.Magnitude());
//				}
//			}

//			return result.Max().ToString();
//		}

//		private string Reduce(string pair)
//		{
//			while (HasExplode(pair) || HasSplit(pair))
//			{
//				if (HasExplode(pair))
//				{
//					var depth = 0;
//					for (var i = 0; i < pair.Length; i++)
//					{
//						var c = pair[i];
//						if (depth >= 5 && char.IsNumber(c))
//						{
//							var oldLeftNumberWasOne = true;

//							var leftIsTwoNumbers = char.IsNumber(pair[i + 1]);

//							if (!(pair[i + (leftIsTwoNumbers ? 2 : 1)] == ',' && char.IsNumber(pair[i + (leftIsTwoNumbers ? 3 : 2)])))
//								continue;

//							var rightIsTwoNumbers = char.IsNumber(pair[i + (leftIsTwoNumbers ? 4 : 3)]);

//							var leftNumberString = leftIsTwoNumbers ? new[] { c, pair[i + 1] } : new[] { c };
//							var leftNumber = Convert.ToInt32(new string(leftNumberString));
//							var newLeftNumber = 0;
//							var rightNumberString = rightIsTwoNumbers ? new[] { pair[i + (leftIsTwoNumbers ? 3 : 2)], pair[i + (leftIsTwoNumbers ? 4 : 3)] } : new[] { pair[i + (leftIsTwoNumbers ? 3 : 2)] };
//							var rightNumber = Convert.ToInt32(new string(rightNumberString));

//							for (var j = i - 1; j >= 0; j--)
//							{
//								if (char.IsNumber(pair[j]))
//								{
//									var isTwoNumbers = char.IsNumber(pair[j - 1]);
//									oldLeftNumberWasOne = !isTwoNumbers;
//									var numberString = isTwoNumbers ? new[] { pair[j - 1], pair[j] } : new[] { pair[j] };
//									newLeftNumber = Convert.ToInt32(new string(numberString)) + leftNumber;

//									pair = pair.Substring(0, isTwoNumbers ? j -1 : j) + newLeftNumber + pair.Substring(j + 1, pair.Length - (j + 1));
//									break;
//								}
//							}

//							for (var j = i + (leftIsTwoNumbers ? (rightIsTwoNumbers ? 6 : 5) : (rightIsTwoNumbers ? 5 : 4)); j < pair.Length; j++)
//							{
//								if (char.IsNumber(pair[j]))
//								{
//									var isTwoNumbers = char.IsNumber(pair[j + 1]);
//									var numberString = isTwoNumbers ? new[] { pair[j], pair[j + 1] } : new[] { pair[j] };
//									var newNumber = Convert.ToInt32(new string(numberString)) + rightNumber;
//									pair = pair.Substring(0, j) + newNumber + pair.Substring(j + (isTwoNumbers ? 2 : 1), pair.Length - (j + (isTwoNumbers ? 2 : 1)));
//									break;
//								}
//							}

//							var numberOfCharsToReplace = 4;
//							if (newLeftNumber > 9 && oldLeftNumberWasOne)
//								numberOfCharsToReplace++;
//							if (leftIsTwoNumbers)
//								numberOfCharsToReplace++;
//							if (rightIsTwoNumbers)
//								numberOfCharsToReplace++;


//							pair = pair.Substring(0, newLeftNumber > 9 && oldLeftNumberWasOne ? i : i - 1) + "0" + pair.Substring(i + numberOfCharsToReplace, pair.Length - (i + numberOfCharsToReplace));

//							break;
//						}

//						if (c == '[')
//							depth++;
//						if (c == ']')
//							depth--;
//					}
//				}
//				else
//				{
//					for (var i = 0; i < pair.Length; i++)
//					{
//						if (char.IsNumber(pair[i]) && char.IsNumber(pair[i + 1]))
//						{
//							var number = Convert.ToInt32(new string(new[] {pair[i], pair[i + 1]}));

//							var leftNumber = Math.Floor(number / 2.0);
//							var rightNumber = Math.Ceiling(number / 2.0);

//							pair = pair.Substring(0, i) + $"[{leftNumber},{rightNumber}]" + pair.Substring(i + 2, pair.Length - (i + 2));

//							break;
//						}
//					}
//				}
//			}

//			return pair;
//		}

//		private bool HasExplode(string pair)
//		{
//			var depth = 0;
//			foreach (var c in pair)
//			{
//				if (depth == 5)
//					return true;
//				if (c == '[')
//					depth++;
//				if (c == ']')
//					depth--;
//			}

//			return false;
//		}

//		private bool HasSplit(string pair)
//		{
//			for (var i = 0; i < pair.Length - 1; i++)
//			{
//				if (char.IsNumber(pair[i]) && char.IsNumber(pair[i + 1]))
//					return true;
//			}

//			return false;
//		}


//		private class Pair
//		{
//			private Pair LeftPair { get; }
//			private Pair RightPair { get; }
//			private int LeftValue { get; }
//			private int RightValue { get; }

//			public Pair()
//			{
//				LeftValue = -1;
//				RightValue = -1;

//				while (currentInputLine.Length > 0)
//				{
//					var c = currentInputLine[0];
//					currentInputLine = currentInputLine.Substring(1, currentInputLine.Length - 1);

//					if (LeftPair == null && LeftValue == -1)
//					{
//						if (c == '[')
//						{
//							LeftPair = new Pair();
//						}
//						else if (char.IsNumber(c))
//						{
//							LeftValue = c - '0';
//						}
//					}
//					else
//					{
//						if (c == '[')
//						{
//							RightPair = new Pair();
//						}
//						else if (char.IsNumber(c))
//						{
//							RightValue = c - '0';
//						}
//					}

//					if (c == ']')
//					{
//						return;
//					}
//				}
//			}

//			public int Magnitude()
//			{
//				var result = 0;

//				if (LeftPair != null)
//					result += 3 * LeftPair.Magnitude();
//				else
//					result += 3 * LeftValue;
//				if (RightPair != null)
//					result += 2 * RightPair.Magnitude();
//				else
//					result += 2 * RightValue;

//				return result;
//			}

//			public string ToString()
//			{
//				var result = "[";

//				if (LeftPair != null)
//				{
//					result += LeftPair.ToString() + ",";
//				}
//				else
//				{
//					result += LeftValue + ",";
//				}

//				if (RightPair != null)
//				{
//					result += RightPair.ToString();
//				}
//				else
//				{
//					result += RightValue.ToString();
//				}

//				return result + "]";
//			}
//		}
//	}
//}
