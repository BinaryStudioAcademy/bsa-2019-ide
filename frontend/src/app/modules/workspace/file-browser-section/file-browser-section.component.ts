import { FileBrowserService } from './../../../services/file-browser.service';
import { HttpClientWrapperService } from './../../../services/http-client-wrapper.service';
import { Component, OnInit } from '@angular/core';
import { TreeNode } from 'primeng/components/common/treenode';
import { MenuItem } from 'primeng/api';
import{ TreeNodeType} from "../../../models/Enums/treeNodeType"

@Component({
    selector: 'app-file-browser-section',
    templateUrl: './file-browser-section.component.html',
    styleUrls: ['./file-browser-section.component.sass']
})
export class FileBrowserSectionComponent implements OnInit {


    files: TreeNode[];
    selectedFile2: TreeNode;
    items: MenuItem[];

    constructor(private fileBService: FileBrowserService) {
    }

    contextMenuSaveButton: MenuItem[];


    ngOnInit() {
        this.files = [];
        this.fileBService.getPrimeTree().then(x => this.files = x);
        this.items = [
            {label: 'create file', icon: 'fa fa-file', command: (event) => this.create(1,this.selectedFile2)},
            {label: 'create folder', icon: 'fa fa-folder', command: (event) => this.create(0,this.selectedFile2)},
            {label: 'delete', icon: 'fa fa-remove', command: (event) => this.delete()},
            {label: 'rename', icon: 'fa fa-refresh', command: (event) => this.rename()}
        ];
    }

    private create(type: TreeNodeType, node: TreeNode)
    {
        console.log(node);
    }

    private rename()
    {
        console.log("rename");
    }

    private delete()
    {
        console.log("delete");
    }

    unselectFile() {
        this.selectedFile2 = null;
    }

    nodeSelect(evt: any): void {
        console.log(evt.node);
    }

}
