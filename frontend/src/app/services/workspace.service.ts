import { HttpResponse } from '@angular/common/http';
import { HttpClientWrapperService } from './http-client-wrapper.service';
import { Injectable } from '@angular/core';
import { FileUpdateDTO } from '../models/DTO/File/fileUpdateDTO';
import { forkJoin, Observable } from 'rxjs';
import { FileDTO } from '../models/DTO/File/fileDTO';

@Injectable({
    providedIn: 'root'
})
export class WorkspaceService {

    constructor(private req: HttpClientWrapperService) { }

    public getFileById(fileId): Observable<HttpResponse<FileDTO>> {
        return this.req.getRequest(`files/${fileId}`);
    }

    public saveFilesRequest(files: FileUpdateDTO[]): Observable<HttpResponse<FileUpdateDTO>[]> {
        const fileRequests: Observable<HttpResponse<FileUpdateDTO>>[] = files.map(x => this.saveFileRequest(x));
        return forkJoin(fileRequests);
    }
    public saveFileRequest(file: FileUpdateDTO): Observable<HttpResponse<FileUpdateDTO>> {
        return this.req.putRequest('files', file);
    }
}
