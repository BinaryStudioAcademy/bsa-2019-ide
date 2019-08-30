const credentials = require('./../testData.json');
const Help = require('../../helpers/helpers');
const Assert = require('../../helpers/validators');
const Wait = require('../../helpers/waiters');
const validate = new Assert();
const wait = new Wait();

//const DashboardPage = require('../page/Dashboard_po');
//const dashboardObject = new DashboardPage();

//const assert = require('chai').assert;
describe('Online-IDE Dashboard', () => {
    
    beforeEach(() => {
       browser.maximizeWindow();
       browser.url(credentials.appUrl);
       Help.loginWithDefaultUser();
       wait.forSpinner();
    
   });

   afterEach(() => {
       browser.reloadSession();
   });


    xit('add project to favourite', () => {
        browser.pause(3000);   
        projectNameToFavourite = Help.addToFavourite(0);
        Help.navigateToFavouriteProjects();
        
        validate.verifyFavouriteProjectTitle(projectNameToFavourite);
        Help.addToFavourite(0);
        Help.navigateToFavouriteProjects();
        validate.verifyNoProjectsInFavourite(credentials.expectedmessageonFavourite);
        Help.logOut();
        
    });


    xit('search project by title', () => {
        
        
        browser.pause(1000);
        Help.searchProjectByTitle("testproject", 1);
        browser.pause(3000);
        
        
        validate.navigationToPage(credentials.projectDetailsUrl);
        validate.checkProjectDetailsData(0, `Name: ${credentials.projectName}`);
        Help.logOut();
        
    });


   
});