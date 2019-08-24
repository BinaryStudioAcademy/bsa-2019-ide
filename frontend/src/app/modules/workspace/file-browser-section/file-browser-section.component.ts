import { MenuItem, TreeNode } from 'primeng/primeng';
import { FileBrowserService } from './../../../services/file-browser.service';
import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { TreeNodeType } from "../../../models/Enums/treeNodeType"
import { ActivatedRoute } from '@angular/router';
import { FileService } from 'src/app/services/file.service/file.service';
import { ProjectStructureDTO } from 'src/app/models/DTO/Workspace/projectStructureDTO';
import { ToastrService } from 'ngx-toastr';
import { FileCreateDTO } from 'src/app/models/DTO/File/fileCreateDTO';
import { ProjectStructureFormaterService } from 'src/app/services/project-structure-formater.service';
import { FileStructureDTO } from 'src/app/models/DTO/Workspace/fileStructureDTO';
import { HotkeyService } from 'src/app/services/hotkey.service/hotkey.service';
import { Extension } from '../model/extension';
import { ProjectService } from 'src/app/services/project.service/project.service';
import filesExtensions from '../../../assets/file-extensions.json';
import defaultExtensions from '../../../assets/newFilesDefaultExtensions.json';
import { ProjectInfoDTO } from 'src/app/models/DTO/Project/projectInfoDTO';
import {ProgressBarModule} from 'primeng/progressbar';

@Component({
    selector: 'app-file-browser-section',
    templateUrl: './file-browser-section.component.html',
    styleUrls: ['./file-browser-section.component.sass']
})
export class FileBrowserSectionComponent implements OnInit {
    @Input()
    project: ProjectInfoDTO;
    @Input()
    showSearchField:boolean;
    @Output()
    fileSelected = new EventEmitter<string>();
    items: MenuItem[];
    public files: TreeNode[];
    public selectedItem: TreeNode;
    public projectId: number;
    public expandFolder = false;

    private fileCounter: number = 0;
    private folderCounter: number = 0;
    private lastSelectedElement: any;
    private extensions: Extension[];
    private defaultExtension: string;

    constructor(private projectStructureService: FileBrowserService,
                private projectStructureFormaterService: ProjectStructureFormaterService,
                activateRoute: ActivatedRoute,
                private fileService: FileService,
                private toast: ToastrService,
                private hotkeys: HotkeyService,
                private fileBrowserService: FileBrowserService,
                private projectService: ProjectService) {
        this.hotkeys.addShortcut({keys: 'shift.e'})
        .subscribe(()=>{
            this.expand();
        });
        this.projectId = activateRoute.snapshot.params['id'];
    }

    contextMenuSaveButton: MenuItem[];
    
    ngOnInit() {
        this.projectStructureService.getProjectStructureById(this.projectId).subscribe(
            (response) => {
                this.files = [];
                this.files.push(this.projectStructureFormaterService.toTreeView(response.body));
                this.setTreeIcons(this.files[0]);
                this.files[0].expanded = true;
            },
            (error) => {
                console.log(error);
            }
        );

        this.extensions = filesExtensions;
        this.items = [
            { label: 'create file', icon: 'fa fa-file', command: () => this.createFile(this.selectedItem),  },
            { label: 'create folder', icon: 'fa fa-folder', command: () => this.createFolder(this.selectedItem) },
            { label: 'delete', icon: 'fa fa-remove', command: () => this.delete(this.selectedItem) },
            { label: 'info', icon: 'fa fa-info', command: () => this.openInfoWindow(this.selectedItem)},
            { label: 'rename', icon: 'fa fa-refresh', command: () => this.rename(this.selectedItem)},
            { label: 'download', icon: 'pi pi-download', command: (event) => console.log(event) }//this.download(this.selectedItem), disabled : true }
        ];
    }

    private download(node: TreeNode){
        console.log(`${node.label} should be downloaded`);
    }

