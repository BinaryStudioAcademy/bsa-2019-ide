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

    changeUserInfo(FirstName, LastName, Nick, Git, month, year, day){
        profile.enterFirstName(FirstName);
        profile.enterLastName(LastName);
        profile.enterNickname(Nick);
        profile.enterGitHub(Git)
        this.browserClickXPath('//p-calendar/span/input');
        profile.clickSelectMonth();
        this.browserClick(`option[value='${month}']`);
        profile.clickSelectYear();
        this.browserClick(`option[value='${year}']`);
        this.browserClickOnArrayElement("a.ui-state-default.ng-star-inserted", day);
        profile.clickUpdateButton();
    }
    changeEditorSettings(){
        this.browserClickOnArrayElement("li.ui-state-default.ui-corner-top.ng-star-inserted", 2);
        profile.enterlineHeight("14");
        profile.enterFontSize("14");
        profile.enterTabSize("3");
        this.clickInDropdownListArrowOf("Thema:");
        this.clickInDropdownListThemaOptions("vs");
        this.clickInDropdownListArrowOf("Scroll beyond last line:");
        this.clickInDropdownListOptionOf("Scroll beyond last line:", "false");
        this.clickInDropdownListArrowOf("Cursor style:");
        this.clickInDropdownListOptionOf("Cursor style:", "block");
        this.clickInDropdownListArrowOf("Line numbers:");
        this.clickInDropdownListOptionOf("Line numbers:", "interval");
        profile.clickSaveButton();
    }

     returnUrl (){
        const urlPage = new URL(browser.getUrl());
        return urlPage;
    }
    
    navigateToFavouriteProjects() {
        this.browserClickOnArrayElement(dashboardObject.projectTabsDashbpord, 1);
    }
    navigateToMyProjects() {
        this.browserClickOnArrayElement(dashboardObject.projectTabsDashbpord, 2);
    }

    addCollaborators(nickname, AccessRights) {
        
       
        detailsObject.collaboratorTab.click();
        detailsObject.collaboratorTitle.waitForDisplayed(10000);
        projectDetails.enterCollaboratorName(nickname);
        $(`//span[contains(text(),'${nickname}')]/..`).click();
        this.browserClickXPath(`//div[contains(text(), "${nickname}")]/../p-dropdown//div[contains(@class, "ui-dropdown-trigger")]`)
        detailsObject.dropdownlist.waitForDisplayed(10000);
        this.browserClick(`li[aria-label="${AccessRights}"]`);
        projectDetails.clickSaveButton();

    }
    changeCollaboratorsRights(nickname, AccessRights) {
        
        detailsObject.collaboratorTab.click();
        detailsObject.collaboratorTitle.waitForDisplayed(10000);
        this.browserClickXPath(`//div[contains(text(), "${nickname}")]/../p-dropdown//div[contains(@class, "ui-dropdown-trigger")]`)
        detailsObject.dropdownlist.waitForDisplayed(10000);
        this.browserClick(`li[aria-label="${AccessRights}"]`);
        projectDetails.clickSaveButton();

    }

    checkDetails() {
        detailsObject.detailsTab.click();
        browser.pause(1000);
        detailsObject.collaboratorTab.click();
    }
    searchProjectByTitleOf(text) {

        dashboard.enterPtojectTitleforSearch(text);
        detailsObject.dropdownlist.waitForDisplayed(10000);
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

    //delete or rewrite this asap
    openFirstProject() {
        $('/html/body/app-root/div/app-dashboard-root/div/div[1]/ul/li[2]').waitForDisplayed(2000);
        $('/html/body/app-root/div/app-dashboard-root/div/div[1]/ul/li[2]').click()
        $('/html/body/app-root/div/app-dashboard-root/div/app-my-projects/div/app-projects-list/div/div/div[1]/app-project-card/p-card/div').waitForDisplayed(2000);
        $('/html/body/app-root/div/app-dashboard-root/div/app-my-projects/div/app-projects-list/div/div/div[1]/app-project-card/p-card/div').click();
    }
}

module.exports = new HelpClass();