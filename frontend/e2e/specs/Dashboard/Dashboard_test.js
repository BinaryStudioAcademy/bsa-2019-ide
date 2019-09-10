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
      // wait.forSpinner();
      wait.forNotificationToDisappear();
    
   });

   afterEach(() => {
       browser.reloadSession();
   });


    xit('should add project to favourite', () => {
        
        wait.ofDashboardMenu();
        validate.successnavigationToPage(credentials.dashboardUrl);
        Help.browserClickXPath("//li[contains(text(), 'My projects')]");//(page.tabMyProjects);
        console.log($("//li[contains(text(), 'My projects')]"));
       // wait.cardsArea();
       $("//div[@class='cards-area']/div[1]/app-project-card").waitForDisplayed(20000);
        dashboard.starProject();
        $("i.pi-star").waitForDisplayed(10000);
        Help.browserClickXPath(page.tabFavouriteProjects);
        $("//div[@class='cards-area']/div[1]/app-project-card").waitForDisplayed(20000);
    
        validate.verifyFavouriteProjectTitle("changedProject");

        dashboard.starProject();
        Help.browserClickXPath("//li[contains(text(), 'My projects')]");
        Help.browserClickXPath(page.tabFavouriteProjects);

        validate.successnavigationToPage(credentials.dashboardUrl);
        validate.verifyNoProjectsInFavourite(credentials.expectedmessageonFavourite);
        Help.logOut();
        
    });


    it('should search project by title in all projects', () => {
        
        
        wait.ofDashboardMenu();
      
        validate.successnavigationToPage(credentials.dashboardUrl);
        Help.searchProjectByTitleOf("13");
        wait.contentOfProjectDetailPage();
        validate.navigationToPage(credentials.projectDetailsUrl);
        validate.checkProjectDetailsData(0, `Name: 13`);
        Help.logOut();
        
    });
    xit('should search project by title in user`s projects', () => {
        
        
        wait.ofDashboardMenu();
        
        validate.successnavigationToPage(credentials.dashboardUrl);
        Help.searchProjectByTitleOf("test");
        
        Help.browserClickOnArrayElement("ul.ui-autocomplete-items.ui-autocomplete-list.ui-widget-content.ui-widget.ui-corner-all.ui-helper-reset li", 1);    
        validate.navigationToPage(credentials.projectDetailsUrl);
        validate.checkProjectDetailsData(0, `Name: ${credentials.projectName}`);
        Help.logOut();
        
    });


   
});