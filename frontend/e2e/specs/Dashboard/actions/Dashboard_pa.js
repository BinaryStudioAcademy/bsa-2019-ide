const DashboardPage = require('../page/Dashboard_po');
const page = new DashboardPage();

class DashboardActions {


    starProject() {
        page.starProjectCard.waitForDisplayed(6000);
        page.starProjectCard.click();
        browser.pause(1000);
    }

    enterPtojectTitleforSearch(text){
      page.searchInput.waitForDisplayed(2000);
      page.searchInput.clearValue();
      page.searchInput.setValue(text);
    }
    

}

module.exports = DashboardActions;
