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
    
   });

   afterEach(() => {
       browser.reloadSession();
   });


    xit('should add project to favourite', () => {
        
        wait.ofDashboardMenu();
        validate.successnavigationToPage(credentials.dashboardUrl);
        Help.browserClickXPath(page.tabMyProjects);
        wait.cardsArea();
        dashboard.starProject();
      //  $('//div[@Class="cards-area"]/div[1]/app-project-card/p-card')
      
        Help.browserClickXPath(page.tabFavouriteProjects);
        wait.cardsArea();
        validate.verifyFavouriteProjectTitle("changedProject");
        Help.browserClickXPath(page.tabMyProjects);
        wait.cardsArea();
        dashboard.starProject();
        Help.browserClickXPath(page.tabFavouriteProjects);
        validate.successnavigationToPage(credentials.dashboardUrl);
        validate.verifyNoProjectsInFavourite(credentials.expectedmessageonFavourite);
        Help.logOut();
        
    });


    xit('should search project by title in all projects', () => {
        
        
        wait.ofDashboardMenu();
      
        validate.successnavigationToPage(credentials.dashboardUrl);
        Help.searchProjectByTitleOf("test");
         
        validate.navigationToPage(credentials.projectDetailsUrl);
        validate.checkProjectDetailsData(0, `Name: ${credentials.projectName}`);
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