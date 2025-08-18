Feature: ManageListingFeature

User can manage listings.

Background: 
	Given User is on the login page
	When User enter valid email and password from the json file located at "C:\repo\AdvanceTaskMarsPart2\AdvanceTaskMarsPart2\AdvanceTaskMarsPart2\JsonTestData\LoginData.json"
	Then User should be logged in successfully
	Then User navigate to manage listings tab

Scenario: 01 - User view manage listings successfully
	When User view manage listings
	Then User can verify view manage listings successfully

Scenario: 02 - User edit manage listings successfully
	When User edit manage listings from the json file located at "C:\repo\AdvanceTaskMarsPart2\AdvanceTaskMarsPart2\AdvanceTaskMarsPart2\JsonTestData\ManageListingsEditTestData.json"
	Then User can view the updated manage listings successfully

Scenario: 03 - User delete manage listings successfully
	When User delete manage listings
	Then User can verify delete manage listings successfully

Scenario: 04 - User send manage listings requests successfully
	When User search profile and enter request message from the json file located at "C:\repo\AdvanceTaskMarsPart2\AdvanceTaskMarsPart2\AdvanceTaskMarsPart2\JsonTestData\ManageListingsSendRequestTestData.json"
	Then User can verify send manage listings requests successfully

Scenario: 05 - User activate manage listing service successfully
	When User activate manage listings
	Then User can verify activate manage listings successfully

Scenario: 06 - User deactivate manage listing service successfully
	When User deactivate manage listings
	Then User can verify deactivate manage listings successfully