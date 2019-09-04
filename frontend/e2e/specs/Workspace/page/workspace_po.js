class WorkspacePage {

    get firstFile () {return $('//html/body/app-root/div/app-workspace-root/div[2]/div[2]/div/div[1]/app-file-browser-section/div/p-tree/div/ul/p-treenode/li/ul/p-treenode[1]')};    get workspaceField () {return $('div.view-lines')};
    get saveBtn () {return $('button[label="Save"]')};
    get buildBtn () {return $('button[label="Build"]')};
    get runBtn () {return $('button[label="Run"]')};
    get editorBackground () {return $('i.pi')};
    
    get fileTabName () {return $('div.tab-text')};
    get editorField () {return $('/html/body/app-root/div/app-workspace-root/div[2]/div[2]/div/div[2]/app-editor-section/ngx-monaco-editor/div/div[1]/div/div/div[1]/div[2]/div[1]/div[4]/div[1]/span/span[1]')}

    get openSearchBtn () {return $('span.pi-search')};
    get openDetailsBtn () {return $('span.pi-info')};

    get fileSearchField () {return $('input.file-search-keyword')};
    get fileSearchBtn () {return $('button[label="Search"]')};

    get historyTab () {return $('a#ui-tabpanel-6-label')};
    get buildResultTab () {return $('a#ui-tabpanel-2-label')};

    get firstHistoryFile () {return $('a#ui-accordiontab-0')};
    get fileHistoryField () {return $('//*[@id="ui-accordiontab-0-content"]/div')};

};

module.exports = WorkspacePage;
