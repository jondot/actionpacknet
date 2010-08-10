using System;
using System.Text;

namespace ActionPack.Helpers
{
    /// <summary>
    /// Date processing additions and HTML generation, adopted from Rails' actionview.
    /// </summary>
    public class DateHelper
    {
        private const string TIME_SEPARATOR = " : ";
        private const string DATE_SEPARATOR = " / ";
        private const string DATETIME_SEPARATOR = " - ";
        private const string DAY_SUFFIX = "Day";
        private const string MONTH_SUFFIX = "Month";
        private const string YEAR_SUFFIX = "Year";
        private const string HOUR_SUFFIX = "Hour";
        private const string MINUTE_SUFFIX = "Minute";
        private const string SECOND_SUFFIX = "Second";

        public class SelectYearOptions
        {
            
        }

        /// <summary>
        /// Desribe the distance of time in words.
        /// </summary>
        /// <param name="fromTime">Start time</param>
        /// <param name="toTime">End time</param>
        /// <param name="includeSeconds">Include seconds in description</param>
        /// <returns>Description of time span</returns>
        public static string DistanceOfTimeInWords(DateTime fromTime, DateTime toTime, bool includeSeconds)
        {
            TimeSpan distance = fromTime.Subtract(toTime);
            int distMin = Math.Abs((int)Math.Round(distance.TotalMinutes));
            int distSec = Math.Abs((int)Math.Round(distance.TotalSeconds));
            if (inRange(distMin, 0, 1))
            {
                if (!includeSeconds)
                    return distMin == 0 ? "less than a minute" : "1 minute";
                if (inRange(distSec, 0, 4))
                    return "less than 5 seconds";
                if (inRange(distSec, 5, 9))
                    return "less than 10 seconds";
                if (inRange(distSec, 10, 19))
                    return "less than 20 seconds";
                if (inRange(distSec, 20, 39))
                    return "half a minute";
                if (inRange(distSec, 40, 59))
                    return "less than a minute";
                return "1 minute";
            }
            if (inRange(distMin, 2, 44))
                return distMin + "minutes";
            if (inRange(distMin, 45, 89))
                return "about 1 hour";
            if (inRange(distMin, 90, 1439))
                return "about " + (int)Math.Round(distMin / 60.0) + " hours";
            if (inRange(distMin, 1440, 2879))
                return "1 day";
            if (inRange(distMin, 2880, 43199))
                return (int)Math.Round(distMin / 1440.0) + " days";
            if (inRange(distMin, 43200, 86399))
                return "about 1 month";
            if (inRange(distMin, 86400, 525599))
                return (int)Math.Round(distMin / 43200.0) + " months";
            if (inRange(distMin, 525600, 1051199))
                return "about 1 year";
            
            return "over " + (int)Math.Round(distMin / 525600.0) + " years";
        }

        /// <summary>
        /// Describe distance of time in words till now
        /// </summary>
        /// <param name="fromTime">Time to start from</param>
        /// <param name="includeSeconds">Include seconds in description</param>
        /// <returns>Description of time in words</returns>
        public static string DistanceOfTimeInWordsToNow(DateTime fromTime, bool includeSeconds)
        {
            return TimeAgoInWords(fromTime, includeSeconds);
        }
        public static string TimeAgoInWords(DateTime fromTime, bool includeSeconds)
        {
            return DistanceOfTimeInWords(fromTime, DateTime.Now, includeSeconds);
        }

        /// <summary>
        /// Generate an Html select for a date/time.
        /// </summary>
        /// <param name="id">Element id</param>
        /// <param name="datetime">Time to currently display</param>
        /// <returns>Html element text</returns>
        public static string SelectDateTime(string id, DateTime datetime)
        {
            return SelectDate(id, datetime, true) + DATETIME_SEPARATOR+ SelectTime(id, datetime, true);
        }

        /// <summary>
        /// Generate an Html select for a date.
        /// </summary>
        /// <param name="id">Element id</param>
        /// <param name="date">Time to currently display</param>
        /// <param name="useShortMonths">Use short description for months</param>
        /// <returns>Html element text</returns>
        public static string SelectDate(string id, DateTime date, bool useShortMonths)
        {
            return SelectDay(id + DAY_SUFFIX, id + DAY_SUFFIX, date.Day, false, false)
                   + DATE_SEPARATOR
                   + SelectMonth(id + MONTH_SUFFIX, id + MONTH_SUFFIX, date.Month, useShortMonths, false, false)
                   + DATE_SEPARATOR
                   + SelectYear(id + YEAR_SUFFIX, id + YEAR_SUFFIX, date.Year, false, false);
        }

