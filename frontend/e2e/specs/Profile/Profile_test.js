const credentials = require('./../testData.json');
const Help = require('../../helpers/helpers');
const Assert = require('../../helpers/validators');
const Wait = require('../../helpers/waiters');
const validate = new Assert();
const wait = new Wait();
const path = require('path');

const ProfileActions = require('./actions/Profile_pa');
const profile = new ProfileActions();
const ProfilePage = require('./page/Profile_po');
const profileObject = new ProfilePage();



describe('Online-IDE User profile', () => {
    
    beforeEach(() => {
       browser.maximizeWindow();
       browser.url(credentials.appUrl);
       Help.loginWithDefaultUser();
       wait.forSpinner();
      // browser.pause(1000);
    
   });

   afterEach(() => {
       browser.reloadSession();
   });


    xit('change password', () => {
        
        
        profile.changePassword(credentials.password, credentials.changedPassword);
        Help.logOut();
        Help.loginWithCustomUser(credentials.email, credentials.changedPassword);
        
        validate.navigationToPage(credentials.expectedDashboardUrl);
        profile.changePassword(credentials.changedPassword, credentials.password);
        Help.logOut();
        
               
    });
    xit('change users info', () => {
        
       
        profile.clickMyProfileButton();
        profile.clickEditProfileButton();
        
        Help.browserClickOnArrayElement(profileObject.editingOptions, 4);
        
        profile.enterFirstName("test");
        
        profile.enterLastName("test");
        profile.enterNickname("new1");
        profile.enterGitHub("https://github.com/test123")
       // browser.executeScript("document.getElementsByClassName('ui-datepicker-group').value='02/11/1989'");
       // profile.clickChangeButton();
       Help.browserClickOnArrayElement("input.ui-inputtext.ui-widget.ui-state-default.ui-corner-all.ng-star-inserted", 2);
       Help.browserClickOnArrayElement("a.ui-state-default.ng-star-inserted", 14);
       
        Help.browserClickOnArrayElement("span.ui-button-text.ui-clickable", 6);
      //  Help.changeEditorSettings();
       // validate.notificationTextIs("Your profile was successfully update");
     
      validate.verifyText($$("span.property-value")[0], "new1");
      validate.verifyText($$("span.property-value")[2], "httpsgithubcomtest123");
      validate.verifyText($$("span.property-value")[3], "Oct 13, 1970");
      validate.verifyText($("p.tname.p-col-align-center"), "test test");
        Help.logOut();
       
               
    });
    xit('change users editor settings', () => {
        
        validate.navigationToPage("bsa-ide.azurewebsites.net/dashboar");
        profile.clickMyProfileButton();
        const panel = $("div.ui-tabview.ui-widget.ui-widget-content.ui-corner-all.ui-tabview-top");
        panel.waitForDisplayed(5000);
        Help.browserClickOnArrayElement("li.ui-state-default.ui-corner-top.ng-star-inserted", 2);
              
        
        profile.enterlineHeight("14");
        profile.enterFontSize("14");
        profile.enterTabSize("3");
        Help.clickInDropdownListArrowOf("Thema:");
        Help.clickInDropdownListOptionOf("Thema:", "vs-dark");
       
        Help.clickInDropdownListArrowOf("Scroll beyond last line:");
        Help.clickInDropdownListOptionOf("Scroll beyond last line:", "false");
       
        Help.clickInDropdownListArrowOf("Cursor style:");
        Help.clickInDropdownListOptionOf("Cursor style:", "block");
        Help.clickInDropdownListArrowOf("Line numbers:");
        Help.clickInDropdownListOptionOf("Line numbers:", "interval");
        /*Help.browserClickOnArrayElement("div.ui-dropdown-trigger.ui-state-default.ui-corner-right", 1);
      
        Help.browserClickOnArrayElement("li.ui-dropdown-item.ui-corner-all", 3);
        
        Help.browserClickOnArrayElement("div.ui-dropdown-trigger.ui-state-default.ui-corner-right", 2);
      // Help.clickInDropdownListArrowOf("Scroll beyond last line:"); 
       Help.browserClickOnArrayElement("li.ui-dropdown-item.ui-corner-all", 1);
        
        Help.browserClickOnArrayElement("div.ui-dropdown-trigger.ui-state-default.ui-corner-right", 3);
       // Help.clickInDropdownListArrowOf("Cursor style:");
        Help.browserClickOnArrayElement("li.ui-dropdown-item.ui-corner-all", 1);
        
        Help.browserClickOnArrayElement("div.ui-dropdown-trigger.ui-state-default.ui-corner-right", 4);
      // Help.clickInDropdownListArrowOf("Line numbers:"); 
       Help.browserClickOnArrayElement("li.ui-dropdown-item.ui-corner-all", 3);
        */
        profile.clickSaveButton();
        wait.forSpinner();
        validate.notificationTextIs("New details have successfully saved!")
        validate.verifyText($$("label.ui-dropdown-label.ui-inputtext.ui-corner-all.ng-star-inserted")[0], "vs-dark");
        validate.verifyText($$("label.ui-dropdown-label.ui-inputtext.ui-corner-all.ng-star-inserted")[1], "false");
        validate.verifyText($$("label.ui-dropdown-label.ui-inputtext.ui-corner-all.ng-star-inserted")[2], "block");
        validate.verifyText($$("label.ui-dropdown-label.ui-inputtext.ui-corner-all.ng-star-inserted")[3], "interval");

       /* validate.verifyText(profileObject.lineHeightInput, "20");
        validate.verifyText(profileObject.fontSizeInput, "11");
        validate.verifyText(profileObject.tabSizeInput, "5");*/
        
        Help.logOut();
        
       
               
    });

    xit('should change avatar', () => {
        
       
        profile.clickMyProfileButton();
        profile.clickEditProfileButton();
       
        Help.browserClickOnArrayElement(profileObject.editingOptions, 2);
        
        profile.UploadControl(path.join(__dirname, credentials.PhotoPath));
        
        $$("button.ui-button.ui-widget.ui-state-default.ui-corner-all.ui-button-text-only")[1].click();
        wait.forSpinner();
        validate.notificationTextIs("photo successfully updated");
        browser.pause(5000);
        profile.clickEditProfileButton();
        Help.browserClickOnArrayElement(profileObject.editingOptions, 3);
        validate.notificationTextIs("photo successfully deleted");
       
  
        Help.logOut();
       
               
    });








   
});