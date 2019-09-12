class DashboardPage {

    get menuTabs () {return $$("div.menu li")};
    get starProjectCard () {return $('//h2[contains(text(), "changedProject")]/../following-sibling::div/div[1]/i')};
    get tabMyProjects () {return $("//li[contains(text(), 'My projects')]")};
    get tabFavouriteProjects () {return $("//li[contains(text(), 'Favourite projects')]")};
    get tabAssignedProject () {return $("//li[contains(text(), 'Assigned projects')]")};

    get navbarDetailsPage () {return $$("ul.ui-tabview-nav.ui-helper-reset.ui-helper-clearfix.ui-widget-header.ui-corner-all.ng-star-inserted li")};
    get projectTabsDashboard () {return $$("div.menu li")};
    get projectCardTitle () {return $$("h2.title-ellipsis")};
    
    get firstProjectCard () {return $("//div[@class='cards-area']/div[1]/app-project-card")};
    get listboxProjects () {return $$("ul.ui-autocomplete-items.ui-autocomplete-list.ui-widget-content.ui-widget.ui-corner-all.ui-helper-reset li")};
    get searchInput () {return $$("input.ui-inputtext.ui-widget.ui-state-default.ui-corner-all.ui-autocomplete-input.ng-star-inserted")[0]};
    
};

module.exports = DashboardPage;
