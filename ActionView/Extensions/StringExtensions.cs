using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using ActionPack.Helpers;

namespace ActionPack.Extensions
{
    /// <summary>
    /// String extensions, most adopted from rails' actionsupport
    /// </summary>
    public static class StringExtensions
    {
        public static string Truncate(this string target, int maxLength, string truncateString)
        {
            return TextHelper.Truncate(target, maxLength, truncateString);
        }

        public static string Pluralize(this string target, int count)
        {
            return TextHelper.Pluralize(count, target);
        }


        public static string Excerpt(this string target, string phrase, int radius)
        {
            return TextHelper.Excerpt(target, phrase, radius);
        }
        /// <summary>
        /// Pluralize a singular form.
        /// </summary>
        /// <param name="singular">The word</param>
        /// <returns>Pluralized form</returns>
        public static string Pluralize(this string singular)
        {
            return Inflector.Pluralize(singular);
        }

        /// <summary>
        /// Singularize a plural form.
        /// </summary>
        /// <param name="plural">The word</param>
        /// <returns>Singular form</returns>
        public static string Singularize(this string plural)
        {
            return Inflector.Singularize(plural);
        }

        /// <summary>
        /// Convert a sentence into camelized form.
        /// </summary>
        /// <param name="sentence">Sentence to convert</param>
        /// <param name="lower">Start with lower letter</param>
        /// <returns>Camelized string</returns>
        public static string Camelize(this string sentence, bool lower)
        {
            return Inflector.Camelize(sentence, lower);
        }

        /// <summary>
        /// Camelize a sentence.
        /// </summary>
        /// <param name="sentence">Sentence to camelize</param>
        /// <returns>Camelized string</returns>
        public static string Camelize(this string sentence)
        {
            return Inflector.Camelize(sentence, false);
        }

        /// <summary>
        /// Capitalize a word
        /// </summary>
        /// <param name="word">The word</param>
        /// <returns>Capitalized word</returns>
        public static string Capitalize(this string word)
        {
            return Inflector.Capitalize(word);
        }

        /// <summary>
        /// Convert a sentence to title case
        /// </summary>
        /// <param name="sentence">Sentence to convert</param>
        /// <returns>The sentence</returns>
        public static string TitleCase(this string sentence)
        {
            return Inflector.Titleize(sentence);
        }

        /// <summary>
        /// Dasherize-a-string.
        /// </summary>
        /// <param name="sentence">Sentence to dash</param>
        /// <returns>Dasherized sentence</returns>
        public static string Dasherize(this string sentence)
        {
            return Inflector.Dasherize(sentence);
        }

        /// <summary>
        /// Convert a camelcase word to a string.
        /// </summary>
        /// <param name="word">The word</param>
        /// <returns>Sentence</returns>
        public static string Decamelize(this string word)
        {
            return Inflector.Decamelize(word, " ");
        }

        /// <summary>
        /// Convert a camelcase word to a string.
        /// </summary>
        /// <param name="word">The word</param>
        /// <param name="separator">Use this separator between words</param>
        /// <returns>Sentence</returns>
        public static string Decamelize(this string word, string separator)
        {
            return Inflector.Decamelize(word, separator);
        }

        /// <summary>
        /// Ordinalize a number, eg. 3rd.
        /// </summary>
        /// <param name="number">The number</param>
        /// <returns>Ordinal</returns>
        public static string Ordinalize(this int number)
        {
            return Inflector.Ordinalize(number);
        }

        /// <summary>
        /// Pick a substring from index.
        /// </summary>
        /// <param name="str">The string</param>
        /// <param name="index">The index</param>
        /// <returns>Substring</returns>
        public static string From(this string str, int index)
        {
            return str.Substring(index);
        }

        /// <summary>
        /// Pick a substring up to an index
        /// </summary>
        /// <param name="str">The string</param>
        /// <param name="index">The index</param>
        /// <returns>Substring</returns>
        public static string To(this string str, int index)
        {
            return str.Substring(0, index+1);
        }

        /// <summary>
        /// Get first x letters of a string
        /// </summary>
        /// <param name="str">The string</param>
        /// <param name="amount">Amount of letters to take</param>
        /// <returns>Substring</returns>
        public static string First(this string str, int amount)
        {
            return str.Substring(0, amount);
        }

        /// <summary>
        /// Get last x letters of a string
        /// </summary>
        /// <param name="str">The string</param>
        /// <param name="amount">Amount of letters to take</param>
        /// <returns>Substring</returns>
        public static string Last(this string str, int amount)
        {
            return str.Substring(str.Length - amount, amount);
        }

        /// <summary>
        /// Double quote a string.
        /// </summary>
        /// <param name="target">String to quote</param>
        /// <returns>Double-quoted string.</returns>
        public static string DQ(this string target)
        {
            return "\"" + target + "\"";
        }

