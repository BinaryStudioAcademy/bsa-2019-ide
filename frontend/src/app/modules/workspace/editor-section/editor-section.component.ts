import { FileUpdateDTO } from './../../../models/DTO/File/fileUpdateDTO';
import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { MenuItem } from 'primeng/api';

@Component({
    selector: 'app-editor-section',
    templateUrl: './editor-section.component.html',
    styleUrls: ['./editor-section.component.sass']
})
export class EditorSectionComponent implements OnInit {
    
    @Output() filesSaveEvent = new EventEmitter<FileUpdateDTO[]>();
    @Output() fileCloseEvent = new EventEmitter<FileUpdateDTO>();
    
    @Input() openedFiles: FileUpdateDTO[];
    editorOptions = { theme: 'vs-dark', language: 'javascript' };
    code: string = 'function x() {\nconsole.log("Hello world!");\n}';
    originalCode: string = 'function x() { // TODO }';
    options = {
        theme: 'vs-dark'
    };

    @Input() items: MenuItem[];
    @Input() activeItem: MenuItem;

    constructor() { }

    ngOnInit() {
        // this.items = [
        //     { label: 'file1', icon: 'fa fa-fw fa-file' },
        //     { label: 'file2', icon: 'fa fa-fw fa-file' },
        //     { label: 'file3', icon: 'fa fa-fw fa-file' },
        // ];

        // this.activeItem = this.items[this.items.length - 1];
        // this.openedFiles = [
        //     { id: '1', folder: 'Project', name: 'Main.cs', content: 'using System;', updaterId: 0 },
        //     { id: '2', folder: 'Project', name: 'Startup.cs', content: 'using System;', updaterId: 0 },
        //     { id: '3', folder: 'Project', name: 'appsetting.json', content: '{ConnectionStrings: {}}', updaterId: 0 },
        // ]
    }

    public closeItem(event, index) {
        this.fileCloseEvent.emit(this.openedFiles[index]);

        this.saveFiles([this.openedFiles[index]]);
        //this.items = this.items.filter((item, i) => i !== index);
        //this.openedFiles = this.openedFiles.filter((item, i) => i !== index);
        //delete this.openedFiles[index];
        index = this.items.length === index ? index - 1 : index;
        this.code = this.openedFiles[index].content;
        this.activeItem = this.items[index];
        event.preventDefault();
    }
    public onTabSelect(evt, index) {
        this.code = this.openedFiles[index].content;
    }

    public saveFiles(files: FileUpdateDTO[]) {
        this.filesSaveEvent.emit(files);
    }

}
