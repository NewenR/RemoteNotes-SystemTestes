Feature: UserCanDeleteAnotherUser
	In order to avoid silly mistakes
	As a bad user
	I want to see a deleted user

@mytag
Scenario: Delete user
	Given I try to connect to the service
	When the result should be connected successfully
	When I enter the login: login and password: password
	When I call user list
	Then I see user list
	Then I can create a new user
	Then I can delete the new user