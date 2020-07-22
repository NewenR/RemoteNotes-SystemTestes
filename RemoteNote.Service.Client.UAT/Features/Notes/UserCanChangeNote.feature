Feature: UserCanChangeNote
	In order to avoid mistakes
	As user who cannot change note
	I want to be told the sum of two numbers

@positive
Scenario: Change notes
	Given I try to connect to the service
	When the result should be connected successfully
	When I enter the login: login and password: password
	Then I see my notes
	When I try to change one of my notes
	Then I see te result that my note is changed
	 
