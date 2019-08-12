import { Injectable } from '@angular/core';
import { HttpClientWrapperService } from '../http-client-wrapper.service';
import { ProjectCreateDTO } from '../../models/DTO/Project/projectCreateDTO';
import { Observable } from 'rxjs';
import { ProjectInfoDTO } from 'src/app/models/DTO/Project/projectInfoDTO';

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
}
