import { Injectable } from '@angular/core';
import { HttpClientWrapperService } from '../http-client-wrapper.service';
import { ProjectCreateDTO } from '../../models/DTO/Project/projectCreateDTO';
import { ProjectDescriptionDTO } from '../../models/DTO/Project/projectDescriptionDTO';
import { Observable } from 'rxjs';
import { HttpResponse } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})
export class ProjectService {

    private address:string = 'project';

    constructor(private httpClient: HttpClientWrapperService) { }

    addProject(project: ProjectCreateDTO) {
        return this.httpClient.postRequest(this.address, project);
    }

    getProject(projectId: number){
        return this.httpClient.getRequest<ProjectInfoDTO>(this.address+ `/${projectId}`);
    }

    getMyProjects(): Observable<HttpResponse<ProjectDescriptionDTO[]>> {
        return this.httpClient.getRequest('project/my');
    }

    getAssignedProjects(): Observable<HttpResponse<ProjectDescriptionDTO[]>>  {
        return this.httpClient.getRequest('project/assigned');
    }

    getAllProjects(): Observable<HttpResponse<ProjectDescriptionDTO[]>>  {
        return this.httpClient.getRequest('project/all');
    }
}
