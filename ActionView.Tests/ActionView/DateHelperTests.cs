using System;
using System.Text;
using ActionPack.Helpers;
using MbUnit.Framework;

namespace ActionPack.Tests.ActionView
{
    [TestFixture]
    public class DateHelperTests
    {

        [Test]
        public void TestDistanceOfTimeInWords()
        {
            Assert.AreEqual("3 days",
                            DateHelper.DistanceOfTimeInWords(new DateTime(2008, 5, 25), new DateTime(2008, 5, 22), false));


        }


        public void TestSelectYearFoo2006()
        {
            Assert.AreEqual("<select id=\"foo\" name=\"foo\">\n"+
                            "<option value=\"2001\">2001</option>\n" +
                            "<option value=\"2002\">2002</option>\n" +
                            "<option value=\"2003\">2003</option>\n" +
                            "<option value=\"2004\">2004</option>\n" +
                            "<option value=\"2005\">2005</option>\n" +
                            "<option value=\"2006\" selected=\"selected\">2006</option>\n" +
                            "<option value=\"2007\">2007</option>\n" +
                            "<option value=\"2008\">2008</option>\n" +
                            "<option value=\"2009\">2009</option>\n" +
                            "<option value=\"2010\">2010</option>\n" +
                            "</select>\n", DateHelper.SelectYear("foo", 2006));
            //Assert.AreEqual("", DateHelper.SelectTime("boo", DateTime.Now, true));
            Assert.AreEqual("", DateHelper.SelectDateTime("goo", DateTime.Now));
        }


        [Test]
        public void perf()
        {
            StringBuilder sb = new StringBuilder();
            string id = "boo";
            int name = 33;

            long start = DateTime.Now.Ticks;
            for (int i = 0; i < 1000000; i++)
                //  String.Format("<select id=\"{0}\" name=\"{1}\"", id, name);
                sb.Append("<select id=\"").Append(id).Append("\" name=\"").Append(name).Append("\"");

            long rest = DateTime.Now.Ticks - start;
            // result - string.append is faster than string.format.
        }
        
    }
}