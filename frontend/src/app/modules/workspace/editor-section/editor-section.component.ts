import { Component, OnInit } from '@angular/core';

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

    constructor() { }

    ngOnInit() {
    }

}
