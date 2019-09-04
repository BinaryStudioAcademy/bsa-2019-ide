const credentials = require('./../testData.json');
const Help = require('../../helpers/helpers');
const Assert = require('../../helpers/validators');
const Wait = require('../../helpers/waiters');
const LoginPage = require('./page/Auhtentication_po');
const pageObject = new LoginPage();
const validate = new Assert();
const wait = new Wait();
const assert = require('chai').assert;

const ProfileActions = require('./actions/Authentication_pa');
const loginActions = new ProfileActions();


describe('Online-IDE authorization', () => {
    
    beforeEach(() => {
       browser.maximizeWindow();
       browser.url(credentials.appUrl);
      

    
   });

   afterEach(() => {
       browser.reloadSession();
   });

    xit('should register a new account', () => {
        
        const email = Help.generateEmail();
        loginActions.registerNewAccount(credentials.name, credentials.surname, credentials.nickname, email, credentials.password);
        
        validate.notificationOfSuccessRegistration(credentials.notificationInfo);
        wait.forNotificationToDisappear();      
 
        validate.successnavigationToPage(credentials.dashboardUrl);
        Help.logOut();
        Help.loginWithCustomUser(email, credentials.password);
        validate.notificationTextIs(credentials.notificationLoginSuccess);
        wait.forNotificationToDisappear(); 
        Help.logOut();
    });

    xit('should login with valid data', () => {
       
      
        Help.loginWithDefaultUser();
        validate.notificationTextIs(credentials.notificationLoginSuccess);
        wait.forNotificationToDisappear(); 
        Help.logOut();
    
    });

    xit('should try to login with invalid data', () => {
       
      
        loginActions.enterDataForLogin(credentials.email, credentials.changedPassword);
        loginActions.clickCreateButton();
        validate.notificationTextIs(credentials.notificationLoginError);
        
       
        
    });

    xit('should try to login with empty fields', () => {
       
     
        loginActions.enterDataForLogin('', '');
        loginActions.waitEnabledCreateButton();
       // validate.notificationTextIs(credentials.notificationLoginError);
        
       
        
    });

    xit('should register with empty fields', () => {
       
      
        loginActions.registerNewAccount('', '', '', '', '');
        loginActions.waitEnabledCreateButton();
       // validate.notificationTextIs(credentials.notificationError);
        
           
            
    });

    xit('should try register a new account with already used email', () => {
       
      
        loginActions.enterDataForRegistration(credentials.name, credentials.surname, credentials.nickname, credentials.email, credentials.password);
        loginActions.clickCreateButton();
        validate.notificationTextIs(credentials.notificationError);
        wait.forNotificationToDisappear();
         
                   
                    
    });

    xit('should register with email without domain', () => {
           
          
        loginActions.enterDataForRegistration(credentials.name, credentials.surname, credentials.nickname, 'test@test', credentials.password);
        loginActions.waitEnabledCreateButton();
       
       // validate.notificationTextIs(credentials.notificationError);
        
               
                
    });

    xit('should recovery password with not registered email', () => {
           
          
        loginActions.recoveryPassword(credentials.notRegisteredEmail);
        validate.notificationTextIs(credentials.notificationErrorRecovery);
        
               
                
    });

    /*it('recovery password with registered email', () => {
           
          
        Help.recoveryPassword(credentials.email);
        validate.notificationTextIs(credentials.notificationSuccessRecovery);
        wait.forNotificationToDisappear(); 
                   
                    
        });*/
    xit('should recovery password with invalid data', () => {
           
          
        loginActions.recoveryPassword(credentials.invalidEmail);
        validate.notificationTextIs(credentials.notificationInvalidDataRecovery);
       
                       
                        
    });
   
});