import { FileUpdateDTO } from './../../../models/DTO/File/fileUpdateDTO';
import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { MenuItem } from 'primeng/api';

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
    
    // FOR REFACTOR
    // think about agregaiting of TabFileWrapper(openedFiles) with MenuItem(tabs)
    public tabs = [] as MenuItem[]; // maybe reneme on "tab"
    public activeItem: MenuItem;
    public openedFiles = [] as TabFileWrapper[];
    
    editorOptions = { theme: 'vs-dark', language: 'typescript' };
    code = '/*\nFor start create new files via options in context menu on file browser item or select existing one \n\n\n\n\n<---- here :) \n*/';
    options = { theme: 'vs-dark' }; 

    constructor() { }

    ngOnInit() {  }

    onChange(ev) {
        const touchedFile = this.getFileFromActiveItem(this.activeItem);
        touchedFile.isChanged = true;
        touchedFile.innerFile.content = this.code;
    }

    public closeItem(event, index) {
        if (this.openedFiles[index].isChanged) {
            this.saveFiles([this.openedFiles[index].innerFile]);
        }
        this.tabs = this.tabs.filter((item, i) => i !== index);
        this.openedFiles = this.openedFiles.filter((item, i) => i !== index);

        // if 1st tab closed
        if(this.openedFiles.length === 0) {
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
    }

    public saveFiles(files: FileUpdateDTO[]) {
        this.filesSaveEvent.emit(files);
    }

    public AddFileToOpened(file: FileUpdateDTO) {
        const fileWrapper: TabFileWrapper = { isChanged: false, innerFile: file }
        this.openedFiles.push(fileWrapper);
    }

    public getFileFromActiveItem(item: MenuItem): TabFileWrapper {
        return this.openedFiles.find(x => x.innerFile.id === item.id);
    }

    public confirmSaving(fileIds: string[]) {
        fileIds.map(x => this.openedFiles.filter(f => f.innerFile.id == x)[0]).forEach(x => x.isChanged = false);
    }

    anyFileChanged(): boolean {
        return this.openedFiles.some(x => x.isChanged);
    }
}
