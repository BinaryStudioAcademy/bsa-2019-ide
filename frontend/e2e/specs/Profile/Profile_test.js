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
       //wait.forSpinner();
       wait.forNotificationToDisappear();

    
   });

   afterEach(() => {
       browser.reloadSession();
   });


    xit('change password', () => {
        
        profile.changePassword(credentials.password, credentials.changedPassword);
        Help.logOut();
        Help.loginWithCustomUser(credentials.email, credentials.changedPassword);
        wait.forNotificationToDisappear();
        validate.successnavigationToPage(credentials.dashboardUrl);
        profile.changePassword(credentials.changedPassword, credentials.password);
        Help.logOut();
        
               
    });
    xit('change users info', () => {
        
        validate.successnavigationToPage(credentials.dashboardUrl);
        profile.clickMyProfileButton();
       // browser.pause(10000);
        $("div.panel.p-grid.ng-star-inserted").waitForDisplayed(10000);
        profile.clickUpdateInfoButton();
        
      //  Help.browserClickOnArrayElement(profileObject.editingOptions, 4);
      $("div.ui-dialog-content.ui-widget-content").waitForDisplayed(10000);
        profile.enterFirstName("test");
        
        profile.enterLastName("test");
        profile.enterNickname("new1");
        profile.enterGitHub("https://github.com/test123")
        Help.browserClickXPath('//p-calendar/span/input');
        $("select.ui-datepicker-month").click();
        Help.browserClick("option[value='9']");
        $("select.ui-datepicker-year").click();
        Help.browserClick("option[value='1988']");
     //  Help.browserClickOnArrayElement("input.ui-inputtext.ui-widget.ui-state-default.ui-corner-all.ng-star-inserted", 2);
       Help.browserClickOnArrayElement("a.ui-state-default.ng-star-inserted", 30);
       $("button[label='Update']").click();
       // Help.browserClickOnArrayElement("span.ui-button-text.ui-clickable", 6);
      //  Help.changeEditorSettings();
       // validate.notificationTextIs("Your profile was successfully update");
     
      validate.verifyText($$("span.property-value")[0], "new1");
     // validate.verifyText($$("span.property-value")[2], "httpsgithubcomtest123");
      validate.verifyText($$("span.property-value")[3], "Sep 30, 2019");
      validate.verifyText($("p.tname.p-col-align-center"), "test test");
        Help.logOut();
       
               
    });
    it('change users editor settings', () => {

        
        validate.successnavigationToPage(credentials.dashboardUrl);
        profile.clickMyProfileButton();
   
        profile.waitPanelOfProjectEditorSettings();
        Help.browserClickOnArrayElement("li.ui-state-default.ui-corner-top.ng-star-inserted", 2);
              
        
        profile.enterlineHeight("14");
        profile.enterFontSize("14");
        profile.enterTabSize("3");
        Help.clickInDropdownListArrowOf("Thema:");
        Help.clickInDropdownListThemaOptions("vs");
       
        Help.clickInDropdownListArrowOf("Scroll beyond last line:");
        Help.clickInDropdownListOptionOf("Scroll beyond last line:", "false");
       
        Help.clickInDropdownListArrowOf("Cursor style:");
        Help.clickInDropdownListOptionOf("Cursor style:", "block");
        Help.clickInDropdownListArrowOf("Line numbers:");
        Help.clickInDropdownListOptionOf("Line numbers:", "interval");
        profile.clickSaveButton();
        wait.forSpinner();
        validate.notificationTextIs("New details have successfully saved!")
        validate.verifyText($$("label.ui-dropdown-label.ui-inputtext.ui-corner-all.ng-star-inserted")[0], "vs");
        validate.verifyText($$("label.ui-dropdown-label.ui-inputtext.ui-corner-all.ng-star-inserted")[1], "false");
        validate.verifyText($$("label.ui-dropdown-label.ui-inputtext.ui-corner-all.ng-star-inserted")[2], "block");
        validate.verifyText($$("label.ui-dropdown-label.ui-inputtext.ui-corner-all.ng-star-inserted")[3], "interval");

       /* validate.verifyText(profileObject.lineHeightInput, "20");
        validate.verifyText(profileObject.fontSizeInput, "11");
        validate.verifyText(profileObject.tabSizeInput, "5");*/
        
        Help.logOut();
        
       
               
    });

    xit('should change avatar', () => {
        
        validate.successnavigationToPage(credentials.dashboardUrl);    
        profile.clickMyProfileButton();
  
        $("div.panel.p-grid.ng-star-inserted").waitForDisplayed(10000);
        profile.clickChangeImageButton();
     
        profile.UploadControl(path.join(__dirname, credentials.PhotoPath));
        profile.clickUpdateAvatarButton();
        wait.forSpinner();
        validate.notificationTextIs("photo successfully updated");
       
       validate.SuccessUploadAvatar();
     
        Help.logOut();
       
               
    });
    xit('should delete avatar', () => {
        
        validate.successnavigationToPage(credentials.dashboardUrl);    
        profile.clickMyProfileButton();
  
        $("div.panel.p-grid.ng-star-inserted").waitForDisplayed(10000);
        profile.clickDeleteImageButton();
      
       
        profile.clickDeleteImageButton();
     
        validate.notificationTextIs("photo successfully deleted");
        validate.SuccessDeleteAvatar();
       
        Help.logOut();
       
               
    });







   
});