const LoginActions = require('../specs/Authentication/actions/Authentication_pa');
const page = new LoginActions();
const ProjectPageActions = require('../specs/Create_Project_Page/actions/CreateProjectPage_pa');
const project = new ProjectPageActions();
const DashboardActions = require('../specs/Dashboard/actions/Dashboard_pa');
const dashboard = new DashboardActions();
const ProjectDetailsActions = require('../specs/Project_Details_Page/actions/ProjectDetails_pa');
const projectDetails = new ProjectDetailsActions();
const DashboardPage = require('../specs/Dashboard/page/Dashboard_po');
const dashboardObject = new DashboardPage();
const ProjectDetailsPage = require('../specs/Project_Details_Page/page/ProjectDetails_po');
const detailsObject = new ProjectDetailsPage();
const ProfileActions = require('../specs/Profile/actions/Profile_pa');
const profile = new ProfileActions();
const ProfilePage = require('../specs/Profile/page/Profile_po');
const profileObject = new ProfilePage();
const credentials = require('./../specs/testData.json');

function  generateRandomString(length) {

    var text = "";
    var possible = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
  
    for (var i = 0; i < length; i++)
  
      text += possible.charAt(Math.floor(Math.random() * possible.length));
    
    return text;
  
}


class HelpClass 
{


    generateEmail(){
        const localPart = generateRandomString(12);
        const domainPart = generateRandomString(3);
        console.log(`${localPart}@${domainPart}.com`);
        return `${localPart}@${domainPart}.com`;
        
    }
    browserClick(elm){ return browser.execute((e) => {document.querySelector(e).click(); }, elm); }

    browserClickXPath(elm){ return browser.execute((e) => {document.evaluate(e, document).iterateNext().click(); }, elm); }

    browserClickOnArrayElement(elm, index){return browser.execute((e, i) => {document.querySelectorAll(e)[i - 1].click();}, elm, index);}
       
    loginWithDefaultUser() {
                
        page.clickloginbtn();
        page.waitFormContainer();
        page.enterEmail(credentials.email);
        page.enterPassword(credentials.password);
        page.clickCreateButton();
    }
    
    loginWithCustomUser(email, password) {
             
        page.clickloginbtn();
        page.enterEmail(email);
        page.enterPassword(password);
        page.clickCreateButton();
    }
    clickInDropdownListArrowOf(ListName){
        const el = $(`//p[contains(text(), "${ListName}")]/../p-dropdown//div[contains(@class, "ui-dropdown-trigger")]`);
        el.click();
    }
    clickInDropdownListOptionOf(ListName, ListOption){
       
        const el = `//p[contains(text(), "${ListName}")]/../p-dropdown//span[contains(text(),"${ListOption}")]/..`;
        const bel = $(el);
        this.browserClickXPath(el);
        bel.waitForExist(3000, true);
    }
    clickInDropdownListThemaOptions(ListOption){
       
        const el = `li[aria-label='${ListOption}']`;
        const bel = $(el);
        this.browserClick(el);
        bel.waitForExist(3000, true);
    }
    clickProjectFormDropdownArrowOf(ListName){
    
        const el = $(`//div[contains(text(), "${ListName}")]/following-sibling::div[1]//p-dropdown//div[contains(@class, "ui-dropdown-trigger")]`);
        el.click();
    }
    clickProjectFormOptionOf(ListName, ListOption){
    
        const el = `//div[contains(text(), "${ListName}")]/following-sibling::div[1]//p-dropdown//span[contains(text(),"${ListOption}")]/..`;
        const bel = $(el);
        this.browserClickXPath(el);
        bel.waitForExist(3000, true);
    }
    chooseColorInDropdownList(Color){

        const color = `//div[contains(text(), "Project color")]/following-sibling::div[1]//p-dropdownitem//li[@aria-label="${Color}"]`;
        const element = $(color);
        this.browserClickXPath(color);
        element.waitForExist(3000, true);
    }
    
    logOut() {

        browser.url(credentials.appUrl);
        page.clickLogOutButton();
       // this.browserClickOnArrayElement("a.ui-menuitem-link.ui-corner-all.ng-star-inserted", 2);
    }

    fillOutDataInForm(projectName, description, buildsNumber, buildsAttempts) {

        project.enterProjectName(projectName);
        project.enterDescription(description);
        this.clickProjectFormDropdownArrowOf("Language");
        this.clickProjectFormOptionOf("Language", "C#");
        this.clickProjectFormDropdownArrowOf("Project type");
        this.clickProjectFormOptionOf("Project type", "Console App");
        this.clickProjectFormDropdownArrowOf("Compiler Type");
        this.clickProjectFormOptionOf("Compiler Type", "Roslyn");
        project.enterBuildsNumbers(buildsNumber);
        project.enterBuildsAttempts(buildsAttempts);
        this.clickProjectFormDropdownArrowOf("Access");
        this.clickProjectFormOptionOf("Access", "Public");
        this.clickProjectFormDropdownArrowOf("Project color");
        this.chooseColorInDropdownList("Red");
      
    }

