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
const page = new ProfilePage();



describe('Online-IDE User profile', () => {
    
    beforeEach(() => {
       browser.maximizeWindow();
       browser.url(credentials.appUrl);
       Help.loginWithDefaultUser();
       wait.forNotificationToDisappear();
       validate.successnavigationToPage(credentials.dashboardUrl); 

    
   });

   afterEach(() => {
       Help.logOut();
       browser.reloadSession();
   });


    xit('should change password', () => {
        
        profile.changePassword(credentials.password, credentials.changedPassword);
        Help.logOut();
        Help.loginWithCustomUser(credentials.email, credentials.changedPassword);
        wait.forNotificationToDisappear();
        validate.successnavigationToPage(credentials.dashboardUrl);
        profile.changePassword(credentials.changedPassword, credentials.password);
       
                       
    });
    xit('should change user`s info', () => {
        
        profile.clickMyProfileButton();
        wait.forUserInfoPanel();
        profile.clickUpdateInfoButton();
        wait.forEditUsersInfoForm();
        Help.changeUserInfo(credentials.changedFirstName, credentials.changedLastName, credentials.changedNickName, credentials.gitHubRepo, credentials.month, credentials.year, credentials.day); 
        validate.verifyText(page.nicknameField, "new1");
        validate.verifyText(page.birthDayField, "Sep 30, 2019");
        validate.verifyText(page.userNameField, "test test");
               
               
    });

    xit('should change user`s editor settings', () => {


        profile.clickMyProfileButton();
        profile.waitPanelOfProjectEditorSettings();
        Help.changeEditorSettings();
        wait.forSpinner();
        validate.notificationTextIs(credentials.notificationSuccessChangedEditorSettings);
        validate.verifyText(page.themaDataField, "vs");
        validate.verifyText(page.scrollBeyondLastLine, "false");
        validate.verifyText(page.cursorStyle, "block");
        validate.verifyText(page.lineNumbers, "interval");
     
               
    });

    xit('should upload avatar', () => {
        
        profile.clickMyProfileButton();
        wait.forUserInfoPanel();
        profile.clickChangeImageButton();
        profile.UploadControl(path.join(__dirname, credentials.PhotoPath));
        profile.clickUpdateAvatarButton();
        wait.forSpinner();
        validate.notificationTextIs(credentials.notificationSuccessUploadAvatar);
        validate.SuccessUploadAvatar();
            
               
    });
    xit('should delete avatar', () => {
        
        profile.clickMyProfileButton();
        wait.forUserInfoPanel();
        profile.clickDeleteImageButton();
        validate.notificationTextIs(credentials.notificationSuccessDeletedAvatar);
        validate.SuccessDeleteAvatar();
             
               
    });







   
});