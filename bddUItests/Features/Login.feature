Feature: Login
	As a Team member of OrangeHRM
	I want to login to Application
	So that i can access to my dashboard

@release1
Scenario: Login to Application
	Given I have navigated to Login page
	And I have entered username on Login Page
	And I have entered password on Login Page
	When I have clicked on LOGIN button
	Then I should see Welcome message with username
		| LoggedInUserName |
		#| Welcome Andrei   |
		| Welcome Paul		   |

@release1
Scenario: Invalid Login Credentials
	Given I have navigated to Login page
	And I have entered below Login details
		| Username | Password      |
		| Admin    | wrongpassword |
	When I have clicked on LOGIN button
	Then I should see "Invalid credentials" on the LoginPanel

@release1
Scenario: UserName cannot be Empty
	Given I have navigated to Login page
	And I have entered below Login details
		| Username | Password      |
		|          | wrongpassword |
	When I have clicked on LOGIN button
	Then I should see "Username cannot be empty" on the LoginPanel