        /// <summary>
        /// Single quote a string.
        /// </summary>
        /// <param name="target">String to quote</param>
        /// <returns>Single-quoted string.</returns>
        public static string SQ(this string target)
        {
            return "'" + target + "'";
        }

        /// <summary>
        /// Back quote a string.
        /// </summary>
        /// <param name="target">String to quote</param>
        /// <returns>Back-quoted string.</returns>
        public static string BQ(this string target)
        {
            return "`" + target + "`";
        }

        /// <summary>
        /// Bracket a string. i.e. [boo]
        /// </summary>
        /// <param name="target">String to bracket</param>
        /// <returns>Bracketed string.</returns>
        public static string Bracketed(this string target)
        {
            return "[" + target + "]";
        }

        /// <summary>
        /// Curl a string. i.e. {boo}
        /// </summary>
        /// <param name="target">String to curl</param>
        /// <returns>Curlied string.</returns>
        public static string Curlied(this string target)
        {
            return "{" + target + "}";
        }

        /// <summary>
        /// Parenthesize a string. i.e. (boo)
        /// </summary>
        /// <param name="target">String to parenthesize</param>
        /// <returns>Parenthesized string.</returns>        
        public static string Parend(this string target)
        {
            return "(" + target + ")";
        }

        /// <summary>
        /// Angle bracket a string.
        /// </summary>
        /// <param name="target">String to angle bracket</param>
        /// <returns>Angle bracketed string.</returns>  
        public static string Angled(this string target)
        {
            return "<" + target + ">";
        }

        /// <summary>
        /// Right-justify a string into width.
        /// </summary>
        /// <param name="target">String to right-justify</param>
        /// <param name="width">Containing width</param>
        /// <returns>Right-justified string</returns>
        public static string RJust(this string target, int width)
        {
            return justify(target, width, " ", true);
        }

        /// <summary>
        /// Right-justify a string into width, using a padder string instead of
        /// whitespace.
        /// </summary>
        /// <param name="target">String to right-justify</param>
        /// <param name="width">Containing width</param>
        /// <param name="padder">Padder string</param>
        /// <returns>Right-justified string</returns>
        public static string RJust(this string target, int width, string padder)
        {
            return justify(target, width, padder, true);
        }

        /// <summary>
        /// Left-justify a string into width.
        /// </summary>
        /// <param name="target">String to left-justify</param>
        /// <param name="width">Containing width</param>
        /// <returns>Left-justified string</returns>
        public static string LJust(this string target, int width)
        {
            return justify(target, width, " ", false);
        }

        /// <summary>
        /// Left-justify a string into width.
        /// </summary>
        /// <param name="target">String to left-justify</param>
        /// <param name="width">Containing width</param>
        /// <param name="padder">Padder string</param>
        /// <returns>Left-justified string</returns>
        public static string LJust(this string target, int width, string padder)
        {
            return justify(target, width, padder, false);
        }

        /// <summary>
        /// Private implementation of justification.
        /// </summary>
        /// <param name="target">String to justify</param>
        /// <param name="width">Containing width</param>
        /// <param name="padder">Padder string</param>
        /// <param name="isRight">Left or right</param>
        /// <returns>Justified string</returns>
        private static string justify(string target, int width, string padder, bool isRight)
        {
            if (target.Length >= width)
                return target;
            width = width - target.Length;

            int plen = padder.Length;
            if (plen >= width)
                return target;

            string padding = getPadding(width, padder, plen);
            return isRight ? padding + target : target + padding;
        }

        /// <summary>
        /// Calculate padding.
        /// </summary>
        /// <param name="width">Containing width</param>
        /// <param name="padder">Padder string </param>
        /// <param name="plen">Padding length</param>
        /// <returns>Padding</returns>
        private static string getPadding(int width, string padder, int plen)
        {
            int charsleft = width % plen;
            int multiplier = width / plen;
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < multiplier; i++)
                sb.Append(padder);

            if (charsleft != 0)
                sb.Append(padder.Substring(0, charsleft));
            return sb.ToString();
        }

        /// <summary>
        /// Center a string within a width.
        /// </summary>
        /// <param name="target">String to center</param>
        /// <param name="width">Containing width</param>
        /// <returns>Centered string</returns>
        public static string Center(this string target, int width)
        {
            return Center(target, width, " ");
        }

        /// <summary>
        /// Center a string within a width using a padder string.
        /// </summary>
        /// <param name="target">String to center</param>
        /// <param name="width">Containing width</param>
        /// <param name="padder">Padder string</param>
        /// <returns>Centered string</returns>
        public static string Center(this string target, int width, string padder)
        {
            if (width <= target.Length)
                return target;
            width = width - target.Length;

            int plen = padder.Length;
            if (plen >= width)
                return target;


            string padding = getPadding(width, padder, (width + target.Length) / 2);
            return padding + target + padding;
        }

