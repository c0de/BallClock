package ballclock

import (
	. "github.com/smartystreets/goconvey/convey"
	"testing"
)

func TestBallTrack(t *testing.T) {
	Convey("NewBallTrack", t, func() {

		Convey("should create track at specified length", func() {
			t := NewBallTrack(5, nil, nil)
			So(len(t.balls), ShouldEqual, 5)
			So(t.currentPos, ShouldEqual, 0)
		})

	})

	Convey("AddBall", t, func() {

		Convey("should incriment the position", func() {
			t := NewBallTrack(1, nil, nil)
			b := t.AddBall(1)
			So(t.currentPos, ShouldEqual, 1)
			So(b, ShouldBeTrue)
		})

		Convey("should ", func() {
			t := NewBallTrack(2, nil, nil)
			t.AddBall(1)
			So(t.currentPos, ShouldEqual, 1)
		})

	})

	Convey("isFull", t, func() {

		Convey("should return true when full", func() {
			t := NewBallTrack(1, nil, nil)
			t.AddBall(1)
			So(t.IsFull(), ShouldBeTrue)
		})

		Convey("should return false when not full", func() {
			t := NewBallTrack(5, nil, nil)
			t.AddBall(1)
			t.AddBall(2)
			So(t.IsFull(), ShouldBeFalse)
		})

	})

	Convey("returns to queue in reverse order and adds ball to next queue", t, func() {
		queue := NewQueue(3)
		hourTrack := NewBallTrack(2, queue, nil)
		minuteTrack := NewBallTrack(2, queue, hourTrack)
		minuteTrack.AddBall(queue.GetBall())
		minuteTrack.AddBall(queue.GetBall())
		minuteTrack.AddBall(queue.GetBall())
		So(hourTrack.balls[0], ShouldEqual, 3)
		So(queue.balls[0], ShouldEqual, 2)
		So(queue.balls[1], ShouldEqual, 1)
	})

	Convey("returns to queue in reverse order", t, func() {
		queue := NewQueue(4)
		hourTrack := NewBallTrack(2, queue, nil)
		hourTrack.AddBall(queue.GetBall())
		hourTrack.AddBall(queue.GetBall())
		hourTrack.AddBall(queue.GetBall())
		So(queue.balls[0], ShouldEqual, 4)
		So(queue.balls[1], ShouldEqual, 2)
		So(queue.balls[2], ShouldEqual, 1)
		So(queue.balls[3], ShouldEqual, 3)
	})

}
