Feature: UserCanDeleteNote
	In order to avoid mistakes
	As user which cannot delete note
	I want to delete note

@positive
Scenario: User can delete note
	Given I try to connect to the service
	When the result should be connected successfully
	When I enter the login: login and password: password
	Then I see my notes
	When I try to delete one of my notes
	Then I see te result that my note is deleted
