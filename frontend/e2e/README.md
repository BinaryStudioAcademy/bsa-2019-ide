#Preconditions
- Install NodeJS LTS version
- VSCode or any other IDE
- terminal
- hands and brain

#Useful materials for locators/selectors
- DOM tree - https://learn.javascript.ru/dom-nodes
- Xpath Manual - https://docs.google.com/document/d/1PdfKMDfoqFIlF4tN1jKrOf1iZ1rqESy2xVMIj3uuV3g/pub
- CSS Selectors - https://www.w3schools.com/cssref/css_selectors.asp
- CSS Selectors Tester - https://www.w3schools.com/cssref/trysel.asp

### Useful links

[WebDriverIO](https://webdriver.io/docs/api.html) - Useful to learn how it works
[MochaJS](https://mochajs.org/#command-line-usage) - Useful to learn additional commands for our test runner
[Chai](https://www.chaijs.com/) - assertion library. Extends the NodeJS's assert.

### Prerequisities
````
npm i

````
Create `credentials.json` file in `/test` folder with your Credentials.

## Running the tests

### Automated tests

Run the following commands inside the folder
````
npm test 
````

##Structure of the project
```
├───output
├───helpers
├───pages
├───specs
    ├───_test.js
├───steps_file.js
```
* helpers - directory with additional helpers that extends base API.
* pages - directory with Page Fragments, Page Objects, Factories etc, more details [here](https://webdriver.io/docs/pageobjects.html)
* specs - tests, located in the folders. Each folder inside includes page objects, actions, steps and tests.
* wdio.conf.js - base configuration for webdriverIO. 

## Nuances for working with helpers
* Name of the method should be "talkable"
* Each method should include a description (comment) about what it does and information about input and output
* BDD concept.
	Bad Example
```
var user = yield I.createUser();
  I.clearCookie();
  I.amOnPage('/404');
  I.setLoginCookieFor(user.email, user.password);
  I.amOnPage('/page/');
```
    Good Example:
```
  I.amAuthorizedUser();
  I.amOnPage('/page/');
```
If method is common it should be located in the helpers.

## Nuances for working with PageObjects
* Name of the file with PageObjects should be talkable, so it is clear what's inside. Pattern of the file name [componentName]-[componentComplexity].js
* All the selectors/locators are stored in the PageObjects. Locator should have comment where it is situated on the page, and what it is.
* Locator priority: Id, CSS, XPath. 
* Repeatable steps in the tests write in the PageObjects as a method.
* Common things are stored in the steps_file.js

## Nuances for writing tests

* Name of the test should be talkable, so one can define what test about. Follow next pattern [acceptance | E2E | integration]_[test suite number]-[name]_test.js

* Name Feature should include name of the file without _tests.js. After the name - write a description.

	Example: `integration_1. Description goes in here`

* Name Scenario - use case or story with acceptance criteria in the name. Follow the rule - When->Then.

	Example: `Unauthorised user goes to the welcome page. The user should be redirected to login page and see the login form to authorize`

* Steps of the test should be described from the end-user perspective and should be talkable.
* All the selectors should be located inside the pageObjects
* All the timeouts should be located inside the pageObjects
* All tests you implement should be easy to customize. 

* WaitUntil should be used most of the time, cause sometimes chromium can move forward without loading whole page.
* Do not refresh the page inside the tests twice; 

## Nuances for running tests
* For now, all test launch can be made with `npm test`. In this case, no parameters can not be changed. If you need to change something, you need to edit the script in package.json. Before committing to the master, you should check that your updated settings are not included in the commit. 