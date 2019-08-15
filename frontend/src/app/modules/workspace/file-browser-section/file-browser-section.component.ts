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
import { FileStructureDTO } from 'src/app/models/DTO/Workspace/fileStructureDTO';

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
                this.files.push(this.projectStructureFormaterService.toTreeView(response.body));
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
                this.updateProjectStructure();
                this.toast.success("File successfully created", "Success Message", { tapToDismiss: true })
            },
            (error) => {
                this.toast.error("File wasn't created", "Error Message", { tapToDismiss: true })
                console.log(error);
            }
        );
    }


    private getFileStructure(files : TreeNode[]) : FileStructureDTO[] {
        let fileStructure : FileStructureDTO[] = [];
        if (!files || files.length === 0)
            return fileStructure;

        files.forEach(element => {
            let file : FileStructureDTO = {
                id : element.key,
                details : element.data || "",
                name : element.label,
                type : element.type === TreeNodeType.folder.toString() ?
                    TreeNodeType.folder : TreeNodeType.file,
                nestedFiles : []
            };
            file.nestedFiles = this.getFileStructure(element.children);
            fileStructure.push(file);
        });

        return fileStructure;
    }

    private updateProjectStructure(){
        
        let fileStructure : FileStructureDTO[];
        fileStructure = this.getFileStructure(this.files);
        let projectStructured : ProjectStructureDTO = {
            id : this.projectId.toString(),
            nestedFiles : fileStructure
        };

        this.projectStructureService.updateProjectStructure(this.projectId, projectStructured).subscribe(
            (response) => {

            },
            (error) => {
                console.log(error);
            }
        );
    }

    private createFolder(node: TreeNode) {
        let newFolderNode = this.projectStructureFormaterService.makeFolderNode(`New Folder ${++this.folderCounter}`, this.folderCounter.toString());
        newFolderNode.type = TreeNodeType.folder.toString();
        newFolderNode.parent = node;
        this.appendNewNode(node, newFolderNode);
        this.toast.success("Folder successfully created", "Success Message", { tapToDismiss: true })
        this.updateProjectStructure();        
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
            this.fileSelected.emit(nodeSelected.key);
        }
    }
}