        /// <summary>
        /// Generate an Html select for a date.
        /// </summary>
        /// <param name="id">Element id</param>
        /// <param name="name">Element name</param>
        /// <param name="date">Time to currently display</param>
        /// <param name="monthNames">Custom month names array</param>
        /// <param name="isDisabled">True if the component is disabled</param>
        /// <param name="includesBlank">Include a blank selection</param>
        /// <returns>Html element text</returns>
        public static string SelectDate(string id, string name, DateTime date, string [] monthNames, bool isDisabled, bool includesBlank)
        {
            return SelectDay(id + DAY_SUFFIX, name + DAY_SUFFIX, date.Day, isDisabled, includesBlank)
                   + DATE_SEPARATOR
                   + SelectMonth(id + MONTH_SUFFIX, name + MONTH_SUFFIX, date.Month, monthNames, isDisabled, includesBlank)
                   + DATE_SEPARATOR
                   + SelectYear(id + YEAR_SUFFIX, name + YEAR_SUFFIX, date.Year, isDisabled, includesBlank);
        }

        /// <summary>
        /// Generate an Html select for a time.
        /// </summary>
        /// <param name="id">Element id</param>
        /// <param name="time">Time to currently display</param>
        /// <param name="includeSeconds">Include seconds field</param>
        /// <returns>Html element text</returns>
        public static string SelectTime(string id, DateTime time, bool includeSeconds)
        {
            return SelectTime(id, id, time, includeSeconds, false, false);
        }

        /// <summary>
        /// Generate an Html select for a time.
        /// </summary>
        /// <param name="id">Element id</param>
        /// <param name="name">Element name</param>
        /// <param name="time">Time to currently display</param>
        /// <param name="includeSeconds">Include seconds field</param>
        /// <param name="isDisabled">True if element is disabled</param>
        /// <param name="includesBlank">Include a blank entry</param>
        /// <returns>Html element text</returns>
        public static string SelectTime(string id, string name, DateTime time, bool includeSeconds, bool isDisabled, bool includesBlank)
        {
            return
                SelectHour(id + HOUR_SUFFIX, name + HOUR_SUFFIX, time.Hour, isDisabled, includesBlank) + TIME_SEPARATOR + SelectMinute(id + MINUTE_SUFFIX, name + MINUTE_SUFFIX, time.Minute, isDisabled, includesBlank) + (includeSeconds
                                                                                                                                                                                                                                ? TIME_SEPARATOR + SelectSecond(id + SECOND_SUFFIX, name + SECOND_SUFFIX, time.Second, isDisabled, includesBlank)
                                                                                                                                                                                                                                : "");
        }

        /// <summary>
        /// Generate a selection for seconds
        /// </summary>
        /// <param name="id">Element id</param>
        /// <param name="name">Element name</param>
        /// <param name="selectedSecond">Second to currently display</param>
        /// <param name="isDisabled">True if element is disabled</param>
        /// <param name="includesBlank">Include a blank entry</param>
        /// <returns>Html element text</returns>
        public static string SelectSecond(string id, string name, int selectedSecond, bool isDisabled, bool includesBlank)
        {
            return SelectMinute(id, name, selectedSecond, isDisabled, includesBlank);
        }

        /// <summary>
        /// Generate a selection for minutes.
        /// </summary>
        /// <param name="id">Element id</param>
        /// <param name="selectedMinute">Minute to currently display</param>
        /// <returns>Html element text</returns>
        public static string SelectMinute(string id, int selectedMinute)
        {
            return SelectMinute(id, id, selectedMinute, false, false);
        }

        /// <summary>
        /// Generate a selection for minutes.
        /// </summary>
        /// <param name="id">Element id</param>
        /// <param name="name">Element name</param>
        /// <param name="selectedMinute">Minute to currently display</param>
        /// <param name="isDisabled">True if element is disabled</param>
        /// <param name="includesBlank">Include a blank entry</param>
        /// <returns>Html element text</returns>
        public static string SelectMinute(string id, string name, int selectedMinute, bool isDisabled, bool includesBlank)
        {
            StringBuilder sb = new StringBuilder();

            for(int i=0; i<60;i++)
            {
                appendOption(sb, padZero(i), padZero(i), i == selectedMinute);
            }
            return selectHtml(id, name, sb.ToString(), isDisabled, includesBlank);
        }

        /// <summary>
        /// Generate a selection for hours.
        /// </summary>
        /// <param name="id">Element id</param>
        /// <param name="selectedHour">Hour to currently display</param>
        /// <returns>Html element text</returns>
        public static string SelectHour(string id, int selectedHour)
        {
            return SelectHour(id, id, selectedHour, false, false);
        }

