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
            var track = new Track(length, null);
            Assert.AreEqual(length, track.MaxLength);
        }

        [TestCase]
        public void AddBall()
        {
            var track = new Track(5, null);
            track.AddBall(1);
            Assert.AreEqual(1, track.Length);
        }

        [TestCase]
        public void ReturnsToQueueInReverseOrderAndAddsBallToNextQueue()
        {
            var queue = new Queue();
            var hourTrack = new Track(2, queue);
            var minuteTrack = new Track(2, queue, hourTrack);
            minuteTrack.AddBall(1);
            minuteTrack.AddBall(2);
            minuteTrack.AddBall(3);
            Assert.AreEqual(0, minuteTrack.Length);
            Assert.AreEqual(1, hourTrack.Length);
            Assert.AreEqual(3, hourTrack[0]);
            Assert.AreEqual(2, queue.First());
            Assert.AreEqual(1, queue.Last());
        }

        [TestCase]
        public void ReturnsToQueueInReverseOrder()
        {
            var queue = new Queue();
            var hourTrack = new Track(2, queue);
            hourTrack.AddBall(1);
            hourTrack.AddBall(2);
            hourTrack.AddBall(3);
            Assert.AreEqual(0, hourTrack.Length);
            Assert.AreEqual(2, queue[0]);
            Assert.AreEqual(1, queue[1]);
            Assert.AreEqual(3, queue[2]);
        }
    }
}
