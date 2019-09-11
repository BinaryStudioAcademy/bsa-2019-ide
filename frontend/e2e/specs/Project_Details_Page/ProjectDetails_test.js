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


describe('Online-IDE ProjectDetails Page', () => {
    
    beforeEach(() => {
       browser.maximizeWindow();
       browser.url(credentials.appUrl);
       Help.loginWithDefaultUser();
       wait.forNotificationToDisappear();
       wait.ofDashboardMenu();
       validate.successnavigationToPage(credentials.dashboardUrl);
    
   });

   afterEach(() => {
       Help.logOut();
       browser.reloadSession();
   });


    xit('should navigate to project details page', () => {
        
        Help.browserClickXPath(page.tabMyProjects);
        projectDetails.clickCardMenuButton();
        Help.browserClickXPath(page.detailsButtonOnProjectCard);
        wait.contentOfProjectDetailPage();
        validate.navigationToPage(credentials.projectDetailsUrl);
        
    });
    /*it('should navigate to workspace',() => {
        $("//div[@class='cards-area']/div[1]/app-project-card").click();
        browser.pause();
    });*/


    xit('should add a collaborator in project', () => {
        
        Help.browserClickXPath(page.tabMyProjects);
        projectDetails.clickCardMenuButton();
        Help.browserClickXPath(page.detailsButtonOnProjectCard);
        wait.contentOfProjectDetailPage();
        Help.addCollaborators(credentials.collaboratorNickName, "Can edit and build");
        validate.notificationTextIs(credentials.notificationSuccessAddCollaborator);
        Help.checkDetails();
        validate.verifyText(page.collaboratorItem, credentials.collaboratorNickName);
        validate.verifyText(page.collaboratorRight, "Can edit and build");
      
    });
    xit('should change collaborators rights', () => {
        
        Help.browserClickXPath(page.tabMyProjects);
        projectDetails.clickCardMenuButton();
        Help.browserClickXPath(page.detailsButtonOnProjectCard);
        wait.contentOfProjectDetailPage();
        Help.changeCollaboratorsRights(credentials.collaboratorNickName, "Provide all access rights");
        validate.notificationTextIs(credentials.notificationSuccessChangeCollaboratorRight);
        Help.checkDetails();
        validate.verifyText(page.collaboratorItem, credentials.collaboratorNickName);
        validate.verifyText(page.collaboratorRight, "Provide all access rights");
        
        
    });
    xit('should delete collaborator', () => {
        
        Help.browserClickXPath(page.tabMyProjects);
        projectDetails.clickCardMenuButton();
        Help.browserClickXPath(page.detailsButtonOnProjectCard);
        wait.contentOfProjectDetailPage();
        projectDetails.deleteCollaborator(0);
        Help.checkDetails();
        validate.verifyAbsence();
 
    });

    xit('change project settings', () => {
        
       
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
      
        
    });

    xit('should delete a project', () => {
            

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
    
        
    });

   
});