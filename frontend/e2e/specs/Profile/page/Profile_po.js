class ProfilePage {

    get profileButton () {return $("button.ui-button.ui-widget.ui-state-default.ui-corner-all.ui-button-text-icon-left")};
    get changeImageButton () {return $("//span[contains(text(), 'Change Image')]/..")};
    get deleteImageButton () {return $("//span[contains(text(), 'Delete Image')]/..")};
    get updateInfoButton () {return $("//span[contains(text(), 'Update Info')]/..")};
    get changePasswordButton () {return $("//span[contains(text(), 'Change password')]/..")};
   
   /* get editProfileButton () {return $("button.ui-button.ui-widget.ui-state-default.ui-corner-all.ui-button-text-icon-left.ng-star-inserted")};
    get editingOptions() {return ("a.ui-menuitem-link.ui-corner-all.ng-star-inserted")};
   */ get projectsTabpanel () {return ("span.ui-tabview-title.ng-star-inserted")};
    get editorSettingsTabpanel () {return ("li.ui-state-default.ui-corner-top.ng-star-inserted.ui-tabview-selected.ui-state-active")};
    
    get lineHeightInput() {return $("input[formcontrolname='lineHeight']")};
    get fontSizeInput() {return $("input[formcontrolname='fontSize']")};
    get tabSizeInput() {return $("input[formcontrolname='tabSize']")};
    get saveButton() {return $("button.settings-btn.ui-button.ui-widget.ui-state-default.ui-corner-all.ui-button-text-only.ng-star-inserted")}

    get changedFirstNameInput() {return $("input[placeholder='Enter your name']")};
    get changedLastNameInput() {return $("input[placeholder='Enter your surname']")};
    get changedNicknameInput() {return $("input[placeholder='Enter your nickname']")};
    get githubUrlInput() {return $("input[placeholder='Enter github url']")};
    get birthdayInput () {return $$("input.ui-inputtext.ui-widget.ui-state-default.ui-corner-all.ng-star-inserted")[1]};

    get uploadAvatarInput () {return $("input#uploadfile")};
    get confirmDeleteImageButton() {return $('//span[contains(text(), "Yes")]/..')};
    get updateAvatarButton(){return $("p-button")};//$$("button.ui-button.ui-widget.ui-state-default.ui-corner-all.ui-button-text-only")[1]};
    get currentPaswordInput () {return $("input[placeholder='Enter current password']")};
    get changedPasswordInput () {return $("input[placeholder='Enter new password']")};
    get repeatChangedPasswordInput () {return $("input[placeholder='Repeat new password']")};
   // get currentPaswordInput () {return $$("input.ng-untouched.ng-pristine.ng-invalid.ui-inputtext.ui-corner-all.ui-state-default.ui-widget")[0]};
   // get changedPasswordInput () {return $("input.ui-inputtext.ui-corner-all.ui-state-default.ui-widget.ng-dirty.ng-touched.ng-invalid")};
   get changeButton () {return $("button[label='Change']")}; 
   get Uploadphoto() {return $('input[type=file]')};
   
   
};

module.exports = ProfilePage;
