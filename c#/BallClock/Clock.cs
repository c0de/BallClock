using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallClock
{
    public class Clock
    {
        private IEnumerable<int> _originalQueue;
        public Queue<int> Queue { get; private set; }

        public Clock(int balls)
        {
            if (balls < 27)
                throw new ArgumentException("number of balls must be 27 or more");
            if (balls > 127)
                throw new ArgumentException("number of balls can not exceed 127");

            this.Queue = new Queue<int>();
            for (var i = 1; i <= balls; i++) {
                this.Queue.Enqueue(i);
            }
            this._originalQueue = this.Queue.ToArray();
        }

        private bool AreQueuesEqual()
        {
            return this._originalQueue.SequenceEqual(this.Queue);
        }

        public string Start()
        {
            Track minuteTrack, fiveTrack, hourTrack;

            hourTrack = new Track(this.Queue, 11);
            fiveTrack = new Track(this.Queue, 11, hourTrack);
            minuteTrack = new Track(this.Queue, 4, fiveTrack);

            var minutes = 0;
            while (true)
            {
                minuteTrack.AddBall(this.Queue.Dequeue());
                minutes += 1;
                if (this.AreQueuesEqual())
                    break;
            }

            return string.Format("{0} balls cycle after {1} days", _originalQueue.Count(), (minutes / 60) / 24);
        }
    }
}
