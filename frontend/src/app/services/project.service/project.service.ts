import { Injectable } from '@angular/core';
import { HttpClientWrapperService } from '../http-client-wrapper.service';
import { ProjectCreateDTO } from 'src/app/models/dto/project/projectCreateDTO';

@Injectable({
  providedIn: 'root'
})
export class ProjectService {

  constructor(private httpClient: HttpClientWrapperService) { }

  addProject(project: ProjectCreateDTO) {
    return this.httpClient.postRequest('project', project);
  }
}
