import { Injectable } from '@angular/core';
import { HttpClientWrapperService } from '../http-client-wrapper.service';
import { ProjectCreateDTO } from '../../models/DTO/Project/projectCreateDTO';
import { ProjectDescriptionDTO } from '../../models/DTO/Project/projectDescriptionDTO';
import { Observable } from 'rxjs';
import { HttpResponse } from '@angular/common/http';
import { ProjectInfoDTO } from 'src/app/models/DTO/Project/projectInfoDTO';

@Injectable({
    providedIn: 'root'
})
export class ProjectService {

    private address: string = 'project';

    constructor(private httpClient: HttpClientWrapperService) { }

    public addProject(project: ProjectCreateDTO) {
        return this.httpClient.postRequest(this.address, project);
    }

    public changeFavourity(projectId: number): Observable<HttpResponse<ProjectDescriptionDTO[]>> {
        return this.httpClient.putRequest(this.address + '/favourite', projectId);
    }

    public getProjectById(id: number): Observable<HttpResponse<ProjectInfoDTO>> {
        return this.httpClient.getRequest(this.address + `/${id}`);
    }

    public getMyProjects(): Observable<HttpResponse<ProjectDescriptionDTO[]>> {
        return this.httpClient.getRequest(this.address + '/my');
    }

    public getFavouriteProjects(): Observable<HttpResponse<ProjectDescriptionDTO[]>> {
        return this.httpClient.getRequest(this.address + '/getFavourite');
    }

    getAssignedProjects(): Observable<HttpResponse<ProjectDescriptionDTO[]>> {
        return this.httpClient.getRequest(this.address + '/assigned');
    }

    getAllProjects(): Observable<HttpResponse<ProjectDescriptionDTO[]>> {
        return this.httpClient.getRequest(this.address + '/all');
    }
}
