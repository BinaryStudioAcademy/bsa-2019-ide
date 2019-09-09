import { FileUpdateDTO } from './../../../models/DTO/File/fileUpdateDTO';
import { Component, OnInit, Output, EventEmitter, Input, ChangeDetectionStrategy, SimpleChanges, SimpleChange, AfterViewInit, ViewChild } from '@angular/core';
import { MenuItem, ConfirmationService } from 'primeng/api';
import { EditorSettingDTO } from '../../../models/DTO/Common/editorSettingDTO'
import editorTabsThemes from '../../../assets/editor-tabs-themes.json';
import { EventService } from 'src/app/services/event.service/event.service';
import { MonacoEditorComponent } from '@materia-ui/ngx-monaco-editor';
import { FileEditService } from 'src/app/services/file-edit.service/file-edit.service';

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
    @Output() tabClosedEvent = new EventEmitter<{ file: FileUpdateDTO, mustSave: boolean }>();

    private _monacoOptions: EditorSettingDTO;
    get monacoOptions(): EditorSettingDTO {
        return this._monacoOptions;
    }
    @Input()
    set monacoOptions(monacoOptions: EditorSettingDTO) {
        this._monacoOptions = monacoOptions;
        this.setEditorTabTheme();
    }

    public tabs = [] as MenuItem[];
    public activeItem: MenuItem;
    public openedFiles = [] as TabFileWrapper[];
    public language: string;
    @Input() canEdit: boolean;
    @Input()
    public isInputTerminalOpen:boolean;
    @ViewChild('monacoEditor', { static: false })
    private monacoEditor: MonacoEditorComponent;

    code = '/*\nFor start create new files via options in context menu on file browser item or select existing one \n\n\n\n\n<---- here :) \n*/';

    constructor(
        private eventService: EventService,
        private confirmationService: ConfirmationService,
        private fileEditService: FileEditService) { }

    ngAfterViewInit() {
        this.eventService.componentAfterInit("EditorSectionComponent");
    }
    ngOnInit() { }

    public getProjectColor(){
        if(this.isInputTerminalOpen){
            return "60vh";
        }
        else{
            return "90vh";
        }
    }

    confirm(index: number) {
        this.confirmationService.confirm({
            message: 'Save changes in file?',
            accept: () => {
                this.closedFileSave(this.openedFiles[index].innerFile);
                this.closeTabAction(index);
            },

            reject: () => {
                this.closedFileNotSave(this.openedFiles[index].innerFile);
                this.closeTabAction(index);
            }
        });
    }

    public onChange(ev) {
        if (!this.canEdit) {
            const touchedFile = this.getFileFromActiveItem();
                if (touchedFile.innerFile.content !== this.code) {

                    touchedFile.isChanged = true;
                    touchedFile.innerFile.content = this.code;
                }

        }
    }

    public changeFileState(fileId: string, state: boolean) {
        this.openedFiles.find(f => f.innerFile.id == fileId).innerFile.isOpen = state;
    }

    public changeReadOnlyState(readOnly: boolean = false) {
        if (this.monacoEditor !== undefined && this.monacoEditor.editor !== undefined) {
            this.monacoEditor.editor.updateOptions({readOnly: readOnly});
        } else {
            this.monacoOptions.readOnly = readOnly;
        }
    }

    public addActiveTab(tabName: string, icon: string, id: string) {
        this.tabs.push({ label: tabName, icon: icon, id: id });
        this.activeItem = this.tabs[this.tabs.length - 1];
    }

    public contains(fileId: string) {
        let contain: boolean = false;
        this.openedFiles.forEach(f => {
            if(f.innerFile.id === fileId)
                contain = true;
        })
        return contain;
    }

    public hightlineMatches(substring: string){

        var matches = this.monacoEditor.editor.getModel().findMatches(substring, false, false, false, "", true);
        const linesToDecorate = matches.map(match => {
            return {
                range: match.range,
                options: { inlineClassName: 'hightliter', stickiness: 2 }
            }
        })
        var decorations = this.monacoEditor.editor.deltaDecorations([], linesToDecorate);
    }

    public closeItem(event, index) {
        if(this.openedFiles[index].isChanged){
            this.confirm(index);
        }else{

            this.closeTabAction(index);
        }
        event.preventDefault();
    }

    public closeTabAction(index: number) {
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
    }

    public onTabSelect(evt, index) {
        console.log(this.openedFiles);
        this.activeItem = this.tabs[index];
        this.code = this.openedFiles[index].innerFile.content;
        this.language = this.openedFiles[index].innerFile.language;
        // console.log('change tab, update readonly to ' + this.openedFiles[index].innerFile.isOpen);
        this.monacoEditor.editor.updateOptions({readOnly: this.openedFiles[index].innerFile.isOpen});
        this.monacoOptions.language = this.language;
        this.monacoEditor.editor.updateOptions({readOnly: this.openedFiles[index].innerFile.isOpen});
    }

    public closedFileSave(file: FileUpdateDTO) {
        this.tabClosedEvent.emit({ file, mustSave: true });
    }

    public updateFile(file: FileUpdateDTO) {
        this.openedFiles.forEach(f => {
            if(f.innerFile.id === file.id)
                f.innerFile.content = file.content;
                // console.log('change file state' + file.id + '  ' + file.isOpen);
                f.innerFile.isOpen = false;
        })
        if(this.activeItem.id === file.id){
            this.code = file.content;
        }
    }

    public closedFileNotSave(file: FileUpdateDTO) {
        this.tabClosedEvent.emit({ file, mustSave: false });
    }

    public AddFileToOpened(file: FileUpdateDTO) {
        const fileWrapper: TabFileWrapper = { isChanged: false, innerFile: file }
        this.openedFiles.push(fileWrapper);
        this.monacoOptions.language = file.language;
        // console.log('show new file ' + file.id + ' with state '+ file.isOpen);
        this.changeReadOnlyState(file.isOpen);
    }

    public getFileFromActiveItem(): TabFileWrapper {
        return this.openedFiles.find(x => x.innerFile.id === this.activeItem.id);
    }

    public confirmSaving(fileIds: string[]) {
        const files = this.openedFiles.filter(f => fileIds.indexOf(f.innerFile.id) != -1);

        files.forEach(x => x.isChanged = false);

    }

    public anyFileChanged(): boolean {
        return this.openedFiles.some(x => x.isChanged);
    }

    private setEditorTabTheme(): void {
        const element = document.querySelector('body');
        let tabsThemeName: string;

        switch (this.monacoOptions.theme) {
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
