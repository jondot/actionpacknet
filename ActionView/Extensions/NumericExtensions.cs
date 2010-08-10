using ActionPack.Helpers;

namespace ActionPack.Extensions
{
    /// <summary>
    /// Numeric extensions, adopted from rails' actionsupport
    /// </summary>
    public static class NumericExtensions
    {
        /// <summary>
        /// Amount in bytes
        /// </summary>
        /// <param name="amount">The amount</param>
        /// <returns>Amount</returns>
        public static int Bytes(this int amount)
        {
            return amount;
        }

        /// <summary>
        /// Amount in kilobytes
        /// </summary>
        /// <param name="amount">The amount</param>
        /// <returns>Amount</returns>
        public static int Kilobytes(this int amount)
        {
            return 1024*amount.Bytes();
        }

        /// <summary>
        /// Amount in megabytes
        /// </summary>
        /// <param name="amount">The amount</param>
        /// <returns>Amount</returns>
        public static int Megabytes(this int amount)
        {
            return 1024 * amount.Kilobytes();
        }

        /// <summary>
        /// Amount in gigabytes
        /// </summary>
        /// <param name="amount">The amount</param>
        /// <returns>Amount</returns>
        public static int Gigabytes(this int amount)
        {
            return 1024 * amount.Megabytes();
        }

        /// <summary>
        /// Amount in petabytes
        /// </summary>
        /// <param name="amount">The amount</param>
        /// <returns>Amount</returns>
        public static int Petabytes(this int amount)
        {
            return 1024 * amount.Gigabytes();
        }

        /// <summary>
        /// Amound in exabytes
        /// </summary>
        /// <param name="amount">The amount</param>
        /// <returns>Amount</returns>
        public static int Exabytes(this int amount)
        {
            return 1024 * amount.Petabytes();
        }

        public static string ToHumanSize(this long size)
        {
            return NumberHelper.NumberToHumanSize(size);
        }


    }
}