const LoginPage = require('../page/Auhtentication_po');
const page = new LoginPage();

class LoginActions {

    clickloginbtn(){
        page.loginbtn.waitForDisplayed(10000);
        page.loginbtn.click();
    }
    clickSignupbtn() {
        page.signupbtn.waitForDisplayed(2000);
        page.signupbtn.click();
    }
    clickRecoveryPassword(){
        page.recoveryPassword.waitForDisplayed(2000);
        page.recoveryPassword.click();
    }
    enterFirstName(value) {
        page.firstNameInput.waitForDisplayed(2000);
        page.firstNameInput.setValue(value);
    }
    enterLastName(value) {
        page.lastNameInput.waitForDisplayed(2000);
        page.lastNameInput.setValue(value);
    }
    enterNickname(value) {
        page.nicknameInput.waitForDisplayed(2000);
        page.nicknameInput.setValue(value);
    }
    enterEmail(value) {
        page.emailInput.waitForDisplayed(2000);
        page.emailInput.setValue(value);
    }

    enterPassword(value) {
        page.passwordInput.waitForDisplayed(2000);
        page.passwordInput.setValue(value);
    }

    clickCreateButton() {
       // page.logInButton.waitForDisplayed(2000);
        page.createButton.click();
    }
    clickLogOutButton() {
        page.logOutButton.waitForDisplayed(3000);
        page.logOutButton.click();

    }
    waitFormContainer(){
        page.formContainer.waitForDisplayed(10000);
    }
    registerNewAccount(name, surname, nickname, email, password) {

        this.clickSignupbtn();
        this.waitFormContainer();
        this.enterFirstName(name);
        this.enterLastName(surname);
        this.enterNickname(nickname);
        this.enterEmail(email);
        this.enterPassword(password);
        this.clickCreateButton();
    }
    enterDataForRegistration(name, surname, nickname, email, password) {

        this.clickSignupbtn();
        this.waitFormContainer();
        this.enterFirstName(name);
        this.enterLastName(surname);
        this.enterNickname(nickname);
        this.enterEmail(email);
        this.enterPassword(password);
        
    }
    recoveryPassword(email) {

        this.clickloginbtn();       
        this.clickRecoveryPassword();
        this.enterEmail(email);
        this.clickCreateButton();
    }
    enterDataForLogin(email, password){

        this.clickloginbtn();
        this.waitFormContainer();
        this.enterEmail(email);
        this.enterPassword(password);
    }
    waitEnabledCreateButton(){

        page.createButton.waitForEnabled(5000, true);
    }

}

module.exports = LoginActions;
