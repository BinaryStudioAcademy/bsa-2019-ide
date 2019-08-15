import { ContextMenu, MenuItem } from 'primeng/primeng';
import { FileBrowserService } from './../../../services/file-browser.service';
import { HttpClientWrapperService } from './../../../services/http-client-wrapper.service';
import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { TreeNode } from 'primeng/components/common/treenode';
import { TreeNodeType } from "../../../models/Enums/treeNodeType"
import { ActivatedRoute } from '@angular/router';
import { FileService } from 'src/app/services/file.service/file.service';
// import { userInfo } from 'os';
import { ProjectCreateDTO } from 'src/app/models/DTO/Project/projectCreateDTO';
import { ProjectStructureDTO } from 'src/app/models/DTO/Workspace/projectStructureDTO';

@Component({
    selector: 'app-file-browser-section',
    templateUrl: './file-browser-section.component.html',
    styleUrls: ['./file-browser-section.component.sass']
})
export class FileBrowserSectionComponent implements OnInit {

    @Output() fileSelected = new EventEmitter<string>();
    items: MenuItem[];
    public files: TreeNode[];
    public selectedItem: TreeNode;
    public projectId: number;

    private fileCounter: number = 1;
    private folderCounter: number = 1;
    // private userInformation = userInfo;

    constructor(private fileBService: FileBrowserService,
        private activateRoute: ActivatedRoute,
        private fileService: FileService) {
        this.projectId = activateRoute.snapshot.params['id'];
        // console.log(this.userInformation);
    }

    contextMenuSaveButton: MenuItem[];


    ngOnInit() {

        this.files = [];
        this.fileBService.getPrimeTree(this.projectId).then(x => {
            console.log("Prime tree");
            console.log(x);
            this.files = x;
        });
        // this.files = this.hardcodedFolderHierarchy.default.data;
        this.items = [
            { label: 'create file', icon: 'fa fa-file', command: (event) => this.createFile(this.selectedItem) },
            { label: 'create folder', icon: 'fa fa-folder', command: (event) => this.createFolder(this.selectedItem) },
            { label: 'delete', icon: 'fa fa-remove', command: (event) => this.delete(this.selectedItem) },
            { label: 'rename', icon: 'fa fa-refresh', command: (event) => this.rename(this.selectedItem) }
        ];
    }


    private createFile(node: TreeNode) {
        var newItem   = {
            name: `New File ${this.fileCounter++}`,
            content: "initial content",
            projectId: this.projectId,
            folder : "",
            //Here should be real creator id
            creatorId: 1
        }
        if (node.type === TreeNodeType.file.toString()) {
            newItem.folder = node.parent.label;
            console.log("File was selected");
        } else {
            newItem.folder = node.label;
            console.log("Folder was selected");
        }

        this.fileService.addFile(newItem).subscribe(response =>{
                debugger;
                console.log("File creating response:");
                console.log(response);
            }, response => {
                debugger;
                console.log("Project structure updated:");
                console.log(response);
            }
        );

        var treeNode = {
            ...newItem,
            label: `New File ${this.fileCounter}`,
            icon: "fa fa-file-word-o"
        }
        if (node.type === TreeNodeType.file + "") {
            node.parent.children.push(treeNode as TreeNode);
        } else {
            node.children.push(treeNode as TreeNode);
        }
        this.fileBService.updateProjectStructure(this.projectId, this.files[0] as ProjectStructureDTO)
            .subscribe(response =>{
                debugger;
                console.log("Project structure updated:");
                console.log(response);
            }, response => {
                debugger;
                console.log("Project structure updated:");
                console.log(response);
            }
        );
        
        console.log(node);
    }

    private createFolder(node: TreeNode) {
        var treeNode = {
            projectId: this.projectId,
            label: `New Folder ${this.folderCounter++}`,
            expandedIcon: "fa fa-folder-open",
            collapsedIcon: "fa fa-folder",
            children: []
        }
        if (node.type === TreeNodeType.file.toString()) {
            node.parent.children.push(treeNode as TreeNode);
        } else {
            node.children.push(treeNode as TreeNode);
        }
        this.fileBService.updateProjectStructure(this.projectId, this.files[0] as ProjectStructureDTO)
            .subscribe(response =>{
                debugger;
                console.log("Project structure updated:");
                console.log(response);
            }, response => {
                debugger;
                console.log("Project structure updated:");
                console.log(response);
            }
        );
        
        console.log(node);
    }

    private rename(node: TreeNode) {
        //TODO add rename implementation
        console.log("rename");
    }

    private delete(node: TreeNode) {
        //TODO add delete implementation
        console.log("delete");
    }

    unselectFile() {
        this.selectedItem = null;
    }

    nodeSelect(evt: any): void {
        const nodeSelected: TreeNode = evt.node;
        if (nodeSelected.data !== 'Folder') {
            this.fileSelected.emit(nodeSelected.key);
        }
    }
}
