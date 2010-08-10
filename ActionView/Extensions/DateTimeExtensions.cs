using System;
using ActionPack.Common;
using ActionPack.Helpers;

namespace ActionPack.Extensions
{
    /// <summary>
    /// Time extensions, adopted from rails' actionsupport
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Return duration in seconds
        /// </summary>
        /// <param name="target">Number of seconds</param>
        /// <returns>The duration</returns>
        public static Duration Seconds(this int target)
        {
            return new Duration(0,0,0,target);
        }

        /// <summary>
        /// Return duration in minutes
        /// </summary>
        /// <param name="target">Number of minutes</param>
        /// <returns>The duration</returns>
        public static Duration Minutes(this int target)
        {
            return new Duration(0, 0, target, 0);
        }

        /// <summary>
        /// Return duration in hours
        /// </summary>
        /// <param name="target">Number of hours</param>
        /// <returns>The duration</returns>
        public static Duration Hours(this int target)
        {
            return new Duration(0, target, 0, 0);
        }

        /// <summary>
        /// Return duration in days
        /// </summary>
        /// <param name="target">Number of days</param>
        /// <returns>The duration</returns>
        public static Duration Days(this int target)
        {
            return new Duration(target, 0, 0, 0);
        }

        /// <summary>
        /// Return duration in months
        /// </summary>
        /// <param name="target">Number of months</param>
        /// <returns>The duration</returns>
        public static Duration Months(this int target)
        {
            return new Duration(target*30, 0, 0, 0);
        }

        /// <summary>
        /// Return duration in years
        /// </summary>
        /// <param name="target">Number of years</param>
        /// <returns>The duration</returns>
        public static Duration Years(this int target)
        {
            return new Duration(target * 365, 0, 0, 0);
        }

        /// <summary>
        /// Return duration in weeks
        /// </summary>
        /// <param name="target">Number of weeks</param>
        /// <returns>The duration</returns>
        public static Duration Weeks(this int target)
        {
            return new Duration(target * 7, 0, 0, 0);
        }

        /// <summary>
        /// Return duration in forthnights
        /// </summary>
        /// <param name="target">Number of forthnights</param>
        /// <returns>The duration</returns>
        public static Duration Fortnights(this int target)
        {
            return new Duration(target * 14, 0, 0, 0);
        }

        /// <summary>
        /// Return time ago. (from now)
        /// </summary>
        /// <param name="d">duration</param>
        /// <returns>The time</returns>
        public static DateTime Ago(this Duration d)
        {
            return d.Until(DateTime.Now);
        }

        /// <summary>
        /// Return time until duration
        /// </summary>
        /// <param name="d">The duration</param>
        /// <param name="time">Destination time</param>
        /// <returns>The time</returns>
        public static DateTime Until(this Duration d, DateTime time)
        {
            return time.Subtract(d.TimeSpan);
        }

        /// <summary>
        /// Return time since duration
        /// </summary>
        /// <param name="d">The duration</param>
        /// <param name="time">The time</param>
        /// <returns>The time</returns>
        public static DateTime Since(this Duration d, DateTime time)
        {
            return time.Add(d.TimeSpan);
        }

        /// <summary>
        /// Return time, duration from now
        /// </summary>
        /// <param name="d">The duration</param>
        /// <returns>The time</returns>
        public static DateTime FromNow(this Duration d)
        {
            return d.Since(DateTime.Now);
        }

        /// <summary>
        /// Yesterday
        /// </summary>
        /// <param name="target">Time</param>
        /// <returns>Yesterday</returns>
        public static DateTime Yesterday(this DateTime target)
        {
            return target.AddDays(-1);
        }

        /// <summary>
        /// Tomorrow
        /// </summary>
        /// <param name="target">Time</param>
        /// <returns>Tomorrow</returns>
        public static DateTime Tomorrow(this DateTime target)
        {
            return target.AddDays(1);
        }

        /// <summary>
        /// Last month
        /// </summary>
        /// <param name="target">Time</param>
        /// <returns>Last month</returns>
        public static DateTime LastMonth(this DateTime target)
        {
            return target.AddMonths(-1);
        }

        /// <summary>
        /// Next month
        /// </summary>
        /// <param name="target">Time</param>
        /// <returns>Next month</returns>
        public static DateTime NextMonth(this DateTime target)
        {
            return target.AddMonths(1);
        }

        /// <summary>
        /// Last year
        /// </summary>
        /// <param name="target">Time</param>
        /// <returns>Last year</returns>
        public static DateTime LastYear(this DateTime target)
        {
            return target.AddYears(-1);
        }

        /// <summary>
        /// Next year
        /// </summary>
        /// <param name="target">Time</param>
        /// <returns>Next year</returns>
        public static DateTime NextYear(this DateTime target)
        {
            return target.AddYears(1);
        }

        public static string TimeAgoInWords(this DateTime target, bool includeSeconds)
        {
            return DateHelper.TimeAgoInWords(target, includeSeconds);
        }
        public static string DistanceOfTimeInWords(this DateTime target, DateTime toTime, bool includeSeconds)
        {
            return DateHelper.DistanceOfTimeInWords(target, toTime, includeSeconds);
        }

        public static string DistanceOfTimeInWords(this DateTime target, bool includeSeconds)
        {
            return DateHelper.DistanceOfTimeInWordsToNow(target, includeSeconds);
        }
    }
}