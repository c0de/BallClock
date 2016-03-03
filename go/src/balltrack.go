package ballclock

type BallTrack struct {
	balls []int
	currentPos int
}

func NewBallTrack(cap int) *BallTrack {
	t := new(BallTrack)
	t.balls = make([]int, cap, cap)
	return t
}

func (t *BallTrack) AddBall(b int) bool {
	f := t.IsFull()
	if (!f) {
		t.balls[t.currentPos] = b
		t.currentPos += 1
	}
	return !f
}

func (t *BallTrack) IsFull() bool {
	return t.currentPos == cap(t.balls)
}