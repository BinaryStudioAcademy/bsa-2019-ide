import { HttpClientWrapperService } from './http-client-wrapper.service';
import { Injectable } from '@angular/core';
import { FileUpdateDTO } from '../models/DTO/File/fileUpdateDTO';

@Injectable({
    providedIn: 'root'
})
export class WorkspaceService {

    constructor(private req: HttpClientWrapperService) { }

   public getFileById(fileId) {
        //this.req.getRequest()
    }

   public saveFilesRequest(files: FileUpdateDTO[]) {
        return this.req.putRequest('files', files);
    }
}
