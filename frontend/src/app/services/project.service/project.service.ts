import { Injectable } from '@angular/core';
import { HttpClientWrapperService } from '../http-client-wrapper.service';
import { ProjectCreateDTO } from 'src/app/models/dto/project/projectCreateDTO';
import { ProjectDescriptionDTO } from 'src/app/models/dto/project/projectDescriptionDTO';
import { Observable } from 'rxjs';
import { HttpResponse } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ProjectService {

  constructor(private httpClient: HttpClientWrapperService) { }

  addProject(project: ProjectCreateDTO) {
    return this.httpClient.postRequest('project', project);
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
