Feature: EducationFeature

User can Add, Delete education details.
Background: 
	Given User is on the login page
	When User enter valid email and password from the json file located at "C:\repo\AdvanceTaskMarsPart2\AdvanceTaskMarsPart2\AdvanceTaskMarsPart2\JsonTestData\LoginData.json"
	Then User should be logged in successfully
	Then Remove existing education data


Scenario: 01 - User enter education details successfully
	Given User navigate to education tab
	When User enter education details from the json file located at "C:\repo\AdvanceTaskMarsPart2\AdvanceTaskMarsPart2\AdvanceTaskMarsPart2\JsonTestData\EducationAddTestData.json"
	Then User should be able to successfully add education details

Scenario: 02 - User delete education details successfully
	Given User navigate to education tab
	When User enter education details to delete from the json file located at "C:\repo\AdvanceTaskMarsPart2\AdvanceTaskMarsPart2\AdvanceTaskMarsPart2\JsonTestData\EducationDeleteTestData.json"
	Then User should be able to successfully delete education details


