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
import { FileUpdateDTO } from 'src/app/models/DTO/File/fileUpdateDTO';
import { delay, throwIfEmpty } from 'rxjs/operators';
import { ProjectInfoDTO } from 'src/app/models/DTO/Project/projectInfoDTO';
import { FileRenameDTO } from '../../../models/DTO/File/fileRenameDTO';
import {ProgressBarModule} from 'primeng/progressbar';
import { saveAs } from 'file-saver';
import { Observable } from 'rxjs';

@Component({
    selector: 'app-file-browser-section',
    templateUrl: './file-browser-section.component.html',
    styleUrls: ['./file-browser-section.component.sass']
})
export class FileBrowserSectionComponent implements OnInit {
    @Input() project: ProjectInfoDTO;
    @Input() showSearchField:boolean;
    @Output() fileSelected = new EventEmitter<string>();
    @Output() renameFile = new EventEmitter<FileRenameDTO>();
    @Input() events: Observable<void>;
    
    items: MenuItem[];
    public files: TreeNode[];
    public selectedItem: TreeNode;
    public projectId: number;
    public expandFolder = false;
    
    private lastSelectedElement: any;
    private extensions: Extension[];
    private defaultExtension: string;
    
    private lastActionFileCreated: boolean = false;
    private lastActionFolderCreated: boolean = false;
    private lastCreatedNode: TreeNode;
    private eventsSubscription: any;
    private currentInputPos: 0;
    private fileNameRegex: RegExp;

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

        this.fileNameRegex = /^[A-Z0-9.]+$/gi
        this.extensions = filesExtensions;
        this.items = [
            { label: 'create file', icon: 'fa fa-file', command: () => this.createFile(this.selectedItem),  },
            { label: 'create folder', icon: 'fa fa-folder', command: () => this.createFolder(this.selectedItem) },
            { label: 'delete', icon: 'fa fa-remove', command: () => this.delete(this.selectedItem) },
            { label: 'info', icon: 'fa fa-info', command: () => this.openInfoWindow(this.selectedItem)},
            { label: 'rename', icon: 'fa fa-refresh', command: () => this.rename(this.selectedItem)},
            { label: 'download', icon: 'pi pi-download', command: (event) => this.download(this.selectedItem) }
        ];

