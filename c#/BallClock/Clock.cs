using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallClock
{
    public class Clock
    {
        private List<int> _balls;
        private Track _minuteTrack;
        private Track _fiveTrack;
        private Track _hourTrack;

        public Queue Queue { get; private set; }

        public Clock(int balls)
        {
            if (balls < 27)
                throw new ArgumentException("number of balls must be 27 or more");
            if (balls > 127)
                throw new ArgumentException("number of balls can not exceed 127");

            this.Queue = new Queue();
            this._balls = new List<int>();
            this._hourTrack = new Track(11, this.Queue);
            this._fiveTrack = new Track(11, this.Queue, this._hourTrack);
            this._minuteTrack = new Track(4, this.Queue, this._fiveTrack);

            for (var i = 1; i <= balls; i++) {
                this.Queue.AddBall(i);
                this._balls.Add(i);
            }
        }

        public string Start()
        {
            var minutes = 0;
            while (true)
            {
                this._minuteTrack.AddBall(this.Queue.GetBall());
                minutes += 1;
                if (this._balls.SequenceEqual(this.Queue.Balls))
                    break;
            }

            return string.Format("{0} balls cycle after {1} days", _balls.Count(), (minutes / 60) / 24);
        }
    }
}
