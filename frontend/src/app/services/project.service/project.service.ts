import { FileDTO } from 'src/app/models/DTO/File/fileDTO';
import { Injectable } from '@angular/core';
import { HttpClientWrapperService } from '../http-client-wrapper.service';
import { ProjectDescriptionDTO } from '../../models/DTO/Project/projectDescriptionDTO';
import { Observable } from 'rxjs';
import { HttpResponse } from '@angular/common/http';
import { ProjectInfoDTO } from 'src/app/models/DTO/Project/projectInfoDTO';
import { SearchProjectDTO } from 'src/app/models/DTO/Project/searchProjectDTO';
import { ProjectCreateDTO } from 'src/app/models/DTO/Project/projectCreateDTO';
import { ProjectUpdateDTO } from 'src/app/models/DTO/Project/projectUpdateDTO';
import { CollaboratorDTO } from 'src/app/models/DTO/User/collaboratorDTO';
import { Language } from 'src/app/models/Enums/language';
import { map, switchMap } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export class ProjectService {

    private address = 'project';

    constructor(private httpClient: HttpClientWrapperService) { }


    public addProject(body) {
        return this.httpClient.postRequest(this.address, body);
    }

    public getProjectCollaborators(projectId: number): Observable<HttpResponse<CollaboratorDTO[]>> {
        return this.httpClient.getRequest(this.address + '/collaborators/' + projectId);
    }

    public getProjectsName(): Observable<HttpResponse<SearchProjectDTO[]>> {
        return this.httpClient.getRequest(this.address + '/name');
    }

    public changeFavourity(projectId: number): Observable<HttpResponse<ProjectDescriptionDTO[]>> {
        return this.httpClient.putRequest(this.address + '/favourite', projectId);
    }

    public getAuthorId(projectId: number): Observable<HttpResponse<number>> {
        return this.httpClient.getRequest(this.address + '/author/' + projectId)
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

    public exportProject(projectId: number): Observable<HttpResponse<Blob>> {
        return this.httpClient.getBlobRequest(`${this.address}/Download/${projectId.toString()}`);
    }

    public exportFolder(projectId: number, folderGuid: string): Observable<HttpResponse<Blob>> {
        return this.httpClient.getBlobRequest(`${this.address}/Download/${projectId.toString()}/${folderGuid}`);
    }

    public getAllFilesFromProject(projectId: number): Observable<HttpResponse<FileDTO[]>> {
        return this.httpClient.getRequest(`files/forProject/${projectId}`)
    }

    public getAuthorOfProjectStatistics(project: ProjectInfoDTO) {

        return this.getAllFilesFromProject(project.id).pipe(map(response => {
            const files = response.body;
            return {
                id: project.authorId,
                name: project.authorName,
                updatedFiles: files.filter(f => f.updaterId == project.authorId).length,
                createdFiles: files.filter(f => f.creatorId == project.authorId).length,
                totalFilesNum: files.length
            }
        }));
    }

    public getUsersOfProjectStatistics(project: ProjectInfoDTO): Observable< ({
        id: number,
        name: string,
        updatedFiles: number,
        createdFiles: number,
    }[] | null)> {
        return this.getProjectCollaborators(project.id)
            .pipe(
                switchMap((colRes) => {
                    return this.getAllFilesFromProject(project.id)
                        .pipe(
                            map(filesRes => colRes.body.map(c => ({
                                id: c.id,
                                name: c.nickName,
                                updatedFiles: filesRes.body.filter(f => f.updaterId == c.id).length,
                                createdFiles: filesRes.body.filter(f => f.creatorId == c.id).length,
                            }))))
        }));
    }
}
