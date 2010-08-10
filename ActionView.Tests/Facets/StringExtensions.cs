using ActionPack.Extensions;
using MbUnit.Framework;

namespace ActionPack.Tests.Facets
{
    [TestFixture]
    public class StringExtensions
    {
        [Test]
        public void Justification()
        {
            Assert.AreEqual("notjustify", "notjustify".RJust(4));
            Assert.AreEqual("notjustify", "notjustify".RJust(12,"toobigpadding"));
            Assert.AreEqual("      just", "just".RJust(10));
            Assert.AreEqual("just      ", "just".LJust(10));
            Assert.AreEqual("justabcabc", "just".LJust(10, "abc"));
            Assert.AreEqual("justabcdab", "just".LJust(10, "abcd"));
            Assert.AreEqual("abcabcjust", "just".RJust(10, "abc"));
            Assert.AreEqual("abcdabjust", "just".RJust(10, "abcd"));
            Assert.AreEqual("notjustify", "notjustify".Center(4));
            Assert.AreEqual("notjustify", "notjustify".Center(12, "toobigpadding"));

            Assert.AreEqual(" moo ", "moo".Center(5));
            Assert.AreEqual("amooa", "moo".Center(5,"a"));
            Assert.AreEqual("amooda", "mood".Center(7, "a"));
        }

    }
}