Feature: Sign In

Scenario: User tries to sign in using valid credentials
	Given the sign in form is loaded
	When user enters valid username and password
	And user clicks Sign In button
	Then user should be signed in
	
Scenario: User tries to sign in using wrong password
	Given the sign in form is loaded
	When user enters wrong password
	And user clicks Sign In button
	Then user should not be signed in
