import { FileBrowserService } from './../../../services/file-browser.service';
import { HttpClientWrapperService } from './../../../services/http-client-wrapper.service';
import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { TreeNode } from 'primeng/components/common/treenode';


@Component({
    selector: 'app-file-browser-section',
    templateUrl: './file-browser-section.component.html',
    styleUrls: ['./file-browser-section.component.sass']
})
export class FileBrowserSectionComponent implements OnInit {

    @Output() fileSelected = new EventEmitter<string>();

    files: TreeNode[];
    constructor(private fileBService: FileBrowserService) {
    }

    ngOnInit() {
        this.files = [];
        this.fileBService.getPrimeTree().then(x => this.files = x);
    }

    nodeSelect(evt: any): void {
        console.log(evt.node);
        const nodeSelected: TreeNode = evt.node;
        if (nodeSelected.data !== 'Folder') {
            this.fileSelected.emit(nodeSelected.key);
        }
    }

}
