namespace MobileTesting.Android.Steps
{
    using System;
    using System.Threading;
    using Enum;
    using PageObjects;
    using TechTalk.SpecFlow;

    [Binding]
    public class FiltersSteps : StepsBase
    {
        [Given(@"I load the Reebonz app on (.*)")]
        public void GivenILoadTheReebonzAppOn(string deviceType)
        {
            var device = GetEnumByName<DeviceType>(deviceType);

            switch (device)
            {
                case DeviceType.Android:
                    this.SetUpCapiblitiesAndDriver(DeviceType.Android);
                    break;
                case DeviceType.Ios:
                    this.SetUpCapiblitiesAndDriver(DeviceType.Ios);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        [Given(@"click on any on going promotions to go to the search page")]
        public void GivenClickOnAnyOnGoingPromotionsToGoToTheSearchPage()
        {
            Thread.Sleep(TimeSpan.FromSeconds(5));
        }

        [When(@"I select the (.*) as (.*)")]
        public void WhenISelectTheAsFilterAndAFilterValue(string fitlerName, string filterValue)
        {
            var productListingPageObject = new ProductListingPageObject(this.Driver);
            productListingPageObject.OpenFacets();

            var filterNameList = ListBuilderCommaSeperatedValues(fitlerName);
            var filterValueList = ListBuilderCommaSeperatedValues(filterValue);
            var filterNameValuePair = ZipLists(filterNameList, filterValueList);

            var searchResultPageObject = new SearchResultPageObject(this.Driver);

            searchResultPageObject.NavigateToFilterSelection(filterNameValuePair);
        }

        [When(@"apply the filters")]
        public void WhenApplyTheFilters()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"all the products on the page should be displayed according to the applied (.*) and (.*)")]
        public void ThenAllTheProductsOnThePageShouldBeDisplayedAccordingToTheAppliedAnd(string filterName, string filterValue)
        {
            ScenarioContext.Current.Pending();
        }
    }
}