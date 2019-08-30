const credentials = require('./../testData.json');
const Help = require('../../helpers/helpers');
const Assert = require('../../helpers/validators');
const Wait = require('../../helpers/waiters');
const validate = new Assert();
const wait = new Wait();
//const assert = require('chai').assert;
describe('Online-IDE creation project', () => {
    
    beforeEach(() => {
       browser.maximizeWindow();
       browser.url(credentials.appUrl);
       browser.pause(5000);
       Help.loginWithDefaultUser();
       //wait.forSpinner();
    
   });

   afterEach(() => {
       browser.reloadSession();
   });

   xit('create a new project with valid data', () => {
       
       
       Help.createNewProject(1, 1, 1, 1, 9);
       validate.notificationTextIs(credentials.notificationProjectCreateSuccess);
       wait.forNotificationToDisappear(); 
       
       validate.navigationToPage(credentials.projectDetailsUrl);
      
       validate.checkProjectDetailsData(0, `Name: ${credentials.projectName}`); 
       
       Help.logOut();
       
   });
   xit('create a new project with too short name', () => {
       
    
    Help.inputDataInFormCreateProject("1", "test", "1", "0", 1, 1, 1, 8);
    Help.logOut();
     
    });
    xit('create a new project with too long name', () => {
       
  
     Help.inputDataInFormCreateProject("this name is too long to be use for our purpose", "test", "1", "0", 1, 1, 1, 8);
     Help.logOut();
     
 });
    xit('create a new project with invalid saved builds number', () => {
       
   
     Help.inputDataInFormCreateProject("test", "test", "12", "0", 1, 1, 1, 8);
     Help.logOut();
     
 });
    xit('create a new project with invalid builds attempts number', () => {
       
   
     Help.inputDataInFormCreateProject("test", "test", "2", "77", 1, 1, 1, 8);
     Help.logOut();
     
 });
          
   
});