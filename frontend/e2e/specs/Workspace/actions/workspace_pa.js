const WorkspacePage = require('./../page/workspace_po');
const page = new WorkspacePage();

class WorkspaceActions {

    openFirstfile() {
        page.firstFile.waitForDisplayed(10000);
        page.firstFile.click();
    };

    editOpenedFile(value) {
        page.firtsWordInEditor.waitForDisplayed(10000);
        page.firtsWordInEditor.click();
        browser.keys(value);
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
        page.firstFile.waitForDisplayed(5000); //for some reason, without this click not working
        page.firstHistoryFile.click();
    };

    openProjectDetails() {
        page.openDetailsBtn.waitForDisplayed(5000);
        page.firstFile.waitForDisplayed(5000); //for some reason, without this click not working
        page.openDetailsBtn.click();
    };

    getMessageText() {
        page.workspaceCannotEditMessage.waitForDisplayed(10000);
        return page.workspaceCannotEditMessage.getText();
    };

    editBigComment(value) { //and this is costil' too...
        page.bigFouthString.waitForDisplayed(10000);
        page.bigFouthString.click();
        browser.keys(value);
    };

    deleteChanges() {
        page.firtsWordInEditor.waitForDisplayed(10000);
        page.firtsWordInEditor.click();
        browser.keys("ArrowRight", "ArrowRight", "Backspace", "Backspace", "Backspace");
    };

};

module.exports = WorkspaceActions;