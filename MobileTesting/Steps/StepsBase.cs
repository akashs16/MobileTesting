namespace MobileTesting.Android.Steps
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Enum;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium.Android;
    using OpenQA.Selenium.Remote;

    public class StepsBase
    {
        private DesiredCapabilities Capabilities { get; set; }

        protected IWebDriver Driver { get; private set; }

        protected static T GetEnumByName<T>(string valueToBeMatched)
        {
            return (T)Enum.Parse(typeof(T), valueToBeMatched, true);
        }

        protected void SetUpCapiblitiesAndDriver(DeviceType deviceType)
        {
            var capabilities = new DesiredCapabilities();
            switch (deviceType)
            {
                case DeviceType.Android:
                    capabilities.SetCapability("platformName", "Android");
                    capabilities.SetCapability("platformVersion", "23");
                    capabilities.SetCapability("automationName", "Appium");
                    capabilities.SetCapability("deviceName", "Nexus 6");
                    capabilities.SetCapability("app", "com.reebonzmobileappdev");
                    capabilities.SetCapability("appActivity", "com.reebonzmobileapp.MainActivity");
                    this.Capabilities = capabilities;
                    this.Driver = new AndroidDriver<IWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), capabilities, TimeSpan.FromSeconds(180));
                    break;
                case DeviceType.Ios:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(deviceType), deviceType, null);
            }
        }

        protected static IEnumerable<string> ListBuilderCommaSeperatedValues(string commaSeperatedValues)
        {
            return commaSeperatedValues.Split(',').Select(x => x.Trim());
        }

        protected static Dictionary<object, object> ZipLists(IEnumerable<object> firstList, IEnumerable<object> secondList)
        {
            return firstList.Zip(secondList, Tuple.Create).ToDictionary(result => result.Item1, result => result.Item2);
        }
    }
}