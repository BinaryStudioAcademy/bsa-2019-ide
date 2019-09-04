class DashboardPage {

    get menuTabs () {return $$("div.menu li")};
   // get addButton () {return $('button.ui-button-raised.ui-button.ui-widget.ui-state-default.ui-corner-all.ui-button-text-icon-left')};
    get starProjectCard () {return $$("div.star i")};
   // get menuProjectCard () {return $$("div.menu-icon i")};
    //get detailsProject () {return $$("a.ui-menuitem-link.ui-corner-all.ng-star-inserted")[2]};
   // get settingsProject () {return $$("a.ui-menuitem-link.ui-corner-all.ng-star-inserted")[3]};
   // get titleProjectCard () {return $$("h2.title-ellipsis")};
   // get authorProject () {return $$("div.ui-card-subtitle.ng-star-inserted")};
    //get createddateProjectCard () {return $$("div.ui-card-content p")};

    get navbarDetailsPage () {return "ul.ui-tabview-nav.ui-helper-reset.ui-helper-clearfix.ui-widget-header.ui-corner-all.ng-star-inserted li"};
    get projectTabsDashbpord () {return "div.menu li"};
    get projectCardTitle () {return $$("h2.title-ellipsis")};
  //  get inputCollaboratorSearch () {return  $("input.ng-tns-c2-3.ui-inputtext.ui-widget.ui-state-default.ui-corner-all.ui-autocomplete-input.ng-star-inserted")};
   
   // get inputCollaboratorNickname () {return $("input.ng-tns-c2-3.ui-inputtext.ui-widget.ui-state-default.ui-corner-all.ui-autocomplete-input.ng-star-inserted")};
   // get inputCollaboratorNickname () {return $$("input.ui-inputtext.ui-widget.ui-state-default.ui-corner-all.ui-autocomplete-input.ng-star-inserted")[1]};
    get listboxProjects () {return "ul.ui-autocomplete-items.ui-autocomplete-list.ui-widget-content.ui-widget.ui-corner-all.ui-helper-reset li"};
   /* get saveCollaboratorButton () {return $("button.save-btn.ui-button.ui-widget.ui-state-default.ui-corner-all.ui-button-text-icon-left.ng-star-inserted")};
   
    get dropdownListspan () {return "div.ui-dropdown-trigger.ui-state-default.ui-corner-right"};
    get addedCollaboratorNick () {return $$("div.collaborator-item div")[0]};
    get addedCollabotorRights () {return $$("div.collaborator-item div")[1]}*/
   
   
    //get homeButton () {return $$("a.ui-menuitem-link.ui-corner-all.ng-star-inserted")[0]}
    //get dashboardButton () {return $$("a.ui-menuitem-link.ui-corner-all.ng-star-inserted")[1]};
   // get profileButton () {return $("button.ng-tns-c3-12.ui-button.ui-widget.ui-state-default.ui-corner-left.ui-button-text-icon-left")};
    get searchInput () {return $$("input.ui-inputtext.ui-widget.ui-state-default.ui-corner-all.ui-autocomplete-input.ng-star-inserted")[0]};
    
};

module.exports = DashboardPage;
