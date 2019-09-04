const credentials = require('./../testData.json');
const Help = require('../../helpers/helpers');
const Assert = require('../../helpers/validators');
const Wait = require('../../helpers/waiters');
const validate = new Assert();
const wait = new Wait();

const ProjectDetailsActions = require('./actions/ProjectDetails_pa');
const projectDetails = new ProjectDetailsActions();

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

//passed
    xit('change project settings', () => {
        
       
        Help.clickProjectSettingsOnCard();
        Help.fillOutChangedDataInForm(credentials.changedProjectName, credentials.changeddescription, credentials.changedBuildsNumber, credentials.changedBuildAttempts);
       
        $("button.ui-button.ui-widget.ui-state-default.ui-corner-all.ui-button-text-only.ng-star-inserted").waitForEnabled(5000);
        $("button.ui-button.ui-widget.ui-state-default.ui-corner-all.ui-button-text-only.ng-star-inserted").click();
     
        validate.notificationTextIs(credentials.successchangedsettingsnotification);
        wait.forNotificationToDisappear();

        Help.clickProjectDetailsOnCard();
        $("ul.ui-tabview-nav.ui-helper-reset.ui-helper-clearfix.ui-widget-header.ui-corner-all.ng-star-inserted").waitForExist(5000);

        validate.navigationToPage(credentials.projectDetailsUrl);
        validate.checkProjectDetailsData(0, "Name: "+ credentials.changedProjectName);
        validate.checkProjectDetailsData(1, "Description: "+ credentials.changeddescription);
        validate.checkProjectDetailsData(8, "Amount of saved builds: "+ credentials.changedBuildsNumber);
        validate.checkProjectDetailsData(9, "Amount of build attempts: "+ credentials.changedBuildAttempts);
        Help.logOut();
        
    });


//failed
    xit('navigate to project details page', () => {
        
        Help.clickProjectDetailsOnCard();
        $("ul.ui-tabview-nav.ui-helper-reset.ui-helper-clearfix.ui-widget-header.ui-corner-all.ng-star-inserted").waitForExist(5000);
        validate.navigationToPage(credentials.projectDetailsUrl);
        
        Help.logOut();
        
    });


    xit('add collaborator', () => {
        
        Help.clickProjectDetailsOnCard();
        $("ul.ui-tabview-nav.ui-helper-reset.ui-helper-clearfix.ui-widget-header.ui-corner-all.ng-star-inserted").waitForExist(5000);
        Help.addCollaborators("testUser1");
        
        validate.notificationTextIs(credentials.notificationSuccessAddCollaborator);
        Help.checkDetails();
        
        validate.verifyText($$("div.collaborator-item div")[0], "testUser1");
        validate.verifyText($("div label"), "Can edit and build");
        Help.logOut();
        
    });
    xit('change collaborators rights', () => {
        
        Help.clickProjectDetailsOnCard();
        $("ul.ui-tabview-nav.ui-helper-reset.ui-helper-clearfix.ui-widget-header.ui-corner-all.ng-star-inserted").waitForExist(5000);
        Help.changeCollaboratorsRights(4);
       
        validate.notificationTextIs(credentials.notificationSuccessChangeCollaboratorRight);
        Help.checkDetails();
        
        validate.verifyText($$("div.collaborator-item div")[0], "testUser1");
        validate.verifyText($("div label"), "Provide all access rights");
        Help.logOut();
        
    });
    xit('delete collaborator', () => {
        
        Help.clickProjectDetailsOnCard();
        $("ul.ui-tabview-nav.ui-helper-reset.ui-helper-clearfix.ui-widget-header.ui-corner-all.ng-star-inserted").waitForExist(5000);
        Help.deleteCollaborator(0);
        
        //console.log($("//div[contains(text(), 'This project has no collaborators yet')]").getText());
        Help.checkDetails();
        
        validate.verifyAbsence();
  
        Help.logOut();
        
    });


    xit('delete a project', () => {
            
            
        expectednotification = Help.returnExpectedNotificationDeletionProject();
        
        Help.clickProjectDetailsOnCard();
        $("ul.ui-tabview-nav.ui-helper-reset.ui-helper-clearfix.ui-widget-header.ui-corner-all.ng-star-inserted").waitForExist(5000);
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