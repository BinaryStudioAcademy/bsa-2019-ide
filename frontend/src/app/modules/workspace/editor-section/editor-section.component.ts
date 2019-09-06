import { FileUpdateDTO } from './../../../models/DTO/File/fileUpdateDTO';
import { Component, OnInit, Output, EventEmitter, Input, ChangeDetectionStrategy, SimpleChanges, SimpleChange, AfterViewInit, ViewChild } from '@angular/core';
import { MenuItem, ConfirmationService } from 'primeng/api';
import { EditorSettingDTO } from '../../../models/DTO/Common/editorSettingDTO'
import editorTabsThemes from '../../../assets/editor-tabs-themes.json';
import { EventService } from 'src/app/services/event.service/event.service';
import { MonacoEditorComponent } from '@materia-ui/ngx-monaco-editor';

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
    @ViewChild('monacoEditor', { static: false })
    private monacoEditor: MonacoEditorComponent;

    code = '/*\nFor start create new files via options in context menu on file browser item or select existing one \n\n\n\n\n<---- here :) \n*/';

    constructor(
        private eventService: EventService,
        private confirmationService: ConfirmationService, ) { }

    ngAfterViewInit() {
        this.eventService.componentAfterInit("EditorSectionComponent");
    }
    ngOnInit() {

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

            if (!this.monacoOptions.readOnly) {

                if (touchedFile.innerFile.content !== this.code) {

                    touchedFile.isChanged = true;
                    touchedFile.innerFile.content = this.code;
                }

            }

        }
    }

    public hightlineMatches(substring: string) {
        console.log(substring);

        var matches = this.monacoEditor.editor.getModel().findMatches(substring, false, false, false, "", true);
        const linesToDecorate = matches.map(match => {
            return {
                range: match.range,
                options: { inlineClassName: 'hightliter', stickiness: 2 }
            }
        })
        console.log(linesToDecorate);
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
        this.monacoOptions.language = this.language;
    }

    public closedFileSave(file: FileUpdateDTO) {
        this.tabClosedEvent.emit({ file, mustSave: true });
    }

    public closedFileNotSave(file: FileUpdateDTO) {
        this.tabClosedEvent.emit({ file, mustSave: false });
    }

    public AddFileToOpened(file: FileUpdateDTO) {
        const fileWrapper: TabFileWrapper = { isChanged: false, innerFile: file }
        this.openedFiles.push(fileWrapper);
        this.monacoOptions.language = file.language;
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
