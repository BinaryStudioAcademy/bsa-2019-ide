import { Injectable } from '@angular/core';
import { HttpClientWrapperService } from '../http-client-wrapper.service';
import { ProjectDescriptionDTO } from '../../models/DTO/Project/projectDescriptionDTO';
import { Observable } from 'rxjs';
import { HttpResponse } from '@angular/common/http';
import { ProjectInfoDTO } from 'src/app/models/DTO/Project/projectInfoDTO';
import { SearchProjectDTO } from 'src/app/models/DTO/Project/searchProjectDTO';
import { ProjectCreateDTO } from 'src/app/models/DTO/Project/projectCreateDTO';
import { ProjectUpdateDTO } from 'src/app/models/DTO/Project/projectUpdateDTO';

@Injectable({
    providedIn: 'root'
})
export class ProjectService {

    private address = 'project';

    constructor(private httpClient: HttpClientWrapperService) { }

    public addProject(project: ProjectCreateDTO) {
        return this.httpClient.postRequest(this.address, project);
    }

    public getProjectsName(): Observable<HttpResponse<SearchProjectDTO[]>>
    {
        return this.httpClient.getRequest(this.address+'/name');
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

    public getAssignedProjects(): Observable<HttpResponse<ProjectDescriptionDTO[]>> {
        return this.httpClient.getRequest(this.address + '/assigned');
    }

    public getAllProjects(): Observable<HttpResponse<ProjectDescriptionDTO[]>> {
        return this.httpClient.getRequest(this.address + '/all');
    }

    public updateProject(project: ProjectUpdateDTO): Observable<HttpResponse<ProjectInfoDTO>> {
        return this.httpClient.putRequest<ProjectInfoDTO>(this.address, project);
    }

    public deleteProject(projectId: number) {
        return this.httpClient.deleteRequest(this.address + '/' + projectId);
    }
}
