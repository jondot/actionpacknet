using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ActionPack.Helpers;

namespace ActionPack.Helpers
{
    /// <summary>
    /// Provide a text and string processing function. Most are adopted from Rails'
    /// actionview, some are new.
    /// </summary>
    public class TextHelper
    {
        private static Regex rn = new Regex(@"\r\n?",RegexOptions.Compiled);
        private static Regex nn = new Regex(@"\n\n+", RegexOptions.Compiled);
        private static Regex br = new Regex(@"([^\n]\n)(?=[^\n])", RegexOptions.Compiled);
        private static Regex email = new Regex(@"([\w\.!#\$%\-+.]+@[A-Za-z0-9\-]+(\.[A-Za-z0-9\-]+)+)",RegexOptions.Compiled);
        private static Regex url = new Regex(@"(<\w+.*?>|[^=!:'""/]|^)((?:https?://)|(?:www\.))([-\w]+(?:\.[-\w]+)*(?::\d+)?(?:/(?:(?:[~\w\+@%-]|(?:[,.;:][^\s$]))+)?)*(?:\?[\w\+@%&=.;-]+)?(?:\#[\w\-]*)?)([[:punct:]]|\s|<|$)", RegexOptions.Compiled);
       
        /// <summary>
        /// Truncate a string into maximal length, and use truncateString to provide
        /// continuation hint. e.g. "..." .
        /// </summary>
        /// <param name="text">Text to truncate</param>
        /// <param name="maxLength">The maximal length</param>
        /// <param name="truncateString">The truncate continuation hint</param>
        /// <returns></returns>
        public static string Truncate(string text, int maxLength, string truncateString)
        {
            int cutlen = maxLength - truncateString.Length;
            if (text.Length > maxLength)
                return text.Substring(0, cutlen) + truncateString;
            
            return text;
        }


        /// <summary>
        /// Highlighting is enclosing a string in a HTML highlight tag. This will
        /// highlight all occurances of phrase in text.
        /// </summary>
        /// <param name="text">Text to highlight</param>
        /// <param name="phrase">Phrase to match highlighting for</param>
        /// <returns>Highlighted text</returns>
        public static string Highlight(string text, string phrase)
        {
            return Highlight(text, new string[] {phrase});
        }

        /// <summary>
        /// Highlighting is enclosing a string in a HTML highlight tag. This will
        /// highlight all occurances of phrase in text.
        /// <example>
        /// You can specify your own highlight tag, with $1 placeholder for content, e.g. :
        /// <![CDATA[ <span>$1</span>  ]]>
        /// </example>
        /// </summary>
        /// <param name="text">Text to highlight</param>
        /// <param name="phrase">Phrase to match highlighting for</param>
        /// <param name="highlighter">Highlighter expression to use</param>
        /// <returns>Highlighted text</returns>
        public static string Highlight(string text, string phrase, string highlighter)
        {
            return Highlight(text, new string[] { phrase }, highlighter);
        }

        /// <summary>
        /// Highlight several phrases inside text.
        /// </summary>
        /// <param name="text">Text to process</param>
        /// <param name="phrases">Phrases to highlight</param>
        /// <returns>Highlighted text</returns>
        public static string Highlight(string text, string [] phrases)
        {
            return Highlight(text, phrases, "<strong class=\"highlight\">$1</strong>");
        }

        /// <summary>
        /// Highlight several phrases inside text, using a 
        /// custom highlighter.
        /// <example>
        /// You can specify your own highlight tag, with $1 placeholder for content, e.g. :
        /// <![CDATA[ <span>$1</span>  ]]>
        /// </example>
        /// </summary>
        /// <param name="text">Text to process</param>
        /// <param name="phrases">Phrases to highlight</param>
        /// <returns>Highlighted text</returns>        /// <returns></returns>
        public static string Highlight(string text, string [] phrases, string highlighter)
        {
            if(string.IsNullOrEmpty(text))
                return text;

            Array.ForEach(phrases, p => Regex.Escape(p));
            string m = String.Join("|", phrases);

            return Regex.Replace(text, "("+ m + ")", highlighter);
        }

        /// <summary>
        /// Create an excerpt of a text, withing a specified radius.
        /// </summary>
        /// <param name="text">Text to excerpt</param>
        /// <param name="phrase">Center excerpt radius by this phrase</param>
        /// <param name="radius">Excerpt radius</param>
        /// <returns>Excerpted text</returns>
        public static string Excerpt(string text, string phrase, int radius)
        {
            int i = text.IndexOf(phrase);
            if(i == -1)
                return text;
            int len = phrase.Length;

            int difright = len + i + radius;
            if (difright < text.Length)
                text = text.Substring(0, difright) + "...";
            
            int difleft = i - radius;
            if (difleft > 0)
                text = "..." + text.Substring(difleft, text.Length - difleft);

            return text;
        }

