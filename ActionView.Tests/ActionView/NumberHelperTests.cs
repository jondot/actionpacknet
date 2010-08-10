using ActionPack.Helpers;
using MbUnit.Framework;

namespace ActionPack.Tests.ActionView
{
    [TestFixture]
    public class NumberHelperTests
    {
        [Test]
        public void NumberToPhone()
        {
            Assert.AreEqual("123-555-1234", NumberHelper.NumberToPhone("1235551234","","","-",false));
        }
        [Test]
        public void NumberWithDelimiter()
        {
            Assert.AreEqual("98 765 432,98", NumberHelper.NumberWithDelimiter("98765432.98", " ", ","));
        }
        [Test]
        public void NumberToHumanSize()
        {
            Assert.AreEqual("1.2 MB", NumberHelper.NumberToHumanSize(1234567, 1));
        }
    }
}