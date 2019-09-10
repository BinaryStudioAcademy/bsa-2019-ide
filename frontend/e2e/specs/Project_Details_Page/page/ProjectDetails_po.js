class ProjectDetailsPage {

    get tabMyProjects () {return ("//li[contains(text(), 'My projects')]")};
    get tabFavouriteProjects () {return ("//li[contains(text(), 'Favourite projects')]")};
    get menuProjectCard () {return $("//h2[contains(text(), 'changedProject')]/../..//div[contains(@class, 'menu-icon')]/i")};
    get detailsButtonOnProjectCard () {return '//span[contains(text(), "Details")]/..'};
    get settingsButtonOnProjectCard () {return '//span[contains(text(), "Settings")]/..'};
    get saveProjectButton () {return $("//span[contains(text(), 'Save')]/..")};//$("button.ui-button.ui-widget.ui-state-default.ui-corner-all.ui-button-text-only.ng-star-inserted")};
    get navbarDetailsPage () {return "ul.ui-tabview-nav.ui-helper-reset.ui-helper-clearfix.ui-widget-header.ui-corner-all.ng-star-inserted li"};
    get deletebtn () {return $("button.ui-button.ui-widget.ui-state-default.ui-corner-all.ui-button-text-icon-left")[2]};
    get deletebtnconfirm () {return  $$("button.undefined.ui-button.ui-widget.ui-state-default.ui-corner-all.ui-button-text-icon-left.ng-star-inserted")[0]};
    get inputCollaboratorNickname () {return $$("input.ui-inputtext.ui-widget.ui-state-default.ui-corner-all.ui-autocomplete-input.ng-star-inserted")[1]};
    get listboxCollaborators () {return "ul.ui-autocomplete-items.ui-autocomplete-list.ui-widget-content.ui-widget.ui-corner-all.ui-helper-reset li"};
    get saveCollaboratorButton () {return $("button.save-btn.ui-button.ui-widget.ui-state-default.ui-corner-all.ui-button-text-icon-left.ng-star-inserted")};
    get deleteCollaboratorButton () {return $$("button.ui-button-raised.ui-button-danger.b-btn.ui-button.ui-widget.ui-state-default.ui-corner-all.ui-button-text-only.ng-star-inserted")};
    
};

module.exports = ProjectDetailsPage;
