const credentials = require('./../testData.json');
const Help = require('../../helpers/helpers');
const Assert = require('../../helpers/validators');
const Wait = require('../../helpers/waiters');
const validate = new Assert();
const wait = new Wait();

const CreateProjectActions = require('./actions/CreateProjectPage_pa');
const project = new CreateProjectActions();


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

    xit('should create a new project with valid data', () => {
       
        project.addButtonClick();
        project.waitFormOfProjectCreation();
        Help.fillOutDataInForm(credentials.projectName, credentials.description, credentials.buildsNumber, credentials.buildAttempts);
        project.clickCreateButton();
     
        validate.notificationTextIs(credentials.notificationProjectCreateSuccess);
        wait.forNotificationToDisappear(); 
        
        $("div.ui-tabview.ui-widget.ui-widget-content.ui-corner-all.ui-tabview-left").waitForDisplayed(10000);
       
        validate.navigationToPage(credentials.projectDetailsUrl);
        
        validate.checkProjectDetailsData(0, `Name: ${credentials.projectName}`); 
        
        Help.logOut();
       
    });
    xit('create a new project with too short name', () => {
       
        project.addButtonClick();
        project.waitFormOfProjectCreation();
        Help.fillOutDataInForm("1", credentials.description, credentials.buildsNumber, credentials.buildAttempts);
        project.waitEnableSaveButton();
        Help.logOut();
     
    });
    xit('create a new project with too long name', () => {
       
  
        project.addButtonClick();
        project.waitFormOfProjectCreation();
        Help.fillOutDataInForm("this name is too long to be use for our purpose", credentials.description, credentials.buildsNumber, credentials.buildAttempts);
        project.waitEnableSaveButton();
        Help.logOut();
     
    });
    xit('create a new project with invalid saved builds number', () => {
       
        project.addButtonClick();
        project.waitFormOfProjectCreation();
        Help.fillOutDataInForm(credentials.projectName, credentials.description, "12", credentials.buildAttempts);
        project.waitEnableSaveButton();
        Help.logOut();
     
    });
    xit('create a new project with invalid builds attempts number', () => {
       
   
        project.addButtonClick();
        project.waitFormOfProjectCreation();
        Help.fillOutDataInForm(credentials.projectName, credentials.description, credentials.buildsNumber, "77");
        project.waitEnableSaveButton();
        Help.logOut();
     
    });
          
   
});