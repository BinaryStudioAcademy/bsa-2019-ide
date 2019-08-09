import { Injectable } from '@angular/core';
import { HttpClientWrapperService } from '../http-client-wrapper.service';
import { ProjectCreate } from 'src/app/models/dto/project/projectCreate';

@Injectable({
  providedIn: 'root'
})
export class ProjectService {

  constructor(private httpClient: HttpClientWrapperService) { }

  addProject(project: ProjectCreate) {
    return this.httpClient.postRequest('project', project);
  }
}
