import { Injectable } from '@angular/core';
import { HttpClientWrapperService } from '../http-client-wrapper.service';
import { Project } from 'src/app/models/project/project';

@Injectable({
  providedIn: 'root'
})
export class ProjectService {

  constructor(private httpClient: HttpClientWrapperService) { }

  addProject(project: Project) {
    return this.httpClient.postRequest('/project', project);
  }
}
