const ProjectPage = require('../page/CreateProjectPage_po');
const page = new ProjectPage();

class ProjectPageActions {


    addButtonClick() {
        
        page.addButton.waitForDisplayed(2000);
        page.addButton.click();
    }
    enterProjectName(value) {
        page.projectNameInput.waitForDisplayed(2000);
        page.projectNameInput.clearValue();
        page.projectNameInput.setValue(value);
    }
    enterDescription(value) {
        page.descriptionInput.waitForDisplayed(2000);
        page.descriptionInput.clearValue();
        page.descriptionInput.setValue(value);
    }
  
    enterBuildsNumbers(value) {
        page.buildssavedInput.waitForDisplayed(2000);
        page.buildssavedInput.clearValue();
        page.buildssavedInput.setValue(value);
    }
    enterBuildsAttempts(value) {
        page.buildsattemptsInput.waitForDisplayed(2000);
        page.buildsattemptsInput.clearValue();
        page.buildsattemptsInput.setValue(value);
    }
 
    clickCreateButton() {
        page.createButton.waitForDisplayed(5000);
        page.createButton.click();
    }
    getTextProjectDetails(index) {
        page.projectDetailData(index).waitForDisplayed(2000);
        page.projectDetailData.getText();
    }
    waitFormOfProjectCreation(){
        
        page.formOfProjectCreation.waitForDisplayed(10000);
    }
    waitEnableSaveButton(){
      
        page.createButton.waitForEnabled(5000, true);
    }
    waitContentProjectDetailPage(){
        page.contentOfProjectDetailPage.waitForDisplayed(10000);
    }
  
}

module.exports = ProjectPageActions;
