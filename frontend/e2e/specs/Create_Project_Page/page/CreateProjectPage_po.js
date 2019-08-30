class ProjectPage {

    get addButton () {return $("button.ui-button-raised.ui-button.ui-widget.ui-state-default.ui-corner-all.ui-button-icon-only")};
    
    get projectNameInput () {return $("input[placeholder=name]")};
    get descriptionInput () {return $('textarea')};
   
    get dropdownListspan () {return $$("div.ui-dropdown-trigger.ui-state-default.ui-corner-right")};
    get publicProjectAccess () {return $("div.ng-trigger.ng-trigger-overlayAnimation.ng-tns-c24-46.ui-dropdown-panel.ui-widget.ui-widget-content.ui-corner-all.ui-shadow.ng-star-inserted")};
    
    get buildssavedInput () {return $("input[placeholder=builds]")};
    get buildsattemptsInput () {return $("input[placeholder='build attempts']")};
  
    get createButton () {return $("button.ui-button.ui-widget.ui-state-default.ui-corner-all.ui-button-text-only.ng-star-inserted")};
    get projectDetailData () {return $$("div.card p")};

};

module.exports = ProjectPage;
