//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace AdventOfCode.Solutions.Year2021
//{

//	class Day16 : ASolution
//	{

//		public Day16() : base(16, 2021, "Packet Decoder")
//		{

//		}

//		private readonly Dictionary<char, string> _dictionary = new()
//		{
//			{ '0', "0000" },
//			{ '1', "0001" },
//			{ '2', "0010" },
//			{ '3', "0011" },
//			{ '4', "0100" },
//			{ '5', "0101" },
//			{ '6', "0110" },
//			{ '7', "0111" },
//			{ '8', "1000" },
//			{ '9', "1001" },
//			{ 'A', "1010" },
//			{ 'B', "1011" },
//			{ 'C', "1100" },
//			{ 'D', "1101" },
//			{ 'E', "1110" },
//			{ 'F', "1111" }
//		};

//		private string _binaryString = "";
//		private readonly List<string> _packetHeaders = new();

//		protected override string SolvePartOne()
//		{
//			var input = System.IO.File.ReadAllText("C:/Projects/Advent of code/AdventOfCodeBase/AdventOfCode/inputs/Day16.txt");

//			_binaryString = string.Join("",input.Select(character => _dictionary[character]));

//			var result = 0;

//			ReadPacket();

//			foreach (var packetHeader in _packetHeaders)
//			{
//				var versionNumberString = packetHeader.Substring(0, 3);
//				var versionNumber = Convert.ToInt32(versionNumberString, 2);

//				result += versionNumber;
//			}

//			return result.ToString();
//		}

//		protected override string SolvePartTwo()
//		{
//			var input = System.IO.File.ReadAllText("C:/Projects/Advent of code/AdventOfCodeBase/AdventOfCode/inputs/Day16.txt");

//			_binaryString = string.Join("", input.Select(character => _dictionary[character]));

//			var packet = ReadPacket();

//			return packet.Value.ToString();
//		}

//		private Packet ReadPacket()
//		{
//			var packetSequence = "";

//			var typeIdString = _binaryString.Substring(3, 3);
//			var typeId = Convert.ToInt32(typeIdString, 2);

//			long value;

//			_packetHeaders.Add(_binaryString.Substring(0, 6));

//			packetSequence += _binaryString.Substring(0, 6);

//			if (typeId != 4)
//			{
//				var lengthTypeId = _binaryString.Substring(6, 1);

//				packetSequence += lengthTypeId;

//				var subPackets = new List<Packet>();

//				if (lengthTypeId == "0")
//				{
//					var lengthOfSubPacketsString = _binaryString.Substring(7, 15);
//					packetSequence += _binaryString.Substring(7, 15);
//					var lengthOfSubPackets = Convert.ToInt32(lengthOfSubPacketsString, 2);

//					_binaryString = _binaryString.Substring(22, _binaryString.Length - 22);

//					var packetsReadLength = 0;

//					while (packetsReadLength < lengthOfSubPackets)
//					{
//						var p = ReadPacket();

//						subPackets.Add(p);

//						packetSequence += p.PacketSequence;

//						packetsReadLength += p.PacketSequence.Length;
//					}
//				}
//				else
//				{
//					var numberOfSubPacketsString = _binaryString.Substring(7, 11);
//					packetSequence += _binaryString.Substring(7, 11);
//					var numberOfSubPackets = Convert.ToInt32(numberOfSubPacketsString, 2);
//					_binaryString = _binaryString.Substring(18, _binaryString.Length - 18);

//					for (var i = 0; i < numberOfSubPackets; i++)
//					{
//						var p = ReadPacket();
//						packetSequence += p.PacketSequence;

//						subPackets.Add(p);
//					}
//				}

//				value = CalculatePackets(subPackets, typeId);
//			}
//			else
//			{
//				_binaryString = _binaryString.Substring(6, _binaryString.Length - 6);

//				var literalValueBinary = ReadLiteralValue(_binaryString);

//				var literalValueLength = literalValueBinary.Length + literalValueBinary.Length / 4;

//				value = Convert.ToInt64(literalValueBinary, 2);

//				packetSequence += _binaryString.Substring(0, literalValueLength);

//				_binaryString = _binaryString.Substring(literalValueLength, _binaryString.Length - literalValueLength);
//			}

//			return new Packet(packetSequence, value);
//		}

//		private string ReadLiteralValue(string binaryString)
//		{
//			var result = binaryString.Substring(1, 4);
//			if (binaryString[0] == '1')
//				result += ReadLiteralValue(binaryString.Substring(5, binaryString.Length - 5));
//			return result;
//		}

//		private long CalculatePackets(List<Packet> packetValues, int operation)
//		{
//			switch (operation)
//			{
//				case 0:
//					return packetValues.Select(p => p.Value).Sum();
//				case 1:
//					return packetValues.Select(p => p.Value).Aggregate((a, x) => a * x);
//				case 2:
//					return packetValues.Select(p => p.Value).Min();
//				case 3:
//					return packetValues.Select(p => p.Value).Max();
//				case 5:
//					return packetValues[0].Value > packetValues[1].Value ? 1 : 0;
//				case 6:
//					return packetValues[0].Value < packetValues[1].Value ? 1 : 0;
//				case 7:
//					return packetValues[0].Value == packetValues[1].Value ? 1 : 0;
//			}

//			return 0;
//		}

//		private class Packet
//		{
//			public string PacketSequence { get; set; }
//			public long Value { get; set; }

//			public Packet(string sequence, long value)
//			{
//				PacketSequence = sequence;
//				Value = value;
//			}
//		}
//	}
//}
