using System;
using System.Text;
using System.Text.RegularExpressions;

namespace ActionPack.Helpers
{
    /// <summary>
    /// Provide numeric to string (mostly) processing functions. Most adopted
    /// from Rails' actionview.
    /// </summary>
    public class NumberHelper
    {
        private static readonly Regex witharea = new Regex("([0-9]{1,3})([0-9]{3})([0-9]{4}$)", RegexOptions.Compiled);
        private static readonly Regex withoutarea = new Regex("([0-9]{1,3})([0-9]{3})([0-9]{4})$", RegexOptions.Compiled);
        private static readonly Regex numberwithdelims = new Regex(@"(\d)(?=(\d\d\d)+(?!\d))", RegexOptions.Compiled);
        
        /// <summary>
        /// Convert a number into a phone number, on-par with Rails' actionview.
        /// </summary>
        /// <param name="number">Raw number</param>
        /// <param name="countryCode">The country code</param>
        /// <param name="extension">The extension</param>
        /// <param name="delimiter">Delimiter to use</param>
        /// <param name="includeAreaCode">If true includes area code</param>
        /// <returns>Formatted phone number</returns>
        public static string NumberToPhone(string number, string countryCode, string extension, string delimiter, bool includeAreaCode)
        {
            StringBuilder sb = new StringBuilder(20);
            if (!string.IsNullOrEmpty(countryCode)) sb.Append("+").Append(countryCode).Append(delimiter);
            if (includeAreaCode)
                sb.Append(witharea.Replace(number, "($1) $2" + delimiter + "$3"));
            else
                sb.Append(withoutarea.Replace(number, "$1" + delimiter + "$2" + delimiter + "$3"));

            if (!string.IsNullOrEmpty(extension)) sb.Append(" x ").Append(extension);

            return sb.ToString();
        }


        /// <summary>
        /// Adds delimiter to a raw number.
        /// </summary>
        /// <param name="number">Raw number</param>
        /// <returns>Delimited string</returns>
        public static string NumberWithDelimiter(int number)
        {
            return NumberWithDelimiter(number.ToString());
        }

        /// <summary>
        /// Adds delimiter to a raw number.
        /// </summary>
        /// <param name="number">Raw number</param>
        /// <returns>Delimited string</returns>
        public static string NumberWithDelimiter(double number)
        {
            return NumberWithDelimiter(number.ToString());
        }

        /// <summary>
        /// Adds delimiter to a raw number.
        /// </summary>
        /// <param name="number">Number as string</param>
        /// <returns>Delimited string</returns>
        public static string NumberWithDelimiter(string number)
        {
            return NumberWithDelimiter(number, ",", ".");
        }

        /// <summary>
        /// Adds delimiter to a raw number using a specified delimiter and separator.
        /// </summary>
        /// <param name="number">Number as string</param>
        /// <param name="delimiter">Delimiter to use</param>
        /// <param name="separator">Separator to use</param>
        /// <returns>Delimited string</returns>
        public static string NumberWithDelimiter(string number, string delimiter, string separator)
        {
            string[] parts = number.Split('.');
            parts[0] = numberwithdelims.Replace(parts[0], "$1" + delimiter);
            return string.Join(separator, parts);
        }


        /// <summary>
        /// Convert a number to human size in bytes.
        /// </summary>
        /// <param name="size">The size</param>
        /// <returns>Formatted string</returns>
        public static string NumberToHumanSize(long size)
        {
            return NumberToHumanSize(size, 1);
        }

        /// <summary>
        /// Convert a number to human size in bytes with a given precision.
        /// </summary>
        /// <param name="size">The size</param>
        /// <param name="precision">The precision</param>
        /// <returns>Formatted string</returns>
        public static string NumberToHumanSize(long size, int precision)
        {
            //IEEE definitions
            if (size == 1)
                return "1 Byte";
            if (size < 1000)
                return String.Format("{0:F" + precision + "}", size) + " Bytes";
            if (size < 1000000)
                return String.Format("{0:F" + precision + "}", size / 1000.0) + " KB";
            if (size < 1000000000)
                return String.Format("{0:F" + precision + "}", size / 1000000.0) + " MB";
            if (size < 1000000000000)
                return String.Format("{0:F" + precision + "}", size / 1000000000.0) + " TB";
            return "??";
        }
    }
}