        /// <summary>
        /// Generate a selection for hours.
        /// </summary>
        /// <param name="id">Element id</param>
        /// <param name="name">Element name</param>
        /// <param name="selectedHour">Hour currently selected</param>
        /// <param name="isDisabled">True if element is disabled</param>
        /// <param name="includesBlank">Include a blank entry</param>
        /// <returns>Html element text</returns>
        public static string SelectHour(string id, string name, int selectedHour, bool isDisabled, bool includesBlank)
        {
            StringBuilder sb = new StringBuilder();

            for(int i=0; i<24; i++)
            {
                appendOption(sb, i, i, i == selectedHour);
            }
            return selectHtml(id, name, sb.ToString(), isDisabled, includesBlank);
        }

        /// <summary>
        /// Generate a selection for days
        /// </summary>
        /// <param name="id">Element id</param>
        /// <param name="selectedDay">Day currently selected</param>
        /// <returns>Html element text</returns>
        public static string SelectDay(string id, int selectedDay)
        {
            return SelectDay(id, id, selectedDay, false, false);
        }

        /// <summary>
        /// Generate a selection for days
        /// </summary>
        /// <param name="id">Element id</param>
        /// <param name="name">Element name</param>
        /// <param name="selectedDay">Day to currently display</param>
        /// <param name="isDisabled">True if element is disabled</param>
        /// <param name="includesBlank">Include a blank entry</param>
        /// <returns>Html element text</returns>
        public static string SelectDay(string id, string name, int selectedDay, bool isDisabled, bool includesBlank)
        {
            if (selectedDay == 0)
                selectedDay = 1;
            
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= 31; i++ )
            {
                appendOption(sb,i, i, i == selectedDay);
            }
            return selectHtml(id, name, sb.ToString(), isDisabled, includesBlank);
        }

        /// <summary>
        /// Generate a selection for months
        /// </summary>
        /// <param name="id">Element id</param>
        /// <param name="selectedMonth">Month to currently display</param>
        /// <param name="monthNames">Custom month names array to use</param>
        /// <returns>Html element text</returns>
        public static string SelectMonth(string id, int selectedMonth, string [] monthNames)
        {
            return SelectMonth(id, id, selectedMonth, monthNames, false, false);
        }

        /// <summary>
        /// Generate a selection for months
        /// </summary>
        /// <param name="id">Element id</param>
        /// <param name="selectedMonth">Month to currently display</param>
        /// <returns>Html element text</returns>
        public static string SelectMonth(string id, int selectedMonth)
        {
            return SelectMonth(id, selectedMonth, true);
        }

        /// <summary>
        /// Generate a selection for months
        /// </summary>
        /// <param name="id">Element id</param>
        /// <param name="selectedMonth">Month to currently display</param>
        /// <param name="useShortMonths">Use short month descriptions</param>
        /// <returns>Html element text</returns>
        public static string SelectMonth(string id, int selectedMonth, bool useShortMonths)
        {
            return SelectMonth(id, id, selectedMonth, useShortMonths, false, false);
        }

        /// <summary>
        /// Generate a selection for months
        /// </summary>
        /// <param name="id">Element id</param>
        /// <param name="name">Element name</param>
        /// <param name="selectedMonth">Month to currently display</param>
        /// <param name="useShortMonths">Use short month descriptions</param>
        /// <param name="isDisabled">True if element is disabled</param>
        /// <param name="includesBlank">Include a blank entry</param>
        /// <returns>Html element text</returns>
        public static string SelectMonth(string id, string name, int selectedMonth, bool useShortMonths, bool isDisabled, bool includesBlank)
        {
            string[] monthNames = useShortMonths
                                      ?
                                          System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.
                                              AbbreviatedMonthNames
                                      :
                                          System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;
            return SelectMonth(id, name, selectedMonth, monthNames, isDisabled, includesBlank);
        }

