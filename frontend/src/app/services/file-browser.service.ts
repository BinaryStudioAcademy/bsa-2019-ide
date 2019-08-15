import { NodesPrepareToViewService } from './nodes-prepare-to-view.service';
import { HttpClientWrapperService } from './http-client-wrapper.service';
import { Injectable } from '@angular/core';
import { ProjectStructureDTO } from '../models/DTO/Workspace/projectStructureDTO';
import { HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable({
    providedIn: 'root'
})
export class FileBrowserService {

    private address = 'projectstructure/';

    constructor(private httpClient: HttpClientWrapperService,
                private convert: NodesPrepareToViewService)
    { }

    public getProjectStructureById(id: number): Observable<HttpResponse<ProjectStructureDTO>> {
        return this.httpClient.getRequest(this.address + `${id}`);
    }

    public updateProjectStructure(id: number, projectStructure : ProjectStructureDTO) : Observable<HttpResponse<any>>{
        debugger;
        return this.httpClient.postRequest(this.address + `${id}`, projectStructure);
    }

    // Obsolete
    public async getProjectStructure(id: number): Promise<ProjectStructureDTO> {
        const psJson = await this.httpClient
            .getRequest(this.address + id)
            .toPromise();
        const ps = psJson.body as ProjectStructureDTO;
        return ps;
    }



    public async getPrimeTree(id: number) {
        const projStruct = await this.getProjectStructure(id);
        return this.convert.toPrimeTree([], projStruct.nestedFiles);
    }
}
