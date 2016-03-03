package ballclock

import (
	"testing"
	. "github.com/smartystreets/goconvey/convey"
)

func TestQueue(t *testing.T) {
	Convey("NewQueue", t, func() {

		Convey("should create queue of specified length", func() {
			t := NewQueue(5)
			So(len(t.balls), ShouldEqual, 5)
		})

	})

	Convey("getBall", t, func() {

		Convey("should get the next ball from the queue", func() {
			t := NewQueue(3)
			So(t.GetBall(), ShouldEqual, 1)
			So(len(t.balls), ShouldEqual, 2)
			So(t.balls[0], ShouldEqual, 2)
			So(t.balls[1], ShouldEqual, 3)
		})

	})
}