package ballclock

import (
	"testing"
	. "github.com/smartystreets/goconvey/convey"
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

		Convey("sets minutes when given the correct number of balls", func() {
			c, _ := New(27)
			So(c.minutes, ShouldEqual, 0)
		})

		Convey("sets queue when given the correct number of balls", func() {
			balls := 27
			c, _ := New(balls)
			So(len(c.queue.balls), ShouldEqual, balls)
		})

  })
}