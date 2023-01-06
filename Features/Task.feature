Feature: Log in to account, add Student job and then delete Student job

@Task
Scenario: Log in to account, add Student job and then delete Student job
    # Log in part
    Given I logging in
    | Key       | Value     |
    | Login     | Admin     |
	| Password  | admin123  |
    # Adding Student job part
    When I go to Admin page
    And I navigate to Job Titles section
    And I click on Add button
    And I fill form for my job
    | Key         | Value        |
    | Title       | Student      |
    | Description | KPI student  |
    | Note        | IASA student |
    # Deleting Student job part
    When I delete Student job

