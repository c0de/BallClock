using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallClock.Tests
{
    public class BallTrackTests
    {
        [TestCase]
        public void CanCreateInstance()
        {
            var track = new BallTrack();
            Assert.IsInstanceOf<BallTrack>(track);
        }
    }
}