    fillOutChangedDataInForm(projectName, description, buildsNumber, buildsAttempts) {


        project.enterProjectName(projectName);
        project.enterDescription(description);
        project.enterBuildsNumbers(buildsNumber);
        project.enterBuildsAttempts(buildsAttempts);
        this.clickProjectFormDropdownArrowOf("Access");
        this.clickProjectFormOptionOf("Access", "Public");
        this.clickProjectFormDropdownArrowOf("Project color");
        this.chooseColorInDropdownList("Red");
      
    }

     returnUrl (){
        const urlPage = new URL(browser.getUrl());
        return urlPage;
    }
    
    navigateToFavouriteProjects() {
        this.browserClickOnArrayElement(dashboardObject.projectTabsDashboard, 1);
    }

    navigateToMyProjects() {
        this.browserClickOnArrayElement(dashboardObject.projectTabsDashboard, 2);
    }

    navigateToAssignedProjects() {
        this.browserClickOnArrayElement(dashboardObject.projectTabsDashboard, 3);
    }

    addCollaborators(nickname) {
        
       
        $('//span[contains(text(),"Collaborators")]/..').click();

        $('//h2[contains(text(),"Search and add new collaborators:")]').waitForDisplayed(10000);
        projectDetails.enterCollaboratorName(nickname);

       $(`//span[contains(text(),'${nickname}')]/..`).click();
       
        this.browserClick("div.ui-dropdown-trigger.ui-state-default.ui-corner-right");
       
       $("div.ng-trigger.ng-trigger-overlayAnimation").waitForDisplayed(10000);
        this.browserClickOnArrayElement("li.ui-dropdown-item.ui-corner-all", 3);
        projectDetails.clickSaveButton();

    }
    changeCollaboratorsRights(index) {
        
        $('//span[contains(text(),"Collaborators")]/..').click();
        $('//h2[contains(text(),"Search and add new collaborators:")]').waitForDisplayed(10000);
        this.browserClick("div.ui-dropdown-trigger.ui-state-default.ui-corner-right");
      
      $("div.ng-trigger.ng-trigger-overlayAnimation").waitForDisplayed(10000);
        this.browserClickOnArrayElement("li.ui-dropdown-item.ui-corner-all", index);
        projectDetails.clickSaveButton();

    }

    checkDetails() {
        $('//span[contains(text(),"Details")]/..').click();
        browser.pause(1000);
        $('//span[contains(text(),"Collaborators")]/..').click();
    }
    searchProjectByTitleOf(text) {

        dashboard.enterPtojectTitleforSearch(text);

        const dropdownlist = $("div.ng-trigger.ng-trigger-overlayAnimation");
        dropdownlist.waitForDisplayed(5000);
        const el = '//p-autocomplete/span/input/following-sibling::div/ul/li[last()]';
        const bel = $(el);
        bel.waitForDisplayed(5000);
        this.browserClickXPath(el);
  

       
    }
    changePassword(currentPassword, newPassword) {
        profile.clickMyProfileButton();
        profile.clickEditProfileButton();
        this.browserClickOnArrayElement(profileObject.editingOptions, 5);
        profile.entercurrentPassword(currentPassword);
        profile.enterChangedPassword(newPassword);
        this.browserClickOnArrayElement("span.ui-button-text.ui-clickable", 6);
    };

    openMyFirstProject() {
        dashboardObject.tabMyProjects.waitForDisplayed(2000);
        dashboardObject.tabMyProjects.click();
        dashboardObject.firstProjectCard.waitForDisplayed(10000);
        dashboardObject.firstProjectCard.click();
    };

    openAssignedFirstProject() {
        dashboardObject.tabAssignedProject.waitForDisplayed(2000);
        dashboardObject.tabAssignedProject.click();
        dashboardObject.firstProjectCard.waitForDisplayed(10000);
        dashboardObject.firstProjectCard.click();
    };

    secondWindowLogin() {
        browser.newWindow('https://bsa-ide.azurewebsites.net/', 'second acc');
        page.clickloginbtn();
        page.waitFormContainer();
        page.enterEmail(credentials.secondEmail);
        page.enterPassword(credentials.password);
        page.clickCreateButton();
    }

}

module.exports = new HelpClass();