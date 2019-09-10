const credentials = require('./../testData.json');
const Help = require('../../helpers/helpers');
const Assert = require('../../helpers/validators');
const Wait = require('../../helpers/waiters');
const validate = new Assert();
const wait = new Wait();

const ProjectDetailsActions = require('./actions/ProjectDetails_pa');
const projectDetails = new ProjectDetailsActions();
const ProjectDetailsObjects = require('./page/ProjectDetails_po');
const page = new ProjectDetailsObjects();

//const assert = require('chai').assert;
describe('Online-IDE ProjectDetails Page', () => {
    
    beforeEach(() => {
       browser.maximizeWindow();
       browser.url(credentials.appUrl);
       Help.loginWithDefaultUser();
      // wait.forSpinner();
      wait.forNotificationToDisappear();
    
   });

   afterEach(() => {
       browser.reloadSession();
   });


    xit('navigate to project details page', () => {
        
        wait.ofDashboardMenu();
        validate.successnavigationToPage(credentials.dashboardUrl);
        Help.browserClickXPath(page.tabMyProjects);
        projectDetails.clickCardMenuButton();
        Help.browserClickXPath(page.detailsButtonOnProjectCard);

        wait.contentOfProjectDetailPage();
        validate.navigationToPage(credentials.projectDetailsUrl);
        
        Help.logOut();
        
    });


    xit('should add a collaborator in project', () => {
        
        wait.ofDashboardMenu();
        validate.successnavigationToPage(credentials.dashboardUrl);
        Help.browserClickXPath(page.tabMyProjects);
        projectDetails.clickCardMenuButton();
        Help.browserClickXPath(page.detailsButtonOnProjectCard);
        wait.contentOfProjectDetailPage();
        Help.addCollaborators("testUser");
      
        validate.notificationTextIs(credentials.notificationSuccessAddCollaborator);
        Help.checkDetails();
        
        validate.verifyText($$("div.collaborator-item div")[0], "testUser");
        validate.verifyText($("div label"), "Can edit and build");
        Help.logOut();
        
    });
    xit('should change collaborators rights', () => {
        
        wait.ofDashboardMenu();
        validate.successnavigationToPage(credentials.dashboardUrl);
        Help.browserClickXPath(page.tabMyProjects);
        projectDetails.clickCardMenuButton();
        Help.browserClickXPath(page.detailsButtonOnProjectCard);

        wait.contentOfProjectDetailPage();
        Help.changeCollaboratorsRights(4);
       
        validate.notificationTextIs(credentials.notificationSuccessChangeCollaboratorRight);
        Help.checkDetails();
        
        validate.verifyText($$("div.collaborator-item div")[0], "testUser");
        validate.verifyText($("div label"), "Provide all access rights");
        Help.logOut();
        
    });
    xit('should delete collaborator', () => {
        
        wait.ofDashboardMenu();
        validate.successnavigationToPage(credentials.dashboardUrl);
        Help.browserClickXPath(page.tabMyProjects);
        projectDetails.clickCardMenuButton();
        Help.browserClickXPath(page.detailsButtonOnProjectCard);

        wait.contentOfProjectDetailPage();
        projectDetails.deleteCollaborator(0);
        Help.checkDetails();
        
        validate.verifyAbsence();
  
        Help.logOut();
        
    });

    xit('change project settings', () => {
        
       
        wait.ofDashboardMenu();
        validate.successnavigationToPage(credentials.dashboardUrl);
        Help.browserClickXPath(page.tabMyProjects);
        projectDetails.clickCardMenuButton();
        Help.browserClickXPath(page.detailsButtonOnProjectCard);
        wait.contentOfProjectDetailPage();
        validate.navigationToPage(credentials.projectDetailsUrl);
        projectUrl = Help.returnUrl();
      
        browser.url(credentials.dashboardMyProjectsUrl);
        projectDetails.clickCardMenuButton();
        Help.browserClickXPath(page.settingsButtonOnProjectCard);

        Help.fillOutChangedDataInForm(credentials.changedProjectName, credentials.changeddescription, credentials.changedBuildsNumber, credentials.changedBuildAttempts);
        projectDetails.clickSaveProjectButton();
        
        validate.notificationTextIs(credentials.successchangedsettingsnotification);
        wait.forNotificationToDisappear();


        browser.url(projectUrl.toString());

        wait.contentOfProjectDetailPage();


        validate.checkProjectDetailsData(0, "Name: "+ credentials.changedProjectName);
        validate.checkProjectDetailsData(1, "Description: "+ credentials.changeddescription);
        validate.checkProjectDetailsData(8, "Amount of saved builds: "+ credentials.changedBuildsNumber);
        validate.checkProjectDetailsData(9, "Amount of build attempts: "+ credentials.changedBuildAttempts);
        Help.logOut();
        
    });

    xit('should delete a project', () => {
            
        wait.ofDashboardMenu();
        validate.successnavigationToPage(credentials.dashboardUrl);
        Help.browserClickXPath(page.tabMyProjects);
        projectDetails.clickCardMenuButton();
        Help.browserClickXPath(page.detailsButtonOnProjectCard);
      
        wait.contentOfProjectDetailPage();
        validate.navigationToPage(credentials.projectDetailsUrl);
        const projectUrl = Help.returnUrl();
        projectDetails.deleteProject();

        validate.notificationTextIs(credentials.notificationSuccessProjectRemoval);
        wait.forNotificationToDisappear(); 
        
        browser.url(projectUrl.toString());
        validate.notificationTextIs(credentials.errormessage);
        wait.forNotificationToDisappear(); 
        Help.logOut();
        
    });

   
});