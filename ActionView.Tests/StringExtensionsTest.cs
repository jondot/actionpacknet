using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using MbUnit.Framework;

namespace ActionSupport.Tests
{
    [TestFixture]
    public class StringExtensionsTest
    {
        [Test]
        public void Camelize()
        {
            Assert.AreEqual("HelloCrewlWorld", "hello crewl world".Camelize());
            Assert.AreEqual("helloCrewlWorld", "hello_crewl_world".Camelize(true));
            Assert.AreEqual("helloCrewlWorld", "hello.crewl.world".Camelize(true));
        }
        [Test]
        public void Capitalize()
        {
            Assert.AreEqual("Hello crewl world. oh crewl, crewl world.", "hello crewl world. oh crewl, crewl world.".Capitalize());
        }
        [Test]
        public void TitleCase()
        {
            Assert.AreEqual("Hello Crewl World. Oh Crewl, Crewl World.", "hello crewl world. oh crewl, crewl world.".TitleCase());   
        }
        [Test]
        public void Singularize()
        {
            Assert.AreEqual("person", "people".Singularize());
            Assert.AreEqual("boo", "boo".Singularize());
        }
        [Test]
        public void Pluralize()
        {
            Assert.AreEqual("people", "person".Pluralize());
            Assert.AreEqual("boos", "boo".Pluralize());
        }
        [Test]
        public void Dasherize()
        {
            Assert.AreEqual("hello-crewl-world", "hello crewl world".Dasherize());
            Assert.AreEqual("hello-crewl-world", " hello_crewl_world  ".Dasherize());
            Assert.AreEqual("hello", "hello".Dasherize());
            Assert.AreEqual("", "".Dasherize());
        }        
        [Test]
        public void Decamelize()
        {
            Assert.AreEqual("Hello World", "HelloWorld".Decamelize());
            Assert.AreEqual("Hello-World", "HelloWorld".Decamelize("-"));
            Assert.AreEqual("hello-World", "helloWorld".Decamelize("-"));
            Assert.AreEqual("Hello", "Hello".Decamelize());
        }
        [Test]
        public void Ordinalize()
        {
            Assert.AreEqual("1st", 1.Ordinalize());
            Assert.AreEqual("2nd", 2.Ordinalize());
            Assert.AreEqual("42nd", 42.Ordinalize());
            Assert.AreEqual("4th", 4.Ordinalize());
            Assert.AreEqual("13th", 13.Ordinalize());
            Assert.AreEqual("14th", 14.Ordinalize());
        }
        [Test]
        public void Access()
        {
            Assert.AreEqual("lo", "hello".From(3));
            Assert.AreEqual("hell", "hello".To(3));
            Assert.AreEqual("he", "hello".First(2));
            Assert.AreEqual("lo", "hello".Last(2));
        }
        public void perf()
        {
            StringBuilder sb = new StringBuilder();
            string word = "encyclopedia";

            long start = DateTime.Now.Ticks;
            for (int i = 0; i < 1000000; i++)
                Thread.CurrentThread.CurrentUICulture.TextInfo.ToTitleCase(word.ToLower(System.Globalization.CultureInfo.InvariantCulture));

            long rest = DateTime.Now.Ticks - start;
            // result - string.append is faster than string.format.
        }

    }
}