        /// <summary>
        /// Generate a selection for months
        /// </summary>
        /// <param name="id">Element id</param>
        /// <param name="name">Element name</param>
        /// <param name="selectedMonth">Month currently selected</param>
        /// <param name="monthNames">Custom month name arrays</param>
        /// <param name="isDisabled">True if element is disabled</param>
        /// <param name="includesBlank">Include a blank entry</param>
        /// <returns>Html element text</returns>
        public static string SelectMonth(string id, string name, int selectedMonth, string[] monthNames, bool isDisabled, bool includesBlank)
        {
            if (selectedMonth == 0)
                selectedMonth = 1;

            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= 12; i++)
            {
                appendOption(sb, i.ToString(), monthNames[i - 1], selectedMonth == i);
            }
            return selectHtml(id, name, sb.ToString(), isDisabled, includesBlank);
        }

        /// <summary>
        /// Generate a selection for years
        /// </summary>
        /// <param name="id">Element id</param>
        /// <param name="selectedYear">Year to currently display</param>
        /// <param name="includesBlank">Include a blank entry</param>
        /// <returns>Html element text</returns>
        public static string SelectYear(string id, int selectedYear, bool includesBlank)
        {
            return SelectYear(id, id, selectedYear, false, includesBlank);
        }

        /// <summary>
        /// Generate a selection for years
        /// </summary>
        /// <param name="id">Element id</param>
        /// <param name="selectedYear">Year to currently display</param>
        /// <returns>Html element text</returns>
        public static string SelectYear(string id, int selectedYear)
        {
            return SelectYear(id, id, selectedYear);
        }

        /// <summary>
        /// Generate a selection for years
        /// </summary>
        /// <param name="id">Element id</param>
        /// <param name="name">Element name</param>
        /// <param name="selectedYear">Year to currently display</param>
        /// <param name="isDisabled">True if element is disabled</param>
        /// <param name="includesBlank">Include a blank entry</param>
        /// <returns>Html element text</returns>
        public static string SelectYear(string id, string name, int selectedYear,  bool isDisabled, bool includesBlank)
        {
            return SelectYear(id, name, selectedYear, selectedYear - 5, selectedYear + 5, isDisabled, includesBlank);
        }

        /// <summary>
        /// Generate a selection for years
        /// </summary>
        /// <param name="id">Element id</param>
        /// <param name="name">Element name</param>
        /// <param name="selectedYear">Year to currently display</param>
        /// <returns>Html element text</returns>
        public static string SelectYear(string id, string name, int selectedYear)
        {
            return SelectYear(id, name, selectedYear, selectedYear - 5, selectedYear + 5, false, false);
        }

        /// <summary>
        /// Generate a selection for years
        /// </summary>
        /// <param name="id">Element id</param>
        /// <param name="name">Element name</param>
        /// <param name="selectedYear">Year to currently display</param>
        /// <param name="startYear">Start year</param>
        /// <param name="endYear">End year</param>
        /// <param name="isDisabled">True if element is disabled</param>
        /// <param name="includesBlank">Include a blank entry</param>
        /// <returns>Html element text</returns>
        public static string SelectYear(string id, string name, int selectedYear, int startYear, int endYear, bool isDisabled, bool includesBlank)
        {
            StringBuilder sb = new StringBuilder();
            int step = startYear < endYear ? 1 : -1;

            while(startYear != endYear)
            {
                appendOption(sb, startYear, startYear, startYear == selectedYear);
                startYear += step;
            }
            return selectHtml(id, name, sb.ToString(), isDisabled, includesBlank);
        }

        /// <summary>
        /// Generate a select element
        /// </summary>
        /// <param name="id">Element id</param>
        /// <param name="name">Element name</param>
        /// <param name="options">Html options</param>
        /// <param name="isDisabled">True if element is disabled</param>
        /// <param name="includesBlank">Include a blank element</param>
        /// <returns>Html element text</returns>
        private static string selectHtml(string id, string name, string options, bool isDisabled, bool includesBlank)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<select id=\"").Append(id).Append("\" name=\"").Append(name).Append("\"");
            if (isDisabled)
                sb.Append(" disabled=\"disabled\"");
            sb.Append(">\n");
            if (includesBlank)
                sb.Append("<option value=\"\"></option>\n");
            sb.Append(options).Append("</select>\n");
            return sb.ToString();
        }


        private static void appendOption(StringBuilder sb, int value, int selection, bool isSelected)
        {
            //TODO: refactor this into 1 single statement with the selected code out.
            if(isSelected)
                sb.Append("<option value=\"")
                    .Append(value)
                    .Append("\" selected=\"selected\">")
                    .Append(selection)
                    .Append("</option>\n");
            else 
                sb.Append("<option value=\"")
                    .Append(value)
                    .Append("\">")
                    .Append(selection).Append("</option>\n");
        }

        private static void appendOption(StringBuilder sb, string value, string selection, bool isSelected)
        {
            if(isSelected)
                sb.Append("<option value=\"")
                    .Append(value)
                    .Append("\" selected=\"selected\">")
                    .Append(selection)
                    .Append("</option>\n");
            else
                sb.Append("<option value=\"")
                    .Append(value)
                    .Append("\">")
                    .Append(selection).Append("</option>\n");
        }

        private static string hiddenHtml(string id, string name, string value)
        {
            return
                new StringBuilder().Append("<input type=\"hidden\" id=\"").Append(id).Append("\" name=\"").Append(name)
                    .Append("\" value=\"").Append(value).Append("\" />").ToString();
        }

        /// <summary>
        /// Pad number with zero
        /// </summary>
        /// <param name="number">Number to pad</param>
        /// <returns>Padded number</returns>
        private static string padZero(int number)
        {
            return (number > 9) ? "" + number : "0" + number;
        }

        /// <summary>
        /// True if number is in range
        /// </summary>
        /// <param name="min">number</param>
        /// <param name="i">lower</param>
        /// <param name="j">higher</param>
        /// <returns>True if number in range</returns>
        private static bool inRange(int min, int i, int j)
        {
            return min >= i && min <= j;
        }
    }
}