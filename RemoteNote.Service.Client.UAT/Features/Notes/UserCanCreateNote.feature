Feature: UserCanCreateNote
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Add two numbers
	Given I try to connect to the service
	When the result should be connected successfully
	When I enter the login: login and password: password
	Then I see my notes
	When I try to create a new note
	Then I see te result that the new note is created

