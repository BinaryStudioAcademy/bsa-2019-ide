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
        return email = localPart+"@"+domainPart+".com"

    }
    /*clickItemInList(name) {
        const place = $$(`//div[contains(@class, "place-item")]//h3/a[contains(., "${name}")]`);
        if (place.length === 0) {
            throw new Error("Element not found");
        }
        //place[0].scrollIntoView();
        place[0].click();
    }*/

    browserClick(elm){ return browser.execute((e) => {document.querySelector(e).click(); }, elm); }

    browserClickOnArrayElement(elm, index){return browser.execute((e, i) => {document.querySelectorAll(e)[i - 1].click();}, elm, index);}
       
    loginWithDefaultUser() {
        browser.maximizeWindow();
        browser.url(credentials.appUrl);
        page.clickloginbtn();
        page.enterEmail(credentials.email);
        page.enterPassword(credentials.password);
        page.clickCreateButton();
    }
    
    loginWithCustomUser(email, password) {
        browser.maximizeWindow();
        browser.url(credentials.appUrl);
        page.clickloginbtn();
        page.enterEmail(email);
        page.enterPassword(password);
        page.clickCreateButton();
    }

    registerNewAccount(name, surname, nickname, email, password) {

        page.clickSignupbtn();
     
        browser.pause(3000);
        page.enterFirstName(name);
        page.enterLastName(surname);
        page.enterNickname(nickname);
        page.enterEmail(email);
        page.enterPassword(password);
        page.clickCreateButton();
    }
    recoveryPassword(email) {

        page.clickloginbtn();
     
        browser.pause(3000);
        page.clickRecoveryPassword();
        page.enterEmail(email);
        
        page.clickCreateButton();
    }
    logOut() {

        browser.url(credentials.appUrl);
        browser.pause(5000);
        page.clickLogOutButton();
        this.browserClickOnArrayElement("a.ui-menuitem-link.ui-corner-all.ng-star-inserted", 2);
    }

    createNewProject(ind1, ind2, ind3, ind4, ind5) {

        project.addButtonClick();
        browser.pause(2000);
        project.enterProjectName(credentials.projectName);
        project.enterDescription(credentials.description);
        this.browserClickOnArrayElement("div.ui-dropdown-trigger.ui-state-default.ui-corner-right", 1);
        this.browserClickOnArrayElement("li.ui-dropdown-item.ui-corner-all", ind1);
        browser.pause(2000);
        this.browserClickOnArrayElement("div.ui-dropdown-trigger.ui-state-default.ui-corner-right", 2);
        this.browserClickOnArrayElement("li.ui-dropdown-item.ui-corner-all", ind2);
        browser.pause(2000);
        this.browserClickOnArrayElement("div.ui-dropdown-trigger.ui-state-default.ui-corner-right", 3);
        this.browserClickOnArrayElement("li.ui-dropdown-item.ui-corner-all", ind3);
        project.enterBuildsNumbers(credentials.buildsNumber);
        project.enterBuildsAttempts(credentials.buildAttempts);
        browser.pause(2000);
      //  this.browserClickOnArrayElement("div.ui-dropdown-trigger.ui-state-default.ui-corner-right", 4);
      // this.browserClickOnArrayElement("div.ui-helper-clearfix.ng-star-inserted", ind4);
        browser.pause(2000);
        this.browserClickOnArrayElement("div.ui-dropdown-trigger.ui-state-default.ui-corner-right", 5);
        this.browserClickOnArrayElement("div.ui-helper-clearfix.ng-star-inserted", ind5);
        browser.pause(2000);
        project.clickCreateButton();

    }
    inputDataInFormCreateProject(name, description, buildsNumber, buildAttempts, ind1, ind2, ind3, ind5) {

        project.addButtonClick();
        browser.pause(2000);
        project.enterProjectName(name);
        project.enterDescription(description);
        this.browserClickOnArrayElement("div.ui-dropdown-trigger.ui-state-default.ui-corner-right", 1);
        this.browserClickOnArrayElement("li.ui-dropdown-item.ui-corner-all", ind1);
        browser.pause(2000);
        this.browserClickOnArrayElement("div.ui-dropdown-trigger.ui-state-default.ui-corner-right", 2);
        this.browserClickOnArrayElement("li.ui-dropdown-item.ui-corner-all", ind2);
        browser.pause(2000);
        this.browserClickOnArrayElement("div.ui-dropdown-trigger.ui-state-default.ui-corner-right", 3);
        this.browserClickOnArrayElement("li.ui-dropdown-item.ui-corner-all", ind3);
        project.enterBuildsNumbers(buildsNumber);
        
        project.enterBuildsAttempts(buildAttempts);
        browser.pause(2000);
      //  this.browserClickOnArrayElement("div.ui-dropdown-trigger.ui-state-default.ui-corner-right", 4);
      // this.browserClickOnArrayElement("div.ui-helper-clearfix.ng-star-inserted", ind4);
        browser.pause(2000);
        this.browserClickOnArrayElement("div.ui-dropdown-trigger.ui-state-default.ui-corner-right", 5);
        this.browserClickOnArrayElement("div.ui-helper-clearfix.ng-star-inserted", ind5);
        $("button.ui-button.ui-widget.ui-state-default.ui-corner-all.ui-button-text-only").waitForEnabled(5000, true);
    }
    inputChangedDataInForm(name, description, buildsNumber, buildAttempts, ind5) {


        project.enterProjectName(name);
        project.enterDescription(description);
        project.enterBuildsNumbers(buildsNumber);
     
        project.enterBuildsAttempts(buildAttempts);
        browser.pause(2000);
      //  this.browserClickOnArrayElement("div.ui-dropdown-trigger.ui-state-default.ui-corner-right", 4);
      // this.browserClickOnArrayElement("div.ui-helper-clearfix.ng-star-inserted", ind4);
        browser.pause(2000);
        this.browserClickOnArrayElement("div.ui-dropdown-trigger.ui-state-default.ui-corner-right", 2);
        this.browserClickOnArrayElement("div.ui-helper-clearfix.ng-star-inserted", ind5);
        project.clickCreateButton();
    }
    returnExpectedNotificationDeletionProject(){
        
        projectDetails.clickMyProjectTab();
        browser.pause(3000);
        const projectNameDeleted = dashboardObject.projectCardTitle[0].getText();
        const expectednotification = `Project "${projectNameDeleted}" was successfully deleted`
        return expectednotification;
    }
    clickProjectDetailsOnCard() {
        browser.pause(3000);
        this.browserClickOnArrayElement(dashboardObject.projectTabsDashbpord, 2);;
        browser.pause(1000);
        projectDetails.clickCardMenuButton();
        browser.pause(1000);
        this.browserClickOnArrayElement("a.ui-menuitem-link.ui-corner-all.ng-star-inserted", 2);
    }
    clickProjectSettingsOnCard() {

        this.browserClickOnArrayElement(dashboardObject.projectTabsDashbpord, 2);
        browser.pause(3000);
        projectDetails.clickCardMenuButton();
        browser.pause(3000);
        this.browserClickOnArrayElement("a.ui-menuitem-link.ui-corner-all.ng-star-inserted", 3);
    }
    DeleteProject() {
        const deletebtn = $$("button.ui-button.ui-widget.ui-state-default.ui-corner-all.ui-button-text-icon-left")[2];
        deletebtn.click();
        const deletebtnconfirm = $$("button.undefined.ui-button.ui-widget.ui-state-default.ui-corner-all.ui-button-text-icon-left.ng-star-inserted")[0];
        deletebtnconfirm.click();
    }
    returnUrl (){
        const urlPage = new URL(browser.getUrl());
        return urlPage;
    }
    addToFavourite(index){
        browser.pause(3000);
        this.browserClickOnArrayElement(dashboardObject.projectTabsDashbpord, 2);
        browser.pause(3000);
        dashboard.starProject(index);
        browser.pause(3000);
        const projectNameToFavourite = dashboardObject.projectCardTitle[index].getText();
        return projectNameToFavourite
    }
    navigateToFavouriteProjects() {
        this.browserClickOnArrayElement(dashboardObject.projectTabsDashbpord, 1);
    }
    navigateToMyProjects() {
        this.browserClickOnArrayElement(dashboardObject.projectTabsDashbpord, 2);
    }
   /* openProjectWorkspace(index) {
        browser.pause(1000);
        this.browserClickOnArrayElement(dashboardObject.projectCardTitle, index);
    }*/
    addCollaborators(nickname) {
        
        this.browserClickOnArrayElement(detailsObject.navbarDetailsPage, 2);
        browser.pause(2000);
        projectDetails.enterCollaboratorName(nickname);
        browser.pause(2000);
        
        this.browserClickOnArrayElement(detailsObject.listboxCollaborators, 1);
        browser.pause(2000);
        this.browserClick("div.ui-dropdown-trigger.ui-state-default.ui-corner-right");
        browser.pause(2000);
        this.browserClickOnArrayElement("li.ui-dropdown-item.ui-corner-all", 3);
        projectDetails.clickSaveButton();

    }
    changeCollaboratorsRights(index) {
        
        this.browserClickOnArrayElement(detailsObject.navbarDetailsPage, 2);
        this.browserClick("div.ui-dropdown-trigger.ui-state-default.ui-corner-right");
        browser.pause(2000);
        this.browserClickOnArrayElement("li.ui-dropdown-item.ui-corner-all", index);
        projectDetails.clickSaveButton();

    }
    deleteCollaborator(index) {
        
        this.browserClickOnArrayElement(detailsObject.navbarDetailsPage, 2);
        browser.pause(3000);
        projectDetails.clickDeleteButton(index);
        projectDetails.clickSaveButton();
       

    }
    checkDetails() {
        this.browserClickOnArrayElement(detailsObject.navbarDetailsPage, 1);
        browser.pause(1000);
        this.browserClickOnArrayElement(detailsObject.navbarDetailsPage, 2);
    }
    searchProjectByTitle(text, index) {
        dashboard.enterPtojectTitleforSearch(text);
        browser.pause(2000);
        this.browserClickOnArrayElement(dashboardObject.listboxProjects, index);

    }
    changePassword(currentPassword, newPassword) {
        profile.clickMyProfileButton();
        profile.clickEditProfileButton();
        browser.pause(1000);
        this.browserClickOnArrayElement(profileObject.editingOptions, 5);
        browser.pause(1000);
        profile.entercurrentPassword(currentPassword);
      //  browser.pause(1000);
        profile.enterChangedPassword(newPassword);
        browser.pause(2000);
       // profile.clickChangeButton();
       this.browserClickOnArrayElement("span.ui-button-text.ui-clickable", 6);
    }
}

module.exports = new HelpClass();