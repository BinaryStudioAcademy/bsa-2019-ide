
import { Injectable } from '@angular/core';
import { TreeNode } from 'primeng/components/common/api';
import { PSFileNode, PSNodeTypeEnum } from '../models/ProjectStructure/ProjectStructure';

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
    toPrimeTree(primeTree: TreeNode[], ps: PSFileNode[]) {
        for (const el of ps) {
            if (el.Type == PSNodeTypeEnum.Folder) {
                const newNode = this.makeFolderNode(el.Name, el.Id);
                if (!el.NestedFiles || el.NestedFiles.length === 0) {
                    primeTree.push(newNode);
                    continue;
                }
                newNode.children = this.toPrimeTree([], el.NestedFiles);
                primeTree.push(newNode);
            } else {
                const newNode = this.makeFileNode(el.Name, el.Id);
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
