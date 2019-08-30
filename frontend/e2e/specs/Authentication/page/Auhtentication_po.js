class LoginPage {

    get loginbtn () {return $("button.login-btn.ui-button.ui-widget.ui-state-default.ui-corner-all.ui-button-text-only")};
    get signupbtn () {return $("button.signup-btn.ui-button.ui-widget.ui-state-default.ui-corner-all.ui-button-text-only")};
    get firstNameInput () {return $("input#float-firstName-input")};
    get lastNameInput () {return $("input#float-lastName-input")};
    get nicknameInput () {return $("input#float-nickName-input")}
    get emailInput () {return $('input#float-email-input')};
    get passwordInput () {return $('input[type=password]')};
    get createButton () {return $('button.auth-btn.ng-star-inserted')};
    get recoveryPassword () {return $("p.auth-recover.ng-star-inserted")};
    get googleButton () {return $('button.google-btn')};
    get logOutButton () {return $("button.ui-splitbutton-menubutton.ui-button.ui-widget.ui-state-default.ui-corner-right.ui-button-icon-only")};
   
};

module.exports = LoginPage;

