/*
The MIT License (MIT)

Copyright (c) 2014 https://github.com/joshyy/DateDiff

Permission is hereby granted, free of charge, to any person obtaining a copy of
this software and associated documentation files (the "Software"), to deal in
the Software without restriction, including without limitation the rights to
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
the Software, and to permit persons to whom the Software is furnished to do so,
subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
using System;


public class DateDiff {
	
	/// DateDiff 3 -- returns the date 3 days in the future
	public DateDiff(int i) {
		DateTime d = DateTime.Today.AddDays(i);
		Console.WriteLine("{0:d}", d);
	}
	
	/// DateDiff 2014-01-01 8 -- returns the date 8 days after 2014-01-01
	public DateDiff(DateTime td, int i) {
		DateTime d = td.AddDays(i);
		Console.WriteLine("{0:d}", d);
	}
	
	/// DateDiff 2014-01-01 2014-03-01 -- returns the number of days between the dates
	public DateDiff(DateTime a, DateTime b) {
		TimeSpan span = b - a;
		Console.WriteLine(span.Days);
	}
	
	public static void Main(string[] args) {
		if (args.Length == 1) {
			int i = 0;
			int.TryParse(args[0], out i);
			new DateDiff(i);
		} else if (args.Length == 2) {				
			// first arg must be a date
			DateTime dt0 = DateTime.MinValue;
			DateTime.TryParse(args[0], out dt0);
			
			// second arg may be int or date
			DateTime dt1 = DateTime.MinValue;	
			DateTime.TryParse(args[1], out dt1);
			
			if (dt1 > DateTime.MinValue) {
				// calculate the difference between the given days
				new DateDiff(dt0, dt1);
			} else {
				// calculate the number of days +- the date given
				int i = 0;	
				int.TryParse(args[1], out i);
				new DateDiff(dt0, i);
			}
		} else {
			Console.WriteLine("Usage: DateDiff 80");
			Console.WriteLine("or Usage: DateDiff yyyy-mm-dd 80");
			Console.WriteLine("or Usage: DateDiff yyyy-mm-dd yyyy-mm-dd");
		}
	}
}
