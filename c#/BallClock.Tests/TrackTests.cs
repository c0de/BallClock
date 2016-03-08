using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallClock.Tests
{
	public class TrackTests
	{
		[TestCase]
		public void CreateTrackWithSpecifiedLength()
		{
			var length = 5;
			var track = new Track(null, length);
			Assert.AreEqual(length, track.Capacity);
		}

		[TestCase]
		public void CanAddBallToTrack()
		{
			var track = new Track(null, 5);
			track.AddBall(1);
			Assert.AreEqual(1, track.Length);
		}

		[TestCase]
		public void IsFull()
		{
			var track = new Track(null, 1);
			track.AddBall(1);
			Assert.IsTrue(track.IsFull());
		}

		[TestCase]
		public void ReturnsToQueueInReverseOrderAndAddsBallToNextQueue()
		{
			var queue = new Queue<int>();
			var hourTrack = new Track(queue, 2);
			var minuteTrack = new Track(queue, 2, hourTrack);
			minuteTrack.AddBall(1);
			minuteTrack.AddBall(2);
			minuteTrack.AddBall(3);
			Assert.AreEqual(0, minuteTrack.Length);
			Assert.AreEqual(1, hourTrack.Length);
			Assert.AreEqual(3, hourTrack.First());
			Assert.AreEqual(2, queue.First());
			Assert.AreEqual(1, queue.Last());
		}

		[TestCase]
		public void ReturnsToQueueInReverseOrder()
		{
			var queue = new Queue<int>();
			var hourTrack = new Track(queue, 2);
			hourTrack.AddBall(1);
			hourTrack.AddBall(2);
			hourTrack.AddBall(3);
			Assert.AreEqual(0, hourTrack.Length);
			Assert.AreEqual(2, queue.First());
			Assert.AreEqual(3, queue.Last());
		}
	}
}