        /// <summary>
        /// Break a string into lines, and operate on each.
        /// </summary>
        /// <param name="target">String to break</param>
        /// <param name="func">Operator</param>
        /// <returns>Processed lines</returns>
        public static IEnumerable<string> EachLine(this string target, Func<string, string> func)
        {
            return Each(target, @"\n", func);
        }

        /// <summary>
        /// Break a string into words, and operate on each.
        /// </summary>
        /// <param name="target">String to break</param>
        /// <param name="func">Operator</param>
        /// <returns>Processed words</returns>
        public static IEnumerable<string> EachWord(this string target, Func<string, string> func)
        {
            return Each(target, @"\s+", func);
        }

        /// <summary>
        /// Get a list of words within a string.
        /// </summary>
        /// <param name="target">The string</param>
        /// <returns>Words</returns>
        public static IEnumerable<string> Words(this string target)
        {
            return Regex.Split(target, @"\s+");
        }

        /// <summary>
        /// Process a string, breaking it apart and processing each part.
        /// </summary>
        /// <param name="target">String to break</param>
        /// <param name="separator">Regular-expression separator</param>
        /// <param name="func">Processor</param>
        /// <returns>Processed parts</returns>
        public static IEnumerable<string> Each(this string target, string separator, Func<string, string> func)
        {
            string[] strs = Regex.Split(target, separator);
            for (int i = 0; i < strs.Length; i++)
                strs[i] = func(strs[i]);
            return strs;
        }

        /// <summary>
        /// Infix a string using a separator
        /// </summary>
        /// <param name="target">String to infix</param>
        /// <param name="separator">The separator</param>
        /// <param name="prefix">The prefix</param>
        /// <param name="postfix">The postfix</param>
        /// <returns>Infixed string</returns>
        public static string Infix(this string target, string separator, string prefix, string postfix)
        {
            return prefix + separator + target + separator + postfix;
        }

        /// <summary>
        /// Infix a string.
        /// </summary>
        /// <param name="target">String to infix</param>
        /// <param name="prefix">The prefix</param>
        /// <param name="postfix">The postfix</param>
        /// <returns>Infixed string</returns>
        public static string Infix(this string target, string prefix, string postfix)
        {
            return Infix(target, "", prefix, postfix);
        }

        /// <summary>
        /// Postfix a string using a separator.
        /// </summary>
        /// <param name="target">String to postfix</param>
        /// <param name="separator">The separator</param>
        /// <param name="str">The initial string</param>
        /// <returns>Postfixed string</returns>
        public static string Postfix(this string target, string separator, string str)
        {
            return str + separator + target;
        }

        /// <summary>
        /// Postfix a string.
        /// </summary>
        /// <param name="target">String to postfix</param>
        /// <param name="str">The initial string</param>
        /// <returns>Postfixed string</returns>
        public static string Postfix(this string target, string str)
        {
            return Postfix(target, "", str);
        }

        /// <summary>
        /// Prefix a string using a separator.
        /// </summary>
        /// <param name="target">String to prefix</param>
        /// <param name="separator">The separator</param>
        /// <param name="str">The remaining string</param>
        /// <returns>Prefixed string</returns>
        public static string Prefix(this string target, string separator, string str)
        {
            return target + separator + str;
        }

        /// <summary>
        /// Prefix a string using a separator.
        /// </summary>
        /// <param name="target">String to prefix</param>
        /// <param name="str">The remaining string</param>
        /// <returns>Prefixed string</returns>
        public static string Prefix(this string target, string str)
        {
            return Prefix(target, "", str);
        }

        /// <summary>
        /// Create a regex from a string
        /// </summary>
        /// <param name="target">The string</param>
        /// <returns>The regex</returns>
        public static Regex AsRegex(this string target)
        {
            return new Regex(target, RegexOptions.Compiled);
        }

        /// <summary>
        /// Create a regex from a string, taking options.
        /// </summary>
        /// <param name="target">The string</param>
        /// <param name="options">Regex options</param>
        /// <returns>The regex</returns>
        public static Regex AsRegex(this string target, RegexOptions options)
        {
            return new Regex(target, options);
        }

        /// <summary>
        /// Word-wrap a string into max width. Uses greedy wrapping.
        /// </summary>
        /// <param name="target">The string to wrap</param>
        /// <param name="maxWidth">Maximal line-width</param>
        /// <returns>Wrapped string</returns>
        public static string Wrap(this string target, int maxWidth)
        {
            //greedy implementation
            StringBuilder sb = new StringBuilder();
            int widthLeft = maxWidth;

            foreach (string word in target.Words())
            {
                if (word.Length < widthLeft)
                {
                    sb.Append(word);
                    widthLeft -= word.Length;
                }
                else
                {
                    sb.Append("\n").Append(word);
                    widthLeft = maxWidth - word.Length;
                }
            }

            return sb.ToString();
        }
    }
}