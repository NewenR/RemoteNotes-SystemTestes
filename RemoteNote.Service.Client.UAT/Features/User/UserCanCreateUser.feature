Feature: UserCanCreateUser
	In order to avoid silly mistakes
	As a bad user
	I want to be able to create user

@mytag
Scenario: Register a new user
	Given I try to connect to the service
	When the result should be connected successfully
	When I enter the login: login and password: password
	When I call user list
	Then I see user list
	Then I can create a new user
