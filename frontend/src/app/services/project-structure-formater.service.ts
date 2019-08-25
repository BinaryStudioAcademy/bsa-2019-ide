
import { Injectable } from '@angular/core';
import { TreeNode } from 'primeng/components/common/api';
import { FileStructureDTO } from '../models/DTO/Workspace/fileStructureDTO';
import {TreeNodeType} from '../models/Enums/treeNodeType';
import { ProjectStructureDTO } from '../models/DTO/Workspace/projectStructureDTO';

@Injectable({
    providedIn: 'root'
})
export class ProjectStructureFormaterService {
    folderNode: TreeNode = {
        label: "NoNameFolder",
        expandedIcon: "fa fa-folder-open",
        collapsedIcon: "fa fa-folder",
    }

    fileNode: TreeNode = {
        label: "NoNameFile",
        icon: "fa fa-file"
    }

    private itemId : number = 0;
    
    constructor() { }
    
    public toTreeView(projectStructure: ProjectStructureDTO) : TreeNode {
        let root : TreeNode;
        root = this.toTreeNode(projectStructure.nestedFiles[0]);
        return root;
    }

    public toTreeNode(fileStructure: FileStructureDTO, parent: TreeNode = null) : TreeNode {
        let root : TreeNode;
        if (fileStructure.type == TreeNodeType.folder){
            root = this.makeFolderNode(fileStructure.name, fileStructure.id);
            root.type = TreeNodeType.folder.toString();
            if (fileStructure.nestedFiles && fileStructure.nestedFiles.length !== 0) {
                if (!root.children)
                    root.children = [];
                for (let item of fileStructure.nestedFiles){
                    root.children.push(this.toTreeNode(item, root));
                }
            }
        } else {
            root = this.makeFileNode(fileStructure.name, fileStructure.id);
            root.type = TreeNodeType.file.toString();
        }
        root.data = fileStructure.details;
        root.parent = parent;
        return root;
    }

    public getEmptyFolderNode(): TreeNode {
        return Object.assign({}, this.folderNode);
    }

    public getEmptyFileNode(): TreeNode {
        return Object.assign({}, this.fileNode);
    }
    
    public makeFolderNode(name: string, id: string): TreeNode {
        const emptyFolder = this.getEmptyFolderNode();
        emptyFolder.label = name;
        emptyFolder.key = id;
        return emptyFolder;
    }
    public makeFileNode(name: string, id: string): TreeNode {
        const emptyFile = this.getEmptyFileNode();
        emptyFile.label = name;
        emptyFile.key = id;
        return emptyFile;
    }

    newGuid() {
        return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function(c) {
            const r = Math.random() * 16 | 0, v = c === 'x' ? r : ( r & 0x3 | 0x8 );
            return v.toString(16);
        });
    }
}
