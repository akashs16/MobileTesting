namespace MobileTesting.Android.PageObjects
{
    using System.Collections.Generic;
    using System.Linq;
    using OpenQA.Selenium;
    using Selectors;

    internal class SearchResultPageObject
    {
        private readonly IWebDriver driver;

        public SearchResultPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void NavigateToFilterSelection(Dictionary<object, object> filterNameValuePair)
        {
            var filters = this.driver.FindElements(By.ClassName(SearchResultsPageSelectors.AllCurrentFiltersClass));

            filters.First().Click();
        }
    }
}