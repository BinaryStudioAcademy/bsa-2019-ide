const credentials = require('./../testData.json');
const Help = require('../../helpers/helpers');
const Assert = require('../../helpers/validators');
const Wait = require('../../helpers/waiters');
const validate = new Assert();
const wait = new Wait();

const DashboardActions = require('./actions/Dashboard_pa');
const dashboard = new DashboardActions();

//const assert = require('chai').assert;
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


    xit('add project to favourite', () => {
        
        dashboard.waitDashboardMenu();
        validate.successnavigationToPage(credentials.dashboardUrl);
        projectNameToFavourite = Help.addToFavourite(0);
        Help.navigateToFavouriteProjects();
        validate.verifyFavouriteProjectTitle(projectNameToFavourite);
        Help.addToFavourite(0);
        Help.navigateToFavouriteProjects();
        validate.successnavigationToPage(credentials.dashboardUrl);
        validate.verifyNoProjectsInFavourite(credentials.expectedmessageonFavourite);
        Help.logOut();
        
    });


    xit('should search project by title in all projects', () => {
        
        
        dashboard.waitDashboardMenu();
        console.log("1____________________");
        validate.successnavigationToPage(credentials.dashboardUrl);
        Help.searchProjectByTitleOf("test");
        console.log("2____________________");       
        validate.navigationToPage(credentials.projectDetailsUrl);
        validate.checkProjectDetailsData(0, `Name: ${credentials.projectName}`);
        Help.logOut();
        
    });
    xit('should search project by title in user`s projects', () => {
        
        
        dashboard.waitDashboardMenu();
        console.log("1____________________");
        validate.successnavigationToPage(credentials.dashboardUrl);
        Help.searchProjectByTitleOf("test");
        console.log("2____________________");   
        Help.browserClickOnArrayElement("ul.ui-autocomplete-items.ui-autocomplete-list.ui-widget-content.ui-widget.ui-corner-all.ui-helper-reset li", 1);    
        validate.navigationToPage(credentials.projectDetailsUrl);
        validate.checkProjectDetailsData(0, `Name: ${credentials.projectName}`);
        Help.logOut();
        
    });


   
});