    private openInfoWindow(node: TreeNode)
    {
        this.fileBrowserService.OpenModalWindow(node,this.projectId.toString());
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
            parent.parent.children.sort(this.nodeCompare);
        } else {
            if (!parent.children)
                parent.children = [];
            parent.children.push(newNode);
            parent.children.sort(this.nodeCompare);
        }
    }

    private createFile(node: TreeNode) {
        if (this.defaultExtension === undefined) {
            const lang = this.project.language.toString();
            this.defaultExtension = defaultExtensions.find(x => x.language === lang).extension;
        }
        var newFile : FileCreateDTO  = {
            name: `New File ${++this.fileCounter}`,
            content: "// Start code here:\n",
            projectId: this.projectId,
            folder : ""
        }
        newFile.folder = this.getFolderName(node);

        this.fileService.addFile(newFile).subscribe(
            (response) => {
                let newFileNode = this.projectStructureFormaterService.makeFileNode(`New File ${this.fileCounter}${this.defaultExtension}`, response.body.id);
                newFileNode.type = TreeNodeType.file.toString();
                newFileNode.parent = node;
                newFileNode.icon = this.getExtensionImage(this.defaultExtension);
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
                nestedFiles : [],
                size: 0
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

    public focusout(node: TreeNode){
        if (this.lastSelectedElement.disabled) {
            return;
        }
        node.selectable = true;
        this.lastSelectedElement.disabled = true;
        const newName = this.lastSelectedElement.value.trim();
        if (node.label === newName) {
            return;
        }
        if (newName === '')
        {
            this.toast.error("Name couldn't be empty!", "Error Message", { tapToDismiss: true });
            this.lastSelectedElement.value = node.label;
            return;
        }
        if (node.parent.children.some(n => n.label === newName))
        {
            this.toast.error(`Name "${newName}" already exist!`, "Error Message", { tapToDismiss: true });
            this.lastSelectedElement.value = node.label;
            return;
        }
        node.label = newName;
        this.toast.success(`Successfully renamed to "${newName}"`, "Success Message", { tapToDismiss: true })
        this.updateProjectStructure();
    }

    public setIcon(node: TreeNode) {
        const label = this.lastSelectedElement.value.trim();
        this.setLocalIcon(node, label);
    }

    private setTreeIcons(node: TreeNode) {
        if (node.type === TreeNodeType.file.toString()) {
            this.setLocalIcon(node, node.label);
        } else if (node.type === TreeNodeType.folder.toString()) {
            if(node.children !== undefined) {
                node.children.forEach(node => this.setTreeIcons(node));
            }
        }
    }

    private setLocalIcon(node: TreeNode, label: string) {
        const lastIndex = label.lastIndexOf('.');
        if (lastIndex > 0) {
            const exc = label.substring(lastIndex);
            node.icon = this.getExtensionImage(exc);
        } else {
            this.getExtensionImage('default');
        }
    }

    private getExtensionImage(exc: string) {
        const extension = this.extensions.find(ex => ex.extension === exc);
        if(extension !== undefined) {
            return extension.extensionInfo.imageClass;
        } else {
            return this.extensions[0].extensionInfo.imageClass;
        }
    }

    private rename(node: TreeNode) {
        if (!node.parent)
        {
            this.toast.error("Couldn't rename root folder", "Error Message", { tapToDismiss: true });
            return;
        }        
        this.lastSelectedElement.disabled = false;
        node.selectable = false;
        this.unselectNode();
        this.lastSelectedElement.focus();
    }

    private delete(node: TreeNode){
        if (!node.parent){
            this.toast.error("Couldn't delete root directory", "Error Message", { tapToDismiss: true })
            return;
        }
        this.deleteFiles(node);
        node.parent.children = node.parent.children.filter(n => node.key !== n.key);
        this.updateProjectStructure();
    }

    private deleteFiles(node : TreeNode){
        if (node.type === TreeNodeType.file.toString()){
            this.fileService.deleteFile(node.key).subscribe(
                () => {
                },
                (error) => {
                    console.log(error);
                }
            );;
        }
        if (!node.children || node.children.length === 0)
            return;
        for (let child of node.children){
            this.deleteFiles(child)
        }
    }

    public expand()
    {
        this.expandFolder=!this.expandFolder;
        this.files.forEach( node => {
            this.expandRecursive(node, this.expandFolder);
        } );
    }

    private expandRecursive(node:TreeNode, isExpand:boolean){
        node.expanded = isExpand;
        if(node.children){
            node.children.forEach( childNode => {
                this.expandRecursive(childNode, isExpand);
            } );
        }
    }

    unselectNode() {
        this.selectedItem = null;
    }

    private cacheElement($event: any){
        this.lastSelectedElement = $event.originalEvent.srcElement;
    }

    nodeContextMenuSelect($event: any){
        this.cacheElement($event);
    }

    nodeSelect(evt: any) {
        this.cacheElement(evt);
        const nodeSelected: TreeNode = evt.node;
        if (nodeSelected.type === TreeNodeType.file.toString()) {
            this.fileSelected.emit(nodeSelected.key);
        }
    }

    nodeCompare(a : TreeNode, b : TreeNode) : number {
        if (+a.type < (+b.type)){
            return -1;
        } else if (+a.type === (+b.type)) {
            if (a.label < b.label) {
                return -1;
            } else if (a.label > b.label) {
                return 1;
            }
            else {
                return 0;
            }
        }
        return 1;
    }
}
