Feature: CertificationFeature

User can Add, Delete certification details.

Background: 
	Given User is on the login page
	When User enter valid email and password from the json file located at "C:\repo\AdvanceTaskMarsPart2\AdvanceTaskMarsPart2\AdvanceTaskMarsPart2\JsonTestData\LoginData.json"
	Then User should be logged in successfully
	Then Remove existing certification data

Scenario: 01 - User enter certification details successfully
	Given User navigate to certification tab
	When User enter certification details from the json file located at "C:\repo\AdvanceTaskMarsPart2\AdvanceTaskMarsPart2\AdvanceTaskMarsPart2\JsonTestData\CertificationAddTestData.json"
	Then User should be able to successfully add certification details

Scenario: 02 - User delete certification details successfully
	Given User navigate to certification tab
	When User enter certification details to delete from the json file located at "C:\repo\AdvanceTaskMarsPart2\AdvanceTaskMarsPart2\AdvanceTaskMarsPart2\JsonTestData\CertificationDeleteTestData.json"
	Then User should be able to successfully delete certification details
