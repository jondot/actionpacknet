using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord.Framework.Internal;

namespace ActionSupport
{
    public static class StringExtensions
    {
        public static string Pluralize(this string singular)
        {
            return Inflector.Pluralize(singular);
        }
        public static string Singularize(this string plural)
        {
            return Inflector.Singularize(plural);
        }
        public static string Camelize(this string sentence, bool lower)
        {
            return Inflector.Camelize(sentence, lower);
        }
        public static string Camelize(this string sentence)
        {
            return Inflector.Camelize(sentence, false);
        }
        public static string Capitalize(this string word)
        {
            return Inflector.Capitalize(word);
        }
        public static string TitleCase(this string sentence)
        {
            return Inflector.Titleize(sentence);
        }
        public static string Dasherize(this string sentence)
        {
            return Inflector.Dasherize(sentence);
        }
        public static string Decamelize(this string word)
        {
            return Inflector.Decamelize(word, " ");
        }
        public static string Decamelize(this string word, string separator)
        {
            return Inflector.Decamelize(word, separator);
        }
        public static string Ordinalize(this int number)
        {
            return Inflector.Ordinalize(number);
        }
        public static string From(this string str, int index)
        {
            return str.Substring(index);
        }
        public static string To(this string str, int index)
        {
            return str.Substring(0, index+1);
        }
        public static string First(this string str, int amount)
        {
            return str.Substring(0, amount);
        }
        public static string Last(this string str, int amount)
        {
            return str.Substring(str.Length - amount, amount);
        }
    }
}
