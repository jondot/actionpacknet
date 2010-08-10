using System.Collections.Generic;
using System.Text;

namespace ActionPack.Extensions
{
    /// <summary>
    /// Additional extensions for arrays
    /// </summary>
    public static class ArrayExtensions
    {
        /// <summary>
        /// Splice a list
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="target">The list</param>
        /// <param name="start">start index</param>
        /// <param name="end">end index</param>
        /// <returns>Result list</returns>
        public static IEnumerable<T> Splice<T>(this IEnumerable<T> target, int start, int end)
        {
            IEnumerator<T> en = target.GetEnumerator();
            List<T> res = new List<T>();
            for (int i = 0; en.MoveNext();i++)
            {
                if(i >=start && i <= end)
                    res.Add(en.Current);
            }
            return res;
        }

        /// <summary>
        /// Conjoin a list. 1,2,3 => 1, 2 and 3.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="target">The list</param>
        /// <param name="separator">Separator</param>
        /// <param name="lastSeparator">Last separator</param>
        /// <returns>Conjoined text form</returns>
        public static string Conjoin<T>(this IEnumerable<T> target, string separator, string lastSeparator)
        {
            StringBuilder sb = new StringBuilder();
            IEnumerator<T> en = target.GetEnumerator();
            T s1;
            bool seenfirst = false;

            en.MoveNext();
            while(true)
            {
                s1 = en.Current;
                if (!en.MoveNext())
                {
                    if(!seenfirst)
                        sb.Append(s1);
                    else
                        sb.Append(lastSeparator).Append(s1);
                    break;
                }

                if(seenfirst)
                    sb.Append(separator).Append(s1);
                else
                {
                    sb.Append(s1);
                    seenfirst = true;
                }
            }
            return sb.ToString();
        }
    }
}