        /// <summary>
        /// Create an excerpt of text with a default width of 100.
        /// </summary>
        /// <param name="text">Text to excerpt</param>
        /// <param name="phrase">Phrase to center around</param>
        /// <returns>Excerpted text</returns>
        public static string Excerpt(string text, string phrase)
        {
            return Excerpt(text,phrase,100);
        }

        /// <summary>
        /// Pluralize a word taking a count, if needed.
        /// e.g. 2 people.
        /// </summary>
        /// <param name="count">Count of items</param>
        /// <param name="singular">Word to pluralize</param>
        /// <returns>Pluralized string</returns>
        public static string Pluralize(int count, string singular)
        {
            return Pluralize(count, singular, null);
        }

        /// <summary>
        /// Pluralize a word taking a count, if needed.
        /// e.g. 2 people, taking a default plural.
        /// </summary>
        /// <param name="count">Count of items</param>
        /// <param name="singular">Word to pluralize</param>
        /// <param name="plural">A default plural</param>
        /// <returns>Pluralized string</returns>
        public static string Pluralize(int count, string singular, string plural)
        {
            if(count == 1)
                return count + " " + singular;

            return count + " " + (string.IsNullOrEmpty(plural) ? Inflector.Pluralize(singular):plural) ;
        }

        /// <summary>
        /// Simple formats a text, replaces a bunch of \ns with
        /// html paragraph.
        /// </summary>
        /// <param name="text">Text to simpleformat</param>
        /// <returns>Simpleformatted text</returns>
        public static string SimpleFormat(string text)
        {
            text = rn.Replace(text, "\n");
            text = nn.Replace(text, "</p>\n\n<p>");
            return "<p>"+br.Replace(text, "$1<br/>")+"</p>";
        }

        /// <summary>
        /// Find links in text and auto-link it.
        /// </summary>
        /// <param name="text">Text to autolink</param>
        /// <param name="opts">Autolink options</param>
        /// <param name="hrefattrs">Link attributes</param>
        /// <returns>Autolinked text</returns>
        public static string AutoLink(string text, AutoLinkOptions opts, string hrefattrs)
        {
            if(string.IsNullOrEmpty(text)) return text;

            switch (opts)
            {
                case AutoLinkOptions.All:
                    return AutoLinkEmailAddresses(AutoLinkUrls(text, hrefattrs));
                case AutoLinkOptions.Email:
                    return AutoLinkEmailAddresses(text);
                case AutoLinkOptions.Url:
                    return AutoLinkUrls(text, hrefattrs);
                default:
                    return text;
            }
        }

        /// <summary>
        /// Cycle through values infinitely. Typically used in table zebra.
        /// </summary>
        /// <typeparam name="T">Cycled type</typeparam>
        /// <param name="elements">Element to cycle from</param>
        /// <returns>Cycled value</returns>
        public static IEnumerable<T> Cycle<T>(T [] elements)
        {
            int i = 0;
            while (true)
            {
                yield return elements[i];
                i = ++i%elements.Length;
            }
        }

        /// <summary>
        /// Autolink email addresses.
        /// </summary>
        /// <param name="text">Text to autolink</param>
        /// <returns>Autolinked email addresses</returns>
        private static string AutoLinkEmailAddresses(string text)
        {
            return email.Replace(text, x => Regex.IsMatch(text, @"<a\b[^>]*>(.*)("+Regex.Escape(x.Groups[0].Value)+@")(.*)<\/a>") ? x.Groups[0].Value : String.Format("<a href=\"mailto:{0}\">{0}</a>",x.Groups[0].Value));
        }

        /// <summary>
        /// Autolink urls
        /// </summary>
        /// <param name="text">Text to autolink</param>
        /// <param name="hrefattrs">Link attributes</param>
        /// <returns>Autolinked text</returns>
        private static string AutoLinkUrls(string text, string hrefattrs)
        {
            return url.Replace(text, x =>
                                         {
                                             if(Regex.IsMatch(x.Groups[1].Value, @"<a\s",RegexOptions.IgnoreCase))
                                                 return x.Groups[0].Value;
                                             string t = x.Groups[2].Value + x.Groups[3].Value;
                                             return String.Format("{0}<a href=\"{1}{2}\"{3}>{4}</a>{5}", x.Groups[1].Value, 
                                                                  x.Groups[2].Value == "www." ? "http://www.": x.Groups[2].Value,
                                                                  x.Groups[3].Value,
                                                                  string.IsNullOrEmpty(hrefattrs) ? "" : " "+hrefattrs,
                                                                  t,
                                                                  x.Groups[4].Value);
                                         });
        }

        /// <summary>
        /// Auto link options.
        /// </summary>
        public enum AutoLinkOptions
        {
            Email,
            Url,
            All
        }
    }
}