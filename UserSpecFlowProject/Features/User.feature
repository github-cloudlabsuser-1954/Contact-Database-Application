Feature: User
    As a user
    I want to manage users
    So that I can keep track of all registered users

Scenario: Index
    Given I am on the User Index page
    When I request a list of all users
    Then I should see a list of all users

Scenario: Details
    Given I am on the User Details page for user with ID 1
    When I request the details of the user
    Then I should see the details of the user

Scenario: Create
    Given I am on the User Create page
    When I enter the details of a new user and submit the form
    Then the new user should be added to the list of users

Scenario: Edit
    Given I am on the User Edit page for user with ID 1
    When I change the details of the user and submit the form
    Then the details of the user should be updated

Scenario: Delete
    Given I am on the User Delete page for user with ID 1
    When I confirm the deletion of the user
    Then the user should be removed from the list of users