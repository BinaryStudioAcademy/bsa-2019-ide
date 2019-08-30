class ProfilePage {

    get profileButton () {return $("button.ui-button.ui-widget.ui-state-default.ui-corner-left.ui-button-text-icon-left")};
    get editProfileButton () {return $("button.ui-button.ui-widget.ui-state-default.ui-corner-all.ui-button-text-icon-left.ng-star-inserted")};
    get editingOptions() {return ("a.ui-menuitem-link.ui-corner-all.ng-star-inserted")};
    get projectsTabpanel () {return ("a#ui-tabpanel-21-label")};
    get editorSettingsTabpanel () {return ("a#ui-tabpanel-22-label")};
    
    get lineHeightInput() {return $$("input.ng-untouched.ng-pristine.ng-valid")[0]};
    get fontSizeInput() {return $$("input.ng-untouched.ng-pristine.ng-valid")[1]};
    get tabSizeInput() {return $$("input.ng-untouched.ng-pristine.ng-valid")[2]};
    get saveButton() {return $("button.settings-btn.ui-button.ui-widget.ui-state-default.ui-corner-all.ui-button-text-only.ng-star-inserted")}

    get changedFirstNameInput() {return $$("input.ng-untouched.ng-pristine.ng-valid.ui-inputtext.ui-corner-all.ui-state-default.ui-widget.ui-state-filled")[0]};
    get changedLastNameInput() {return $$("input.ng-untouched.ng-pristine.ng-valid.ui-inputtext.ui-corner-all.ui-state-default.ui-widget.ui-state-filled")[1]};
    get changedNicknameInput() {return $$("input.ng-untouched.ng-pristine.ng-valid.ui-inputtext.ui-corner-all.ui-state-default.ui-widget.ui-state-filled")[2]};
    get githubUrlInput() {return $$("input.ng-untouched.ng-pristine.ng-valid.ui-inputtext.ui-corner-all.ui-state-default.ui-widget")[3]};
    get birthdayInput () {return $$("input.ui-inputtext.ui-widget.ui-state-default.ui-corner-all.ng-star-inserted")[1]};

    get uploadAvatarInput () {return $("input#uploadfile")};
    get currentPaswordInput () {return $("input[placeholder='password']")};
    get changedPasswordInput () {return $("input[placeholder='new password']")};
   // get currentPaswordInput () {return $$("input.ng-untouched.ng-pristine.ng-invalid.ui-inputtext.ui-corner-all.ui-state-default.ui-widget")[0]};
   // get changedPasswordInput () {return $("input.ui-inputtext.ui-corner-all.ui-state-default.ui-widget.ng-dirty.ng-touched.ng-invalid")};
   get changeButton () {return $("button[label='Change']")}; 
   //get changeButton() {return $$("button.ui-button.ui-widget.ui-state-default.ui-corner-all.ui-button-text-only.ng-star-inserted")[1]}
};

module.exports = ProfilePage;
