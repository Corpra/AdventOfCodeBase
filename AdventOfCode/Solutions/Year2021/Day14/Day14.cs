//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection.Metadata;

//namespace AdventOfCode.Solutions.Year2021
//{

//	class Day14 : ASolution
//	{

//		public Day14() : base(14, 2021, "Extended Polymerization")
//		{

//		}

//		protected override string SolvePartOne()
//		{
//			var inputLines = System.IO.File.ReadLines("inputs/Day14.txt").ToList();
//			var polymer = inputLines[0];
//			var rules = inputLines.Where(line => line.Contains("->")).Select(line => line.Split(" -> ")).ToList();

//			for (var step = 0; step < 10; step++)
//			{
//				var insertions = new List<Tuple<int, string>>();

//				for (var i = 0; i < polymer.Length - 1; i++)
//				{
//					var matchingRule = rules.FirstOrDefault(rule => rule[0] == polymer.Substring(i, 2));
//					if (matchingRule != null)
//					{
//						insertions.Add(new Tuple<int, string>(i + 1, matchingRule[1]));
//					}
//				}

//				for (var i = 0; i < insertions.Count; i++)
//				{
//					polymer = polymer.Insert(insertions[i].Item1 + i, insertions[i].Item2);
//				}

//				insertions.Clear();
//			}

//			var mostOccurrences = polymer.Max(letter => polymer.Count(c => c == letter));
//			var leastOccurrences = polymer.Min(letter => polymer.Count(c => c == letter));

//			return (mostOccurrences - leastOccurrences).ToString();
//		}

//		protected override string SolvePartTwo()
//		{
//			var inputLines = System.IO.File.ReadLines("inputs/Day14.txt").ToList();
//			var polymer = inputLines[0];
//			var rules = inputLines.Where(line => line.Contains("->")).Select(line => line.Split(" -> ")).ToList();

//			var letters = new Dictionary<char, long>();
//			foreach (var rule in rules)
//			{
//				if (!letters.ContainsKey(rule[0][0]))
//				{
//					letters.Add(rule[0][0], 0);
//				}
//				if (!letters.ContainsKey(rule[0][1]))
//				{
//					letters.Add(rule[0][1], 0);
//				}
//			}

//			var pairCount = new Dictionary<string, long>();
//			foreach (var rule in rules)
//			{
//				pairCount.Add(rule[0], 0);
//			}

//			for (var i = 0; i < polymer.Length - 1; i++)
//			{
//				pairCount[polymer.Substring(i, 2)]++;
//				letters[polymer[i]]++;
//			}

//			letters[polymer[polymer.Length - 1]]++;

//			for (var step = 0; step < 40; step++)
//			{
//				var changes = new Dictionary<string, long>();
//				foreach (var pair in pairCount)
//				{
//					changes.Add(pair.Key, 0);
//				}

//				foreach (var pair in pairCount)
//				{
//					var rule = rules.FirstOrDefault(r => r[0] == pair.Key);

//					changes[pair.Key] -= pair.Value;
//					changes[pair.Key.Substring(0, 1) + rule[1]] += pair.Value;
//					changes[rule[1] + pair.Key.Substring(1, 1)] += pair.Value;

//					letters[rule[1][0]] += pair.Value;
//				}

//				foreach (var change in changes)
//				{
//					pairCount[change.Key] += change.Value;
//				}
//			}

//			var mostOccurrences = letters.Max(letter => letter.Value);
//			var leastOccurrences = letters.Min(letter => letter.Value);

//			return (mostOccurrences - leastOccurrences).ToString();
//		}
//	}
//}
