import { NodesPrepareToViewService } from './nodes-prepare-to-view.service';
import { HttpClientWrapperService } from './http-client-wrapper.service';
import { Injectable } from '@angular/core';
import { TreeNode } from 'primeng/components/common/treenode';
import { JsonPipe } from '@angular/common';
import { ProjectStructure } from '../models/ProjectStructure/ProjectStructure';


@Injectable({
    providedIn: 'root'
})
export class FileBrowserService {

    constructor(private requests: HttpClientWrapperService, private convert: NodesPrepareToViewService) { }

    async getProjectStructure(): Promise<ProjectStructure> {
        const psJson = await this.requests
            .getRequest('https://my-json-server.typicode.com/rshul/hello-world/ProjectStructure')
            .toPromise();
        let ps = psJson.body as ProjectStructure[];
        let psOne = ps.find(x => x.Id == "1");
        return psOne;

    }
    async getPrimeTree() {
        const projStruct = await this.getProjectStructure();
        return this.convert.toPrimeTree([], projStruct.NestedFiles);

    }

}
