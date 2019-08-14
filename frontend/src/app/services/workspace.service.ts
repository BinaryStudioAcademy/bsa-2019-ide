import { HttpRequest, HttpResponse } from '@angular/common/http';
import { HttpClientWrapperService } from './http-client-wrapper.service';
import { Injectable } from '@angular/core';
import { FileUpdateDTO } from '../models/DTO/File/fileUpdateDTO';
import { of } from 'rxjs/internal/observable/of';

@Injectable({
    providedIn: 'root'
})
export class WorkspaceService {

    constructor(private req: HttpClientWrapperService) { }

   public getFileById(fileId) {
        //this.req.getRequest()
    }

   public saveFilesRequest(files: FileUpdateDTO[]) {
        //return this.req.putRequest('files', files);
        const re =  new HttpResponse<FileUpdateDTO>({status:200});// delete when backend setup
        return of(re);                                            // delete when backend setup
    }
}
