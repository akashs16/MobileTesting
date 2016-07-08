Feature: Filters
	In order to filters on the search result page

Scenario Outline: To verify the correct results are displayed when a combintation of filters is applied
	Given I load the Reebonz app on <deviceType> 
	And click on any on going promotions to go to the search page
	When I select the <filterNames> as <filterValues>
	And apply the filters
	Then all the products on the page should be displayed according to the applied <fitlerNames> and <filterValues>
Examples: 
| deviceType | filterNames | filterValues |
| android    |             |              |