using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ActionSupport
{
    public class Duration 
    {
        TimeSpan t = new TimeSpan();
        public  TimeSpan TimeSpan { get { return t; } }

        public int Days { get { return t.Days; } }
        public int Hours { get { return t.Hours; } }
        public int Milliseconds { get { return t.Milliseconds; } }
        public int Minutes { get { return t.Minutes; } }
        public int Seconds { get { return t.Seconds; } }
        public long Ticks { get { return t.Ticks; } }
        public double TotalDays { get { return t.TotalDays; } }
        public double TotalHours { get { return t.TotalHours; } }
        public double TotalMilliseconds { get { return t.TotalMilliseconds; } }
        public double TotalMinutes { get { return t.TotalMinutes; } }
        public double TotalSeconds { get { return t.TotalSeconds; } }

        public Duration(int days, int hours, int minutes, int seconds, int milliseconds)
        {
            t = new TimeSpan(days, hours, minutes, seconds, milliseconds);
        }
        public Duration(int days, int hours, int minutes, int seconds)
        {
            t = new TimeSpan(days, hours, minutes, seconds);
        }
        public Duration(int hours, int minutes, int seconds)
        {
            t = new TimeSpan(hours, minutes, seconds);
        }
        public Duration(long ticks)
        {
            t = new TimeSpan(ticks);
        }
        private Duration(TimeSpan ts)
        {
            t = ts;
        }
        public Duration Add(Duration d)
        {
            return new Duration(TimeSpan.Add(d.TimeSpan));
        }
        public int CompareTo(object o)
        {
            return t.CompareTo(o);
        }
        public int CompareTo(Duration d)
        {
            return t.CompareTo(d.TimeSpan);
        }
        public override int  GetHashCode()
        {
             return TimeSpan.GetHashCode();
        }
        public override bool Equals(object o)
        {
            return t.Equals(o);
        }
        public bool Equals(Duration d)
        {
            return t.Equals(d.TimeSpan);
        }
        public Duration Negate()
        {
            return new Duration(TimeSpan.Negate());
        }
        public Duration Subtract(Duration d)
        {
            return new Duration(TimeSpan.Subtract(d.TimeSpan));
        }
        public override string ToString()
        {
            return TimeSpan.ToString();
        }
        public static bool operator >(Duration l, Duration r)
        {
            return l.TimeSpan > r.TimeSpan;
        }
        public static bool operator <(Duration l, Duration r)
        {
            return l.TimeSpan < r.TimeSpan;
        }
        public static bool operator <=(Duration l, Duration r)
        {
            return l.TimeSpan <= r.TimeSpan;
        }
        public static bool operator >=(Duration l, Duration r)
        {
            return l.TimeSpan >= r.TimeSpan;
        }
        public static bool operator ==(Duration l, Duration r)
        {
            return l.Equals(r);
        }
        public static bool operator !=(Duration l, Duration r)
        {
            return !(l == r);
        }
        public static Duration operator +(Duration l, Duration r)
        {
            return new Duration(l.TimeSpan + r.TimeSpan);
        }
        public static Duration operator -(Duration l, Duration r)
        {
            return new Duration(l.TimeSpan + r.TimeSpan);
        }
        public static Duration operator *(Duration l, int r)
        {
            return new Duration(l.TimeSpan.Ticks * r);
        }
        public static Duration operator *(int l, Duration r)
        {
            return r*l;
        }
    }
}
