using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallClock
{
	public class Track
	{
		public int Capacity { get; private set; }
		private Stack<int> _balls;
		private Queue<int> _queue;
		private Track _nextTrack;

		public Track(Queue<int> queue, int capacity, Track nextTrack = null)
		{
			this._queue = queue;
			this.Capacity = capacity;
			this._balls = new Stack<int>(capacity);
			this._nextTrack = nextTrack;
		}

		public int Length
		{
			get
			{
				return this._balls.Count;
			}
		}

		public bool IsFull()
		{
			return this.Length == this.Capacity;
		}

		public void AddBall(int ball)
		{
			if (!this.IsFull())
			{
				this._balls.Push(ball);
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
				this._queue.Enqueue(ball);
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
				this._queue.Enqueue(ball);
			}
		}

		public int First()
		{
			return this._balls.First();
		}
	}
}
