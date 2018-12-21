using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTests.TaskCoreTests
{
	internal static class TestHelper
	{
		private static readonly Random Random = new Random();
		public static string RandomStringGenerator(int requiredLength)
		{
			string allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			return new string(Enumerable.Repeat(allowedChars, requiredLength)
		        .Select(s => s[Random.Next(s.Length)]).ToArray());
        }
	}
}
