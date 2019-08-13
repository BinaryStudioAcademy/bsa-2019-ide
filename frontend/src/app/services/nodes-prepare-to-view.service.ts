
import { Injectable } from '@angular/core';
import { TreeNode } from 'primeng/components/common/api';
import { FileStructureDTO } from '../models/DTO/Workspace/fileStructureDTO';
import {TreeNodeType} from '../models/Enums/treeNodeType';

@Injectable({
    providedIn: 'root'
})
export class NodesPrepareToViewService {
    folderNode: TreeNode = {
        label: "NoNameFolder",
        data: "Folder",
        expandedIcon: "fa fa-folder-open",
        collapsedIcon: "fa fa-folder",
        children: []
    }

    fileNode: TreeNode = {
        label: "NoNameFile",
        data: "File",
        icon: "fa fa-file"
    }

    constructor() { }
    toPrimeTree(primeTree: TreeNode[], ps: FileStructureDTO[]) {
        for (const el of ps) {
            if (el.type == TreeNodeType.folder) {
                const newNode = this.makeFolderNode(el.name, el.id);
                if (!el.nestedFiles || el.nestedFiles.length === 0) {
                    primeTree.push(newNode);
                    continue;
                }
                newNode.children = this.toPrimeTree([], el.nestedFiles);
                primeTree.push(newNode);
            } else {
                const newNode = this.makeFileNode(el.name, el.id);
                primeTree.push(newNode);
            }
        }
        return primeTree;

    }

    getEmptyFolderNode() {
        return Object.assign({}, this.folderNode);
    }
    getEmptyFileNode() {
        return Object.assign({}, this.fileNode);
    }
    makeFolderNode(name: string, id: string) {
        const emptyFolder = this.getEmptyFolderNode();
        emptyFolder.label = name;
        emptyFolder.key = id;
        return emptyFolder;
    }
    makeFileNode(name: string, id: string) {
        const emptyFile = this.getEmptyFileNode();
        emptyFile.label = name;
        emptyFile.key = id;
        return emptyFile;
    }
}
