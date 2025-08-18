Feature: ManageSentRequests

User can manage sent requests.

Background: 
	Given User is on the login page
	When User enter valid email and password from the json file located at "C:\repo\AdvanceTaskMarsPart2\AdvanceTaskMarsPart2\AdvanceTaskMarsPart2\JsonTestData\LoginData.json"
	Then User should be logged in successfully
	Then User navigate to manage requests tab
	Then User navigate to sent requests option

Scenario: 01 - User can withdraw requests
	When User click on the withdraw button 
	Then User can verify the withdraw request successfully

Scenario: 02 - User can update the completed requests
	When User click on the completed button  
	Then User can verify the completed request successfully

Scenario: 03 - User can review the completed requests
	When User review the service from the json file located at "C:\repo\AdvanceTaskMarsPart2\AdvanceTaskMarsPart2\AdvanceTaskMarsPart2\JsonTestData\SentRequesTestData.json"
	Then User can verify the review service successfully

Scenario: 04 - User can view the declined requests
	When User view the declined requests
	Then User can verify view declined requests successfully
