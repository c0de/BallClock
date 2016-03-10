package ballclock

import (
	. "github.com/smartystreets/goconvey/convey"
	"testing"
)

func TestBallClock(t *testing.T) {
	Convey("New", t, func() {

		Convey("errors when given fewer then the min number balls", func() {
			c, e := New(1)
			So(c, ShouldEqual, nil)
			So(e, ShouldEqual, "number of balls must be 27 or more")
		})

		Convey("errors when given more then the max number of balls", func() {
			c, e := New(128)
			So(c, ShouldEqual, nil)
			So(e, ShouldEqual, "number of balls can not exceed 127")
		})

		Convey("creates a queue when given the correct number of balls", func() {
			balls := 27
			c, _ := New(balls)
			So(len(c.queue.balls), ShouldEqual, balls)
		})

	})

	Convey("Start", t, func() {

		Convey("returns a string starting with the number of balls given", func() {
			c, _ := New(27)
			So(c.Start(), ShouldStartWith, "27")
		})

		Convey("returns 15 days when given 30 balls", func() {
			c, _ := New(30)
			So(c.Start(), ShouldEqual, "30 balls cycle after 15 days")
		})

		Convey("returns 378 days when given 45 balls", func() {
			c, _ := New(45)
			So(c.Start(), ShouldEqual, "45 balls cycle after 378 days")
		})

	})
}
