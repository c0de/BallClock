package ballclock

type BallTrack struct {
	balls      []int
	currentPos int
	queue      *Queue
	nextTrack  *BallTrack
}

func NewBallTrack(cap int, queue *Queue, nextTrack *BallTrack) *BallTrack {
	t := new(BallTrack)
	t.balls = make([]int, cap, cap)
	t.queue = queue
	t.nextTrack = nextTrack
	return t
}

func (t *BallTrack) AddBall(b int) bool {
	f := t.IsFull()
	if !f {
		t.balls[t.currentPos] = b
		t.currentPos += 1
	} else {
		t.MoveBallsToQueue()
		t.MoveToNextTrack(b)
		t.Clear()
	}
	return !f
}

func (t *BallTrack) MoveBallsToQueue() {
	t.ReverseBalls()
	for _, i := range t.balls {
		t.queue.AddBall(i)
	}
}

func (t *BallTrack) MoveToNextTrack(b int) {
	if t.nextTrack != nil {
		t.nextTrack.AddBall(b)
	} else {
		t.queue.AddBall(b)
	}
}

func (t *BallTrack) ReverseBalls() {
	for i := (t.currentPos - 1) / 2; i >= 0; i-- {
		opp := t.currentPos - 1 - i
		t.balls[i], t.balls[opp] = t.balls[opp], t.balls[i]
	}
}

func (t *BallTrack) Clear() {
	t.balls = make([]int, cap(t.balls), cap(t.balls))
	t.currentPos = 0
}

func (t *BallTrack) IsFull() bool {
	return t.currentPos == cap(t.balls)
}
