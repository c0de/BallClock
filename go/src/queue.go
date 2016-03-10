package ballclock

type Queue struct {
	balls      []int
	currentPos int
}

func NewQueue(cap int) *Queue {
	q := new(Queue)
	q.balls = make([]int, cap, cap)

	for i := 0; i < cap; i++ {
		q.AddBall(i + 1)
	}

	return q
}

func (q *Queue) GetBall() int {
	b := q.balls[0]

	tmp := make([]int, len(q.balls), cap(q.balls))
	copy(tmp, q.balls[1:])
	q.balls = tmp
	q.currentPos -= 1

	return b
}

func (q *Queue) AddBall(b int) {
	q.balls[q.currentPos] = b
	q.currentPos += 1
}
