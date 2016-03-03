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
        private List<int> _minuteTrack;

        public Queue Queue { get; private set; }

        public Clock(int balls)
        {
            if (balls < 27)
                throw new ArgumentException("number of balls must be 27 or more");
            if (balls > 127)
                throw new ArgumentException("number of balls can not exceed 127");

            this.Queue = new Queue();
            this._balls = new List<int>();
            this._minuteTrack = new List<int>();

            for (var i = 1; i <= balls; i++) {
                this.Queue.AddBall(i);
                this._balls.Add(i);
            }
        }

        public string Start()
        {
            this.AddMinute();

            return string.Format("{0}", _balls.Count());
        }

        private void AddMinute()
        {
            var ball = this.Queue.GetBall();
            if (this._minuteTrack.Count < 4)
            {
                this._minuteTrack.Add(ball);
            }
            else
            {
                this.MoveToQueue(this._minuteTrack);
                this.AddHour(ball);
                this._minuteTrack.Clear();
            }
        }

        private void AddHour(int ball)
        {
        }

        private void MoveToQueue(List<int> balls)
        {
            balls.Reverse();
            foreach (var ball in balls)
            {
                this.Queue.AddBall(ball);
            }
        }
    }
}
