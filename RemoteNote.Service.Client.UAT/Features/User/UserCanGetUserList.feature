Feature: UserCanGetUserList
	In order to avoid silly mistakes
	As a bad user
	I want to be shown user list

@mytag
Scenario: Get user list
	Given I try to connect to the service
	When the result should be connected successfully
	When I enter the login: login and password: password
	When I call user list
	Then I see user list
