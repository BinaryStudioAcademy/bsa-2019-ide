const ProfilePage = require('../page/Profile_po');
const page = new ProfilePage();

class ProfileActions {

    clickMyProfileButton(){
        page.profileButton.waitForDisplayed(2000);
        page.profileButton.click();
    }
    clickEditProfileButton(){
        page.editProfileButton.waitForDisplayed(2000);
        page.editProfileButton.click();
    }
    enterlineHeight(value){
        page.lineHeightInput.waitForDisplayed(2000);
        page.lineHeightInput.clearValue();
        page.lineHeightInput.setValue(value);
    }
    enterFontSize(value){
        page.fontSizeInput.waitForDisplayed(2000);
        page.fontSizeInput.clearValue();
        page.fontSizeInput.setValue(value);
    }
    enterTabSize(value){
        page.tabSizeInput.waitForDisplayed(2000);
        page.tabSizeInput.clearValue();
        page.tabSizeInput.setValue(value);
    }
    clickSaveButton(){
        page.saveButton.waitForDisplayed(2000);
        page.saveButton.click();
    }
    entercurrentPassword(value){
        page.currentPaswordInput.waitForDisplayed(2000);
        page.currentPaswordInput.clearValue();
        page.currentPaswordInput.setValue(value);
    }
    enterChangedPassword(value){
       // page.changedPasswordInput.waitForDisplayed(2000);
        page.changedPasswordInput.clearValue();
        page.changedPasswordInput.setValue(value);
    }
    clickChangeButton(){
        page.changeButton.waitForDisplayed(2000);
        page.changeButton.click();
    }
    
 
}

module.exports = ProfileActions;
