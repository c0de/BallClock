package ballclock

type Queue struct {
	*BallTrack
}

func NewQueue(cap int) *Queue {
	q := new(Queue)
	q.BallTrack = NewBallTrack(cap)

	for i := 0; i < cap; i++ {
		q.AddBall(i+1)
	}

	return q
}

func (q *Queue) GetBall() int {
	b := q.balls[0]

	q.balls = q.balls[1:]

	return b;
}