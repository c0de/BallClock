using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallClock.Tests
{
    public class QueueTests
    {
        [TestCase]
        public void GetBall()
        {
            var queue = new Queue();
            queue.AddBall(1);
            queue.AddBall(2);
            Assert.AreEqual(1, queue.GetBall());
            Assert.AreEqual(1, queue.Length);
        }
    }
}
