const assert = require('chai').assert;
const expect = require('chai').expect;

const workspaceActions = require('./../specs/Workspace/actions/workspace_pa');
const workspace = new workspaceActions();
const WorkspacePage = require('./../specs/Workspace/page/workspace_po');
const workPage = new WorkspacePage();


class CustomValidates {
 
    notificationOfSuccessRegistration(expectedText) {

    const notification = $('div.toast-message');
    notification.waitForDisplayed(10000);
    const actualText = notification.getText();
       assert.equal(actualText, expectedText);
    }

    notificationTextIs(expectedText) {
      
    const notification = $('div.toast-message.ng-star-inserted');
    notification.waitForDisplayed(10000);
    const actualText = notification.getText()
    console.log("_________________________" + actualText);
    assert.equal(actualText, expectedText, `Expected ${actualText} to be equal to ${expectedText}`);
    
    }
    errorNotificationTextIs(expectedText) {
        const notification = $("div.toast-error");
        notification.waitForDisplayed(10000);
    const actualText = notification.getText()
  //  console.log("_________________________" + actualText);
    assert.equal(actualText, expectedText, `Expected ${actualText} to be equal to ${expectedText}`);
    }
    tooltipNotificationTextIs(expectedText, index) {
    const notification = $("div.invalid.ng-star-inserted")[index];
    const actualText = notification.getText()
    assert.equal(actualText, expectedText, `Expected ${actualText} to be equal to ${expectedText}`);
    }
   
    successnavigationToPage(expectedUrl) {
        const url = new URL(browser.getUrl());
        const actualUrl = 'http://' + url.hostname.toString() + url.pathname.toString();
        assert.equal(actualUrl, expectedUrl);
    }
    navigationToPage(expectedUrl) {
        const url = new URL(browser.getUrl());
        const pathname = url.pathname.slice(0,9);
        const actualUrl = url.hostname.toString() + pathname.toString();
        assert.equal(actualUrl, expectedUrl);
    }
    verifyProjectTitle(expectedProjectName) {
        const titles =  $$("h2.title-ellipsis");
        const actualProjectName = titles[titles.length-1].getText()
        assert.equal(actualProjectName, expectedProjectName)
    }
    checkProjectDetailsData(index, expectedData) {
        assert.equal($$("div.card p")[index].getText(), expectedData);;
    }
    verifyFavouriteProjectTitle(expectedProjectName) {
       
        const title =  $("h2.title-ellipsis");
        const actualProjectName = title.getText()
        assert.equal(actualProjectName, expectedProjectName)
    }
    verifyNoProjectsInFavourite (expectedmessage){

        const message = $("div.ng-star-inserted p").getText();
        assert.equal(message, expectedmessage)
    }
    verifyText(elm, expectedResult) {
        const element = elm.getText();
        assert.equal(element, expectedResult);
    }
    verifyAbsence() {
        const element = $("div.collaborator-item");
        element.waitForExist(undefined, true);;
    };

    verifyEditedFile(expectedChanges) {
        workspace.openFirstfile();
        workPage.editorField.waitForDisplayed(10000);
        assert.equal(workPage.editorField.getText(), expectedChanges);
    };

    verifyProjectHistory(expectedChanges) {
        const historyText = $('//*[@id="ui-accordiontab-0-content"]/div').getText();
        const firstWord = historyText.split(' ', 1);
        assert.equal(firstWord, expectedChanges);
    };
}

module.exports = CustomValidates;