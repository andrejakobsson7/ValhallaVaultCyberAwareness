Feature: Login

  Scenario: Login with valid credentials
    Given I am on the login page
    When I type "admin" in ":nth-child(5) > .form-control"
    And I type "Password1234!" in ":nth-child(6) > .form-control"
    And I click the login button
    Then I should see be redirected to home