using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallClock
{
    public class Queue
    {
        public List<int> Balls { get; private set; }

        public Queue()
        {
            this.Balls = new List<int>();
        }

        public void AddBall(int ball)
        {
            this.Balls.Add(ball);
        }

        public int this[int index]
        {
            get
            {
                return this.Balls[index];
            }
        }

        public int GetBall()
        {
            var ball = this.Balls.First();
            this.Balls.RemoveAt(0);
            return ball;
        }

        public int Length
        {
            get
            {
                return this.Balls.Count();
            }
        }

        public int First()
        {
            return this.Balls.First();
        }

        public int Last()
        {
            return this.Balls.Last();
        }
    }
}
