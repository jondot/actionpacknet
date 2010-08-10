using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ActionSupport
{
    public static class TimeExtensions
    {
        public static Duration Seconds(this int target)
        {
            return new Duration(0,0,0,target);
        }
        public static Duration Minutes(this int target)
        {
            return new Duration(0, 0, target, 0);
        }
        public static Duration Hours(this int target)
        {
            return new Duration(0, target, 0, 0);
        }
        public static Duration Days(this int target)
        {
            return new Duration(target, 0, 0, 0);
        }
        public static Duration Months(this int target)
        {
            return new Duration(target*30, 0, 0, 0);
        }
        public static Duration Years(this int target)
        {
            return new Duration(target * 365, 0, 0, 0);
        }
        public static Duration Weeks(this int target)
        {
            return new Duration(target * 7, 0, 0, 0);
        }
        public static Duration Fortnights(this int target)
        {
            return new Duration(target * 14, 0, 0, 0);
        }
        public static DateTime Ago(this Duration d)
        {
            return d.Until(DateTime.Now);
        }
        public static DateTime Until(this Duration d, DateTime time)
        {
            return time.Subtract(d.TimeSpan);
        }
        public static DateTime Since(this Duration d, DateTime time)
        {
            return time.Add(d.TimeSpan);
        }
        public static DateTime FromNow(this Duration d)
        {
            return d.Since(DateTime.Now);
        }
        public static DateTime Yesterday(this DateTime target)
        {
            return target.AddDays(-1);
        }
        public static DateTime Tomorrow(this DateTime target)
        {
            return target.AddDays(1);
        }
        public static DateTime LastMonth(this DateTime target)
        {
            return target.AddMonths(-1);
        }
        public static DateTime NextMonth(this DateTime target)
        {
            return target.AddMonths(1);
        }
        public static DateTime LastYear(this DateTime target)
        {
            return target.AddYears(-1);
        }
        public static DateTime NextYear(this DateTime target)
        {
            return target.AddYears(1);
        }
    }
}
