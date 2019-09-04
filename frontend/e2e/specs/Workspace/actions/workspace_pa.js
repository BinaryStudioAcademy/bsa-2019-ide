const WorkspacePage = require('./../page/workspace_po');
const page = new WorkspacePage();

class WorkspaceActions {

    openFirstfile() {
        page.firstFile.waitForDisplayed(10000);
        page.firstFile.click();
    };

    editOpenedFile(value) {
        page.editorField.waitForDisplayed(10000);
        page.editorField.click();
        browser.keys(value);
    };

    saveChanges() {
        page.saveBtn.waitForDisplayed(2000);
        page.saveBtn.click();
    };

    saveChanges() {
        page.saveBtn.waitForDisplayed(2000);
        page.saveBtn.click();
    };

    buildProject() {
        page.buildBtn.waitForDisplayed(2000);
        page.buildBtn.click();
    };

    runProject() {
        page.runBtn.waitForDisplayed(2000);
        page.runBtn.click();
    };

    openBuildResults() {
        page.buildResultTab.waitForDisplayed(5000);
        page.buildResultTab.click();
    };

    openProjectHistory() {
        page.historyTab.waitForDisplayed(5000);
        page.historyTab.click();
    };

    openFirstFileHIstory() {
        page.firstHistoryFile.waitForDisplayed(5000);
        page.firstHistoryFile.click();
    };

    openProjectDetails() {
        page.openDetailsBtn.waitForDisplayed(2000);
        page.openDetailsBtn.click();
    };

};

module.exports = WorkspaceActions;