Feature: UserCanGetNotification
	In order to avoid silly mistakes
	As a bad user
	I want to be able to get a notification

@mytag
Scenario: Get notification
	Given I try to connect to the service
	When the result should be connected successfully
	When I enter the login: login and password: password
	Then I can get a notification
