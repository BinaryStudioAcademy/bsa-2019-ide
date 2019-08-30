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



/*function generateRandomString(length) {

    var text = "";
    var possible = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
  
    for (var i = 0; i < length; i++)
  
      text += possible.charAt(Math.floor(Math.random() * possible.length));
    
    return text;
  
  }*/
describe('Online-IDE authorization', () => {
    
    beforeEach(() => {
       browser.maximizeWindow();
       browser.url(credentials.appUrl);
      

    
   });

   afterEach(() => {
       browser.reloadSession();
   });

   it('should register a new account', () => {
       
    
   // const email = `${generateRandomString(12)}@${generateRandomString(3)}.com`;
        const email = Help.generateEmail();
        loginActions.registerNewAccount(credentials.name, credentials.surname, credentials.nickname, email, credentials.password);
       // wait.forSpinner();
      // validate.notificationTextIs(credentials.notificationRegistrationSuccess);
       //wait.forNotificationToDisappear();      
      //  validate.notificationTextIs(credentials.notificationInfo);
      //  wait.forNotificationToDisappear(); 
       browser.pause(3000);
        validate.successnavigationToPage(credentials.dashboardUrl);
        Help.logOut();
        Help.loginWithCustomUser(email, credentials.password);
        validate.notificationTextIs(credentials.notificationLoginSuccess);
        wait.forNotificationToDisappear(); 

    Help.logOut();
       
   });

   it('should login with valid data', () => {
       
      
    Help.loginWithDefaultUser();
    validate.notificationTextIs(credentials.notificationLoginSuccess);
    wait.forNotificationToDisappear(); 
    Help.logOut();
    
    });

    it('should try to login with invalid data', () => {
       
      
        Help.loginWithCustomUser(credentials.email, credentials.changedPassword);
        validate.notificationTextIs(credentials.notificationLoginError);
        
       
        
        });
    it('should try to login with empty fields', () => {
       
      
        Help.loginWithCustomUser('', '');
        validate.notificationTextIs(credentials.notificationLoginError);
        
       
        
        });
    it('should register with empty fields', () => {
       
      
        loginActions.registerNewAccount('', '', '', '', '');
        validate.notificationTextIs(credentials.notificationError);
        
           
            
        });
    it('should try register a new account with already used email', () => {
       
      
        loginActions.registerNewAccount(credentials.name, credentials.surname, credentials.nickname, credentials.email, credentials.password);
        validate.notificationTextIs(credentials.notificationError);
         
                   
                    
        });
    it('should register with email without domain', () => {
           
          
        loginActions.registerNewAccount(credentials.name, credentials.surname, credentials.nickname, 'test@test', credentials.password);
        validate.notificationTextIs(credentials.notificationError);
        
               
                
        });
    it('should recovery password with not registered email', () => {
           
          
        loginActions.recoveryPassword(credentials.notRegisteredEmail);
        validate.notificationTextIs(credentials.notificationErrorRecovery);
        
               
                
        });
    /*it('recovery password with registered email', () => {
           
          
        Help.recoveryPassword(credentials.email);
        validate.notificationTextIs(credentials.notificationSuccessRecovery);
        wait.forNotificationToDisappear(); 
                   
                    
        });*/
    it('should recovery password with invalid data', () => {
           
          
        loginActions.recoveryPassword(credentials.invalidEmail);
        validate.notificationTextIs(credentials.notificationInvalidDataRecovery);
       
                       
                        
        });
   
});