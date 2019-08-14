import { NodesPrepareToViewService } from './nodes-prepare-to-view.service';
import { HttpClientWrapperService } from './http-client-wrapper.service';
import { Injectable } from '@angular/core';
import { ProjectStructureDTO } from '../models/DTO/Workspace/projectStructureDTO';


@Injectable({
    providedIn: 'root'
})
export class FileBrowserService {

    private address:string = 'projectstructure/';

    constructor(private requests: HttpClientWrapperService, private convert: NodesPrepareToViewService) { }

    public async getProjectStructure(id: number): Promise<ProjectStructureDTO> {
        const psJson = await this.requests
            .getRequest(this.address + id)
            .toPromise();
        const ps = psJson.body as ProjectStructureDTO;
        console.log(ps);
        return ps;

    }
    public async getPrimeTree(id: number) {
        const projStruct = await this.getProjectStructure(id);
        return this.convert.toPrimeTree([], projStruct.nestedFiles);

    }

}
