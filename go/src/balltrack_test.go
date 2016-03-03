package ballclock

import (
	"testing"
	. "github.com/smartystreets/goconvey/convey"
)

func TestBallTrack(t *testing.T) {
	Convey("NewBallTrack", t, func() {

		Convey("should create track at specified length", func() {
			t := NewBallTrack(5)
			So(len(t.balls), ShouldEqual, 5)
			So(t.currentPos, ShouldEqual, 0)
		})

	})

	Convey("AddBall", t, func() {

		Convey("should incriment the position", func() {
			t := NewBallTrack(2)
			b := t.AddBall(1)
			So(t.currentPos, ShouldEqual, 1)
			So(b, ShouldBeTrue)
		})

		Convey("should ", func() {
			t := NewBallTrack(2)
			t.AddBall(1)
			So(t.currentPos, ShouldEqual, 1)
		})

	})

	Convey("isFull", t, func() {

		Convey("should return true when full", func() {
			t := NewBallTrack(1)
			t.AddBall(1)
			So(t.IsFull(), ShouldBeTrue)
		})

		Convey("should return false when not full", func() {
			t := NewBallTrack(5)
			t.AddBall(1)
			t.AddBall(2)
			So(t.IsFull(), ShouldBeFalse)
		})

	})
}