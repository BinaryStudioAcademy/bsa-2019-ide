import { ContextMenu, MenuItem } from 'primeng/primeng';
import { FileBrowserService } from './../../../services/file-browser.service';
import { HttpClientWrapperService } from './../../../services/http-client-wrapper.service';
import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { TreeNode } from 'primeng/components/common/treenode';
import{ TreeNodeType} from "../../../models/Enums/treeNodeType"
import { ActivatedRoute} from '@angular/router';



@Component({
    selector: 'app-file-browser-section',
    templateUrl: './file-browser-section.component.html',
    styleUrls: ['./file-browser-section.component.sass']
})
export class FileBrowserSectionComponent implements OnInit {

    @Output() fileSelected = new EventEmitter<string>();
    items: MenuItem[];
    files: TreeNode[];
    selectedFile2: TreeNode;
    public projectId: number;
  
  
    constructor(private fileBService: FileBrowserService,
        private activateRoute: ActivatedRoute) {
        this.projectId = activateRoute.snapshot.params['id'];
    }

    contextMenuSaveButton: MenuItem[];


    ngOnInit() {
        
        this.files = [];
        this.fileBService.getPrimeTree(this.projectId).then(x => this.files = x);
        this.items = [
            {label: 'create file', icon: 'fa fa-file', command: (event) => this.create(1,this.selectedFile2)},
            {label: 'create folder', icon: 'fa fa-folder', command: (event) => this.create(0,this.selectedFile2)},
            {label: 'delete', icon: 'fa fa-remove', command: (event) => this.delete(this.selectedFile2)},
            {label: 'rename', icon: 'fa fa-refresh', command: (event) => this.rename(this.selectedFile2)}
        ];
    }

    private create(type: TreeNodeType, node: TreeNode)
    {
        //TODO add create implementation
        console.log(node);
    }

    private rename(node: TreeNode)
    {
        //TODO add rename implementation
        console.log("rename");
    }

    private delete(node: TreeNode)
    {
        //TODO add delete implementation
        console.log("delete");
    }

    unselectFile() {
        this.selectedFile2 = null;
    }

    nodeSelect(evt: any): void {
        console.log(evt.node);
        const nodeSelected: TreeNode = evt.node;
        if (nodeSelected.data !== 'Folder') {
            this.fileSelected.emit(nodeSelected.key);
        }
    }

}
