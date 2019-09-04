const DashboardPage = require('../page/Dashboard_po');
const page = new DashboardPage();

class DashboardActions {


   /* addButtonClick() {
        
        page.addButton.waitForDisplayed(2000);
        page.addButton.click();
    }

    clickMyProjectTab(){
        page.menuTabs[1].waitForDisplayed(2000);
        page.menuTabs[1].click();
    }
    clickCardMenuButton() {
        page.menuProjectCard[0].waitForDisplayed(2000);
        page.menuProjectCard[0].click();
    }
    clickProjectDetailsButton() {
        page.detailsProject.waitForDisplayed(2000);
        page.detailsProject.click(); 
    }
    clickProjectSettingsButton() {
        page.settingsProject.waitForDisplayed(2000);
        page.settingsProject.click(); 
    }
    getProjectTitle() {
        page.titleProjectCard[0].waitForDisplayed(2000);
        page.titleProjectCard[0].getText();
    }*/
    starProject(index) {
        page.starProjectCard[index].waitForDisplayed(6000);
        page.starProjectCard[index].click();
    }
   /* enterCollaboratorName(value) {
        page.inputCollaboratorNickname.waitForDisplayed(2000);
        page.inputCollaboratorNickname.clearValue();
        page.inputCollaboratorNickname.setValue(value);
    }
  clickSaveButton() {
        page.saveCollaboratorButton.waitForDisplayed(2000);
        page.saveCollaboratorButton.click();
  }*/
    enterPtojectTitleforSearch(text){
      page.searchInput.waitForDisplayed(2000);
      page.searchInput.clearValue();
      page.searchInput.setValue(text);
    }
    waitDashboardMenu(){
        const menu = $("div.menu");
        menu.waitForDisplayed(10000);
    }

}

module.exports = DashboardActions;
