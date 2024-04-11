import { Given, When, Then } from "@badeball/cypress-cucumber-preprocessor";

Given("I am on the login page", () => {
  cy.visit("/Account/Login");
});

When("I type {string} in {string}", (a, selector) => {
  cy.get(selector).type(a);
});

When("I click the login button", () => {
  cy.get(".w-100").click();
});

Then("I should see be redirected to home", () => {
  cy.get('href="/UserPage"]').should("be.visible");
});
