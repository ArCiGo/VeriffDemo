
# Test Plan

A short test plan for Veriff assessment

## Objectives 🎯

The following items are going to be tested.-

* **Functional testing**
    * *API*
        * Automation testing of the following endpoints.-
            * https://demo.saas-3.veriff.me/
            * https://magic.saas-3.veriff.me/api/v2/sessions
    * *UI*
        * Automation testing, in Chrome browser, for [Veriff demo site](https://demo.saas-3.veriff.me/).-
            * Session configuration.

Non-functional testing is not considered in this plan since there are no people trained in this.

## Deliverables 💼

Automation framework, made in C#, with tests and test plan.

## Assumptions 🤔

* Since we are working in an agile environment, we are expecting a continuous delivery of the features developed to start testing.  
* The Development team must deliver to the Test team the features and environments needed for testing.  
* The Development team should work as soon as possible on the issues found during testing, and then report to the Test team about the fixes (to continue the testing process).  
* The testers dedicated to testing the features agreed for this sprint should be focused on these tasks.

## Test Scenarios 💻

The following scenarios were made from a user perspective.

```gherkin
Feature: Veriff demo flow

# As a user, I should be able to create a valid session configuration using InContext option
Scenario outline: Valid session configuration
    Given the following values "<fullNname>", "<sessionLanguage>", 
        "<documentCountry>" and "<documentType>"
    When I click on InContext option
    And I click on Veriff Me button
    Then I should be able to see the QR code to continue setting up the session

    Examples:
    | fullNname                 | sessionLanguage   | documentCountry   | documentType      |
    | Armando Cifuentes González| Español (México)  | Mexico            | ID Card           |
    | Viktoriia Pentina         | Eesti             | Estonia           | Passport          |
    | Κατερίνα Σακελλαροπούλου  | Ελληνικά          | Greece            | Residence Permit  |
    | სალომე ზურაბიშვილი        | ქართული           | Georgia           | Driver's license  |
    # An so on...

# As a user, I should be able to create a valid session configuration using Redirect option
Scenario outline: Valid session configuration
    Given the following values "<fullNname>", "<sessionLanguage>", 
        "<documentCountry>" and "<documentType>"
    When I click on Redirect option
    And I click on Veriff Me button
    Then I should be able to see the QR code to continue setting up the session

    Examples:
    | fullNname                 | sessionLanguage   | documentCountry   | documentType      |
    | Володимир Зеленський      | Українська        | Ukraine           | ID Card           |
    # An so on...

# As a user, I should not be able to create a valid session configuration 
# if I set a wrong value for full name
Scenario outline: Invalid session configuration
    Given the following values "<fullNname>", "<sessionLanguage>", 
        "<documentCountry>", "<documentType>" and "<launchVeriff>"
    When I click on InContext option
    And I click on Veriff Me button
    Then I should not be able to create a session

    Examples:
    | fullNname                                     | sessionLanguage   | documentCountry   | documentType  |
    | ""                                            | Čeština           | Czech Republic    | Passport      |
    | null                                          | Čeština           | Czech Republic    | Passport      |
    # this is an space value
    |                                               | Čeština           | Czech Republic    | Passport      |
    # this is an empty string value
    |                                               | Čeština           | Czech Republic    | Passport      |
    | UNION SELECT username, password from users--  | Čeština           | Czech Republic    | Passport      |
    # An so on...

# As a user, I should not be able to create a valid session configuration 
# if I set a wrong value for full name
Scenario outline: Invalid session configuration
    Given the following values "<fullNname>", "<sessionLanguage>", 
        "<documentCountry>", "<documentType>" and "<launchVeriff>"
    When I click on Redirect option
    And I click on Veriff Me button
    Then I should not be able to create a session

    Examples:
    | fullNname                                     | sessionLanguage   | documentCountry   | documentType  |
    | UNION SELECT username, password from users--  | Čeština           | Czech Republic    | Passport      |
    # An so on...

```
## Risks ☠️

### Technical discoveries (bugs 🕵️ 🔎 🐞)

During the exploratory testing of the UI and API, I found these interesting things

* There is no validation for the **Full Name** input field. It is possible to set any kind of value (like empty strings, SQL queries, blank spaces, alphanumeric strings, special characters, emojis, names with less than 1 character, etcetera).
* What is the validation for alphabets like Greek, Russian, Arabian, etcetera, or special characters of the Latino alphabet?
* Dropdowns and options are in different places in DOM. Options are rendered inside `<reach-portal>` node, and "dropdown" inside `<section class="grid-double">` node (also, it is a button). For automation purposes, and as good HTML practice, `<select>` tag is recommended and facilitates code development.
* There are no error flows.
* If you click on the **Close** icon button, instead of returning you to Veriff Demo it returns you to Veriff home page and the URL has parameters.
* When **Session Language** is set, the disposition of the elements in the iFrame element and Redirect page changes (check with Arabian language).
* Elements have values generated by the transpiler (maybe generated by React). For example: `<input class="TextField-module_input__3FXIK" name="name" value="Laney Jacintha">` (_3FXIK_ is the value).
* There are no IDs to identify the elements.
* Token does not expire. I can still use the same token I generated days ago.
* There is no validation for body objects sent to the endpoints.
* **Extent Reports** does not allow to change the name of the reports.

### Others 📄 💉 ⚠️

* Delays in the continuous delivery due to.- 
    * Failure in third-party services:
        * Lack of knowledge about how to implement the services needed for development. 
        * Third-party services are no longer maintained by the provider or supporters. 
        * Third-party services are down. 
    * In-house services are down. 
    * Lack of knowledge from the testers about the system or tools for testing. 
    * Site is unavailable. 
* Changes in the sprint. 
* Lack of clarity about the scope of the sprint. 
* Lack of/Ambiguous requirements to develop and test the features. 
* Lack of trained staff. 
* Extraordinary events, such as vacations, illnesses, pandemics, deaths, PTOs, holidays, etcetera.

## Staff 🧍

- **Armando Cifuentes González** ([@ArCiGo](https://www.linkedin.com/in/arcigo/))
    * _Software Engineer in Test_.
        * Experience with:
            * **Manual testing process**: _API/UI/UX testing for Web and Mobile (Android & iOS). A little bit of UX testing_.
            * **Automation testing process**: _API/UI testing for Web. A little bit of Unit testing_.
            * **Testing practice**: _Exploratory, Smoke, e2e, Retesting and Regression testing. Software analysis_.
            * **Tools**: _Postman, C#, Java, git, Selenium, Restsharp. A little bit of JS (but open to retaking it!)_.

## Tools 🔨

The following tools are going to be used to develop the automation framework.

* **Products**
    * _Postman_.
    * _Google Chrome_.
    * _Visual Studio for Mac_.
    * _Restsharp_.
    * _Extent Reports_.
    * _hyper_.
    * _Github_.
* **Languages**
    * _C#._
    * _Markdown_.
* **SVC**
    * _git_.

### Known limitations

* Lack of experience in Docker.
* I did not find a way to merge both reports (API and UI).
* Time.

I'm open to improvements!

## About Veriff 💻

Growing up on a farm, hay bales were a staple of Kaarel Kotkas’s childhood. At the age of 14, he noticed that the strings that bound them did not biodegrade, and often ended up littered across the fields of the otherwise pristine landscape of rural Estonia. 
 
Kaarel set out to find an environmentally-friendly alternative, and after browsing the web he came across the perfect string (it also came in his favorite color). As he registered an account on arguably the biggest global online marketplace, he was asked to verify that he was over 18. After a little photo editing, he breezed through their security and was able to buy the string. 

While his mission was a success, Kaarel couldn’t stop thinking about how easy it was to pretend to be someone else online. If successful companies are this vulnerable to fraud, then smaller businesses don’t stand a chance. This early experience planted the seed that would one day grow into Veriff. 
 
Kaarel founded Veriff in 2015 at the age of 20. Shortly after, it popped up on the global radar and in 2018 it joined the Y Combinator spring batch. Fast forward to now, Veriff has over 360 employees and serves over 190 countries as the gold standard for online identity verification. 


## Agreement signatures ✍️

* **Armando Cifuentes González**. *Software Engineer in Test*. Team Veriff Demo.
