namespace MobileTesting.Android.PageObjects
{
    using System.Linq;
    using OpenQA.Selenium;

    internal class ProductListingPageObject
    {
        private readonly IWebDriver driver;

        private const string HorizontalScrollClass = "android.widget.HorizontalScrollView";
        private const string FacetsClass = "android.view.ViewGroup";

        public ProductListingPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void OpenFacets()
        {
            var parentScroll = this.driver.FindElements(By.ClassName(HorizontalScrollClass));
            var requriredFacets = parentScroll.First().FindElement(By.ClassName(FacetsClass)).FindElements(By.ClassName(FacetsClass));
            requriredFacets.First().Click();
        }
    }
}