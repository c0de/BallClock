
describe('ballclock', () => {
	it ('is an object', () => {
		expect(typeof BallClock).toBe('function');
	});
	
	describe('constructor', () => {
		it ('accepts a number of balls and creates a queue', () => {
			var clock = new BallClock(27);
			var expected = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27];
			expect((<any>clock)._balls).toEqual(expected);
			expect((<any>clock)._queue).toEqual(expected);
		});
		
		it ('throws an exception when given null', () => {
			expect(() => { new BallClock(null); }).toThrow('balls can not be null');		
		});

		it ('throws an exception when given a negative value', () => {
			expect(() => { new BallClock(-1); }).toThrow('balls must be greater then 27');		
		});

		it ('throws an exception when given a number less then 27', () => {
			expect(() => { new BallClock(1); }).toThrow('balls must be greater then 27');		
		});

		it ('throws an exception when given a number greater then 127', () => {
			expect(() => { new BallClock(128); }).toThrow('number of balls can not exceed 127');		
		});
	});

	describe('start()', () => {
		it ('returns a string starting with the number of balls given', () => {
			var balls = 27;
			var expected = new BallClock(balls).start().substring(0, balls.toString().length);
			expect(expected).toEqual(balls.toString());
		});
	});
	
	describe('nextBall()', () => {
		it ('returns the first ball in the queue', () => {
			var clock = <any>new BallClock(27);
			expect(clock._nextBall()).toEqual(1);
			expect(clock._nextBall()).toEqual(2);
			expect(clock._nextBall()).toEqual(3);
			expect(clock._nextBall()).toEqual(4);
			expect(clock._nextBall()).toEqual(5);
		});
	});
	
	describe('addMinute()', () => {
		it ('moves the first ball from the queue to the minute track', () => {
			var clock = <any>new BallClock(27);
			clock._addMinute();
			expect(clock._queue).toEqual([2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27]);
			expect(clock._minuteTrack).toEqual([1]);
		});
		it ('moves moves the 5th ball to the 5 minute track and returns the other balls to the queue in reverse order', () => {
			var clock = <any>new BallClock(27);
			clock._addMinute();
			clock._addMinute();
			clock._addMinute();
			clock._addMinute();
			clock._addMinute();
			expect(clock._queue).toEqual([6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 4, 3, 2, 1]);
			expect(clock._minuteTrack).toEqual([]);
			expect(clock._fiveMinuteTrack).toEqual([5]);
		});		
	});
	
	describe('addFiveMinute()', () => {
		it ('moves the given ball to the five minute track', () => {
			var clock = <any>new BallClock(27);
			clock._addFiveMinute(5);
			expect(clock._fiveMinuteTrack).toEqual([5]);
		});
		it ('moves moves the 12th ball to the hour track and returns the other balls to the queue in reverse order', () => {
			var clock = <any>new BallClock(27);
			clock._queue = [];
			clock._fiveMinuteTrack = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11];
			clock._addFiveMinute(12);
			expect(clock._fiveMinuteTrack).toEqual([]);
			expect(clock._hourTrack).toEqual([12]);
			expect(clock._queue).toEqual([11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1]);
		});		
	});
	
	describe('addHour()', () => {
		it ('moves the given ball to the hour track', () => {
			var clock = <any>new BallClock(27);
			clock._addHour(1);
			expect(clock._hourTrack).toEqual([1]);
		});
		it ('moves moves the 12th and subsequent balls to the queue in reverse order', () => {
			var clock = <any>new BallClock(27);
			clock._queue = [];
			clock._hourTrack = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
			clock._addHour(12);
			expect(clock._hourTrack).toEqual([]);
			expect(clock._queue).toEqual([11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 12]);
		});		
	});
	
	describe('expected outputs', () => {
		it ('returns 15 days when given 30 balls', () => {
			expect(new BallClock(30).start()).toEqual("30 balls cycle after 15 days");
		});
		it ('returns 378 days when given 45 balls', () => {
			expect(new BallClock(45).start()).toEqual("45 balls cycle after 378 days");
		});
	});
});