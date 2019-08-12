import { HttpClientWrapperService } from './http-client-wrapper.service';
import { Injectable } from '@angular/core';
import { TreeNode } from 'primeng/components/common/treenode';
import { JsonPipe } from '@angular/common';

export interface ProjectStructure {
    Id: string;
    NestedFiles: PSFileNode[];
}
export interface PSFileNode {
    Id: string;
    Type: PSNodeTypeEnum;
    Name: string;
    Details: string;
    NestedFiles: PSFileNode[];
}
export enum PSNodeTypeEnum {
    Folder = 0,
    File = 1
}


@Injectable({
    providedIn: 'root'
})
export class FileBrowserService {
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

    constructor(private requests: HttpClientWrapperService) { }

    async getProjectStructure(): Promise<ProjectStructure> {
        const psJson = await this.requests
            .getRequest('https://my-json-server.typicode.com/rshul/hello-world/ProjectStructure')
            .toPromise();
        let ps = psJson.body as ProjectStructure[];
        let psOne =  ps.filter(x => x.Id == "1")[0];

        return psOne;

    }
    async getPrimeTree() {
        const projStruct = await this.getProjectStructure();
        return this.toPrimeTree([], projStruct.NestedFiles);

    }

    toPrimeTree(primeTree: TreeNode[], ps: PSFileNode[]) {
        for (let i = 0; i < ps.length; i++) {
            const element = ps[i];
            if (element.Type == 0) {
                let newNode = this.makeFolderNode(element.Name, element.Id);
                if (!element.NestedFiles || element.NestedFiles.length == 0) {

                    primeTree.push(newNode);
                    continue;
                }
                newNode.children = this.toPrimeTree([], element.NestedFiles);
                primeTree.push(newNode);
            } else {
                let newNode = this.makeFileNode(element.Name, element.Id);
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
