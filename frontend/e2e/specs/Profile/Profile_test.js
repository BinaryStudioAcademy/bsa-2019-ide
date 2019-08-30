const credentials = require('./../testData.json');
const Help = require('../../helpers/helpers');
const Assert = require('../../helpers/validators');
const Wait = require('../../helpers/waiters');
const validate = new Assert();
const wait = new Wait();


describe('Online-IDE User profile', () => {
    
    beforeEach(() => {
       browser.maximizeWindow();
       browser.url(credentials.appUrl);
       Help.loginWithDefaultUser();
       //wait.forSpinner();
    
   });

   afterEach(() => {
       browser.reloadSession();
   });


    xit('change password', () => {
        
        browser.pause(1000);
        Help.changePassword(credentials.password, credentials.changedPassword);
        Help.logOut();
        Help.loginWithCustomUser(credentials.email, credentials.changedPassword);
        browser.pause(2000);
        validate.navigationToPage(credentials.expectedDashboardUrl);
        Help.changePassword(credentials.changedPassword, credentials.password);
        Help.logOut();
        
               
    });
    it('change users info', () => {
        
        browser.pause(1000);
        Help.changeUserInfo();
        
        Help.logOut();
       
               
    });
    it('change users editor settings', () => {
        
        browser.pause(1000);
        Help.changeEditorSettings();
        
        Help.logOut();
       
               
    });








   
});