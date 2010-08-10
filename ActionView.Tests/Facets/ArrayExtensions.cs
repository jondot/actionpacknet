using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ActionPack.Extensions;
using MbUnit.Framework;

namespace ActionPack.Tests.Facets
{
    [TestFixture]
    public class ArrayExtensions
    {
        [Test]
        public void TestConjoin()
        {
            List<string> l = new List<string>();
            l.Add("foo");

            Assert.AreEqual("foo", l.Conjoin(", ", " and "));
            l.Add("fa");

            Assert.AreEqual("foo and fa", l.Conjoin(", ", " and "));
            l.Add("fafee");
            Assert.AreEqual("foo, fa and fafee", l.Conjoin(", ", " and "));
            l.Add("feefee");
            Assert.AreEqual("foo, fa, fafee and feefee", l.Conjoin(", ", " and "));
        }
        public void TestSplice()
        {
            List<string> l = new List<string>();
            l.Add("1");
            l.Add("2");
            l.Add("3");
            l.Add("4");
            Assert.AreEqual("1", l.Splice(0,0).Conjoin(", ", " and "));
            Assert.AreEqual("2 and 3", l.Splice(1,2).Conjoin(", ", " and "));
            Assert.AreEqual("2, 3 and 4", l.Splice(1, 3).Conjoin(", ", " and "));
        }
    }
}