package ballclock

const MIN_BALLS = 27
const MAX_BALLS = 127

type BallClock struct {
	minutes int
	minuteTrack *BallTrack
	fiveTrack *BallTrack
	hourTrack *BallTrack
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
	c.minuteTrack = NewBallTrack(4)
	c.fiveTrack = NewBallTrack(11)
	c.hourTrack = NewBallTrack(11)
	c.queue = NewQueue(balls)
	return c, ""
}

func AddMinute(c *BallClock) {
	
}