import { FileBrowserService } from './../../../services/file-browser.service';
import { HttpClientWrapperService } from './../../../services/http-client-wrapper.service';
import { Component, OnInit } from '@angular/core';
import { TreeNode } from 'primeng/components/common/treenode';

@Component({
    selector: 'app-file-browser-section',
    templateUrl: './file-browser-section.component.html',
    styleUrls: ['./file-browser-section.component.sass']
})
export class FileBrowserSectionComponent implements OnInit {


    files: TreeNode[];

    constructor(private fbs: FileBrowserService) {
    }

    ngOnInit() {
        this.files = [];
        this.files = JSON.parse(this.jsonStr).data as TreeNode[];
        // let testTree = Object.assign({}, this.folderNode);
        // testTree.children = Array.from(new Array(5), (item, index) => { let f = Object.assign({}, this.fileNode); f.label = f.label.concat((index + 1).toString()); return f });
        // this.files = [testTree];
        // let temp = Object.assign({}, testTree);
        // temp.children = [Object.assign({}, testTree), Object.assign({}, testTree)];
        // this.files.push(temp);
        // this.files.push(Object.assign({}, temp));
    }

    nodeSelect(evt: any): void {
        console.log(evt.node);
        //this.h.setHeader('Content-type', 'application/json');
        this.fbs.getPrimeTree().then(x => this.files = x);


    }


    jsonStr = `
 {
    "data": 
    [
        {
            "label": "Documents",
            "data": "Documents Folder",
            "expandedIcon": "fa fa-folder-open",
            "collapsedIcon": "fa fa-folder",
            "children": [{
                    "label": "Work",
                    "data": "Work Folder",
                    "expandedIcon": "fa fa-folder-open",
                    "collapsedIcon": "fa fa-folder",
                    "children": [{"label": "Expenses.doc", "icon": "fa fa-file-word-o", "data": "Expenses Document"}, {"label": "Resume.doc", "icon": "fa fa-file-word-o", "data": "Resume Document"}]
                },
                {
                    "label": "Home",
                    "data": "Home Folder",
                    "expandedIcon": "fa fa-folder-open",
                    "collapsedIcon": "fa fa-folder",
                    "children": [{"label": "Invoices.txt", "icon": "fa fa-file-word-o", "data": "Invoices for this month"}]
                }]
        },
        {
            "label": "Pictures",
            "data": "Pictures Folder",
            "expandedIcon": "fa fa-folder-open",
            "collapsedIcon": "fa fa-folder",
            "children": [
                {"label": "barcelona.jpg", "icon": "fa fa-file-image-o", "data": "Barcelona Photo"},
                {"label": "logo.jpg", "icon": "fa fa-file-image-o", "data": "PrimeFaces Logo"},
                {"label": "primeui.png", "icon": "fa fa-file-image-o", "data": "PrimeUI Logo"}]
        },
        {
            "label": "Movies",
            "data": "Movies Folder",
            "expandedIcon": "fa fa-folder-open",
            "collapsedIcon": "fa fa-folder",
            "children": [{
                    "label": "Al Pacino",
                    "data": "Pacino Movies",
                    "children": [{"label": "Scarface", "icon": "fa fa-file-video-o", "data": "Scarface Movie"}, {"label": "Serpico", "icon": "fa fa-file-video-o", "data": "Serpico Movie"}]
                },
                {
                    "label": "Robert De Niro",
                    "data": "De Niro Movies",
                    "children": [{"label": "Goodfellas", "icon": "fa fa-file-video-o", "data": "Goodfellas Movie"}, {"label": "Untouchables", "icon": "fa fa-file-video-o", "data": "Untouchables Movie"}]
                }]
        }
    ]
}
 `

}
