class ProfilePage {

    get profileButton () {return $("button.ui-button.ui-widget.ui-state-default.ui-corner-all.ui-button-text-icon-left")};
    get changeImageButton () {return $("//span[contains(text(), 'Change Image')]/..")};
    get deleteImageButton () {return $("//span[contains(text(), 'Delete Image')]/..")};
    get updateInfoButton () {return $("//span[contains(text(), 'Update Info')]/..")};
    get changePasswordButton () {return $("//span[contains(text(), 'Change password')]/..")};
    get projectsTabpanel () {return ("span.ui-tabview-title.ng-star-inserted")};
    get editorSettingsTabpanel () {return ("li.ui-state-default.ui-corner-top.ng-star-inserted.ui-tabview-selected.ui-state-active")};
    get lineHeightInput() {return $("input[formcontrolname='lineHeight']")};
    get fontSizeInput() {return $("input[formcontrolname='fontSize']")};
    get tabSizeInput() {return $("input[formcontrolname='tabSize']")};
    get saveButton() {return $("button.settings-btn.ui-button.ui-widget.ui-state-default.ui-corner-all.ui-button-text-only.ng-star-inserted")}
    get updateButton() {return $("button[label='Update']")};
    get selectMonth() {return $("select.ui-datepicker-month")};
    get selectYear() {return $("select.ui-datepicker-month")};
    get changedFirstNameInput() {return $("input[placeholder='Enter your name']")};
    get changedLastNameInput() {return $("input[placeholder='Enter your surname']")};
    get changedNicknameInput() {return $("input[placeholder='Enter your nickname']")};
    get githubUrlInput() {return $("input[placeholder='Enter github url']")};
    get birthdayInput () {return $$("input.ui-inputtext.ui-widget.ui-state-default.ui-corner-all.ng-star-inserted")[1]};
    get uploadAvatarInput () {return $("input#uploadfile")};
    get confirmDeleteImageButton() {return $('//span[contains(text(), "Yes")]/..')};
    get updateAvatarButton(){return $("p-button")};
    get currentPaswordInput () {return $("input[placeholder='Enter current password']")};
    get changedPasswordInput () {return $("input[placeholder='Enter new password']")};
    get repeatChangedPasswordInput () {return $("input[placeholder='Repeat new password']")};
    get changeButton () {return $("button[label='Change']")}; 
    get Uploadphoto() {return $('input[type=file]')};
    get nicknameField() {return $$("span.property-value")[0]};
    get birthDayField() {return $$("span.property-value")[3]};
    get userNameField() {return $("p.tname.p-col-align-center")};
    get themaDataField() {return $$("label.ui-dropdown-label.ui-inputtext.ui-corner-all.ng-star-inserted")[0]};
    get scrollBeyondLastLine() {return $$("label.ui-dropdown-label.ui-inputtext.ui-corner-all.ng-star-inserted")[1]};
    get cursorStyle() {return $$("label.ui-dropdown-label.ui-inputtext.ui-corner-all.ng-star-inserted")[2]};
    get lineNumbers() {return $$("label.ui-dropdown-label.ui-inputtext.ui-corner-all.ng-star-inserted")[3]};
   
   
};

module.exports = ProfilePage;
