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
        $("div.ng-trigger.ng-trigger-animation").waitForDisplayed(10000);
       // const form = $("div.ui-dialog-content.ui-widget-content").waitForDisplayed(10000);
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
        this.browserClickOnArrayElement("a.ui-menuitem-link.ui-corner-all.ng-star-inserted", 2);
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
       
        this.browserClickOnArrayElement(dashboardObject.projectTabsDashbpord, 2);
        const cards =  $("div.cards-area");
        cards.waitForDisplayed(10000);
        dashboard.starProject(index);
        const projectNameToFavourite = dashboardObject.projectCardTitle[index].getText();
        return projectNameToFavourite
    }
    navigateToFavouriteProjects() {
        this.browserClickOnArrayElement(dashboardObject.projectTabsDashbpord, 1);
    }
    navigateToMyProjects() {
        this.browserClickOnArrayElement(dashboardObject.projectTabsDashbpord, 2);
    }

    addCollaborators(nickname) {
        
       
        $('//span[contains(text(),"Collaborators")]/..').click();

        $('//h2[contains(text(),"Search and add new collaborators:")]').waitForDisplayed(10000);
        projectDetails.enterCollaboratorName(nickname);

       $("//span[contains(text(),'testUser1')]/..").click();
       
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
    deleteCollaborator(index) {
        
        $('//span[contains(text(),"Collaborators")]/..').click();
        $('//h2[contains(text(),"Search and add new collaborators:")]').waitForDisplayed(10000);
        projectDetails.clickDeleteButton(index);
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
        const button = $("span.ui-button-secondary.ui-button.ui-widget.ui-state-default.ui-corner-all.ui-button-text-only.ng-star-inserted");
        button.click();

        console.log("111______________");
        //this.browserClickOnArrayElement(dashboardObject.listboxProjects, index);
       // console.log("123______________________");

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
    };

    //delete or rewrite this asap
    openFirstProject() {
        $('/html/body/app-root/div/app-dashboard-root/div/div[1]/ul/li[2]').waitForDisplayed(2000);
        $('/html/body/app-root/div/app-dashboard-root/div/div[1]/ul/li[2]').click()
        $('/html/body/app-root/div/app-dashboard-root/div/app-my-projects/div/app-projects-list/div/div/div[1]/app-project-card/p-card/div').waitForDisplayed(2000);
        $('/html/body/app-root/div/app-dashboard-root/div/app-my-projects/div/app-projects-list/div/div/div[1]/app-project-card/p-card/div').click();
    }
}

module.exports = new HelpClass();