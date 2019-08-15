import { MenuItem, TreeNode } from 'primeng/primeng';
import { FileBrowserService } from './../../../services/file-browser.service';
import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { TreeNodeType } from "../../../models/Enums/treeNodeType"
import { ActivatedRoute } from '@angular/router';
import { FileService } from 'src/app/services/file.service/file.service';
import { ProjectStructureDTO } from 'src/app/models/DTO/Workspace/projectStructureDTO';
import { ToastrService } from 'ngx-toastr';
import { FileCreateDTO } from 'src/app/models/DTO/File/fileCreateDTO';
import { ProjectStructureFormaterService } from 'src/app/services/project-structure-formater.service';

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

    private fileCounter: number = 0;
    private folderCounter: number = 0;
    

    constructor(private projectStructureService: FileBrowserService,
                private projectStructureFormaterService: ProjectStructureFormaterService,
                private activateRoute: ActivatedRoute,
                private fileService: FileService,
                private toast: ToastrService) {
        this.projectId = activateRoute.snapshot.params['id'];
    }

    contextMenuSaveButton: MenuItem[];


    ngOnInit() {
        this.projectStructureService.getProjectStructureById(this.projectId).subscribe(
            (response) => {
                this.files = [];
                console.log("Formating to tree view:");
                this.files.push(this.projectStructureFormaterService.toTreeView(response.body));
                console.log(this.files);
            },
            (error) => {
                console.log(error);
            }
        );
        
        this.items = [
            { label: 'create file', icon: 'fa fa-file', command: (event) => this.createFile(this.selectedItem) },
            { label: 'create folder', icon: 'fa fa-folder', command: (event) => this.createFolder(this.selectedItem) },
            { label: 'delete', icon: 'fa fa-remove', command: (event) => this.delete(this.selectedItem) },
            { label: 'rename', icon: 'fa fa-refresh', command: (event) => this.rename(this.selectedItem) }
        ];
    }

    private getFolderName(node: TreeNode): string{
        if (node.type === TreeNodeType.file.toString()) {
            return node.parent.label;
        } else {
            return node.label;
        }
    }

    private appendNewNode(parent: TreeNode, newNode: TreeNode): void{
        if (parent.type === TreeNodeType.file.toString()) {
            if (!parent.parent.children)
                parent.parent.children = [];
            parent.parent.children.push(newNode);
        } else {
            if (!parent.children)
                parent.children = [];
            parent.children.push(newNode);
        }
    }

    private createFile(node: TreeNode) {
        var newFile : FileCreateDTO  = {
            name: `New File ${++this.fileCounter}`,
            content: "// Start code here:\n",
            projectId: this.projectId,
            folder : ""
        }
        newFile.folder = this.getFolderName(node);

        this.fileService.addFile(newFile).subscribe(
            (response) =>{
                let newFileNode = this.projectStructureFormaterService.makeFileNode(`New File ${this.fileCounter}`, response.body.id);
                newFileNode.type = TreeNodeType.file.toString();
                newFileNode.parent = node;
                this.appendNewNode(node, newFileNode);
                this.toast.success("File successfully created", "Success Message", { tapToDismiss: true })
            },
            (error) => {
                this.toast.error("File wasn't created", "Error Message", { tapToDismiss: true })
                console.log(error);
            }
        );
       
        // this.projectStructureService.updateProjectStructure(this.projectId, this.files[0] as ProjectStructureDTO)
        //     .subscribe(response =>{
        //         debugger;
        //         console.log("Project structure updated:");
        //         console.log(response);
        //     }, response => {
        //         debugger;
        //         console.log("Project structure updated:");
        //         console.log(response);
        //     }
        // );
        
        console.log(node);
    }

    private createFolder(node: TreeNode) {
        debugger;
        let newFolderNode = this.projectStructureFormaterService.makeFolderNode(`New Folder ${++this.folderCounter}`, this.folderCounter.toString());
        newFolderNode.type = TreeNodeType.folder.toString();
        // newFolderNode.parent = node;
        newFolderNode.children = null;
        this.appendNewNode(node, newFolderNode);
        this.toast.success("Folder successfully created", "Success Message", { tapToDismiss: true })


        // this.projectStructureService.updateProjectStructure(this.projectId, this.files[0] as ProjectStructureDTO)
        //     .subscribe(response =>{
        //         debugger;
        //         console.log("Project structure updated:");
        //         console.log(response);
        //     }, response => {
        //         debugger;
        //         console.log("Project structure updated:");
        //         console.log(response);
        //     }
        // );
        
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
        if (nodeSelected.type === TreeNodeType.file.toString()) {
            debugger;
            this.fileSelected.emit(nodeSelected.key);
        }
    }
}
