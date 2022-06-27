Feature: Sign In Full Coverage

Scenario: User tries to sign in using empty fields
	Given the sign in form is loaded
	When user clicks Sign In button
	Then user should not be signed in
	
Scenario: User tries to sign in using only username
	Given the sign in form is loaded
	When user enters username
	And user clicks Sign In button
	Then user should not be signed in

Scenario: User tries to sign in using only password
	Given the sign in form is loaded
	When user enters password
	And user clicks Sign In button
	Then user should not be signed in

Scenario: User tries to sign in using not existing username
	Given the sign in form is loaded
	When user enters not existing username
	And user clicks Sign In button
	Then user should not be signed in

Scenario: User tries to sign in using wrong password
	Given the sign in form is loaded
	When user enters wrong password
	And user clicks Sign In button
	Then user should not be signed in

Scenario: User tries to sign in using valid credentials
	Given the sign in form is loaded
	When user enters valid username and password
	And user clicks Sign In button
	Then user should be signed in
