import { NodesPrepareToViewService } from './nodes-prepare-to-view.service';
import { HttpClientWrapperService } from './http-client-wrapper.service';
import { Injectable } from '@angular/core';
import { ProjectStructureDTO } from '../models/DTO/Workspace/projectStructureDTO';


@Injectable({
    providedIn: 'root'
})
export class FileBrowserService {

    constructor(private requests: HttpClientWrapperService, private convert: NodesPrepareToViewService) { }

    public async getProjectStructure(): Promise<ProjectStructureDTO> {
        const psJson = await this.requests
            .getRequest('https://localhost:44352/ProjectStructure/5d5287797404f941bcfc9e2f')
            .toPromise();
        const ps = psJson.body as ProjectStructureDTO;
        console.log(ps);
        return ps;

    }
    public async getPrimeTree() {
        const projStruct = await this.getProjectStructure();
        return this.convert.toPrimeTree([], projStruct.nestedFiles);

    }

}
