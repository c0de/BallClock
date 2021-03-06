﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallClock.Tests
{
	public class ClockTests
	{
		[TestCase]
		public void CanCreateClock()
		{
			var expected = 27;
			var clock = new Clock(expected);

			Assert.AreEqual(expected, clock.Queue.Count());
			Assert.AreEqual(1, clock.Queue.First());
			Assert.AreEqual(27, clock.Queue.Last());
		}

		[TestCase]
		[ExpectedException(typeof(ArgumentException),
				ExpectedMessage = "number of balls must be 27 or more")]
		public void ThrowsErrorWhenBallsLessThenMin()
		{
			new Clock(1);
		}

		[TestCase]
		[ExpectedException(typeof(ArgumentException),
				ExpectedMessage = "number of balls can not exceed 127")]
		public void ThrowsErrorWhenBallsMoreThenMax()
		{
			new Clock(128);
		}

		[TestCase]
		public void Run_ReturnsStringStartingWithTheNumberOfBallsGiven()
		{
			var expected = 27;
			var clock = new Clock(expected);
			Assert.IsTrue(clock.Start().StartsWith(expected.ToString()));
		}

		[TestCase]
		public void Run_Returns15DaysWhenGiven30Balls()
		{
			var clock = new Clock(30);
			Assert.AreEqual("30 balls cycle after 15 days", clock.Start());
		}

		[TestCase]
		public void Run_Returns378DaysWhenGiven45Balls()
		{
			var clock = new Clock(45);
			Assert.AreEqual("45 balls cycle after 378 days", clock.Start());
		}

		/// <summary>
		/// Runs all tests 27-127
		/// </summary>
		//[TestCase]
		public void Run_All()
		{
			for (int i = 27; i <= 127; i++)
			{
				var clock = new Clock(i);
				var result = clock.Start();
				Assert.IsTrue(result.StartsWith(i.ToString()));
			}
		}
	}
}
