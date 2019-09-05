class ProjectPage {

    get addButton () {return $("button.ui-button-raised.ui-button.ui-widget.ui-state-default.ui-corner-all.ui-button-icon-only")};
    
    get projectNameInput () {return $("input[placeholder=name]")};
    get descriptionInput () {return $('textarea')};
    get contentOfProjectDetailPage () {return $("div.ui-tabview.ui-widget.ui-widget-content.ui-corner-all.ui-tabview-left")};
   
    get buildssavedInput () {return $("input[placeholder=builds]")};
    get buildsattemptsInput () {return $("input[placeholder='build attempts']")};
  
    get createButton () {return $("button.ui-button.ui-widget.ui-state-default.ui-corner-all.ui-button-text-only.ng-star-inserted")};
    get projectDetailData () {return $$("div.card p")};
    get formOfProjectCreation () {return $("div.ui-dialog-content.ui-widget-content");} 
   

};

module.exports = ProjectPage;
