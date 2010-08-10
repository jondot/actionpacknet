using System.Collections.Generic;
using ActionPack.Helpers;
using MbUnit.Framework;

namespace ActionPack.Tests.ActionView
{
    [TestFixture]
    public class TextHelperTests
    {
        [Test]
        public void Truncate()
        {
            Assert.AreEqual("And they found t(clipped)", TextHelper.Truncate("And they found that many people were sleeping better.", 25, "(clipped)"));
        }
        [Test]
        public void Highlight()
        {
            Assert.AreEqual("You searched for: <strong class=\"highlight\">rails</strong>",
                            TextHelper.Highlight("You searched for: rails", "rails")  );
        }
        [Test]
        public void Excerpt()
        {
            Assert.AreEqual("...s is an exam...",TextHelper.Excerpt("This is an example", "an", 5) );
            Assert.AreEqual("This is a...", TextHelper.Excerpt("This is an example", "is", 5));
            Assert.AreEqual("This is an example",TextHelper.Excerpt("This is an example", "is") );
            Assert.AreEqual("... next ...", TextHelper.Excerpt("This next thing is an example", "ex", 2) );
        }
        [Test]
        public void Pluralize()
        {
            Assert.AreEqual("1 person", TextHelper.Pluralize(1, "person"));
            Assert.AreEqual("2 people", TextHelper.Pluralize(2, "person"));
            Assert.AreEqual("3 users", TextHelper.Pluralize(3, "person", "users"));
            Assert.AreEqual("0 people", TextHelper.Pluralize(0, "person"));
        }

        [Test]
        public void AutoLink()
        {
            Assert.AreEqual("hello <a href=\"mailto:dipid@gmail.com\">dipid@gmail.com</a> crewl world!", TextHelper.AutoLink("hello dipid@gmail.com crewl world!", TextHelper.AutoLinkOptions.Email,""));
            Assert.AreEqual("hello <a href=\"http://www.some.fucking.org\">http://www.some.fucking.org</a> world!", TextHelper.AutoLink("hello http://www.some.fucking.org world!", TextHelper.AutoLinkOptions.Url,""));
        }
        [Test]
        public void Cycle()
        {
            IEnumerator<string> e = TextHelper.Cycle<string>(new string[] { "hello", "world" }).GetEnumerator();
            e.MoveNext();

            Assert.AreEqual("hello", e.Current);
            e.MoveNext();
            Assert.AreEqual("world", e.Current);
            e.MoveNext();
            Assert.AreEqual("hello", e.Current);
            e.MoveNext();
            Assert.AreEqual("world", e.Current);
        }

    }
}