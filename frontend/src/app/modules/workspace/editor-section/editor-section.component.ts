import { Component, OnInit } from '@angular/core';
import { MenuItem } from 'primeng/api';

@Component({
    selector: 'app-editor-section',
    templateUrl: './editor-section.component.html',
    styleUrls: ['./editor-section.component.sass']
})
export class EditorSectionComponent implements OnInit {
    openedFiles: string[];
    editorOptions = { theme: 'vs-dark', language: 'javascript' };
    code: string = 'function x() {\nconsole.log("Hello world!");\n}';
    originalCode: string = 'function x() { // TODO }';
    options = {
        theme: 'vs-dark'
    };

    items: MenuItem[];
    activeItem: MenuItem;

    constructor() { }

    ngOnInit() {
        this.items = [
            { label: 'file1', icon: 'fa fa-fw fa-file' },
            { label: 'file2', icon: 'fa fa-fw fa-file' },
            { label: 'file3', icon: 'fa fa-fw fa-file' },
            { label: 'file4', icon: 'fa fa-fw fa-file' },
        ];

        this.activeItem = this.items[1];
        this.openedFiles = [
            `file 1****************`,
            `file 2****************`,
            `file 3***************`,
            `file 4****************`
        ]
    }

    closeItem(event, index) {
        this.items = this.items.filter((item, i) => i !== index);
        //delete this.openedFiles[index];
        this.code = this.openedFiles[index - 1];
        this.activeItem = this.items[index - 1];
        event.preventDefault();
    }
    onTabSelect(evt, index) {
        this.code = this.openedFiles[index];
        console.log(this.openedFiles);

    }

}
