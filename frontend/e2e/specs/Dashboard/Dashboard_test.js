const credentials = require('./../testData.json');
const Help = require('../../helpers/helpers');
const Assert = require('../../helpers/validators');
const Wait = require('../../helpers/waiters');
const validate = new Assert();
const wait = new Wait();
const assert = require('chai').assert;

const DashboardActions = require('./actions/Dashboard_pa');
const dashboard = new DashboardActions();
const DashboardPage = require('./page/Dashboard_po');
const page = new DashboardPage();
describe('Online-IDE Dashboard', () => {
    
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


    xit('should add project to favourite', () => {
        
        Help.browserClickXPath(page.tabMyProjects);
        wait.forProjectCard();
        dashboard.starProject();
        wait.forChosenStar();
        Help.browserClickXPath(page.tabFavouriteProjects);
        wait.forProjectCard();
        validate.verifyFavouriteProjectTitle("changedProject");
        dashboard.starProject();
        Help.browserClickXPath(page.tabMyProjects);
        Help.browserClickXPath(page.tabFavouriteProjects);
        validate.successnavigationToPage(credentials.dashboardUrl);
        validate.verifyNoProjectsInFavourite(credentials.expectedmessageonFavourite);
  
        
    });


    xit('should search project by title in user`s projects', () => {
        
        validate.successnavigationToPage(credentials.dashboardUrl);
        Help.searchProjectByTitleOf("13");
        wait.contentOfProjectDetailPage();
        validate.navigationToPage(credentials.projectDetailsUrl);
        validate.checkProjectDetailsData(0, `Name: 13`);
        
        
    });
    xit('should search project by title in all projects', () => {
        
        const projectTitle = 'polyglot';
        dashboard.enterPtojectTitleforSearch(projectTitle);
        $("div.ng-trigger.ng-trigger-overlayAnimation").waitForDisplayed(10000);
        Help.browserClickXPath("//span[contains(text(), 'in All projects')]");
        const actualmessage = $("div.content-wrapper p").getText();
        const expectedmessage = `Global search results for query "${projectTitle}":`;
        assert.equal(expectedmessage, actualmessage);
        const ProjectItem = $$("div.result-project");
                   
        const title = [];
        const result = [];
        for (var i=0; i < ProjectItem.length; i++) {
            title[i] = ProjectItem[i].getText();
            result[i] = title[i].indexOf(projectTitle) !==-1;
            assert.equal(true, result[i]);
            
        }

        
        
    });
    xit('should not find project by title in all projects', () => {
        
        const projectTitle = "publicproject";
        dashboard.enterPtojectTitleforSearch(projectTitle);
        $("div.ng-trigger.ng-trigger-overlayAnimation").waitForDisplayed(10000);
        Help.browserClickXPath("//span[contains(text(), 'in All projects')]");
        const actualmessage = $("div.content-wrapper p").getText();
        const expectedmessage = `Global search results for query "${projectTitle}":`;
        assert.equal(expectedmessage, actualmessage);
        assert.equal(false, $$("div.result-project").length !== 0);
        

        
        
        
    });

   
});