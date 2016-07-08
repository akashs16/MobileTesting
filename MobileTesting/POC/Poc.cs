namespace MobileTesting.Android.POC
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium.Android;
    using OpenQA.Selenium.Remote;

    [TestFixture]
    public class Poc
    {
        private AndroidDriver<IWebElement> driver;
        private DesiredCapabilities capabilities;

        [SetUp]
        public void Setup()
        {
            this.capabilities = new DesiredCapabilities();
            this.capabilities.SetCapability("platformName", "Android");
            this.capabilities.SetCapability("platformVersion", "23");
            this.capabilities.SetCapability("automationName", "Appium");
            this.capabilities.SetCapability("deviceName", "Galxy_S7_Edge_Black");
        }

        [Test]
        public void TryCallingAppium()
        {
            this.capabilities.SetCapability("app", "com.android.calculator2");
            this.capabilities.SetCapability("appActivity", "com.android.calculator2.Calculator");
            this.driver = new AndroidDriver<IWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), this.capabilities, TimeSpan.FromSeconds(180));

            this.driver.FindElementByName("2").Click();
            this.driver.FindElementByName("+").Click();
            this.driver.FindElementByName("2").Click();
            this.driver.FindElementByName("=").Click();

            var result = this.driver.FindElementByClassName("android.widget.EditText").Text;

            Assert.That(result, Is.EqualTo("4"), "The correct result should be calculated");
        }

        [Test]
        public void TryDailing()
        {
            this.capabilities.SetCapability("app", "com.android.dialer");
            this.capabilities.SetCapability("appActivity", "com.android.dialer.DialtactsActivity");
            this.driver = new AndroidDriver<IWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), this.capabilities, TimeSpan.FromSeconds(180));

            var numbersToDial = new List<string>() { "8", "2", "3", "4", "4", "3", "2", "1" };
            this.driver.FindElementByClassName("android.widget.ImageButton").Click();

            var element = this.driver.FindElementById("com.android.dialer:id/dialpad_view");

            var dialPad = element.FindElements(By.ClassName("android.widget.FrameLayout"));

            foreach (var number in numbersToDial)
            {
                dialPad.First(x => x.FindElement(By.ClassName("android.widget.TextView")).Text == number).Click();
            }
        }

        [TearDown]
        public void KillDriver()
        {
            this.driver.Quit();
        }
    }
}
