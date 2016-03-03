using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallClock
{
    public class Queue
    {
        private List<int> _balls;
        public Queue()
        {
            this._balls = new List<int>();
        }

        public void AddBall(int ball)
        {
            this._balls.Add(ball);
        }

        public int GetBall()
        {
            var ball = this._balls.First();
            this._balls.RemoveAt(0);
            return ball;
        }

        public int Length
        {
            get
            {
                return this._balls.Count();
            }
        }

        public int First()
        {
            return this._balls.First();
        }

        public int Last()
        {
            return this._balls.Last();
        }
    }
}
