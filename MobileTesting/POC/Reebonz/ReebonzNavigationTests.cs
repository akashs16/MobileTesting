namespace MobileTesting.Android.POC.Reebonz
{
    using System;
    using DataObjects;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium.Android;
    using OpenQA.Selenium.Remote;
    using OpenQA.Selenium.Support.UI;

    [TestFixture]
    public class ReebonzNavigationTests
    {
        private DesiredCapabilities capabilities;
        private AndroidDriver<IWebElement> driver;
        private User user;

        [SetUp]
        public void Setup()
        {
            this.capabilities = new DesiredCapabilities();
            this.capabilities.SetCapability("platformName", "Android");
            this.capabilities.SetCapability("platformVersion", "23");
            this.capabilities.SetCapability("automationName", "Appium");
            this.capabilities.SetCapability("deviceName", "Nexus_6");

            this.user = new User()
            {
                FirstName = "Reebonz",
                LastName = "Tester",
                EmailAddress = Guid.NewGuid().ToString("N") + "@reebonz.com",
                Country = "Singapore",
                Gender = "Female",
                Password = "P@ssword@123"
            };
        }

        [Test]
        public void RegisterOnReebonz()
        {
            this.capabilities.SetCapability("app", "com.reebonz.fashion");
            this.capabilities.SetCapability("appActivity", "com.reebonz.fashion.supportclasses.SplashScreen");
            this.driver = new AndroidDriver<IWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), this.capabilities, TimeSpan.FromSeconds(180));
            var wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(10));
            wait.Until(dvr => dvr.FindElement(By.ClassName("android.widget.ImageButton")).Displayed);

            this.driver.FindElementByClassName("android.widget.ImageButton").Click();
            wait.Until(dvr => dvr.FindElement(By.Id("com.reebonz.fashion:id/txtRegisterHere")).Displayed);

            this.driver.FindElementById("com.reebonz.fashion:id/txtRegisterHere").Click();
            wait.Until(dvr => dvr.FindElement(By.Id("com.reebonz.fashion:id/txtEmail")).Displayed);

            this.driver.FindElementById("com.reebonz.fashion:id/txtEmail").SendKeys(this.user.EmailAddress);
            this.driver.HideKeyboard();
            this.driver.FindElementById("com.reebonz.fashion:id/txtPassword").SendKeys(this.user.Password);
            this.driver.HideKeyboard();
            this.driver.FindElementById("com.reebonz.fashion:id/txtLastName").SendKeys(this.user.LastName);
            this.driver.HideKeyboard();
            this.driver.FindElementById("com.reebonz.fashion:id/txtFirstName").SendKeys(this.user.FirstName);
            this.driver.HideKeyboard();
            this.driver.FindElementById("com.reebonz.fashion:id/txtCountry").Click();
            wait.Until(dvr => dvr.FindElement(By.ClassName("android.widget.FrameLayout")).Displayed);

            //var parent = this.driver.FindElement(By.ClassName("android.widget.FrameLayout"));
            var country = this.driver.ScrollTo("Singapore");
            country.Click();
        }

        [Test]
        public void LoginIntoReebonz()
        {

        }

        [TearDown]
        public void TearDown()
        {
            this.driver.Quit();
        }

    }
}