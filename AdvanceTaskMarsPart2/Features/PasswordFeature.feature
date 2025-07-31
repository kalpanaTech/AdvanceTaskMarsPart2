Feature: PasswordFeature

User can change password.
Background: 
	Given User is on the login page
	When User enter valid email and password from the json file located at "C:\repo\AdvanceTaskMarsPart2\AdvanceTaskMarsPart2\AdvanceTaskMarsPart2\JsonTestData\LoginData.json"
	Then User should be logged in successfully
	Then User navigate to change password option

Scenario: 01 - User change password successfully
	When User enter passwords from the json file located at "C:\repo\AdvanceTaskMarsPart2\AdvanceTaskMarsPart2\AdvanceTaskMarsPart2\JsonTestData\PasswordChangeTestData.json"	
	Then User should be able to successfully change the password

Scenario: 02 - User add invalid data to change password 
	When User enter invalid passwords from the json file located at "C:\repo\AdvanceTaskMarsPart2\AdvanceTaskMarsPart2\AdvanceTaskMarsPart2\JsonTestData\PasswordChangeInvalidTestData.json"	
	Then User should be able to test invalid passwords