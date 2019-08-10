import { Component, OnInit } from '@angular/core';
import {MenuItem} from 'primeng/api';

@Component({
    selector: 'app-editor-section',
    templateUrl: './editor-section.component.html',
    styleUrls: ['./editor-section.component.sass']
})
export class EditorSectionComponent implements OnInit {

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
            {label: 'file1', icon: 'fa fa-fw fa-file'},
            {label: 'file2', icon: 'fa fa-fw fa-file'},
            {label: 'file3', icon: 'fa fa-fw fa-file'},
            {label: 'file4', icon: 'fa fa-fw fa-file'},
        ];

        this.activeItem = this.items[0];
    }

}
