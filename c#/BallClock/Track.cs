using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallClock
{
    public class Track
    {
        public int MaxLength { get; private set; }
        private List<int> _balls;
        private Queue _queue;
        private Track _nextTrack;

        public Track(int maxLength, Queue queue, Track nextTrack = null)
        {
            this.MaxLength = maxLength;
            this._balls = new List<int>();
            this._queue = queue;
            this._nextTrack = nextTrack;
        }

        public int this[int index]
        {
            get
            {
                return this._balls[index];
            }
        }

        public int Length
        {
            get
            {
                return this._balls.Count;
            }
        }

        private bool IsFull()
        {
            return this.Length == this.MaxLength;
        }

        public void AddBall(int ball)
        {
            if (!this.IsFull())
            {
                this._balls.Add(ball);
            }
            else
            {
                this.MoveBallsToQueue();
                this.MoveToNextTrack(ball);
                this._balls.Clear();
            }
        }

        private void MoveBallsToQueue()
        {
            this._balls.Reverse();
            foreach (var ball in this._balls)
            {
                this._queue.AddBall(ball);
            }
        }

        private void MoveToNextTrack(int ball)
        {
            if (_nextTrack != null)
            {
                this._nextTrack.AddBall(ball);
            }
            else
            {
                this._queue.AddBall(ball);
            }
        }
    }
}
