Feature: Dashboard

@release1
Scenario: View Dashboard
	Given I have navigated to Login page
	And I have entered username on Login Page
	And I have entered password on Login Page
	And I have clicked on LOGIN button
	Then I should see "Dashboard" title on DashboardPage
	Then I should see below Dashboard columns on DashboardPage
		| Column1                          | Column2 | Column3                |
		| Employee Distribution by Subunit | Legend  | Pending Leave Requests |
	And I should see below Legend categories on DashboardPage
		| Names                    |
		| Not assigned to Subunits |
		| Administration           |
		| Client Services          |
		| Engineering              |
		| Finance                  |
		| Human Resources          |
		| Sales & Marketing        |

@release1
Scenario: View My Timesheet
	Given I have navigated to Login page
	And I have entered username on Login Page
	And I have entered password on Login Page
	And I have entered password on Login Page
	And I have clicked on LOGIN button
	When I have clicked on MyTimeSheet link
	#Then  I should see section as "Actions Performed on the Timesheet" on mytimesheet
	Then I should see "Status: Not Submitted" in the Time tabPage

	#And I should see below actions performed on the timesheet
	#	| Action    | Performed By       | Date       | Comment |
	#	| Submitted | Andrei Ionut Popescu | 2021-11-10 |         |