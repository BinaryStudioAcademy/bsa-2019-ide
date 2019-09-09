const ProjectDetailsPage = require('../page/ProjectDetails_po');
const page = new ProjectDetailsPage();

class ProjectDetailsActions {


    clickMyProjectTab(){
        page.menuTabs[1].waitForDisplayed(2000);
        page.menuTabs[1].click();
    }
    clickCardMenuButton() {
        page.menuProjectCard.waitForDisplayed(2000);
        page.menuProjectCard.click();
        
    }
    clickDeleteButton(index) {
        page.deleteCollaboratorButton[index].waitForDisplayed(2000);
        page.deleteCollaboratorButton[index].click();
    }
    clickSaveProjectButton() {
        page.saveProjectButton.waitForEnabled(5000);
        page.saveProjectButton.click();
    }
  
    enterCollaboratorName(value) {
        page.inputCollaboratorNickname.waitForDisplayed(2000);
        page.inputCollaboratorNickname.clearValue();
        page.inputCollaboratorNickname.setValue(value);
    }
    clickSaveButton() {
        page.saveCollaboratorButton.waitForDisplayed(2000);
        page.saveCollaboratorButton.click();
    }
    waitEnabledSaveButton(){
        page.saveCollaboratorButton.waitForEnabled(10000);
    }
    waitContentOfDetailsPage(){
        page.contentOfDetailsPage.waitForExist(5000);
    }
    deleteProject() {
     //   page.deletebtn.waitForDisplayed(5000);
     //   page.deletebtn.click();
     $("//app-confirmation-dialog/button").click();
        page.deletebtnconfirm.waitForDisplayed(5000);
        page.deletebtnconfirm.click();
    }
    deleteCollaborator(index) {
        
        $('//span[contains(text(),"Collaborators")]/..').click();
        $('//h2[contains(text(),"Search and add new collaborators:")]').waitForDisplayed(10000);
        this.clickDeleteButton(index);
        this.clickSaveButton();
      

    }
 
}

module.exports = ProjectDetailsActions;
