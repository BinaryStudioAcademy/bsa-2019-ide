class WorkspacePage {

    get firstFile () {return $('//html/body/app-root/div/app-workspace-root/div[2]/div[2]/div/div[1]/app-file-browser-section/div/p-tree/div/ul/p-treenode/li/ul/p-treenode[1]')};    
    get workspaceField () {return $('div.view-lines')};
    get saveBtn () {return $('button[label="Save"]')};
    get buildBtn () {return $('button[label="Build"]')};
    get runBtn () {return $('button[label="Run"]')};
    get editorBackground () {return $('i.pi')};
    get workspaceCannotEditMessage() {return $('div.message')};
    
    get fileTabName () {return $('div.tab-text')};
    get firtsWordInEditor () {return $('/html/body/app-root/div/app-workspace-root/div[2]/div[2]/div/div[3]/app-editor-section/ngx-monaco-editor/div/div[1]/div/div/div[1]/div[2]/div[1]/div[4]/div/span/span[1]')};
    get bigFouthString () {return $('/html/body/app-root/div/app-workspace-root/div[2]/div[2]/div/div[3]/app-editor-section/ngx-monaco-editor/div/div[1]/div/div/div[1]/div[2]/div[1]/div[4]/div[4]/span/span')}; //just a costil'... might be better way, i think

    get openSearchBtn () {return $('span.pi-search')};
    get openDetailsBtn () {return $('/html/body/app-root/div/app-workspace-root/div[2]/div[1]/button[2]/span[1]')};

    get fileSearchField () {return $('input.file-search-keyword')};
    get fileSearchBtn () {return $('button[label="Search"]')};

    get historyTab () {return $('/html/body/app-root/div/app-project-root/app-project-details/div[2]/p-tabview/div/ul/li[7]/a')};
    get buildResultTab () {return $('/html/body/app-root/div/app-project-root/app-project-details/div[2]/p-tabview/div/ul/li[3]/a')};

    get firstHistoryFile () {return $('a#ui-accordiontab-0')};
    get firstHistoryRecord () {return $('/html/body/app-root/div/app-project-root/app-project-details/div[2]/p-tabview/div/div/p-tabpanel[7]/div/app-history-changes/div[2]/div/p-accordion/div/p-accordiontab[1]/div[2]/div/div/div')};

};

module.exports = WorkspacePage;
