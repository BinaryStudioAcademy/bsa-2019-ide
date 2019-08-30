const assert = require('chai').assert;
const expect = require('chai').expect;

class CustomValidates {

    

   /* elementCountIs(locator, expectedQty) {
        const els = locator;
        const actualQty = els.length;

        assert.strictEqual(actualQty, expectedQty, `Expected ${expectedQty} is not equal to ${actualQty}`);
    }

    wrongValueIndicationOnField(locator) {
        const attr = locator.getAttribute('class');
        expect(attr, `${attr} doesn't include validation class`).to.include("is-danger");
    }

    wrongValueIndicationOnLable(locator) {

        const attr = locator.getAttribute('class');
        expect(attr, `${attr} doesn't include error class`).to.include("error");
    }
*/  

    notificationTextIs(expectedText) {
      
    const notification = $('div.toast-message.ng-star-inserted');
    const actualText = notification.getText()
    assert.equal(actualText, expectedText, `Expected ${actualText} to be equal to ${expectedText}`);
    
    }
    tooltipNotificationTextIs(expectedText, index) {
    const notification = $("div.invalid.ng-star-inserted")[index];
    const actualText = notification.getText()
    assert.equal(actualText, expectedText, `Expected ${actualText} to be equal to ${expectedText}`);
    }
   /* errorNotificationTextIs(expectedText) {
        const notification = $('div.toast-message.ng-star-inserted');
        const actualText = notification.getText()
        assert.equal(actualText, expectedText, `Expected ${actualText} to be equal to ${expectedText}`);
    }
    

    successNotificationTextIs(expectedText) {
        
        const notification = $("div.toast-success.ngx-toastr.ng-trigger.ng-trigger-flyInOut");
        const actualText = notification.getText()
        assert.equal(actualText, expectedText, `Expected ${actualText} to be equal to ${expectedText}`);
        
    }
    InfoNotificationTextIs(expectedText) {
      
        const notification = $('div.toast-message.ng-star-inserted');
        const actualText = notification.getText()
        assert.equal(actualText, expectedText, `Expected ${actualText} to be equal to ${expectedText}`);
        
    }*/

   
    successnavigationToPage(expectedUrl) {
        const url = new URL(browser.getUrl());
        const actualUrl = url.hostname.toString() + url.pathname.toString();
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
        browser.pause(2000);
        const title =  $$("h2.title-ellipsis")[0];
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
    }
}

module.exports = CustomValidates;