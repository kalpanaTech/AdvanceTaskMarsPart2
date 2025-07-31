Feature: DescriptionFeature

User can Add, Delete and update the description.

Background: 
	Given User is on the login page
	When User enter valid email and password from the json file located at "C:\repo\AdvanceTaskMarsPart2\AdvanceTaskMarsPart2\AdvanceTaskMarsPart2\JsonTestData\LoginData.json"
	Then User should be logged in successfully
	Then User navigate to the desctiption on home page

Scenario: 01 - User add description successfully
	When User enter desctiption details from the json file located at "C:\repo\AdvanceTaskMarsPart2\AdvanceTaskMarsPart2\AdvanceTaskMarsPart2\JsonTestData\DescriptionAddTestData.json"
	Then User should be able to successfully add desctiption details

Scenario: 02 - User update description successfully
	When User enter desctiption details to update from the json file located at "C:\repo\AdvanceTaskMarsPart2\AdvanceTaskMarsPart2\AdvanceTaskMarsPart2\JsonTestData\DescriptionUpdateTestData.json"
	Then User should be able to successfully update desctiption details

Scenario: 03 - User delete description successfully
	When User enter desctiption details to delete from the json file located at "C:\repo\AdvanceTaskMarsPart2\AdvanceTaskMarsPart2\AdvanceTaskMarsPart2\JsonTestData\DescriptionDeleteTestData.json"
	Then User should be able to successfully delete desctiption details

Scenario: 04 - User add invalid description
	When User enter invalid desctiption details to add from the json file located at "C:\repo\AdvanceTaskMarsPart2\AdvanceTaskMarsPart2\AdvanceTaskMarsPart2\JsonTestData\DescriptionAddInvalidTestData.json"
	Then User should be able to test invalid desctiption details