        this.eventsSubscription = this.events.subscribe(() => this.expand())
    }

    ngOnDestroy() {
        this.eventsSubscription.unsubscribe()
    }
    
    private expand() {
        this.expandFolder = !this.expandFolder;
        this.files.forEach( node => {
            this.expandRecursive(node, this.expandFolder);
        } );
    }
    
    private downloadFile(node: TreeNode){
        this.fileService.getFileById(node.key).subscribe(
            (response) => {
                const fileType = "text/plain;charset=utf-8";
                const fileName = node.label;
                const fileContent = response.body.content;
                const blob = new Blob([fileContent], { type: fileType });
                saveAs(blob, fileName);                
            },
            (error) => {
                console.log(error);
                this.toast.error('Something went wrong(. Couldn\'t download file','Error Message', {tapToDismiss: true});
            }
        )
    }

    private downloadFolder(node: TreeNode){
        if (!node.children || node.children.length == 0)
        {
            this.toast.info('Folder is empty', 'Info Message', {tapToDismiss: true});            
            return;
        }
        this.projectService.exportFolder(this.project.id, node.key).subscribe(
        (result) => {    
            console.log(result);
            const blob = new Blob([result.body], {
                type: 'application/zip'
            });

            saveAs(blob, `${node.label}.zip`);
        },
        (error) => {
            console.log(error);
            this.toast.error('Error: can\'t download folder', 'Error Message', {tapToDismiss: true});
        });
    }
    
    private download(node: TreeNode){
        console.log(this.files);
        if (node.type == TreeNodeType.file.toString()){            
            this.downloadFile(node);
        }
        else {
            this.downloadFolder(node);
        }
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
        this.selectedItem = newNode;   
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

    public inputKeyDown(event: any) {
        const pos = event.target.selectionStart;
        switch(event.keyCode) {
            case 37:
                if (pos > 0) {
                    (this.lastSelectedElement as HTMLInputElement).setSelectionRange(pos, pos);
                    event.stopPropagation();
                }
                break;
            case 39:
                (this.lastSelectedElement as HTMLInputElement).setSelectionRange(pos, pos);
                event.stopPropagation();
                break;
        }
    }

    private createFile(node: TreeNode) {
        if(this.lastActionFileCreated || this.lastActionFolderCreated) {
            return;
        }
        if (this.defaultExtension === undefined) {
            const lang = this.project.language.toString();
            this.defaultExtension = defaultExtensions.find(x => x.language === lang).extension;
        }
        this.lastActionFileCreated = true;
        this.lastCreatedNode = this.projectStructureFormaterService.makeFileNode(`file${this.defaultExtension}`, '1')
        this.lastCreatedNode.type = TreeNodeType.file.toString();
        this.lastCreatedNode.parent = node;
        this.lastCreatedNode.icon = this.getExtensionImage(this.defaultExtension);
        this.appendNewNode(node, this.lastCreatedNode);

        setTimeout(() => {
            var element = document.getElementsByClassName('ui-state-highlight').item(0).children.item(0).children.item(0) as HTMLInputElement;
            this.lastSelectedElement = element;
            this.rename(this.selectedItem);
        }, 1);
    }

    private createFolder(node: TreeNode) {
        if(this.lastActionFileCreated || this.lastActionFolderCreated) {
            return;
        }
        this.lastActionFolderCreated = true;
        this.lastCreatedNode = this.projectStructureFormaterService.makeFolderNode(`New folder`, '1')
        this.lastCreatedNode.type = TreeNodeType.folder.toString();
        this.lastCreatedNode.parent = node;
        this.appendNewNode(node, this.lastCreatedNode);

        setTimeout(() => {
            var element = document.getElementsByClassName('ui-state-highlight').item(0).children.item(0).children.item(0) as HTMLInputElement;
            this.lastSelectedElement = element;
            this.rename(this.selectedItem);
        }, 1);
    }

    private create(node: TreeNode) {
        const label = this.lastSelectedElement.value.trim();

        if (this.lastActionFolderCreated) {
            if ((label === `New folder` && node.parent.children.filter(n => n.label === label).length > 1)
                || (label !== `New folder` && node.parent.children.some(n => n.label === label))) {
                this.lastSelectedElement.focus();
                this.toast.error(`File with name \"${label}\" already exist!`, "Error Message", { tapToDismiss: true });
                return;
            }
            this.lastActionFolderCreated = false;
            
            this.lastCreatedNode.label = label;
            this.toast.success(`Folder \"${label}\" successfully created`, "Success Message", { tapToDismiss: true })
            this.updateProjectStructure();    
            node.selectable = true;
            this.lastSelectedElement.disabled = true;
            this.lastSelectedElement = null;
            this.lastCreatedNode = null;
        } else {
            if ((label === `file${this.defaultExtension}` && node.parent.children.filter(n => n.label === label).length > 1)
                || (label !== `file${this.defaultExtension}` && node.parent.children.some(n => n.label === label))) {
                this.lastSelectedElement.focus();
                this.toast.error(`File with name \"${label}\" already exist!`, "Error Message", { tapToDismiss: true });
                return;
            }
            this.lastCreatedNode.label = label;
            this.lastActionFileCreated = false;
            var newFile : FileCreateDTO  = {
                name: label,
                content: "// Start code here:\n",
                projectId: this.projectId,
                folder : this.getFolderName(node)
            }
            
            this.fileService.addFile(newFile).subscribe(
                (response) => {
                    this.lastCreatedNode.key = response.body.id;
                    this.updateProjectStructure(); 
                    this.toast.success(`File \"${label}\" successfully created`, "Success Message", { tapToDismiss: true })
                    node.selectable = true;
                    this.lastSelectedElement.disabled = true;
                },
                (error) => {
                    this.toast.error("File wasn't created", "Error Message", { tapToDismiss: true })
                    console.log(error);
                },
                () => {
                    this.lastSelectedElement = null;
                    this.lastCreatedNode = null;
                }
            );
        }
    }

    public focusout(node: TreeNode){
        if (this.lastSelectedElement.disabled) {
            return;
        }

        if (this.lastActionFileCreated || this.lastActionFolderCreated) {
            this.create(node);
            return;
        }
        const newName = this.lastSelectedElement.value.trim();
        if (!this.fileNameRegex.test(newName)) {
            this.toast.error("Name should contain only latin letters, numbers and dots!", "Error Message", { tapToDismiss: true });
            this.lastSelectedElement.focus();
            return;
        }
        node.selectable = true;
        this.lastSelectedElement.disabled = true;
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
        const fileRename: FileRenameDTO = { name: node.label, id: node.key };
        this.fileService.updateFileName(fileRename).subscribe((response) => {
            this.toast.success(`Successfully renamed to "${newName}"`, "Success Message", { tapToDismiss: true })
            this.updateProjectStructure();
            this.renameFile.emit(fileRename);
        })
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
