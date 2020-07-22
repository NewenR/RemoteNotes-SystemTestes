Feature: UserCanGetNotes
	In order to avoid mistakes
	As person without notes
	I want to see my notes

@positive
Scenario: See all my notes
	Given I try to connect to the service
	When the result should be connected successfully
	When I enter the login: login and password: password
	Then I see my notes
