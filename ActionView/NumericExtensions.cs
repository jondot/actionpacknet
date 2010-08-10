using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ActionSupport
{
    public static class NumericExtensions
    {
        public static int Bytes(this int amount)
        {
            return amount;
        }
        public static int Kilobytes(this int amount)
        {
            return 1024*amount.Bytes();
        }
        public static int Megabytes(this int amount)
        {
            return 1024 * amount.Kilobytes();
        }
        public static int Gigabytes(this int amount)
        {
            return 1024 * amount.Megabytes();
        }
        public static int Petabytes(this int amount)
        {
            return 1024 * amount.Gigabytes();
        }
        public static int Exabytes(this int amount)
        {
            return 1024 * amount.Petabytes();
        }
     }
}
