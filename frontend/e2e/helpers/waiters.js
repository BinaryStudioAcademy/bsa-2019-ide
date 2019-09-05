class CustomWaits {
    forSpinner() {
        const spinner = $('div.ui-progress-spinner');
        spinner.waitForDisplayed(10000);
        spinner.waitForDisplayed(10000, true);

    }

    forNotificationToDisappear() {
        const notification = $('div.toast-message');
        notification.waitForDisplayed(10000);
        notification.waitForDisplayed(10000, true);
        console.log('hello');
    }
    contentOfProjectDetailPage(){
        $("ul.ui-tabview-nav.ui-helper-reset.ui-helper-clearfix.ui-widget-header.ui-corner-all.ng-star-inserted").waitForDisplayed(10000);
    }
    ofDashboardMenu(){
        const menu = $("div.menu");
        menu.waitForDisplayed(10000);
    }
    cardsArea(){
        const cards =  $("div.cards-area");
        cards.waitForDisplayed(10000);
    }
    forPanelOfProjectEditorSettings(){
        const panel = $("div.ui-tabview.ui-widget.ui-widget-content.ui-corner-all.ui-tabview-top");
        panel.waitForDisplayed(5000);
    }

}

module.exports = CustomWaits;