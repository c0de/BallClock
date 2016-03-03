class BallClock {
	private _minutes: number;
	private _balls: number[];
	private _queue: number[];
	private _minuteTrack: number[]; // 4;
	private _fiveMinuteTrack: number[]; // 11
	private _hourTrack: number[]; // 11
	
	constructor(balls: number) {
		if (balls === null || balls === undefined)
			throw 'balls can not be null';
		if (balls < 27)
			throw 'balls must be greater then 27';
		if (balls > 127)
			throw 'number of balls can not exceed 127';

		this._minutes = 0;
		this._balls = [];
		this._queue = [];
		this._minuteTrack = [];
		this._fiveMinuteTrack = [];
		this._hourTrack = [];

		for(var i = 1; i <= balls; i++) {
			this._balls.push(i);
			this._queue.push(i);
		}
	}

	private _nextBall(): number {
		return this._queue.shift();
	}

	private _addMinute() {
		var ball = this._nextBall();
		if (this._minuteTrack.length < 4) {
			this._minuteTrack.push(ball);	
		} else {
			this._moveToQueue(this._minuteTrack);
			this._addFiveMinute(ball);
			this._minuteTrack = [];
		}
		this._minutes += 1;
	}
	
	private _addFiveMinute(ball: number) {
		if (this._fiveMinuteTrack.length < 11) {
			this._fiveMinuteTrack.push(ball);	
		} else {
			this._moveToQueue(this._fiveMinuteTrack);
			this._addHour(ball);
			this._fiveMinuteTrack = [];
		}
	}
	
	private _addHour(ball) {
		if (this._hourTrack.length < 11) {
			this._hourTrack.push(ball);
		}
		else {
			this._moveToQueue(this._hourTrack);
			this._hourTrack = [];
			this._queue.push(ball);
		}
	}

	private _moveToQueue(balls: number[]) {
		balls.reverse().forEach((ball) => this._queue.push(ball));
	}

	start(): string {
		if (this._balls.length > 0) {
			var balls = JSON.stringify(this._balls);
			while (true) {
				this._addMinute();
				if (JSON.stringify(this._queue) === balls) {
					break;
				}
			}			
		}
		
		return `${this._balls.length} balls cycle after ${Math.round((this._minutes / 60) / 24)} days`;
	}
}
