const ProfilePage = require('../page/Profile_po');
const page = new ProfilePage();

class ProfileActions {

    clickMyProfileButton(){
        page.profileButton.waitForDisplayed(5000);
        page.profileButton.click();
    }
    clickChangeImageButton(){
        page.changeImageButton.waitForDisplayed(5000);
        page.changeImageButton.click();
    }
    clickDeleteImageButton(){
        page.deleteImageButton.waitForDisplayed(5000);
        page.deleteImageButton.click();
        page.confirmDeleteImageButton.waitForDisplayed(5000);
        page.confirmDeleteImageButton.click();
    }
    clickUpdateInfoButton(){
        page.updateInfoButton.waitForDisplayed(5000);
        page.updateInfoButton.click();
    }
    clickUpdateButton(){
        page.updateButton.waitForDisplayed(5000);
        page.updateButton.click();
    }
    clickSelectMonth(){
        page.selectMonth.waitForDisplayed(5000);
        page.selectMonth.click();
    }
    clickSelectYear(){
        page.selectYear.waitForDisplayed(5000);
        page.selectYear.click();
    }
    clickChangePasswordButton(){
        page.changePasswordButton.waitForDisplayed(5000);
        page.changePasswordButton.click();
    }
    enterlineHeight(value){
        page.lineHeightInput.waitForDisplayed(5000);
        page.lineHeightInput.clearValue();
        page.lineHeightInput.setValue(value);
    }
    enterFontSize(value){
        page.fontSizeInput.waitForDisplayed(5000);
        page.fontSizeInput.clearValue();
        page.fontSizeInput.setValue(value);
    }
    enterTabSize(value){
        page.tabSizeInput.waitForDisplayed(5000);
        page.tabSizeInput.clearValue();
        page.tabSizeInput.setValue(value);
    }
    clickSaveButton(){
        page.saveButton.waitForDisplayed(5000);
        page.saveButton.click();
    }
    entercurrentPassword(value){
        page.currentPaswordInput.waitForDisplayed(2000);
        page.currentPaswordInput.clearValue();
        page.currentPaswordInput.setValue(value);
    }
    enterChangedPassword(value){
        page.changedPasswordInput.waitForDisplayed(2000);
        page.changedPasswordInput.clearValue();
        page.changedPasswordInput.setValue(value);
    }
    enterRepeatPassword(value){
        page.repeatChangedPasswordInput.waitForDisplayed(2000);
        page.repeatChangedPasswordInput.clearValue();
        page.repeatChangedPasswordInput.setValue(value);
    }
    clickChangeButton(){
        page.changeButton.waitForDisplayed(2000);
        page.changeButton.click();
    }
    enterFirstName(value){
        page.changedFirstNameInput.waitForDisplayed(2000);
        page.changedFirstNameInput.clearValue();
        page.changedFirstNameInput.setValue(value);
    }
    enterLastName(value){
        page.changedLastNameInput.waitForDisplayed(2000);
        page.changedLastNameInput.clearValue();
        page.changedLastNameInput.setValue(value);
    }
    enterNickname(value){
        page.changedNicknameInput.waitForDisplayed(2000);
        page.changedNicknameInput.clearValue();
        page.changedNicknameInput.setValue(value);
    }
    enterGitHub(value){
        page.githubUrlInput.waitForDisplayed(2000);
        page.githubUrlInput.clearValue();
        page.githubUrlInput.setValue(value);
    }
    clickSaveButton(){
        page.saveButton.waitForDisplayed(2000);
        page.saveButton.click();
    }
    UploadControl(path) {
        console.log("2_____________________" + path);
        page.Uploadphoto.setValue(path);
     }
    changePassword(currentPassword, newPassword) {
        
        this.clickMyProfileButton();
         $("div.panel.p-grid.ng-star-inserted").waitForDisplayed(10000);
        this.clickChangePasswordButton();
        $("app-user-dialog-window").waitForDisplayed(10000);    
        this.entercurrentPassword(currentPassword);
        this.enterChangedPassword(newPassword);
        this.enterRepeatPassword(newPassword);
        this. clickChangeButton()
  
    }
    waitPanelOfProjectEditorSettings(){
        const panel = $("div.ui-tabview.ui-widget.ui-widget-content.ui-corner-all.ui-tabview-top");
        panel.waitForDisplayed(5000);
    }
    clickUpdateAvatarButton(){
        page.updateAvatarButton.waitForDisplayed(2000);
        page.updateAvatarButton.click();
    }
    
    
 
}

module.exports = ProfileActions;
