const credentials = require('./../testData.json');
const Help = require('../../helpers/helpers');
const Assert = require('../../helpers/validators');
const Wait = require('../../helpers/waiters');
const validate = new Assert();
const wait = new Wait();

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
        Help.searchProjectByTitleOf("test");
        Help.browserClickOnArrayElement("ul.ui-autocomplete-items.ui-autocomplete-list.ui-widget-content.ui-widget.ui-corner-all.ui-helper-reset li", 1);    
        validate.navigationToPage(credentials.projectDetailsUrl);
        validate.checkProjectDetailsData(0, `Name: ${credentials.projectName}`);      
    });
   
});