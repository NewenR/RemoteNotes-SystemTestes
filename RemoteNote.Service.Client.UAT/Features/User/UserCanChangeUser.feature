Feature: UserCanChangeUser
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Add two numbers
	Given I try to connect to the service
	When the result should be connected successfully
	When I enter the login: login and password: password
	When I call user list
	Then I see user list
	Then I can create a new user
	Then I can change this user
