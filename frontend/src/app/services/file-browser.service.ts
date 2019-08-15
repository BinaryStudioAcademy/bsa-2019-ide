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

    constructor(private httpClient: HttpClientWrapperService)
    { }

    public getProjectStructureById(id: number): Observable<HttpResponse<ProjectStructureDTO>> {
        return this.httpClient.getRequest(this.address + `${id}`);
    }

    public updateProjectStructure(id: number, projectStructure : ProjectStructureDTO) : Observable<HttpResponse<any>>{
        return this.httpClient.postRequest(this.address + `${id}`, projectStructure);
    }
}
