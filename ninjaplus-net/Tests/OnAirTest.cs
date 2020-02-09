using NUnit.Framework;
using Coypu;
using Coypu.Drivers.Selenium;
using System.Threading;
using NinjaPlus.Common;

namespace NinjaPlus.Tests
{
    public class OnAirTest : BaseTest
    {

        
        [Test]
        [Category("Smoke")]
        public void ShouldBeHaveTitle()
        {
            Browser.Visit("/login");
            Assert.AreEqual("Ninja+", Browser.Title);
            //Thread.Sleep(5000);
            //browser.Dispose();
        }

        


    }
}