package ballclock

import (
	"fmt"
	"reflect"
)

const MIN_BALLS = 27
const MAX_BALLS = 127

type BallClock struct {
	queue *Queue
}

func New(balls int) (ballClock *BallClock, err string) {
	if balls < MIN_BALLS {
		return nil, "number of balls must be 27 or more"
	}
	if balls > MAX_BALLS {
		return nil, "number of balls can not exceed 127"
	}

	c := new(BallClock)
	c.queue = NewQueue(balls)

	return c, ""
}

func (c *BallClock) Start() string {
	minutes := 0
	startingQueue := c.queue.balls
	hourTrack := NewBallTrack(11, c.queue, nil)
	fiveTrack := NewBallTrack(11, c.queue, hourTrack)
	minuteTrack := NewBallTrack(4, c.queue, fiveTrack)

	for {
		minuteTrack.AddBall(c.queue.GetBall())
		minutes += 1
		if reflect.DeepEqual(startingQueue, c.queue.balls) {
			break
		}
	}

	return fmt.Sprintf("%v balls cycle after %v days", len(c.queue.balls), (minutes/60)/24)
}
