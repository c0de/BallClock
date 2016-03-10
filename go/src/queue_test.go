package ballclock

import (
	. "github.com/smartystreets/goconvey/convey"
	"testing"
)

func TestQueue(t *testing.T) {
	Convey("NewQueue", t, func() {

		Convey("should create queue of specified length", func() {
			t := NewQueue(5)
			So(len(t.balls), ShouldEqual, 5)
		})

	})

	Convey("GetBall", t, func() {

		Convey("should get the next ball from the queue", func() {
			q := NewQueue(2)
			So(q.GetBall(), ShouldEqual, 1)
			So(q.balls[0], ShouldEqual, 2)
		})

		Convey("should get balls from the queue", func() {
			q := NewQueue(5)
			So(q.GetBall(), ShouldEqual, 1)
			So(q.GetBall(), ShouldEqual, 2)
			So(q.GetBall(), ShouldEqual, 3)
			So(q.GetBall(), ShouldEqual, 4)
			So(q.GetBall(), ShouldEqual, 5)
		})

	})

	Convey("AddBall", t, func() {

		Convey("should get balls from the queue", func() {
			q := NewQueue(2)
			b1 := q.GetBall()
			b2 := q.GetBall()

			q.AddBall(b2)
			q.AddBall(b1)

			So(q.balls[0], ShouldEqual, 2)
			So(q.balls[1], ShouldEqual, 1)
		})

	})
}
