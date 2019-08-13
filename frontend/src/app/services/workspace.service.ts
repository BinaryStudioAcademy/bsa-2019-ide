import { HttpClientWrapperService } from './http-client-wrapper.service';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class WorkspaceService {

  constructor(private req: HttpClientWrapperService) { }

  getFileById(fileId){
      //this.req.getRequest()
  }
}
