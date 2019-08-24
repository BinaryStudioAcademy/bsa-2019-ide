import { Injectable } from '@angular/core';
import { HttpClientWrapperService } from '../http-client-wrapper.service';
import { Observable } from 'rxjs';
import { HttpResponse } from '@angular/common/http';
import { FileDTO } from 'src/app/models/DTO/File/fileDTO';
import { FileCreateDTO } from 'src/app/models/DTO/File/fileCreateDTO';
import { FileRenameDTO } from 'src/app/models/DTO/File/FileRenameDTO';

@Injectable({
    providedIn: 'root'
})
export class FileService {
    private address: string = 'files';

    constructor(private httpClient: HttpClientWrapperService) { }

    public getProjectById(id: string): Observable<HttpResponse<FileDTO>> {
        return this.httpClient.getRequest(this.address + `/${id}`);
    }

    public addFile(file: FileCreateDTO): Observable<HttpResponse<FileDTO>> {
        return this.httpClient.postRequest(this.address, file);
    }

    public deleteFile(id: string): Observable<HttpResponse<any>> {
        return this.httpClient.deleteRequest(this.address + '/' + id);
    }

    public getFileById(id: string): Observable<HttpResponse<FileDTO>> {
        return this.httpClient.getRequest(this.address + '/' + id);
    }

    public updateFileName(file: FileRenameDTO): Observable<HttpResponse<any>> {
        return this.httpClient.putRequest(this.address + '/rename', file);
    }
}
