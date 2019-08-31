import { FileUpdateDTO } from './../../../models/DTO/File/fileUpdateDTO';
import { Component, OnInit, Output, EventEmitter, Input, ChangeDetectionStrategy, SimpleChanges, SimpleChange } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { EditorSettingDTO } from '../../../models/DTO/Common/editorSettingDTO'
import editorTabsThemes from '../../../assets/editor-tabs-themes.json';

export interface TabFileWrapper {
    isChanged: boolean;
    innerFile: FileUpdateDTO;
}

@Component({
    selector: 'app-editor-section',
    templateUrl: './editor-section.component.html',
    styleUrls: ['./editor-section.component.sass']
})
export class EditorSectionComponent implements OnInit {
    @Output() filesSaveEvent = new EventEmitter<FileUpdateDTO[]>();

    private _monacoOptions: EditorSettingDTO; 
    get monacoOptions(): EditorSettingDTO {
        return this._monacoOptions;
    }  
    @Input()
    set monacoOptions(monacoOptions: EditorSettingDTO) {
        this._monacoOptions = monacoOptions;
        this.setEditorTabTheme();  
    }
    
    // FOR REFACTOR
    // think about agregaiting of TabFileWrapper(openedFiles) with MenuItem(tabs)
    public tabs = [] as MenuItem[]; // maybe reneme on "tab"
    public activeItem: MenuItem;
    public openedFiles = [] as TabFileWrapper[];
    public language:string;
    @Input() canEdit: boolean;

    code = '/*\nFor start create new files via options in context menu on file browser item or select existing one \n\n\n\n\n<---- here :) \n*/';

    constructor() { }

    ngOnInit() {
              
    }

    onChange(ev) {
        if (!this.canEdit) {
            const touchedFile = this.getFileFromActiveItem(this.activeItem);
            if (!this.monacoOptions.readOnly) {
                touchedFile.isChanged = true;
                touchedFile.innerFile.content = this.code;
            }
            this.monacoOptions.language = this.language;
        }
    }

    public closeItem(event, index) {
        this.saveFiles([this.openedFiles[index].innerFile]);
        this.tabs = this.tabs.filter((item, i) => i !== index);
        this.openedFiles = this.openedFiles.filter((item, i) => i !== index);

        // if 1st tab closed
        if (this.openedFiles.length === 0) {
            event.preventDefault();
            this.code = '';
            return;
        }

        index = this.tabs.length === index ? index - 1 : index;
        this.code = this.openedFiles[index].innerFile.content;
        this.activeItem = this.tabs[index];
        event.preventDefault();
    }

    public onTabSelect(evt, index) {
        this.activeItem = this.tabs[index];
        this.code = this.openedFiles[index].innerFile.content;
        this.language = this.openedFiles[index].innerFile.language;
        
    }

    public saveFiles(files: FileUpdateDTO[]) {
        this.filesSaveEvent.emit(files);
    }

    public AddFileToOpened(file: FileUpdateDTO) {
        const fileWrapper: TabFileWrapper = { isChanged: false, innerFile: file }
        this.openedFiles.push(fileWrapper);
        this.monacoOptions.language = file.language;
    }

    public getFileFromActiveItem(item: MenuItem): TabFileWrapper {
        return this.openedFiles.find(x => x.innerFile.id === item.id);
    }

    public confirmSaving(fileIds: string[]) {
        fileIds.map(x => this.openedFiles.filter(f => f.innerFile.id == x)[0]).forEach(x => x.isChanged = false);
    }

    public anyFileChanged(): boolean {
        return this.openedFiles.some(x => x.isChanged);
    }

    private setEditorTabTheme(): void {
        const element = document.querySelector('body');
        let tabsThemeName: string;

        switch(this.monacoOptions.theme) { 
            case 'vs': { 
                tabsThemeName = 'light';
                break; 
            } 
            case 'vs-dark':
            case 'hc-black': { 
                tabsThemeName = 'dark';
                break; 
            } 
            default: { 
                tabsThemeName = 'light';
                break; 
            }    
        } 
        
        const tabTheme = editorTabsThemes.find(tt => tt.name === tabsThemeName);

        for (const key in tabTheme.colors) {
            element.style.setProperty(key, tabTheme.colors[key]);
        }   
    }
}
