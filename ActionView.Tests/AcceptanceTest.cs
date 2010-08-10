using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;
using ActionSupport;

namespace ActionSupport.Tests
{
    [TestFixture]
    public class AcceptanceTest
    {
        [Test]
        public void TimeExtensions()
        {
            Assert.IsTrue(Math.Abs(1.Days().FromNow().Ticks - DateTime.Now.AddDays(1).Ticks) < 200);
            Assert.IsTrue(Math.Abs((1.Days() * 3).Ticks - new TimeSpan(3,0,0,0).Ticks) < 20);
        }
    }
}
