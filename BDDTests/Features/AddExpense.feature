Feature: Add Expense

Scenario: User tries to add expense with empty input fields
	Given the new expense form is loaded
	When user enters "" in amount field
	And user enters "" in description field
	And user clicks Add button
	Then new expense should not be added

Scenario: User tries to add expense with positive number in amount field and empty description
	Given the new expense form is loaded
	When user enters "10" in amount field
	And user enters "" in description field
	And user clicks Add button
	Then new expense should be added

Scenario: User tries to add expense with positive number in amount field and provides description
	Given the new expense form is loaded
	When user enters "10" in amount field
	And user enters "Provided description" in description field
	And user clicks Add button
	Then new expense should be added

Scenario: User tries to add expense with empty amount field and provides description
	Given the new expense form is loaded
	When user enters "" in amount field
	And user enters "Provided description" in description field
	And user clicks Add button
	Then new expense should not be added

Scenario: User tries to add expense with NaN amount and empty description
	Given the new expense form is loaded
	When user enters "amount" in amount field
	And user enters "" in description field
	And user clicks Add button
	Then new expense should not be added

Scenario: User tries to add expense with NaN amount and provides description
	Given the new expense form is loaded
	When user enters "amount" in amount field
	And user enters "Provided description" in description field
	And user clicks Add button
	Then new expense should not be added
