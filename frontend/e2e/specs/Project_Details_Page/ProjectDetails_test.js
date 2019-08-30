const credentials = require('./../testData.json');
const Help = require('../../helpers/helpers');
const Assert = require('../../helpers/validators');
const Wait = require('../../helpers/waiters');
const validate = new Assert();
const wait = new Wait();

//const DashboardPage = require('../page/Dashboard_po');
//const dashboardObject = new DashboardPage();

//const assert = require('chai').assert;
describe('Online-IDE ProjectDetails Page', () => {
    
    beforeEach(() => {
       browser.maximizeWindow();
       browser.url(credentials.appUrl);
       Help.loginWithDefaultUser();
       wait.forSpinner();
    
   });

   afterEach(() => {
       browser.reloadSession();
   });


    xit('change project settings', () => {
        
        browser.pause(1000);
        Help.clickProjectSettingsOnCard();
        //wait.forSpinner();
        browser.pause(3000);
        Help.inputChangedDataInForm(credentials.changedProjectName, credentials.changeddescription, credentials.changedBuildsNumber, credentials.changedBuildAttempts, 4);
        //wait.forSpinner();

        validate.notificationTextIs(credentials.successchangedsettingsnotification);
        wait.forNotificationToDisappear();

        Help.clickProjectDetailsOnCard();
        browser.pause(3000);
        validate.checkProjectDetailsData(0, "Name: "+ credentials.changedProjectName);
        validate.checkProjectDetailsData(1, "Description: "+ credentials.changeddescription);
        validate.checkProjectDetailsData(7, "Amount of saved builds: "+ credentials.changedBuildsNumber);
        validate.checkProjectDetailsData(8, "Amount of build attempts: "+ credentials.changedBuildAttempts);
        Help.logOut();
        
    });



    xit('navigate to project details page', () => {
        
        Help.clickProjectDetailsOnCard();
        browser.pause(1000);
        validate.navigationToPage(credentials.projectDetailsUrl);
        
        Help.logOut();
        
    });


    xit('add collaborator', () => {
        
        Help.clickProjectDetailsOnCard();
        browser.pause(3000);
        Help.addCollaborators("test");
        browser.pause(3000);
        validate.notificationTextIs(credentials.notificationSuccessAddCollaborator);
        Help.checkDetails();
        browser.pause(2000);
        validate.verifyText($$("div.collaborator-item div")[0], "testUser1");
        validate.verifyText($("div label"), "Can edit and build");
        Help.logOut();
        
    });
    xit('change collaborators rights', () => {
        
        Help.clickProjectDetailsOnCard();
        browser.pause(3000);
        Help.changeCollaboratorsRights(4);
       // browser.pause(3000);
        validate.notificationTextIs(credentials.notificationSuccessChangeCollaboratorRight);
        Help.checkDetails();
        browser.pause(2000);
        validate.verifyText($$("div.collaborator-item div")[0], "testUser1");
        validate.verifyText($("div label"), "Provide all access rights");
        Help.logOut();
        
    });
    xit('delete collaborator', () => {
        
        Help.clickProjectDetailsOnCard();
        browser.pause(3000);
        Help.deleteCollaborator(0);
        browser.pause(3000);
        //validate.notificationTextIs(credentials.notificationSuccessDeleteCollaborator);
        Help.checkDetails();
        browser.pause(2000);
        validate.verifyAbsence();
       // validate.verifyText($$("div.collaborator-item div")[0], "test");
       // validate.verifyText($("div label"), "Can read");
        Help.logOut();
        
    });


    xit('delete a project', () => {
            
            
        expectednotification = Help.returnExpectedNotificationDeletionProject();
        
        Help.clickProjectDetailsOnCard();
        browser.pause(3000);
        validate.navigationToPage(credentials.projectDetailsUrl);
        const projectUrl = Help.returnUrl();
        Help.DeleteProject();

        
        validate.notificationTextIs(expectednotification);
        wait.forNotificationToDisappear(); 
        
        browser.url(projectUrl.toString());
        validate.notificationTextIs(credentials.errormessage);
        wait.forNotificationToDisappear(); 
        Help.logOut();
        
    });

   
});