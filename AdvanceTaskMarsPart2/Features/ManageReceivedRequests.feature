Feature: ManageRequests

User can manage received requests.

Background: 
	Given User is on the login page
	When User enter valid email and password from the json file located at "C:\repo\AdvanceTaskMarsPart2\AdvanceTaskMarsPart2\AdvanceTaskMarsPart2\JsonTestData\LoginData.json"
	Then User should be logged in successfully
	Then User navigate to manage requests tab
	Then User navigate to received requests option

Scenario: 01 - User can accept received requests
	When User click on the accept button and view the status
	Then User can verify accept received request successfully 

Scenario: 02 - User can decline received requests
	When User click on the decline button and view the status
	Then User can verify decline received request successfully 

Scenario: 03 - User can view the requests after completing from the user's end
	When User click on the complete button and view the status
	Then User can verify completed requests view successfully  

Scenario: 04 - User can view the requests after completing from the sender's end
	When User view the completed requests
	Then User can verify the completed requests view successfully  

Scenario: 05 - User can view the requests withdrawn from the sender's end
	When User view the withdrawn requests
	Then User can verify the withdrawn requests view successfully  
